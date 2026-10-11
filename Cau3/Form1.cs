using Cau3.Models;
using Microsoft.EntityFrameworkCore;


using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;



namespace Cau3
{
    public partial class Form1 : Form
    {
        private readonly SunriseHomestayContext _context = new();

        private int? _maPhong = null;
        private string? _tenAnh = null;

        private readonly string _thuMucAnh =
            Path.Combine(Application.StartupPath, "Images");
        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory(_thuMucAnh);

            cboTinhTrang.Items.AddRange(new object[]
            {
            "Trống", "Đang ở", "Đang dọn"
            });

            cboTimTrangThai.Items.AddRange(new object[]
            {
            "Tất cả", "Trống", "Đang ở", "Đang dọn"
            });

            Load += FrmPhong_Load;
            dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;
        }

        private void FrmPhong_Load(object? sender, EventArgs e)
        {
            LoadLoaiPhong();
            LoadDanhSachPhong();
        }
        private void LoadLoaiPhong()
        {
            var ds = _context.LoaiPhongs
                .OrderBy(x => x.TenLoai)
                .ToList();

            cboLoaiPhong.DataSource = ds;
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoai";

            cboTimLoai.DataSource = ds.ToList();
            cboTimLoai.DisplayMember = "TenLoai";
            cboTimLoai.ValueMember = "MaLoai";

            cboTimLoai.SelectedIndex = -1;
            cboTimTrangThai.SelectedIndex = 0;
        }
        private Image? DocAnh(string? tenAnh)
        {
            if (string.IsNullOrWhiteSpace(tenAnh))
                return null;

            string duongDan = Path.Combine(_thuMucAnh, tenAnh);

            if (!File.Exists(duongDan))
                return null;

            using var fs = new FileStream(
                duongDan, FileMode.Open, FileAccess.Read);

            using var img = Image.FromStream(fs);

            return new Bitmap(img);
        }

        private void LoadDanhSachPhong()
        {
            var ds = _context.Phongs
                .Include(x => x.MaLoaiNavigation)
                .OrderBy(x => x.SoPhong)
                .ToList();

            dgvPhong.Columns.Clear();
            dgvPhong.Rows.Clear();
            dgvPhong.AutoGenerateColumns = false;
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.MultiSelect = false;
            dgvPhong.RowTemplate.Height = 70;

            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaPhong",
                HeaderText = "Mã phòng"
            });

            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoPhong",
                HeaderText = "Số phòng"
            });

            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TangSo",
                HeaderText = "Tầng"
            });

            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenLoai",
                HeaderText = "Loại phòng"
            });

            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TinhTrang",
                HeaderText = "Tình trạng"
            });

            dgvPhong.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Anh",
                HeaderText = "Ảnh phòng",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });

            foreach (var p in ds)
            {
                int i = dgvPhong.Rows.Add(
                    p.MaPhong,
                    p.SoPhong,
                    p.TangSo,
                    p.MaLoaiNavigation?.TenLoai,
                    p.TinhTrang,
                    DocAnh(p.HinhAnh));

                dgvPhong.Rows[i].Tag = p.MaPhong;
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter =
                "File ảnh|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string duoiFile = Path.GetExtension(ofd.FileName);
            string tenFile = Guid.NewGuid().ToString("N") + duoiFile;
            string dich = Path.Combine(_thuMucAnh, tenFile);

            File.Copy(ofd.FileName, dich, true);

            _tenAnh = tenFile;

            picPhong.Image?.Dispose();
            picPhong.Image = DocAnh(_tenAnh);
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập số phòng.");
                txtSoPhong.Focus();
                return;
            }

            if (cboLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng.");
                return;
            }

            if (cboTinhTrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tình trạng phòng.");
                return;
            }

            string soPhong = txtSoPhong.Text.Trim();

            if (_context.Phongs.Any(x => x.SoPhong == soPhong))
            {
                MessageBox.Show("Số phòng đã tồn tại.");
                return;
            }

            var p = new Phong
            {
                SoPhong = soPhong,
                TangSo = (int)nudTangSo.Value,
                TinhTrang = cboTinhTrang.Text,
                MaLoai = Convert.ToInt32(cboLoaiPhong.SelectedValue),
                HinhAnh = _tenAnh
            };

            try
            {
                _context.Phongs.Add(p);
                await _context.SaveChangesAsync();

                LoadDanhSachPhong();
                MessageBox.Show("Thêm phòng thành công.");
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(
                    ex.InnerException?.Message ?? ex.Message);
            }
        }
        private void dgvPhong_SelectionChanged(
    object? sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null ||
                dgvPhong.CurrentRow.Tag == null)
                return;

            int maPhong = Convert.ToInt32(
                dgvPhong.CurrentRow.Tag);

            var p = _context.Phongs
                .Include(x => x.MaLoaiNavigation)
                .FirstOrDefault(x => x.MaPhong == maPhong);

            if (p == null)
                return;

            _maPhong = p.MaPhong;
            txtSoPhong.Text = p.SoPhong;
            nudTangSo.Value = p.TangSo ?? 0;
            cboLoaiPhong.SelectedValue = p.MaLoai;
            cboTinhTrang.SelectedItem = p.TinhTrang;
            _tenAnh = p.HinhAnh;

            picPhong.Image?.Dispose();
            picPhong.Image = DocAnh(p.HinhAnh);
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_maPhong == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa.");
                return;
            }

            var p = await _context.Phongs
                .FirstOrDefaultAsync(x => x.MaPhong == _maPhong.Value);

            if (p == null)
            {
                MessageBox.Show("Không tìm thấy phòng.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoPhong.Text) ||
                cboLoaiPhong.SelectedValue == null ||
                cboTinhTrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            string soPhong = txtSoPhong.Text.Trim();

            bool trung = await _context.Phongs.AnyAsync(
                x => x.SoPhong == soPhong &&
                     x.MaPhong != _maPhong.Value);

            if (trung)
            {
                MessageBox.Show("Số phòng đã tồn tại.");
                return;
            }

            p.SoPhong = soPhong;
            p.TangSo = (int)nudTangSo.Value;
            p.MaLoai = Convert.ToInt32(cboLoaiPhong.SelectedValue);
            p.TinhTrang = cboTinhTrang.Text;
            p.HinhAnh = _tenAnh;

            try
            {
                await _context.SaveChangesAsync();
                LoadDanhSachPhong();
                MessageBox.Show("Sửa phòng thành công.");
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(
                    ex.InnerException?.Message ?? ex.Message);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maPhong == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa.");
                return;
            }

            var xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa phòng này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            var p = await _context.Phongs
                .FirstOrDefaultAsync(x => x.MaPhong == _maPhong.Value);

            if (p == null)
                return;

            try
            {
                _context.Phongs.Remove(p);
                await _context.SaveChangesAsync();

                _maPhong = null;
                _tenAnh = null;

                picPhong.Image?.Dispose();
                picPhong.Image = null;

                LoadDanhSachPhong();
                MessageBox.Show("Xóa phòng thành công.");
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(
                    "Không thể xóa phòng.\n" +
                    (ex.InnerException?.Message ?? ex.Message));
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _maPhong = null;
            _tenAnh = null;
            txtSoPhong.Clear();
            nudTangSo.Value = 0;
            cboLoaiPhong.SelectedIndex = -1;
            cboTinhTrang.SelectedIndex = -1;
            cboTimLoai.SelectedIndex = -1;
            cboTimTrangThai.SelectedIndex = 0;

            picPhong.Image?.Dispose();
            picPhong.Image = null;

            LoadDanhSachPhong();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var query = _context.Phongs
       .Include(x => x.MaLoaiNavigation)
       .AsQueryable();

            if (cboTimLoai.SelectedValue != null)
            {
                int maLoai = Convert.ToInt32(
                    cboTimLoai.SelectedValue);

                query = query.Where(x => x.MaLoai == maLoai);
            }

            string? tinhTrang = cboTimTrangThai.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(tinhTrang) &&
                tinhTrang != "Tất cả")
            {
                query = query.Where(x => x.TinhTrang == tinhTrang);
            }

            var ds = query
                .OrderBy(x => x.SoPhong)
                .ToList();

            dgvPhong.Rows.Clear();

            foreach (var p in ds)
            {
                int i = dgvPhong.Rows.Add(
                    p.MaPhong,
                    p.SoPhong,
                    p.TangSo,
                    p.MaLoaiNavigation?.TenLoai,
                    p.TinhTrang,
                    DocAnh(p.HinhAnh));

                dgvPhong.Rows[i].Tag = p.MaPhong;
            }
        }
    }
}
