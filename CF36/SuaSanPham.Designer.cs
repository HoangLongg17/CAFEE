namespace CF36
{
    partial class SuaSanPham
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
            tlpAll = new TableLayoutPanel();
            picLogo = new PictureBox();
            tlpThongtin = new TableLayoutPanel();
            lbMa = new Label();
            lbTen = new Label();
            txtMa = new TextBox();
            txtTen = new TextBox();
            lbLoai = new Label();
            cbbLoaiSanPham = new ComboBox();
            tlpSize = new TableLayoutPanel();
            lbSuaSize = new Label();
            lbSuaAnh = new Label();
            grSuaSizeVaGia = new GroupBox();
            txtSuaGiaL = new TextBox();
            txtSuaGiaM = new TextBox();
            txtSuaGiaS = new TextBox();
            cbL = new CheckBox();
            cbM = new CheckBox();
            cbS = new CheckBox();
            tlpSuaMoTa = new TableLayoutPanel();
            picAnhSua = new PictureBox();
            btnSuaAnh = new Button();
            tlpEnd = new TableLayoutPanel();
            btnThoat = new Button();
            btnLuu = new Button();
            tlpAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpThongtin.SuspendLayout();
            tlpSize.SuspendLayout();
            grSuaSizeVaGia.SuspendLayout();
            tlpSuaMoTa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAnhSua).BeginInit();
            tlpEnd.SuspendLayout();
            SuspendLayout();
            // 
            // tlpAll
            // 
            tlpAll.ColumnCount = 1;
            tlpAll.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpAll.Controls.Add(picLogo, 0, 0);
            tlpAll.Controls.Add(tlpThongtin, 0, 1);
            tlpAll.Controls.Add(tlpSize, 0, 2);
            tlpAll.Controls.Add(tlpEnd, 0, 3);
            tlpAll.Dock = DockStyle.Fill;
            tlpAll.Location = new Point(0, 0);
            tlpAll.Name = "tlpAll";
            tlpAll.RowCount = 4;
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Percent, 16.9230766F));
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Percent, 11.2820511F));
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Percent, 47.6923065F));
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Percent, 24.3589745F));
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpAll.Size = new Size(1051, 780);
            tlpAll.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(1045, 125);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpThongtin
            // 
            tlpThongtin.ColumnCount = 4;
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6109257F));
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.9587517F));
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.5128212F));
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.14047F));
            tlpThongtin.Controls.Add(lbMa, 0, 0);
            tlpThongtin.Controls.Add(lbTen, 0, 1);
            tlpThongtin.Controls.Add(txtMa, 1, 0);
            tlpThongtin.Controls.Add(txtTen, 1, 1);
            tlpThongtin.Controls.Add(lbLoai, 2, 0);
            tlpThongtin.Controls.Add(cbbLoaiSanPham, 3, 0);
            tlpThongtin.Dock = DockStyle.Fill;
            tlpThongtin.Location = new Point(3, 134);
            tlpThongtin.Name = "tlpThongtin";
            tlpThongtin.RowCount = 2;
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 47.5609741F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 52.4390259F));
            tlpThongtin.Size = new Size(1045, 81);
            tlpThongtin.TabIndex = 1;
            // 
            // lbMa
            // 
            lbMa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbMa.AutoSize = true;
            lbMa.Location = new Point(72, 0);
            lbMa.Name = "lbMa";
            lbMa.Size = new Size(98, 20);
            lbMa.TabIndex = 1;
            lbMa.Text = "Mã sản phẩm";
            // 
            // lbTen
            // 
            lbTen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTen.AutoSize = true;
            lbTen.Location = new Point(70, 38);
            lbTen.Name = "lbTen";
            lbTen.Size = new Size(100, 20);
            lbTen.TabIndex = 2;
            lbTen.Text = "Tên sản phẩm";
            // 
            // txtMa
            // 
            txtMa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMa.Location = new Point(176, 3);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(212, 27);
            txtMa.TabIndex = 3;
            // 
            // txtTen
            // 
            txtTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTen.Location = new Point(176, 41);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(212, 27);
            txtTen.TabIndex = 3;
            // 
            // lbLoai
            // 
            lbLoai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbLoai.AutoSize = true;
            lbLoai.Location = new Point(496, 0);
            lbLoai.Name = "lbLoai";
            lbLoai.Size = new Size(105, 20);
            lbLoai.TabIndex = 4;
            lbLoai.Text = "Loại sản phẩm";
            // 
            // cbbLoaiSanPham
            // 
            cbbLoaiSanPham.FormattingEnabled = true;
            cbbLoaiSanPham.Location = new Point(607, 3);
            cbbLoaiSanPham.Name = "cbbLoaiSanPham";
            cbbLoaiSanPham.Size = new Size(261, 28);
            cbbLoaiSanPham.TabIndex = 5;
            // 
            // tlpSize
            // 
            tlpSize.ColumnCount = 2;
            tlpSize.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSize.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSize.Controls.Add(lbSuaSize, 0, 0);
            tlpSize.Controls.Add(lbSuaAnh, 0, 1);
            tlpSize.Controls.Add(grSuaSizeVaGia, 1, 0);
            tlpSize.Controls.Add(tlpSuaMoTa, 1, 1);
            tlpSize.Dock = DockStyle.Fill;
            tlpSize.Location = new Point(3, 221);
            tlpSize.Name = "tlpSize";
            tlpSize.RowCount = 2;
            tlpSize.RowStyles.Add(new RowStyle(SizeType.Percent, 39.17808F));
            tlpSize.RowStyles.Add(new RowStyle(SizeType.Percent, 60.82192F));
            tlpSize.Size = new Size(1045, 365);
            tlpSize.TabIndex = 2;
            // 
            // lbSuaSize
            // 
            lbSuaSize.Anchor = AnchorStyles.Right;
            lbSuaSize.AutoSize = true;
            lbSuaSize.Location = new Point(305, 61);
            lbSuaSize.Name = "lbSuaSize";
            lbSuaSize.Size = new Size(214, 20);
            lbSuaSize.TabIndex = 0;
            lbSuaSize.Text = "Thông tin về kích cỡ và giá tiền";
            // 
            // lbSuaAnh
            // 
            lbSuaAnh.Anchor = AnchorStyles.Right;
            lbSuaAnh.AutoSize = true;
            lbSuaAnh.Location = new Point(377, 244);
            lbSuaAnh.Name = "lbSuaAnh";
            lbSuaAnh.Size = new Size(142, 20);
            lbSuaAnh.TabIndex = 1;
            lbSuaAnh.Text = "Mô tả ảnh minh họa";
            // 
            // grSuaSizeVaGia
            // 
            grSuaSizeVaGia.Controls.Add(txtSuaGiaL);
            grSuaSizeVaGia.Controls.Add(txtSuaGiaM);
            grSuaSizeVaGia.Controls.Add(txtSuaGiaS);
            grSuaSizeVaGia.Controls.Add(cbL);
            grSuaSizeVaGia.Controls.Add(cbM);
            grSuaSizeVaGia.Controls.Add(cbS);
            grSuaSizeVaGia.Location = new Point(525, 3);
            grSuaSizeVaGia.Name = "grSuaSizeVaGia";
            grSuaSizeVaGia.Size = new Size(255, 137);
            grSuaSizeVaGia.TabIndex = 2;
            grSuaSizeVaGia.TabStop = false;
            grSuaSizeVaGia.Text = "Size và giá từng size";
            // 
            // txtSuaGiaL
            // 
            txtSuaGiaL.Location = new Point(78, 103);
            txtSuaGiaL.Name = "txtSuaGiaL";
            txtSuaGiaL.Size = new Size(125, 27);
            txtSuaGiaL.TabIndex = 1;
            // 
            // txtSuaGiaM
            // 
            txtSuaGiaM.Location = new Point(78, 63);
            txtSuaGiaM.Name = "txtSuaGiaM";
            txtSuaGiaM.Size = new Size(125, 27);
            txtSuaGiaM.TabIndex = 1;
            // 
            // txtSuaGiaS
            // 
            txtSuaGiaS.Location = new Point(78, 21);
            txtSuaGiaS.Name = "txtSuaGiaS";
            txtSuaGiaS.Size = new Size(125, 27);
            txtSuaGiaS.TabIndex = 1;
            // 
            // cbL
            // 
            cbL.AutoSize = true;
            cbL.Location = new Point(16, 106);
            cbL.Name = "cbL";
            cbL.Size = new Size(38, 24);
            cbL.TabIndex = 0;
            cbL.Text = "L";
            cbL.UseVisualStyleBackColor = true;
            // 
            // cbM
            // 
            cbM.AutoSize = true;
            cbM.Location = new Point(16, 66);
            cbM.Name = "cbM";
            cbM.Size = new Size(44, 24);
            cbM.TabIndex = 0;
            cbM.Text = "M";
            cbM.UseVisualStyleBackColor = true;
            // 
            // cbS
            // 
            cbS.AutoSize = true;
            cbS.Location = new Point(16, 24);
            cbS.Name = "cbS";
            cbS.Size = new Size(39, 24);
            cbS.TabIndex = 0;
            cbS.Text = "S";
            cbS.UseVisualStyleBackColor = true;
            // 
            // tlpSuaMoTa
            // 
            tlpSuaMoTa.ColumnCount = 2;
            tlpSuaMoTa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSuaMoTa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSuaMoTa.Controls.Add(btnSuaAnh, 1, 0);
            tlpSuaMoTa.Controls.Add(picAnhSua, 0, 0);
            tlpSuaMoTa.Dock = DockStyle.Fill;
            tlpSuaMoTa.Location = new Point(525, 146);
            tlpSuaMoTa.Name = "tlpSuaMoTa";
            tlpSuaMoTa.RowCount = 1;
            tlpSuaMoTa.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSuaMoTa.Size = new Size(517, 216);
            tlpSuaMoTa.TabIndex = 3;
            // 
            // picAnhSua
            // 
            picAnhSua.Anchor = AnchorStyles.Left;
            picAnhSua.Location = new Point(3, 3);
            picAnhSua.Name = "picAnhSua";
            picAnhSua.Size = new Size(252, 210);
            picAnhSua.SizeMode = PictureBoxSizeMode.Zoom;
            picAnhSua.TabIndex = 0;
            picAnhSua.TabStop = false;
            // 
            // btnSuaAnh
            // 
            btnSuaAnh.Anchor = AnchorStyles.Left;
            btnSuaAnh.Location = new Point(261, 71);
            btnSuaAnh.Name = "btnSuaAnh";
            btnSuaAnh.Size = new Size(142, 73);
            btnSuaAnh.TabIndex = 1;
            btnSuaAnh.Text = "Chọn ảnh khác";
            btnSuaAnh.UseVisualStyleBackColor = true;
            // 
            // tlpEnd
            // 
            tlpEnd.ColumnCount = 2;
            tlpEnd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.92823F));
            tlpEnd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.07177F));
            tlpEnd.Controls.Add(btnThoat, 1, 0);
            tlpEnd.Controls.Add(btnLuu, 0, 0);
            tlpEnd.Dock = DockStyle.Fill;
            tlpEnd.Location = new Point(3, 592);
            tlpEnd.Name = "tlpEnd";
            tlpEnd.RowCount = 1;
            tlpEnd.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpEnd.Size = new Size(1045, 185);
            tlpEnd.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(786, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 52);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.Location = new Point(686, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 52);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "LƯU";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // SuaSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 780);
            Controls.Add(tlpAll);
            Name = "SuaSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa thông tin sản phẩm";
            tlpAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpThongtin.ResumeLayout(false);
            tlpThongtin.PerformLayout();
            tlpSize.ResumeLayout(false);
            tlpSize.PerformLayout();
            grSuaSizeVaGia.ResumeLayout(false);
            grSuaSizeVaGia.PerformLayout();
            tlpSuaMoTa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAnhSua).EndInit();
            tlpEnd.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpAll;
        private PictureBox picLogo;
        private TableLayoutPanel tlpThongtin;
        private Label lbMa;
        private Label lbTen;
        private TextBox txtMa;
        private TextBox txtTen;
        private Label lbLoai;
        private ComboBox cbbLoaiSanPham;
        private TableLayoutPanel tlpSize;
        private Label lbSuaSize;
        private Label lbSuaAnh;
        private GroupBox grSuaSizeVaGia;
        private TextBox txtSuaGiaL;
        private TextBox txtSuaGiaM;
        private TextBox txtSuaGiaS;
        private CheckBox cbL;
        private CheckBox cbM;
        private CheckBox cbS;
        private TableLayoutPanel tlpSuaMoTa;
        private PictureBox picAnhSua;
        private Button btnSuaAnh;
        private TableLayoutPanel tlpEnd;
        private Button btnThoat;
        private Button btnLuu;
    }
}