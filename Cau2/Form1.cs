using Cau2.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System;

namespace Cau2
{
    public partial class Form1 : Form
    {
        private readonly FitZoneDBContext _context = new();

        private int? _maHV = null;
        public Form1()
        {
            InitializeComponent();
            cboHangThanhVien.Items.AddRange(
                new object[] { "Basic", "VIP", "Premium" });

            cboLocHang.Items.AddRange(
                new object[] { "Tất cả", "Basic", "VIP", "Premium" });

            cboHangThanhVien.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboLocHang.DropDownStyle =
                ComboBoxStyle.DropDownList;

            dtpNgaySinh.Format = DateTimePickerFormat.Short;

            cboLocHang.SelectedIndex = 0;
            cboHangThanhVien.SelectedIndex = 0;

            dgvHoiVien.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHoiVien.MultiSelect = false;
            dgvHoiVien.ReadOnly = true;
            dgvHoiVien.AllowUserToAddRows = false;

            Load += async (s, e) => await TaiDanhSachAsync();

            dgvHoiVien.CellClick += dgvHoiVien_CellClick;

            btnThem.Click += async (s, e) => await ThemAsync(GetDtpNgaySinh1());
            btnSua.Click += async (s, e) => await SuaAsync(Get_maHV1());
            btnXoa.Click += async (s, e) => await XoaAsync();
            btnLamMoi.Click += (s, e) => LamMoi();
            btnTimKiem.Click += async (s, e) => await TimKiemAsync();
        }
        private async Task TaiDanhSachAsync()
        {
            dgvHoiVien.DataSource = await _context.HoiViens
                .AsNoTracking()
                .OrderBy(h => h.MaHV)
                .ToListAsync();
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên hội viên!");
                txtHoTen.Focus();
                return false;
            }

            if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                txtSDT.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtSDT.Text.Trim(), @"^\d{9,11}$"))
            {
                MessageBox.Show(
                    "Số điện thoại chỉ được chứa chữ số và phải có từ 9 đến 11 chữ số!");
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!");
                txtEmail.Focus();
                return false;
            }

            if (!txtEmail.Text.Trim().Contains('@'))
            {
                MessageBox.Show("Email phải chứa ký tự '@'!");
                txtEmail.Focus();
                return false;
            }

            DateTime ngaySinh = dtpNgaySinh.Value.Date;
            DateTime homNay = DateTime.Today;

            if (ngaySinh > homNay)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại!");
                return false;
            }

            int tuoi = homNay.Year - ngaySinh.Year;

            if (ngaySinh.Date > homNay.AddYears(-tuoi))
                tuoi--;

            if (tuoi < 15)
            {
                MessageBox.Show("Hội viên phải đủ 15 tuổi trở lên!");
                return false;
            }

            if (cboHangThanhVien.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn hạng thành viên!");
                return false;
            }

            return true;
        }

        private DateTimePicker GetDtpNgaySinh1()
        {
            return dtpNgaySinh;
        }

        private async Task ThemAsync(DateTimePicker dtpNgaySinhPicker)
        {
            if (!KiemTraDuLieu())
                return;

            var hv = new HoiVien
            {
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = rdoNam.Checked,
                NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                Sdt = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                HangThanhVien = cboHangThanhVien.SelectedItem?.ToString() ?? "",
                TrangThai = chkTrangThai.Checked
            };

            _context.HoiViens.Add(hv);
             try
            {
                await _context.SaveChangesAsync();
                MessageBox.Show("Lưu thành công!");
            }
            catch (DbUpdateException ex)
            {
                string loi = ex.InnerException?.Message ?? ex.Message;

                MessageBox.Show(loi, "Chi tiết lỗi SQL Server");
            }

            MessageBox.Show("Thêm hội viên thành công!");

            LamMoi();
            await TaiDanhSachAsync();
        }

        private void dgvHoiVien_CellClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var hv = dgvHoiVien.Rows[e.RowIndex]
                .DataBoundItem as HoiVien;

            if (hv == null)
                return;

            _maHV = (int?)hv.MaHV;

            txtHoTen.Text = hv.HoTen;
            txtSDT.Text = hv.Sdt;
            txtEmail.Text = hv.Email;

            rdoNam.Checked = hv.GioiTinh;
            rdoNu.Checked = !hv.GioiTinh;

            dtpNgaySinh.Value = hv.NgaySinh.ToDateTime(TimeOnly.MinValue);

            cboHangThanhVien.SelectedItem = hv.HangThanhVien;

            chkTrangThai.Checked = hv.TrangThai;
        }

        private int? Get_maHV1()
        {
            return _maHV;
        }


        private async Task SuaAsync(int? v)
        {
            if (this._maHV == null)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần sửa!");
                return;
            }

            if (!KiemTraDuLieu())
                return;

            var hv = await _context.HoiViens
                .FirstOrDefaultAsync(h => h.MaHV == this._maHV.Value);

            if (hv == null)
            {
                MessageBox.Show("Không tìm thấy hội viên!");
                await TaiDanhSachAsync();
                return;
            }

            hv.HoTen = txtHoTen.Text.Trim();
            hv.GioiTinh = rdoNam.Checked;
            hv.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
            hv.Sdt = txtSDT.Text.Trim();
            hv.Email = txtEmail.Text.Trim();
            hv.HangThanhVien = cboHangThanhVien.SelectedItem?.ToString() ?? "";
            hv.TrangThai = chkTrangThai.Checked;

            await _context.SaveChangesAsync();

            MessageBox.Show("Cập nhật hội viên thành công!");

            LamMoi();
            await TaiDanhSachAsync();
        }

        private async Task XoaAsync()
        {
            if (_maHV == null)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa!");
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa hội viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
                return;

            var hv = await _context.HoiViens
                .FirstOrDefaultAsync(h => h.MaHV == _maHV.Value);

            if (hv == null)
            {
                MessageBox.Show("Hội viên không tồn tại!");
                await TaiDanhSachAsync();
                return;
            }

            _context.HoiViens.Remove(hv);
            await _context.SaveChangesAsync();

            MessageBox.Show("Xóa hội viên thành công!");

            LamMoi();
            await TaiDanhSachAsync();
        }

        private async Task TimKiemAsync()
        {
            string ten = txtTimTen.Text.Trim();
            string hang = cboLocHang.SelectedItem?.ToString() ?? "Tất cả";

            var query = _context.HoiViens.AsNoTracking().AsQueryable();

            query = query.Where(h =>
                h.HoTen.Contains(ten) &&
                (hang == "Tất cả" || h.HangThanhVien == hang));

            dgvHoiVien.DataSource = await query
                .OrderBy(h => h.MaHV)
                .ToListAsync();

            if (dgvHoiVien.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy hội viên phù hợp!");
        }

        private void LamMoi()
        {
            _maHV = null;

            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();

            rdoNam.Checked = false;
            rdoNu.Checked = false;

            dtpNgaySinh.Value = DateTime.Today;

            cboHangThanhVien.SelectedIndex = 0;
            chkTrangThai.Checked = true;

            dgvHoiVien.ClearSelection();
        }


    }
}
