using Cau4.Models;
using Microsoft.EntityFrameworkCore;

namespace Cau4
{
    public partial class Form1 : Form
    {
        private readonly AnKhangClinicContext _context = new();
        private int? _maLich = null;
        public Form1()
        {
            InitializeComponent();
            dgvLichKham.SelectionChanged += dgvLichKham_SelectionChanged;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnQuanLyBacSi.Click += btnQuanLyBacSi_Click;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            dtpNgayKham.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Format = DateTimePickerFormat.Short;

            dtpGioKham.Format = DateTimePickerFormat.Time;
            dtpGioKham.ShowUpDown = true;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[]
            {
                "Chờ khám", "Đã khám", "Đã hủy"
            });

            LoadBacSi();
            LoadDanhSachLichKham();
            LamMoi();
        }

        // Nạp bác sĩ vào ComboBox
        private void LoadBacSi()
        {
            var dsBacSi = _context.BacSis
                .OrderBy(x => x.HoTen)
                .ToList();

            cboBacSi.DataSource = null;
            cboBacSi.DataSource = dsBacSi.ToList();
            cboBacSi.DisplayMember = "HoTen";
            cboBacSi.ValueMember = "MaBs";

            // Thêm lựa chọn "Tất cả" cho ComboBox tìm kiếm
            var dsTim = dsBacSi.ToList();
            dsTim.Insert(0, new BacSi
            {
                MaBs = 0,
                HoTen = "-- Tất cả bác sĩ --",
                ChuyenKhoa = ""
            });

            cboTimBacSi.DataSource = null;
            cboTimBacSi.DataSource = dsTim;
            cboTimBacSi.DisplayMember = "HoTen";
            cboTimBacSi.ValueMember = "MaBs";
            cboTimBacSi.SelectedValue = 0;
        }

        // Hiển thị danh sách lịch khám và thông tin bác sĩ
        private void LoadDanhSachLichKham()
        {
            var ds = _context.LichKhams
                .Include(x => x.MaBsNavigation)
                .OrderBy(x => x.NgayKham)
                .ThenBy(x => x.GioKham)
                .ToList();

            dgvLichKham.DataSource = ds.Select(x => new
            {
                x.MaLich,
                x.TenBenhNhan,
                x.Sdt,
                x.NgayKham,
                GioKham = x.GioKham.ToString(),
                TenBacSi = x.MaBsNavigation != null
                    ? x.MaBsNavigation.HoTen : "(Không có bác sĩ)",
                ChuyenKhoa = x.MaBsNavigation != null
                    ? x.MaBsNavigation.ChuyenKhoa : "",
                x.TrangThai,
                x.MaBs
            }).ToList();

            CauHinhLuoi();
        }

        private void CauHinhLuoi()
        {
            dgvLichKham.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvLichKham.MultiSelect = false;
            dgvLichKham.ReadOnly = true;
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvLichKham.Columns["MaLich"] is { } colMaLich)
                colMaLich.HeaderText = "Mã lịch";

            if (dgvLichKham.Columns["TenBenhNhan"] is { } colTenBN)
                colTenBN.HeaderText = "Tên bệnh nhân";

            if (dgvLichKham.Columns["Sdt"] is { } colSdt)
                colSdt.HeaderText = "Số điện thoại";

            if (dgvLichKham.Columns["NgayKham"] is { } colNgayKham)
                colNgayKham.HeaderText = "Ngày khám";

            if (dgvLichKham.Columns["GioKham"] is { } colGioKham)
                colGioKham.HeaderText = "Giờ khám";

            if (dgvLichKham.Columns["TenBacSi"] is { } colTenBS)
                colTenBS.HeaderText = "Bác sĩ";

            if (dgvLichKham.Columns["ChuyenKhoa"] is { } colChuyenKhoa)
                colChuyenKhoa.HeaderText = "Chuyên khoa";

            if (dgvLichKham.Columns["TrangThai"] is { } colTrangThai)
                colTrangThai.HeaderText = "Trạng thái";

            if (dgvLichKham.Columns["MaBs"] is { } colMaBs)
                colMaBs.Visible = false;
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtTenBN.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bệnh nhân.");
                txtTenBN.Focus();
                return false;
            }

            if (cboBacSi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ.");
                return false;
            }

            if (dtpNgayKham.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Không được đặt lịch vào ngày trong quá khứ.");
                return false;
            }

            if (cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.");
                return false;
            }

            return true;
        }

        private LichKham TaoLichKham()
        {
            return new LichKham
            {
                TenBenhNhan = txtTenBN.Text.Trim(),
                Sdt = txtSDT.Text.Trim(),
                NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value),
                GioKham = TimeOnly.FromDateTime(dtpGioKham.Value),
                MaBs = Convert.ToInt32(cboBacSi.SelectedValue),
                TrangThai = cboTrangThai.Text
            };
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            try
            {
                var lich = TaoLichKham();

                _context.LichKhams.Add(lich);
                await _context.SaveChangesAsync();

                LoadDanhSachLichKham();
                LamMoi();

                MessageBox.Show("Thêm lịch khám thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm lịch khám: " + ex.Message);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (_maLich == null)
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần sửa.");
                return;
            }

            if (!KiemTraDuLieu()) return;

            try
            {
                var lich = await _context.LichKhams
                    .FirstOrDefaultAsync(x => x.MaLich == _maLich.Value);

                if (lich == null)
                {
                    MessageBox.Show("Không tìm thấy lịch khám.");
                    return;
                }

                var duLieu = TaoLichKham();

                lich.TenBenhNhan = duLieu.TenBenhNhan;
                lich.Sdt = duLieu.Sdt;
                lich.NgayKham = duLieu.NgayKham;
                lich.GioKham = duLieu.GioKham;
                lich.MaBs = duLieu.MaBs;
                lich.TrangThai = duLieu.TrangThai;

                await _context.SaveChangesAsync();

                LoadDanhSachLichKham();
                LamMoi();

                MessageBox.Show("Sửa lịch khám thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể sửa lịch khám: " + ex.Message);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (_maLich == null)
            {
                MessageBox.Show("Vui lòng chọn lịch khám cần xóa.");
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lịch khám này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes) return;

            try
            {
                var lich = await _context.LichKhams
                    .FirstOrDefaultAsync(x => x.MaLich == _maLich.Value);

                if (lich == null) return;

                _context.LichKhams.Remove(lich);
                await _context.SaveChangesAsync();

                LoadDanhSachLichKham();
                LamMoi();

                MessageBox.Show("Xóa lịch khám thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa lịch khám: " + ex.Message);
            }
        }

        // Chọn một dòng để đưa dữ liệu lên các control
        private void dgvLichKham_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvLichKham.CurrentRow == null ||
                dgvLichKham.CurrentRow.IsNewRow ||
                dgvLichKham.CurrentRow.Cells["MaLich"].Value == null)
                return;

            var row = dgvLichKham.CurrentRow;

            _maLich = Convert.ToInt32(row.Cells["MaLich"].Value);
            txtTenBN.Text = row.Cells["TenBenhNhan"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["Sdt"].Value?.ToString() ?? "";

            if (DateTime.TryParse(
                row.Cells["NgayKham"].Value?.ToString(), out DateTime ngay))
                dtpNgayKham.Value = ngay;

            if (TimeSpan.TryParse(
                row.Cells["GioKham"].Value?.ToString(), out TimeSpan gio))
                dtpGioKham.Value = DateTime.Today.Add(gio);

            if (row.Cells["MaBs"].Value != null)
                cboBacSi.SelectedValue =
                    Convert.ToInt32(row.Cells["MaBs"].Value);

            cboTrangThai.Text =
                row.Cells["TrangThai"].Value?.ToString() ?? "Chờ khám";
        }

        // Tìm theo khoảng ngày VÀ bác sĩ
        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không được lớn hơn Đến ngày.");
                return;
            }

            var query = _context.LichKhams
                .Include(x => x.MaBsNavigation)
                .Where(x =>
                    x.NgayKham >= DateOnly.FromDateTime(dtpTuNgay.Value) &&
                    x.NgayKham <= DateOnly.FromDateTime(dtpDenNgay.Value));

            if (cboTimBacSi.SelectedValue != null &&
                Convert.ToInt32(cboTimBacSi.SelectedValue) != 0)
            {
                int maBS = Convert.ToInt32(cboTimBacSi.SelectedValue);
                query = query.Where(x => x.MaBs == maBS);
            }

            var ds = query
                .OrderBy(x => x.NgayKham)
                .ThenBy(x => x.GioKham)
                .ToList();

            dgvLichKham.DataSource = ds.Select(x => new
            {
                x.MaLich,
                x.TenBenhNhan,
                x.Sdt,
                x.NgayKham,
                GioKham = x.GioKham.ToString(),
                TenBacSi = x.MaBsNavigation != null
                    ? x.MaBsNavigation.HoTen : "(Không có bác sĩ)",
                ChuyenKhoa = x.MaBsNavigation != null
                    ? x.MaBsNavigation.ChuyenKhoa : "",
                x.TrangThai,
                x.MaBs
            }).ToList();

            CauHinhLuoi();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            LoadDanhSachLichKham();
            LamMoi();
        }

        private void LamMoi()
        {
            _maLich = null;
            txtTenBN.Clear();
            txtSDT.Clear();
            dtpNgayKham.Value = DateTime.Today;
            dtpGioKham.Value = DateTime.Today.AddHours(8);

            if (cboBacSi.Items.Count > 0)
                cboBacSi.SelectedIndex = 0;

            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            dgvLichKham.ClearSelection();
        }

        private void btnQuanLyBacSi_Click(object? sender, EventArgs e)
        {
            using var frm = new FrmBacSi();
            frm.ShowDialog();

            // Nạp lại bác sĩ nếu có thêm, sửa hoặc xóa
            LoadBacSi();
            LoadDanhSachLichKham();
        }
    }
}
