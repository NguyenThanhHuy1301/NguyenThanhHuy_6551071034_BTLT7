namespace dataFirst
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
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTenTheLoai = new TextBox();
            txtMoTa = new TextBox();
            txtTimKiem = new TextBox();
            dgvTheLoai = new DataGridView();
            btnTimKiem = new Button();
            btnLamMoi = new Button();
            txtMaTL = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            SuspendLayout();
            // 
            // btnThem
            // 
            btnThem.Location = new Point(435, 22);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(550, 22);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa ";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(661, 22);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 31);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 4;
            label1.Text = "Mã thể loại";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 77);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 5;
            label2.Text = "Tên Thể loại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 129);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 6;
            label3.Text = "Mô tả";
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.Location = new Point(135, 74);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(194, 27);
            txtTenTheLoai.TabIndex = 8;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(135, 129);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(192, 77);
            txtMoTa.TabIndex = 9;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(27, 212);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(323, 27);
            txtTimKiem.TabIndex = 11;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // dgvTheLoai
            // 
            dgvTheLoai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoai.Location = new Point(27, 250);
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.RowHeadersWidth = 51;
            dgvTheLoai.Size = new Size(814, 188);
            dgvTheLoai.TabIndex = 12;
            dgvTheLoai.CellContentClick += dgvTheLoai_CellContentClick;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(382, 215);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(773, 22);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 14;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // btnLamMoi.Click += button4_Click_1Async;
            // 
            // txtMaTL
            // 
            txtMaTL.Location = new Point(135, 28);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.Size = new Size(192, 27);
            txtMaTL.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 450);
            Controls.Add(txtMaTL);
            Controls.Add(btnLamMoi);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvTheLoai);
            Controls.Add(txtTimKiem);
            Controls.Add(txtMoTa);
            Controls.Add(txtTenTheLoai);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void button4_Click_1Async(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTenTheLoai;
        private TextBox txtMoTa;
        private TextBox txtTimKiem;
        private DataGridView dgvTheLoai;
        private Button btnTimKiem;
        private Button btnLamMoi;
        private TextBox txtMaTL;
    }
}
