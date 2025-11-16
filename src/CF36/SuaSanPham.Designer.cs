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
            btnSuaAnh = new Button();
            picAnhSua = new PictureBox();
            tlpEnd = new TableLayoutPanel();
            btnThoat = new Button();
            btnLuu = new Button();
            label1 = new Label();
            txtSoLuongCanhBao = new TextBox();
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
            tlpAll.Margin = new Padding(3, 2, 3, 2);
            tlpAll.Name = "tlpAll";
            tlpAll.RowCount = 4;
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Percent, 16.9230766F));
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Percent, 11.2820511F));
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Percent, 47.6923065F));
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Percent, 24.3589745F));
            tlpAll.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tlpAll.Size = new Size(920, 585);
            tlpAll.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 2);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(914, 94);
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
            tlpThongtin.Controls.Add(txtSoLuongCanhBao, 3, 1);
            tlpThongtin.Controls.Add(label1, 2, 1);
            tlpThongtin.Controls.Add(lbMa, 0, 0);
            tlpThongtin.Controls.Add(lbTen, 0, 1);
            tlpThongtin.Controls.Add(txtMa, 1, 0);
            tlpThongtin.Controls.Add(txtTen, 1, 1);
            tlpThongtin.Controls.Add(lbLoai, 2, 0);
            tlpThongtin.Controls.Add(cbbLoaiSanPham, 3, 0);
            tlpThongtin.Dock = DockStyle.Fill;
            tlpThongtin.Location = new Point(3, 100);
            tlpThongtin.Margin = new Padding(3, 2, 3, 2);
            tlpThongtin.Name = "tlpThongtin";
            tlpThongtin.RowCount = 2;
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 47.5609741F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 52.4390259F));
            tlpThongtin.Size = new Size(914, 61);
            tlpThongtin.TabIndex = 1;
            // 
            // lbMa
            // 
            lbMa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbMa.AutoSize = true;
            lbMa.Location = new Point(69, 0);
            lbMa.Name = "lbMa";
            lbMa.Size = new Size(79, 15);
            lbMa.TabIndex = 1;
            lbMa.Text = "Mã sản phẩm";
            // 
            // lbTen
            // 
            lbTen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTen.AutoSize = true;
            lbTen.Location = new Point(68, 29);
            lbTen.Name = "lbTen";
            lbTen.Size = new Size(80, 15);
            lbTen.TabIndex = 2;
            lbTen.Text = "Tên sản phẩm";
            // 
            // txtMa
            // 
            txtMa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMa.Location = new Point(154, 2);
            txtMa.Margin = new Padding(3, 2, 3, 2);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(185, 23);
            txtMa.TabIndex = 3;
            // 
            // txtTen
            // 
            txtTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTen.Location = new Point(154, 31);
            txtTen.Margin = new Padding(3, 2, 3, 2);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(185, 23);
            txtTen.TabIndex = 3;
            // 
            // lbLoai
            // 
            lbLoai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbLoai.AutoSize = true;
            lbLoai.Location = new Point(442, 0);
            lbLoai.Name = "lbLoai";
            lbLoai.Size = new Size(84, 15);
            lbLoai.TabIndex = 4;
            lbLoai.Text = "Loại sản phẩm";
            // 
            // cbbLoaiSanPham
            // 
            cbbLoaiSanPham.FormattingEnabled = true;
            cbbLoaiSanPham.Location = new Point(532, 2);
            cbbLoaiSanPham.Margin = new Padding(3, 2, 3, 2);
            cbbLoaiSanPham.Name = "cbbLoaiSanPham";
            cbbLoaiSanPham.Size = new Size(229, 23);
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
            tlpSize.Location = new Point(3, 165);
            tlpSize.Margin = new Padding(3, 2, 3, 2);
            tlpSize.Name = "tlpSize";
            tlpSize.RowCount = 2;
            tlpSize.RowStyles.Add(new RowStyle(SizeType.Percent, 39.17808F));
            tlpSize.RowStyles.Add(new RowStyle(SizeType.Percent, 60.82192F));
            tlpSize.Size = new Size(914, 274);
            tlpSize.TabIndex = 2;
            // 
            // lbSuaSize
            // 
            lbSuaSize.Anchor = AnchorStyles.Right;
            lbSuaSize.AutoSize = true;
            lbSuaSize.Location = new Point(283, 46);
            lbSuaSize.Name = "lbSuaSize";
            lbSuaSize.Size = new Size(171, 15);
            lbSuaSize.TabIndex = 0;
            lbSuaSize.Text = "Thông tin về kích cỡ và giá tiền";
            // 
            // lbSuaAnh
            // 
            lbSuaAnh.Anchor = AnchorStyles.Right;
            lbSuaAnh.AutoSize = true;
            lbSuaAnh.Location = new Point(339, 183);
            lbSuaAnh.Name = "lbSuaAnh";
            lbSuaAnh.Size = new Size(115, 15);
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
            grSuaSizeVaGia.Location = new Point(460, 2);
            grSuaSizeVaGia.Margin = new Padding(3, 2, 3, 2);
            grSuaSizeVaGia.Name = "grSuaSizeVaGia";
            grSuaSizeVaGia.Padding = new Padding(3, 2, 3, 2);
            grSuaSizeVaGia.Size = new Size(223, 103);
            grSuaSizeVaGia.TabIndex = 2;
            grSuaSizeVaGia.TabStop = false;
            grSuaSizeVaGia.Text = "Size và giá từng size";
            // 
            // txtSuaGiaL
            // 
            txtSuaGiaL.Location = new Point(68, 77);
            txtSuaGiaL.Margin = new Padding(3, 2, 3, 2);
            txtSuaGiaL.Name = "txtSuaGiaL";
            txtSuaGiaL.Size = new Size(110, 23);
            txtSuaGiaL.TabIndex = 1;
            // 
            // txtSuaGiaM
            // 
            txtSuaGiaM.Location = new Point(68, 47);
            txtSuaGiaM.Margin = new Padding(3, 2, 3, 2);
            txtSuaGiaM.Name = "txtSuaGiaM";
            txtSuaGiaM.Size = new Size(110, 23);
            txtSuaGiaM.TabIndex = 1;
            // 
            // txtSuaGiaS
            // 
            txtSuaGiaS.Location = new Point(68, 16);
            txtSuaGiaS.Margin = new Padding(3, 2, 3, 2);
            txtSuaGiaS.Name = "txtSuaGiaS";
            txtSuaGiaS.Size = new Size(110, 23);
            txtSuaGiaS.TabIndex = 1;
            // 
            // cbL
            // 
            cbL.AutoSize = true;
            cbL.Location = new Point(14, 80);
            cbL.Margin = new Padding(3, 2, 3, 2);
            cbL.Name = "cbL";
            cbL.Size = new Size(32, 19);
            cbL.TabIndex = 0;
            cbL.Text = "L";
            cbL.UseVisualStyleBackColor = true;
            cbL.CheckedChanged += cbL_CheckedChanged;
            // 
            // cbM
            // 
            cbM.AutoSize = true;
            cbM.Location = new Point(14, 50);
            cbM.Margin = new Padding(3, 2, 3, 2);
            cbM.Name = "cbM";
            cbM.Size = new Size(37, 19);
            cbM.TabIndex = 0;
            cbM.Text = "M";
            cbM.UseVisualStyleBackColor = true;
            cbM.CheckedChanged += cbM_CheckedChanged;
            // 
            // cbS
            // 
            cbS.AutoSize = true;
            cbS.Location = new Point(14, 18);
            cbS.Margin = new Padding(3, 2, 3, 2);
            cbS.Name = "cbS";
            cbS.Size = new Size(32, 19);
            cbS.TabIndex = 0;
            cbS.Text = "S";
            cbS.UseVisualStyleBackColor = true;
            cbS.CheckedChanged += cbS_CheckedChanged;
            // 
            // tlpSuaMoTa
            // 
            tlpSuaMoTa.ColumnCount = 2;
            tlpSuaMoTa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSuaMoTa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSuaMoTa.Controls.Add(btnSuaAnh, 1, 0);
            tlpSuaMoTa.Controls.Add(picAnhSua, 0, 0);
            tlpSuaMoTa.Dock = DockStyle.Fill;
            tlpSuaMoTa.Location = new Point(460, 109);
            tlpSuaMoTa.Margin = new Padding(3, 2, 3, 2);
            tlpSuaMoTa.Name = "tlpSuaMoTa";
            tlpSuaMoTa.RowCount = 1;
            tlpSuaMoTa.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSuaMoTa.Size = new Size(451, 163);
            tlpSuaMoTa.TabIndex = 3;
            // 
            // btnSuaAnh
            // 
            btnSuaAnh.Anchor = AnchorStyles.Left;
            btnSuaAnh.Location = new Point(228, 54);
            btnSuaAnh.Margin = new Padding(3, 2, 3, 2);
            btnSuaAnh.Name = "btnSuaAnh";
            btnSuaAnh.Size = new Size(124, 55);
            btnSuaAnh.TabIndex = 1;
            btnSuaAnh.Text = "Chọn ảnh khác";
            btnSuaAnh.UseVisualStyleBackColor = true;
            btnSuaAnh.Click += btnSuaAnh_Click;
            // 
            // picAnhSua
            // 
            picAnhSua.Anchor = AnchorStyles.Left;
            picAnhSua.Location = new Point(3, 2);
            picAnhSua.Margin = new Padding(3, 2, 3, 2);
            picAnhSua.Name = "picAnhSua";
            picAnhSua.Size = new Size(219, 158);
            picAnhSua.SizeMode = PictureBoxSizeMode.Zoom;
            picAnhSua.TabIndex = 0;
            picAnhSua.TabStop = false;
            // 
            // tlpEnd
            // 
            tlpEnd.ColumnCount = 2;
            tlpEnd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.92823F));
            tlpEnd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.07177F));
            tlpEnd.Controls.Add(btnThoat, 1, 0);
            tlpEnd.Controls.Add(btnLuu, 0, 0);
            tlpEnd.Dock = DockStyle.Fill;
            tlpEnd.Location = new Point(3, 443);
            tlpEnd.Margin = new Padding(3, 2, 3, 2);
            tlpEnd.Name = "tlpEnd";
            tlpEnd.RowCount = 1;
            tlpEnd.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpEnd.Size = new Size(914, 140);
            tlpEnd.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(687, 2);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(101, 53);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.Location = new Point(588, 2);
            btnLuu.Margin = new Padding(3, 2, 3, 2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(93, 53);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "LƯU";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(420, 29);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 7;
            label1.Text = "Số lượng cảnh báo";
            // 
            // txtSoLuongCanhBao
            // 
            txtSoLuongCanhBao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSoLuongCanhBao.Location = new Point(532, 31);
            txtSoLuongCanhBao.Margin = new Padding(3, 2, 3, 2);
            txtSoLuongCanhBao.Name = "txtSoLuongCanhBao";
            txtSoLuongCanhBao.Size = new Size(379, 23);
            txtSoLuongCanhBao.TabIndex = 8;
            // 
            // SuaSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 585);
            Controls.Add(tlpAll);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SuaSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa thông tin sản phẩm";
            Load += SuaSanPham_Load;
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
        private Label label1;
        private TextBox txtSoLuongCanhBao;
    }
}