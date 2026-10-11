namespace Cau4
{
    partial class FrmBacSi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtHoTen = new TextBox();
            txtChuyenKhoa = new TextBox();
            label3 = new Label();
            txtSDT = new TextBox();
            dgvBacSi = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 24);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ tên";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 75);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 1;
            label2.Text = "Chuyên khoa";
            label2.Click += label2_Click;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(159, 21);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(162, 27);
            txtHoTen.TabIndex = 2;
            // 
            // txtChuyenKhoa
            // 
            txtChuyenKhoa.Location = new Point(159, 72);
            txtChuyenKhoa.Name = "txtChuyenKhoa";
            txtChuyenKhoa.Size = new Size(162, 27);
            txtChuyenKhoa.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 124);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 4;
            label3.Text = "SDT";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(159, 124);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(162, 27);
            txtSDT.TabIndex = 5;
            // 
            // dgvBacSi
            // 
            dgvBacSi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBacSi.Location = new Point(12, 186);
            dgvBacSi.Name = "dgvBacSi";
            dgvBacSi.RowHeadersWidth = 51;
            dgvBacSi.Size = new Size(853, 249);
            dgvBacSi.TabIndex = 6;
            dgvBacSi.CellContentClick += dgvBacSi_CellContentClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(448, 36);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(638, 36);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(448, 104);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(638, 104);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // FrmBacSi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 447);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvBacSi);
            Controls.Add(txtSDT);
            Controls.Add(label3);
            Controls.Add(txtChuyenKhoa);
            Controls.Add(txtHoTen);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmBacSi";
            Text = "FrmBacSi";
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtHoTen;
        private TextBox txtChuyenKhoa;
        private Label label3;
        private TextBox txtSDT;
        private DataGridView dgvBacSi;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
    }
}