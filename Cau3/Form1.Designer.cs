namespace Cau3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSoPhong = new TextBox();
            label2 = new Label();
            nudTangSo = new NumericUpDown();
            cboLoaiPhong = new ComboBox();
            cboTinhTrang = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            picPhong = new PictureBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnChonAnh = new Button();
            cboTimLoai = new ComboBox();
            cboTimTrangThai = new ComboBox();
            btnTimKiem = new Button();
            dgvPhong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudTangSo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPhong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 21);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Số phòng";
            // 
            // txtSoPhong
            // 
            txtSoPhong.Location = new Point(38, 55);
            txtSoPhong.Name = "txtSoPhong";
            txtSoPhong.Size = new Size(125, 27);
            txtSoPhong.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 21);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 2;
            label2.Text = "Số Tầng";
            // 
            // nudTangSo
            // 
            nudTangSo.Location = new Point(188, 56);
            nudTangSo.Name = "nudTangSo";
            nudTangSo.Size = new Size(86, 27);
            nudTangSo.TabIndex = 3;
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Location = new Point(301, 54);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(129, 28);
            cboLoaiPhong.TabIndex = 4;
            // 
            // cboTinhTrang
            // 
            cboTinhTrang.FormattingEnabled = true;
            cboTinhTrang.Location = new Point(451, 54);
            cboTinhTrang.Name = "cboTinhTrang";
            cboTinhTrang.Size = new Size(129, 28);
            cboTinhTrang.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(301, 19);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 6;
            label3.Text = "Loại phòng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(451, 19);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 7;
            label4.Text = "Tình trạng";
            // 
            // picPhong
            // 
            picPhong.Location = new Point(619, 21);
            picPhong.Name = "picPhong";
            picPhong.Size = new Size(125, 116);
            picPhong.TabIndex = 8;
            picPhong.TabStop = false;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(801, 28);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(941, 28);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(801, 89);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(941, 89);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 13;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(619, 157);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(94, 29);
            btnChonAnh.TabIndex = 14;
            btnChonAnh.Text = "Chọn ảnh...";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // cboTimLoai
            // 
            cboTimLoai.FormattingEnabled = true;
            cboTimLoai.Location = new Point(12, 197);
            cboTimLoai.Name = "cboTimLoai";
            cboTimLoai.Size = new Size(151, 28);
            cboTimLoai.TabIndex = 15;
            // 
            // cboTimTrangThai
            // 
            cboTimTrangThai.FormattingEnabled = true;
            cboTimTrangThai.Location = new Point(188, 197);
            cboTimTrangThai.Name = "cboTimTrangThai";
            cboTimTrangThai.Size = new Size(151, 28);
            cboTimTrangThai.TabIndex = 16;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(373, 196);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 17;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvPhong
            // 
            dgvPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Location = new Point(12, 260);
            dgvPhong.Name = "dgvPhong";
            dgvPhong.RowHeadersWidth = 51;
            dgvPhong.Size = new Size(1055, 222);
            dgvPhong.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 494);
            Controls.Add(dgvPhong);
            Controls.Add(btnTimKiem);
            Controls.Add(cboTimTrangThai);
            Controls.Add(cboTimLoai);
            Controls.Add(btnChonAnh);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(picPhong);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cboTinhTrang);
            Controls.Add(cboLoaiPhong);
            Controls.Add(nudTangSo);
            Controls.Add(label2);
            Controls.Add(txtSoPhong);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudTangSo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPhong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSoPhong;
        private Label label2;
        private NumericUpDown nudTangSo;
        private ComboBox cboLoaiPhong;
        private ComboBox cboTinhTrang;
        private Label label3;
        private Label label4;
        private PictureBox picPhong;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnChonAnh;
        private ComboBox cboTimLoai;
        private ComboBox cboTimTrangThai;
        private Button btnTimKiem;
        private DataGridView dgvPhong;
    }
}
