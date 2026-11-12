namespace _25520531_BT03
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
            tbMaSanPham = new TextBox();
            tbSoLuong = new TextBox();
            label2 = new Label();
            tbDonGia = new TextBox();
            label3 = new Label();
            tbTenSanPham = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cbbDonViTinh = new ComboBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            tbTimKiem = new TextBox();
            btnTimKiem = new Button();
            label6 = new Label();
            dgvSanPham = new DataGridView();
            MaSanPham = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            DonViTinh = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 79);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã Sản Phẩm";
            // 
            // tbMaSanPham
            // 
            tbMaSanPham.Enabled = false;
            tbMaSanPham.Location = new Point(113, 76);
            tbMaSanPham.Name = "tbMaSanPham";
            tbMaSanPham.ReadOnly = true;
            tbMaSanPham.Size = new Size(257, 23);
            tbMaSanPham.TabIndex = 1;
            // 
            // tbSoLuong
            // 
            tbSoLuong.Location = new Point(113, 137);
            tbSoLuong.Name = "tbSoLuong";
            tbSoLuong.Size = new Size(257, 23);
            tbSoLuong.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 140);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Số Lượng";
            // 
            // tbDonGia
            // 
            tbDonGia.Location = new Point(520, 142);
            tbDonGia.Name = "tbDonGia";
            tbDonGia.Size = new Size(257, 23);
            tbDonGia.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(432, 145);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 6;
            label3.Text = "Đơn Giá";
            // 
            // tbTenSanPham
            // 
            tbTenSanPham.Location = new Point(520, 79);
            tbTenSanPham.Name = "tbTenSanPham";
            tbTenSanPham.Size = new Size(257, 23);
            tbTenSanPham.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(432, 79);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 4;
            label4.Text = "Tên Sản Phẩm";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 188);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 8;
            label5.Text = "Đơn Vị Tính";
            // 
            // cbbDonViTinh
            // 
            cbbDonViTinh.FormattingEnabled = true;
            cbbDonViTinh.Location = new Point(113, 185);
            cbbDonViTinh.Name = "cbbDonViTinh";
            cbbDonViTinh.Size = new Size(257, 23);
            cbbDonViTinh.TabIndex = 9;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(27, 230);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(126, 230);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(227, 230);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 12;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // tbTimKiem
            // 
            tbTimKiem.Location = new Point(355, 231);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(286, 23);
            tbTimKiem.TabIndex = 13;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(668, 230);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(75, 23);
            btnTimKiem.TabIndex = 14;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(323, 20);
            label6.Name = "label6";
            label6.Size = new Size(191, 25);
            label6.TabIndex = 15;
            label6.Text = "Danh Sách Sản Phẩm";
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { MaSanPham, TenSanPham, SoLuong, DonGia, DonViTinh });
            dgvSanPham.Location = new Point(27, 280);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(755, 175);
            dgvSanPham.TabIndex = 16;
            // 
            // MaSanPham
            // 
            MaSanPham.DataPropertyName = "MaSanPham";
            MaSanPham.HeaderText = "Mã Sản Phẩm";
            MaSanPham.Name = "MaSanPham";
            MaSanPham.ReadOnly = true;
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.HeaderText = "Tên Sản Phẩm";
            TenSanPham.Name = "TenSanPham";
            TenSanPham.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn Giá";
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // DonViTinh
            // 
            DonViTinh.DataPropertyName = "DonViTinh";
            DonViTinh.HeaderText = "Đơn Vị Tính";
            DonViTinh.Name = "DonViTinh";
            DonViTinh.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvSanPham);
            Controls.Add(label6);
            Controls.Add(btnTimKiem);
            Controls.Add(tbTimKiem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(cbbDonViTinh);
            Controls.Add(label5);
            Controls.Add(tbDonGia);
            Controls.Add(label3);
            Controls.Add(tbTenSanPham);
            Controls.Add(label4);
            Controls.Add(tbSoLuong);
            Controls.Add(label2);
            Controls.Add(tbMaSanPham);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbMaSanPham;
        private TextBox tbSoLuong;
        private Label label2;
        private TextBox tbDonGia;
        private Label label3;
        private TextBox tbTenSanPham;
        private Label label4;
        private Label label5;
        private ComboBox cbbDonViTinh;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private TextBox tbTimKiem;
        private Button btnTimKiem;
        private Label label6;
        private DataGridView dgvSanPham;
        private DataGridViewTextBoxColumn MaSanPham;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn DonViTinh;
    }
}
