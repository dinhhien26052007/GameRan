namespace _25520531_BT02
{
    partial class QuanLySanPhamForm
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
            h = new Label();
            tbMaSanPham = new TextBox();
            tbTenSanPham = new TextBox();
            label3 = new Label();
            tbDonGia = new TextBox();
            label4 = new Label();
            tbSoLuong = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cbbDonViTinh = new ComboBox();
            dgvSanPham = new DataGridView();
            MaSanPham = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonViTinh = new DataGridViewTextBoxColumn();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnTimKiem = new Button();
            tbTimKiem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(315, 23);
            label1.Name = "label1";
            label1.Size = new Size(169, 25);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Sản Phẩm";
            // 
            // h
            // 
            h.AutoSize = true;
            h.Location = new Point(30, 77);
            h.Name = "h";
            h.Size = new Size(80, 15);
            h.TabIndex = 1;
            h.Text = "Mã Sản Phẩm";
            // 
            // tbMaSanPham
            // 
            tbMaSanPham.Enabled = false;
            tbMaSanPham.Location = new Point(118, 74);
            tbMaSanPham.Name = "tbMaSanPham";
            tbMaSanPham.ReadOnly = true;
            tbMaSanPham.Size = new Size(284, 23);
            tbMaSanPham.TabIndex = 2;
            // 
            // tbTenSanPham
            // 
            tbTenSanPham.Location = new Point(118, 119);
            tbTenSanPham.Name = "tbTenSanPham";
            tbTenSanPham.Size = new Size(284, 23);
            tbTenSanPham.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 122);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 3;
            label3.Text = "Tên Sản Phẩm";
            // 
            // tbDonGia
            // 
            tbDonGia.Location = new Point(493, 74);
            tbDonGia.Name = "tbDonGia";
            tbDonGia.Size = new Size(284, 23);
            tbDonGia.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(427, 77);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 5;
            label4.Text = "Đơn Giá";
            // 
            // tbSoLuong
            // 
            tbSoLuong.Location = new Point(493, 119);
            tbSoLuong.Name = "tbSoLuong";
            tbSoLuong.Size = new Size(284, 23);
            tbSoLuong.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(427, 122);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 7;
            label5.Text = "Số Lượng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 9;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 174);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 10;
            label7.Text = "Đơn Vị Tính";
            // 
            // cbbDonViTinh
            // 
            cbbDonViTinh.FormattingEnabled = true;
            cbbDonViTinh.Location = new Point(118, 166);
            cbbDonViTinh.Name = "cbbDonViTinh";
            cbbDonViTinh.Size = new Size(284, 23);
            cbbDonViTinh.TabIndex = 11;
            // 
            // dgvSanPham
            // 
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { MaSanPham, TenSanPham, DonGia, SoLuong, DonViTinh });
            dgvSanPham.Location = new Point(30, 247);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(747, 201);
            dgvSanPham.TabIndex = 12;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
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
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn Giá";
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.Name = "SoLuong";
            // 
            // DonViTinh
            // 
            DonViTinh.DataPropertyName = "DonViTinh";
            DonViTinh.HeaderText = "Đơn Vị Tính";
            DonViTinh.Name = "DonViTinh";
            DonViTinh.ReadOnly = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(33, 208);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(77, 22);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(135, 207);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(246, 208);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 15;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(700, 208);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(75, 23);
            btnTimKiem.TabIndex = 16;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // tbTimKiem
            // 
            tbTimKiem.Location = new Point(410, 208);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(284, 23);
            tbTimKiem.TabIndex = 17;
            // 
            // QuanLySanPhamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(dgvSanPham);
            Controls.Add(cbbDonViTinh);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(tbSoLuong);
            Controls.Add(label5);
            Controls.Add(tbDonGia);
            Controls.Add(label4);
            Controls.Add(tbTenSanPham);
            Controls.Add(label3);
            Controls.Add(tbMaSanPham);
            Controls.Add(h);
            Controls.Add(label1);
            Name = "QuanLySanPhamForm";
            Text = "Form1";
            Load += QuanLySanPhamForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label h;
        private TextBox tbMaSanPham;
        private TextBox tbTenSanPham;
        private Label label3;
        private TextBox tbDonGia;
        private Label label4;
        private TextBox tbSoLuong;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cbbDonViTinh;
        private DataGridView dgvSanPham;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnTimKiem;
        private TextBox tbTimKiem;
        private DataGridViewTextBoxColumn MaSanPham;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonViTinh;
    }
}