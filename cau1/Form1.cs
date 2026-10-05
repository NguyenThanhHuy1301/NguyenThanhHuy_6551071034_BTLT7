using System.Threading.Tasks;
using dataFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace dataFirst
{
    public partial class Form1 : Form
    {
        private localhostSQLEXPRESSContext context;

        public Form1()
        {
            InitializeComponent();

            var options = new DbContextOptionsBuilder<localhostSQLEXPRESSContext>()
                .UseSqlServer(
                    "Server=.\\SQLEXPRESS;Database=TriThucBooks;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            context = new localhostSQLEXPRESSContext(options);

            Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var danhSach = await context.TheLoaiSaches
                .AsNoTracking()
                .OrderBy(x => x.MaTl)
                .ToListAsync();

            dgvTheLoai.DataSource = danhSach;

            // Đổi tên tiêu đề cột
            dgvTheLoai.Columns["MaTl"].HeaderText = "Mã TL";
            dgvTheLoai.Columns["TenTheLoai"].HeaderText = "Tên thể loại";
            dgvTheLoai.Columns["MoTa"].HeaderText = "Mô tả";
            dgvTheLoai.Columns["SoLuongSach"].HeaderText = "Số lượng sách";
            dgvTheLoai.Columns["NgayTao"].HeaderText = "Ngày tạo";

            // Định dạng ngày
            dgvTheLoai.Columns["NgayTao"]
                .DefaultCellStyle
                .Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private async void button4_Click_1(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            ClearInput();
            await LoadData();
        }

        private async Task LoadDataAsync()
        {
            var danhSach = await context.TheLoaiSaches.AsNoTracking().OrderBy(x => x.MaTl).ToListAsync(); 
            dgvTheLoai.DataSource = danhSach;
        }

        private void ClearInput()
        {
            txtMaTL.Clear(); 
            txtTenTheLoai.Clear(); 
            txtMoTa.Clear(); 
           
            txtTenTheLoai.Focus();
        }

        private void dgvTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTheLoai.CurrentRow == null) return; 
            if (dgvTheLoai.CurrentRow.DataBoundItem is not TheLoaiSach item) return; 
            txtMaTL.Text = item.MaTl.ToString(); 
            txtTenTheLoai.Text = item.TenTheLoai; 
            txtMoTa.Text = item.MoTa ?? ""; 
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            string tenTheLoai = txtTenTheLoai.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            // Kiểm tra bỏ trống
            if (string.IsNullOrWhiteSpace(tenTheLoai))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            // Kiểm tra trùng tên
            bool daTonTai = await context.TheLoaiSaches
                .AnyAsync(x => x.TenTheLoai == tenTheLoai);

            if (daTonTai)
            {
                MessageBox.Show("Tên thể loại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            try
            {
                TheLoaiSach theLoai = new TheLoaiSach
                {
                    TenTheLoai = tenTheLoai,
                    MoTa = string.IsNullOrWhiteSpace(moTa) ? null : moTa,
                    SoLuongSach = 0,
                    NgayTao = DateTime.Now
                };

                context.TheLoaiSaches.Add(theLoai);
                await context.SaveChangesAsync();

                MessageBox.Show("Thêm thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadData();
                ClearInput();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể thêm dữ liệu.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenTheLoai = txtTenTheLoai.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenTheLoai))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            // Kiểm tra trùng tên với thể loại khác
            bool trungTen = await context.TheLoaiSaches
                .AnyAsync(x => x.TenTheLoai == tenTheLoai && x.MaTl != maTL);

            if (trungTen)
            {
                MessageBox.Show("Tên thể loại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            try
            {
                var theLoai = await context.TheLoaiSaches
                    .FirstOrDefaultAsync(x => x.MaTl == maTL);

                if (theLoai == null)
                {
                    MessageBox.Show("Không tìm thấy thể loại cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                theLoai.TenTheLoai = tenTheLoai;
                theLoai.MoTa = string.IsNullOrWhiteSpace(moTa) ? null : moTa;
                await context.SaveChangesAsync();

                MessageBox.Show("Cập nhật thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadData();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể cập nhật dữ liệu.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                var theLoai = await context.TheLoaiSaches.FirstOrDefaultAsync(x => x.MaTl == maTL);

                if (theLoai == null)
                {
                    MessageBox.Show("Không tìm thấy thể loại cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                context.TheLoaiSaches.Remove(theLoai);
                await context.SaveChangesAsync();

                MessageBox.Show("Xóa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadData();
                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa thể loại này vì đang có sách tham chiếu đến thể loại!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            try
            {
                var ketQua = await context.TheLoaiSaches
                    .AsNoTracking()
                    .Where(x => x.TenTheLoai.Contains(tuKhoa))
                    .OrderBy(x => x.MaTl)
                    .ToListAsync();

                dgvTheLoai.DataSource = ketQua;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}