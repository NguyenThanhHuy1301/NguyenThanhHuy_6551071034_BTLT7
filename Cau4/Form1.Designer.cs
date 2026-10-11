namespace Cau4
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
            label2 = new Label();
            label3 = new Label();
            txtTenBN = new TextBox();
            txtSDT = new TextBox();
            dtpNgayKham = new DateTimePicker();
            label4 = new Label();
            dtpGioKham = new DateTimePicker();
            label5 = new Label();
            cboBacSi = new ComboBox();
            label6 = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            label7 = new Label();
            dtpTuNgay = new DateTimePicker();
            label8 = new Label();
            dtpDenNgay = new DateTimePicker();
            cboTimBacSi = new ComboBox();
            btnTimKiem = new Button();
            dgvLichKham = new DataGridView();
            btnQuanLyBacSi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 28);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên bệnh nhân";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 73);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 1;
            label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 118);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 2;
            label3.Text = "Ngày khám";
            // 
            // txtTenBN
            // 
            txtTenBN.Location = new Point(137, 21);
            txtTenBN.Name = "txtTenBN";
            txtTenBN.Size = new Size(250, 27);
            txtTenBN.TabIndex = 3;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(137, 66);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(250, 27);
            txtSDT.TabIndex = 4;
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.Location = new Point(137, 111);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(250, 27);
            dtpNgayKham.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(434, 73);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 6;
            label4.Text = "Giờ khám";
            // 
            // dtpGioKham
            // 
            dtpGioKham.Location = new Point(420, 111);
            dtpGioKham.Name = "dtpGioKham";
            dtpGioKham.Size = new Size(131, 27);
            dtpGioKham.TabIndex = 7;
            dtpGioKham.Value = new DateTime(2026, 10, 11, 10, 43, 0, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(588, 73);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 8;
            label5.Text = "Bác sĩ";
            // 
            // cboBacSi
            // 
            cboBacSi.FormattingEnabled = true;
            cboBacSi.Location = new Point(577, 110);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(236, 28);
            cboBacSi.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(833, 73);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 10;
            label6.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(833, 110);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 28);
            cboTrangThai.TabIndex = 11;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(541, 12);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(651, 12);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(761, 12);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(876, 12);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 187);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 16;
            label7.Text = "Từ ngày";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(104, 182);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(212, 27);
            dtpTuNgay.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(337, 187);
            label8.Name = "label8";
            label8.Size = new Size(72, 20);
            label8.TabIndex = 18;
            label8.Text = "Đến ngày";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(420, 182);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(250, 27);
            dtpDenNgay.TabIndex = 19;
            // 
            // cboTimBacSi
            // 
            cboTimBacSi.FormattingEnabled = true;
            cboTimBacSi.Location = new Point(685, 179);
            cboTimBacSi.Name = "cboTimBacSi";
            cboTimBacSi.Size = new Size(151, 28);
            cboTimBacSi.TabIndex = 20;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(856, 178);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 21;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // dgvLichKham
            // 
            dgvLichKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichKham.Location = new Point(27, 234);
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.RowHeadersWidth = 51;
            dgvLichKham.Size = new Size(1077, 308);
            dgvLichKham.TabIndex = 22;
            // 
            // btnQuanLyBacSi
            // 
            btnQuanLyBacSi.Location = new Point(1010, 187);
            btnQuanLyBacSi.Name = "btnQuanLyBacSi";
            btnQuanLyBacSi.Size = new Size(94, 29);
            btnQuanLyBacSi.TabIndex = 23;
            btnQuanLyBacSi.Text = "QL bác sĩ";
            btnQuanLyBacSi.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 568);
            Controls.Add(btnQuanLyBacSi);
            Controls.Add(dgvLichKham);
            Controls.Add(btnTimKiem);
            Controls.Add(cboTimBacSi);
            Controls.Add(dtpDenNgay);
            Controls.Add(label8);
            Controls.Add(dtpTuNgay);
            Controls.Add(label7);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cboTrangThai);
            Controls.Add(label6);
            Controls.Add(cboBacSi);
            Controls.Add(label5);
            Controls.Add(dtpGioKham);
            Controls.Add(label4);
            Controls.Add(dtpNgayKham);
            Controls.Add(txtSDT);
            Controls.Add(txtTenBN);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTenBN;
        private TextBox txtSDT;
        private DateTimePicker dtpNgayKham;
        private Label label4;
        private DateTimePicker dtpGioKham;
        private Label label5;
        private ComboBox cboBacSi;
        private Label label6;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label label7;
        private DateTimePicker dtpTuNgay;
        private Label label8;
        private DateTimePicker dtpDenNgay;
        private ComboBox cboTimBacSi;
        private Button btnTimKiem;
        private DataGridView dgvLichKham;
        private Button btnQuanLyBacSi;
    }
}
