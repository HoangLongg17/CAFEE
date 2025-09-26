namespace CF36
{
    partial class ThemTonKho
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
            tlpall = new TableLayoutPanel();
            picLogo = new PictureBox();
            tlpThongtin = new TableLayoutPanel();
            lbChonNhaCungCap = new Label();
            cbbNhaCungCap = new ComboBox();
            lbChonSanPham = new Label();
            txtTimKiem = new TextBox();
            txtSoLuong = new TextBox();
            lbNhapSoLuong = new Label();
            lbGiaNhap = new Label();
            txtGiaNhap = new TextBox();
            dgvSanPham = new DataGridView();
            tlpend = new TableLayoutPanel();
            btnThoat = new Button();
            btnThem = new Button();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpThongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            tlpend.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpThongtin, 0, 1);
            tlpall.Controls.Add(dgvSanPham, 0, 2);
            tlpall.Controls.Add(tlpend, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.5384617F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 26.73077F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 46.1538467F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 10.9615383F));
            tlpall.Size = new Size(794, 520);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(788, 79);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpThongtin
            // 
            tlpThongtin.ColumnCount = 2;
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpThongtin.Controls.Add(lbChonNhaCungCap, 0, 0);
            tlpThongtin.Controls.Add(cbbNhaCungCap, 0, 1);
            tlpThongtin.Controls.Add(lbChonSanPham, 0, 2);
            tlpThongtin.Controls.Add(txtTimKiem, 0, 3);
            tlpThongtin.Controls.Add(txtSoLuong, 1, 3);
            tlpThongtin.Controls.Add(lbNhapSoLuong, 1, 2);
            tlpThongtin.Controls.Add(lbGiaNhap, 1, 0);
            tlpThongtin.Controls.Add(txtGiaNhap, 1, 1);
            tlpThongtin.Dock = DockStyle.Fill;
            tlpThongtin.Location = new Point(3, 88);
            tlpThongtin.Name = "tlpThongtin";
            tlpThongtin.RowCount = 4;
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpThongtin.Size = new Size(788, 132);
            tlpThongtin.TabIndex = 1;
            // 
            // lbChonNhaCungCap
            // 
            lbChonNhaCungCap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbChonNhaCungCap.AutoSize = true;
            lbChonNhaCungCap.Location = new Point(3, 13);
            lbChonNhaCungCap.Name = "lbChonNhaCungCap";
            lbChonNhaCungCap.Size = new Size(135, 20);
            lbChonNhaCungCap.TabIndex = 0;
            lbChonNhaCungCap.Text = "Chọn nhà cung cấp";
            // 
            // cbbNhaCungCap
            // 
            cbbNhaCungCap.FormattingEnabled = true;
            cbbNhaCungCap.Location = new Point(3, 36);
            cbbNhaCungCap.Name = "cbbNhaCungCap";
            cbbNhaCungCap.Size = new Size(388, 28);
            cbbNhaCungCap.TabIndex = 1;
            // 
            // lbChonSanPham
            // 
            lbChonSanPham.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbChonSanPham.AutoSize = true;
            lbChonSanPham.Location = new Point(3, 79);
            lbChonSanPham.Name = "lbChonSanPham";
            lbChonSanPham.Size = new Size(178, 20);
            lbChonSanPham.TabIndex = 2;
            lbChonSanPham.Text = "Chọn sản phẩm/Tìm kiếm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(3, 102);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(388, 27);
            txtTimKiem.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(397, 102);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(388, 27);
            txtSoLuong.TabIndex = 4;
            // 
            // lbNhapSoLuong
            // 
            lbNhapSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbNhapSoLuong.AutoSize = true;
            lbNhapSoLuong.Location = new Point(397, 79);
            lbNhapSoLuong.Name = "lbNhapSoLuong";
            lbNhapSoLuong.Size = new Size(162, 20);
            lbNhapSoLuong.TabIndex = 5;
            lbNhapSoLuong.Text = "Số lượng nhập vào kho";
            // 
            // lbGiaNhap
            // 
            lbGiaNhap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbGiaNhap.AutoSize = true;
            lbGiaNhap.Location = new Point(397, 13);
            lbGiaNhap.Name = "lbGiaNhap";
            lbGiaNhap.Size = new Size(68, 20);
            lbGiaNhap.TabIndex = 6;
            lbGiaNhap.Text = "Giá nhập";
            lbGiaNhap.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Anchor = AnchorStyles.Left;
            txtGiaNhap.Location = new Point(397, 36);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(387, 27);
            txtGiaNhap.TabIndex = 7;
            // 
            // dgvSanPham
            // 
            dgvSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Location = new Point(3, 226);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(788, 233);
            dgvSanPham.TabIndex = 2;
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 3;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.85787F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.8934F));
            tlpend.Controls.Add(btnThoat, 2, 0);
            tlpend.Controls.Add(btnThem, 1, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 465);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(788, 52);
            tlpend.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(649, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(135, 46);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Right;
            btnThem.Location = new Point(517, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(126, 46);
            btnThem.TabIndex = 1;
            btnThem.Text = "THÊM";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // ThemTonKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 520);
            Controls.Add(tlpall);
            Name = "ThemTonKho";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm tồn kho";
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpThongtin.ResumeLayout(false);
            tlpThongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            tlpend.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpThongtin;
        private Label lbChonNhaCungCap;
        private ComboBox cbbNhaCungCap;
        private Label lbChonSanPham;
        private DataGridView dgvSanPham;
        private TextBox txtTimKiem;
        private TextBox txtSoLuong;
        private Label lbNhapSoLuong;
        private TableLayoutPanel tlpend;
        private Button btnThoat;
        private Label lbGiaNhap;
        private TextBox txtGiaNhap;
        private Button btnThem;
    }
}