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
            tlpall = new TableLayoutPanel();
            picLogo = new PictureBox();
            tlpThantren = new TableLayoutPanel();
            lbMaSanPham = new Label();
            lbTensanpham = new Label();
            txtMaSanPham = new TextBox();
            txtTenSanPham = new TextBox();
            lbLoaiSanPham = new Label();
            cbbLoaiSanPham = new ComboBox();
            tlpSize = new TableLayoutPanel();
            lbSize = new Label();
            gbSize = new GroupBox();
            txtGiaM = new TextBox();
            txtGiaL = new TextBox();
            txtGiaS = new TextBox();
            cbL = new CheckBox();
            cbM = new CheckBox();
            cbS = new CheckBox();
            lbMoTa = new Label();
            tlpAnh = new TableLayoutPanel();
            picAnh = new PictureBox();
            btnThem = new Button();
            tlpButton = new TableLayoutPanel();
            btnXacNhan = new Button();
            btnThoat = new Button();
            openFileDialog1 = new OpenFileDialog();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpThantren.SuspendLayout();
            tlpSize.SuspendLayout();
            gbSize.SuspendLayout();
            tlpAnh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnh).BeginInit();
            tlpButton.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
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
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0866547F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 11.0918541F));
            tlpall.Size = new Size(822, 577);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(816, 102);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
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
            tlpThantren.Location = new Point(3, 111);
            tlpThantren.Name = "tlpThantren";
            tlpThantren.RowCount = 2;
            tlpThantren.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThantren.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThantren.Size = new Size(816, 110);
            tlpThantren.TabIndex = 1;
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
            lbTensanpham.Location = new Point(119, 55);
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
            txtTenSanPham.Location = new Point(225, 58);
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(206, 27);
            txtTenSanPham.TabIndex = 3;
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
            cbbLoaiSanPham.Size = new Size(216, 28);
            cbbLoaiSanPham.TabIndex = 5;
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
            tlpSize.Location = new Point(3, 227);
            tlpSize.Name = "tlpSize";
            tlpSize.RowCount = 2;
            tlpSize.RowStyles.Add(new RowStyle(SizeType.Percent, 59.9290771F));
            tlpSize.RowStyles.Add(new RowStyle(SizeType.Percent, 40.0709229F));
            tlpSize.Size = new Size(816, 282);
            tlpSize.TabIndex = 2;
            // 
            // lbSize
            // 
            lbSize.Anchor = AnchorStyles.Right;
            lbSize.AutoSize = true;
            lbSize.Location = new Point(168, 74);
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
            gbSize.Location = new Point(411, 5);
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
            txtGiaL.Location = new Point(117, 126);
            txtGiaL.Name = "txtGiaL";
            txtGiaL.Size = new Size(125, 27);
            txtGiaL.TabIndex = 1;
            // 
            // txtGiaS
            // 
            txtGiaS.Location = new Point(117, 22);
            txtGiaS.Name = "txtGiaS";
            txtGiaS.Size = new Size(125, 27);
            txtGiaS.TabIndex = 1;
            // 
            // cbL
            // 
            cbL.AutoSize = true;
            cbL.Location = new Point(20, 129);
            cbL.Name = "cbL";
            cbL.Size = new Size(38, 24);
            cbL.TabIndex = 0;
            cbL.Text = "L";
            cbL.UseVisualStyleBackColor = true;
            // 
            // cbM
            // 
            cbM.AutoSize = true;
            cbM.Location = new Point(20, 74);
            cbM.Name = "cbM";
            cbM.Size = new Size(44, 24);
            cbM.TabIndex = 0;
            cbM.Text = "M";
            cbM.UseVisualStyleBackColor = true;
            // 
            // cbS
            // 
            cbS.AutoSize = true;
            cbS.Location = new Point(20, 25);
            cbS.Name = "cbS";
            cbS.Size = new Size(39, 24);
            cbS.TabIndex = 0;
            cbS.Text = "S";
            cbS.UseVisualStyleBackColor = true;
            // 
            // lbMoTa
            // 
            lbMoTa.Anchor = AnchorStyles.Right;
            lbMoTa.AutoSize = true;
            lbMoTa.Location = new Point(142, 215);
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
            tlpAnh.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tlpAnh.Controls.Add(picAnh, 0, 0);
            tlpAnh.Controls.Add(btnThem, 1, 0);
            tlpAnh.Location = new Point(411, 172);
            tlpAnh.Name = "tlpAnh";
            tlpAnh.RowCount = 1;
            tlpAnh.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpAnh.Size = new Size(359, 107);
            tlpAnh.TabIndex = 3;
            // 
            // picAnh
            // 
            picAnh.Anchor = AnchorStyles.Left;
            picAnh.Location = new Point(3, 3);
            picAnh.Name = "picAnh";
            picAnh.Size = new Size(173, 101);
            picAnh.TabIndex = 0;
            picAnh.TabStop = false;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Left;
            btnThem.Location = new Point(182, 21);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(118, 65);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm ảnh";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // tlpButton
            // 
            tlpButton.ColumnCount = 2;
            tlpButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.1666641F));
            tlpButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.833334F));
            tlpButton.Controls.Add(btnXacNhan, 0, 0);
            tlpButton.Controls.Add(btnThoat, 1, 0);
            tlpButton.Dock = DockStyle.Fill;
            tlpButton.Location = new Point(3, 515);
            tlpButton.Name = "tlpButton";
            tlpButton.RowCount = 1;
            tlpButton.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpButton.Size = new Size(816, 59);
            tlpButton.TabIndex = 3;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXacNhan.Location = new Point(548, 3);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(94, 53);
            btnXacNhan.TabIndex = 0;
            btnXacNhan.Text = "XÁC NHẬN";
            btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(648, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 53);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // ThemSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 577);
            Controls.Add(tlpall);
            Name = "ThemSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm sản phẩm";
            Load += ThemSanPham_Load;
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpThantren.ResumeLayout(false);
            tlpThantren.PerformLayout();
            tlpSize.ResumeLayout(false);
            tlpSize.PerformLayout();
            gbSize.ResumeLayout(false);
            gbSize.PerformLayout();
            tlpAnh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAnh).EndInit();
            tlpButton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpThantren;
        private Label lbMaSanPham;
        private Label lbTensanpham;
        private TextBox txtMaSanPham;
        private TextBox txtTenSanPham;
        private Label lbLoaiSanPham;
        private ComboBox cbbLoaiSanPham;
        private TableLayoutPanel tlpSize;
        private Label lbSize;
        private GroupBox gbSize;
        private CheckBox cbL;
        private CheckBox cbM;
        private CheckBox cbS;
        private TextBox txtGiaM;
        private TextBox txtGiaL;
        private TextBox txtGiaS;
        private Label lbMoTa;
        private OpenFileDialog openFileDialog1;
        private TableLayoutPanel tlpAnh;
        private PictureBox picAnh;
        private Button btnThem;
        private TableLayoutPanel tlpButton;
        private Button btnXacNhan;
        private Button btnThoat;
    }
}