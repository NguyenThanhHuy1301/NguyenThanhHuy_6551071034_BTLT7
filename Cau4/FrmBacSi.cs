using Cau4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cau4
{
    public partial class FrmBacSi : Form
    {
        private readonly AnKhangClinicContext _context = new();
        private int? _maBS = null;

        public FrmBacSi()
        {
            InitializeComponent();
            Load += FrmBacSi_Load;
            dgvBacSi.SelectionChanged += dgvBacSi_SelectionChanged;

            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void FrmBacSi_Load(object? sender, EventArgs e)
        {
            dgvBacSi.ReadOnly = true;
            dgvBacSi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBacSi.MultiSelect = false;
            dgvBacSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            dgvBacSi.DataSource = _context.BacSis
                .OrderBy(x => x.HoTen)
                .Select(x => new
                {
                    x.MaBs,
                    x.HoTen,
                    x.ChuyenKhoa,
                    x.Sdt
                })
                .ToList();

            if (dgvBacSi.Columns["MaBs"] is { } colMaBs)
                colMaBs.HeaderText = "Mã bác sĩ";
            if (dgvBacSi.Columns["HoTen"] is { } colHoTen)
                colHoTen.HeaderText = "Họ tên";
            if (dgvBacSi.Columns["ChuyenKhoa"] is { } colChuyenKhoa)
                colChuyenKhoa.HeaderText = "Chuyên khoa";
            if (dgvBacSi.Columns["Sdt"] is { } colSdt)
                colSdt.HeaderText = "Số điện thoại";
        }

        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên bác sĩ.");
                txtHoTen.Focus();
                return false;
            }

            return true;
        }

        private void label2_Click(object? sender, EventArgs e)
        {
        }

        private void label1_Click(object? sender, EventArgs e)
        {
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTra()) return;

            try
            {
                var bs = new BacSi
                {
                    HoTen = txtHoTen.Text.Trim(),
                    ChuyenKhoa = txtChuyenKhoa.Text.Trim(),
                    Sdt = txtSDT.Text.Trim()
                };

                _context.BacSis.Add(bs);
                await _context.SaveChangesAsync();

                LoadDanhSach();
                LamMoi();

                MessageBox.Show("Thêm bác sĩ thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm bác sĩ: " + ex.Message);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (_maBS == null)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần sửa.");
                return;
            }

            if (!KiemTra()) return;

            try
            {
                var bs = await _context.BacSis
                    .FirstOrDefaultAsync(x => x.MaBs == _maBS.Value);

                if (bs == null) return;

                bs.HoTen = txtHoTen.Text.Trim();
                bs.ChuyenKhoa = txtChuyenKhoa.Text.Trim();
                bs.Sdt = txtSDT.Text.Trim();

                await _context.SaveChangesAsync();

                LoadDanhSach();
                LamMoi();

                MessageBox.Show("Sửa bác sĩ thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa bác sĩ: " + ex.Message);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (_maBS == null)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần xóa.");
                return;
            }

            var xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa bác sĩ này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) return;

            try
            {
                var bs = await _context.BacSis
                    .FirstOrDefaultAsync(x => x.MaBs == _maBS.Value);

                if (bs == null) return;

                // Không thể xóa bác sĩ nếu còn lịch khám tham chiếu.
                bool coLich = await _context.LichKhams
                    .AnyAsync(x => x.MaBs == bs.MaBs);

                if (coLich)
                {
                    MessageBox.Show(
                        "Bác sĩ này đang có lịch khám. " +
                        "Hãy xử lý các lịch khám liên quan trước khi xóa.");
                    return;
                }

                _context.BacSis.Remove(bs);
                await _context.SaveChangesAsync();

                LoadDanhSach();
                LamMoi();

                MessageBox.Show("Xóa bác sĩ thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa bác sĩ: " + ex.Message);
            }
        }

        private void dgvBacSi_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            CapNhatThongTinTuDongChon();
        }

        private void dgvBacSi_SelectionChanged(object? sender, EventArgs e)
        {
            CapNhatThongTinTuDongChon();
        }

        private void CapNhatThongTinTuDongChon()
        {
            if (dgvBacSi.CurrentRow == null ||
               dgvBacSi.CurrentRow.Cells["MaBs"].Value == null)
                return;

            var row = dgvBacSi.CurrentRow;

            _maBS = Convert.ToInt32(row.Cells["MaBs"].Value);
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtChuyenKhoa.Text = row.Cells["ChuyenKhoa"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["Sdt"].Value?.ToString() ?? "";
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            _maBS = null;
            txtHoTen.Clear();
            txtChuyenKhoa.Clear();
            txtSDT.Clear();
            dgvBacSi.ClearSelection();
        }
    }
}
