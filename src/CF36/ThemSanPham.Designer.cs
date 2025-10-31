namespace CF36
{
    partial class ThemSanPham
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
            openFileDialog1 = new OpenFileDialog();
            btnXacNhan = new Button();
            tlpButton = new TableLayoutPanel();
            btnThoat = new Button();
            picAnh = new PictureBox();
            btnThem = new Button();
            lbMoTa = new Label();
            tlpAnh = new TableLayoutPanel();
            lbSize = new Label();
            gbSize = new GroupBox();
            txtGiaM = new TextBox();
            txtGiaL = new TextBox();
            txtGiaS = new TextBox();
            cbL = new CheckBox();
            cbM = new CheckBox();
            cbS = new CheckBox();
            lbLoaiSanPham = new Label();
            cbbLoaiSanPham = new ComboBox();
            lbMaSanPham = new Label();
            lbTensanpham = new Label();
            txtMaSanPham = new TextBox();
            txtTenSanPham = new TextBox();
            tlpThantren = new TableLayoutPanel();
            tlpall = new TableLayoutPanel();
            picLogo = new PictureBox();
            tlpSize = new TableLayoutPanel();
            tlpButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnh).BeginInit();
            tlpAnh.SuspendLayout();
            gbSize.SuspendLayout();
            tlpThantren.SuspendLayout();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpSize.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnXacNhan
            // 
            btnXacNhan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXacNhan.Location = new Point(509, 3);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(133, 70);
            btnXacNhan.TabIndex = 0;
            btnXacNhan.Text = "XÁC NHẬN";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // tlpButton
            // 
            tlpButton.ColumnCount = 2;
            tlpButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.1666641F));
            tlpButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.833334F));
            tlpButton.Controls.Add(btnXacNhan, 0, 0);
            tlpButton.Controls.Add(btnThoat, 1, 0);
            tlpButton.Dock = DockStyle.Fill;
            tlpButton.Location = new Point(3, 545);
            tlpButton.Name = "tlpButton";
            tlpButton.RowCount = 1;
            tlpButton.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpButton.Size = new Size(816, 76);
            tlpButton.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(648, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(122, 70);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // picAnh
            // 
            picAnh.Anchor = AnchorStyles.Left;
            picAnh.Location = new Point(3, 3);
            picAnh.Name = "picAnh";
            picAnh.Size = new Size(171, 101);
            picAnh.TabIndex = 0;
            picAnh.TabStop = false;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Left;
            btnThem.Location = new Point(181, 21);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(118, 65);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm ảnh";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // lbMoTa
            // 
            lbMoTa.Anchor = AnchorStyles.Right;
            lbMoTa.AutoSize = true;
            lbMoTa.Location = new Point(142, 224);
            lbMoTa.Name = "lbMoTa";
            lbMoTa.Size = new Size(263, 20);
            lbMoTa.TabIndex = 2;
            lbMoTa.Text = "Thêm mô tả (Ảnh minh họa sản phẩm)";
            // 
            // tlpAnh
            // 
            tlpAnh.Anchor = AnchorStyles.Left;
            tlpAnh.ColumnCount = 2;
            tlpAnh.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpAnh.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 181F));
            tlpAnh.Controls.Add(picAnh, 0, 0);
            tlpAnh.Controls.Add(btnThem, 1, 0);
            tlpAnh.Location = new Point(411, 180);
            tlpAnh.Name = "tlpAnh";
            tlpAnh.RowCount = 1;
            tlpAnh.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpAnh.Size = new Size(359, 107);
            tlpAnh.TabIndex = 3;
            // 
            // lbSize
            // 
            lbSize.Anchor = AnchorStyles.Right;
            lbSize.AutoSize = true;
            lbSize.Location = new Point(168, 77);
            lbSize.Name = "lbSize";
            lbSize.Size = new Size(237, 20);
            lbSize.TabIndex = 0;
            lbSize.Text = "Thêm kích cỡ và giá tiền sản phẩm";
            // 
            // gbSize
            // 
            gbSize.Anchor = AnchorStyles.Left;
            gbSize.Controls.Add(txtGiaM);
            gbSize.Controls.Add(txtGiaL);
            gbSize.Controls.Add(txtGiaS);
            gbSize.Controls.Add(cbL);
            gbSize.Controls.Add(cbM);
            gbSize.Controls.Add(cbS);
            gbSize.Location = new Point(411, 8);
            gbSize.Name = "gbSize";
            gbSize.Size = new Size(322, 159);
            gbSize.TabIndex = 1;
            gbSize.TabStop = false;
            gbSize.Text = "Chọn size và thêm giá cho từng size";
            // 
            // txtGiaM
            // 
            txtGiaM.Location = new Point(117, 71);
            txtGiaM.Name = "txtGiaM";
            txtGiaM.Size = new Size(125, 27);
            txtGiaM.TabIndex = 1;
            // 
            // txtGiaL
            // 
            txtGiaL.Location = new Point(117, 125);
            txtGiaL.Name = "txtGiaL";
            txtGiaL.Size = new Size(125, 27);
            txtGiaL.TabIndex = 1;
            // 
            // txtGiaS
            // 
            txtGiaS.Location = new Point(117, 21);
            txtGiaS.Name = "txtGiaS";
            txtGiaS.Size = new Size(125, 27);
            txtGiaS.TabIndex = 1;
            // 
            // cbL
            // 
            cbL.AutoSize = true;
            cbL.Location = new Point(21, 128);
            cbL.Name = "cbL";
            cbL.Size = new Size(38, 24);
            cbL.TabIndex = 0;
            cbL.Text = "L";
            cbL.UseVisualStyleBackColor = true;
            cbL.CheckedChanged += cbL_CheckedChanged;
            // 
            // cbM
            // 
            cbM.AutoSize = true;
            cbM.Location = new Point(21, 73);
            cbM.Name = "cbM";
            cbM.Size = new Size(44, 24);
            cbM.TabIndex = 0;
            cbM.Text = "M";
            cbM.UseVisualStyleBackColor = true;
            cbM.CheckedChanged += cbM_CheckedChanged;
            // 
            // cbS
            // 
            cbS.AutoSize = true;
            cbS.Location = new Point(21, 24);
            cbS.Name = "cbS";
            cbS.Size = new Size(39, 24);
            cbS.TabIndex = 0;
            cbS.Text = "S";
            cbS.UseVisualStyleBackColor = true;
            cbS.CheckedChanged += cbS_CheckedChanged;
            // 
            // lbLoaiSanPham
            // 
            lbLoaiSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbLoaiSanPham.AutoSize = true;
            lbLoaiSanPham.Location = new Point(449, 0);
            lbLoaiSanPham.Name = "lbLoaiSanPham";
            lbLoaiSanPham.Size = new Size(105, 20);
            lbLoaiSanPham.TabIndex = 4;
            lbLoaiSanPham.Text = "Loại sản phẩm";
            // 
            // cbbLoaiSanPham
            // 
            cbbLoaiSanPham.FormattingEnabled = true;
            cbbLoaiSanPham.Location = new Point(560, 3);
            cbbLoaiSanPham.Name = "cbbLoaiSanPham";
            cbbLoaiSanPham.Size = new Size(217, 28);
            cbbLoaiSanPham.TabIndex = 5;
            // 
            // lbMaSanPham
            // 
            lbMaSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbMaSanPham.AutoSize = true;
            lbMaSanPham.Location = new Point(121, 0);
            lbMaSanPham.Name = "lbMaSanPham";
            lbMaSanPham.Size = new Size(98, 20);
            lbMaSanPham.TabIndex = 0;
            lbMaSanPham.Text = "Mã sản phẩm";
            // 
            // lbTensanpham
            // 
            lbTensanpham.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTensanpham.AutoSize = true;
            lbTensanpham.Location = new Point(119, 60);
            lbTensanpham.Name = "lbTensanpham";
            lbTensanpham.Size = new Size(100, 20);
            lbTensanpham.TabIndex = 1;
            lbTensanpham.Text = "Tên sản phẩm";
            // 
            // txtMaSanPham
            // 
            txtMaSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaSanPham.Location = new Point(225, 3);
            txtMaSanPham.Name = "txtMaSanPham";
            txtMaSanPham.Size = new Size(206, 27);
            txtMaSanPham.TabIndex = 2;
            // 
            // txtTenSanPham
            // 
            txtTenSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenSanPham.Location = new Point(225, 63);
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(206, 27);
            txtTenSanPham.TabIndex = 3;
            // 
            // tlpThantren
            // 
            tlpThantren.ColumnCount = 4;
            tlpThantren.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.205883F));
            tlpThantren.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.9803925F));
            tlpThantren.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.0735292F));
            tlpThantren.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.7401962F));
            tlpThantren.Controls.Add(lbMaSanPham, 0, 0);
            tlpThantren.Controls.Add(lbTensanpham, 0, 1);
            tlpThantren.Controls.Add(txtMaSanPham, 1, 0);
            tlpThantren.Controls.Add(txtTenSanPham, 1, 1);
            tlpThantren.Controls.Add(lbLoaiSanPham, 2, 0);
            tlpThantren.Controls.Add(cbbLoaiSanPham, 3, 0);
            tlpThantren.Dock = DockStyle.Fill;
            tlpThantren.Location = new Point(3, 120);
            tlpThantren.Name = "tlpThantren";
            tlpThantren.RowCount = 2;
            tlpThantren.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThantren.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThantren.Size = new Size(816, 120);
            tlpThantren.TabIndex = 1;
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 21F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpThantren, 0, 1);
            tlpall.Controls.Add(tlpSize, 0, 2);
            tlpall.Controls.Add(tlpButton, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 18.8908138F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 20.2772961F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 48.0769234F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 12.9807692F));
            tlpall.Size = new Size(822, 624);
            tlpall.TabIndex = 1;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(816, 111);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpSize
            // 
            tlpSize.ColumnCount = 2;
            tlpSize.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSize.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSize.Controls.Add(lbSize, 0, 0);
            tlpSize.Controls.Add(gbSize, 1, 0);
            tlpSize.Controls.Add(lbMoTa, 0, 1);
            tlpSize.Controls.Add(tlpAnh, 1, 1);
            tlpSize.Dock = DockStyle.Fill;
            tlpSize.Location = new Point(3, 246);
            tlpSize.Name = "tlpSize";
            tlpSize.RowCount = 2;
            tlpSize.RowStyles.Add(new RowStyle(SizeType.Percent, 59.9290771F));
            tlpSize.RowStyles.Add(new RowStyle(SizeType.Percent, 40.0709229F));
            tlpSize.Size = new Size(816, 293);
            tlpSize.TabIndex = 2;
            // 
            // ThemSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 624);
            Controls.Add(tlpall);
            Name = "ThemSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm sản phẩm";
            Load += ThemSanPham_Load;
            tlpButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAnh).EndInit();
            tlpAnh.ResumeLayout(false);
            gbSize.ResumeLayout(false);
            gbSize.PerformLayout();
            tlpThantren.ResumeLayout(false);
            tlpThantren.PerformLayout();
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpSize.ResumeLayout(false);
            tlpSize.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button btnXacNhan;
        private TableLayoutPanel tlpButton;
        private Button btnThoat;
        private PictureBox picAnh;
        private Button btnThem;
        private Label lbMoTa;
        private TableLayoutPanel tlpAnh;
        private Label lbSize;
        private GroupBox gbSize;
        private TextBox txtGiaM;
        private TextBox txtGiaL;
        private TextBox txtGiaS;
        private CheckBox cbL;
        private CheckBox cbM;
        private CheckBox cbS;
        private Label lbLoaiSanPham;
        private ComboBox cbbLoaiSanPham;
        private Label lbMaSanPham;
        private Label lbTensanpham;
        private TextBox txtMaSanPham;
        private TextBox txtTenSanPham;
        private TableLayoutPanel tlpThantren;
        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpSize;
    }
}