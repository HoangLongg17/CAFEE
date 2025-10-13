namespace CF36
{
    partial class SuaMaGiamGiaMua1Tang1
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
            tlpTren = new TableLayoutPanel();
            lbMaGiamGia = new Label();
            lbTenMaGiamGia = new Label();
            lbLoaiMaGiamGia = new Label();
            lbTimKiem = new Label();
            txtMaGiamGia = new TextBox();
            txtTenMaGiamGia = new TextBox();
            txtTimKiem = new TextBox();
            cbbLoaiMaGiamGia = new ComboBox();
            tlpDuoi = new TableLayoutPanel();
            dgvSanPhamTang = new DataGridView();
            tlpDate = new TableLayoutPanel();
            lbBatDau = new Label();
            lbKetThuc = new Label();
            dtpNgayBatDau = new DateTimePicker();
            dtpNgayHetHan = new DateTimePicker();
            tlpThaoTac = new TableLayoutPanel();
            lbHoaDonToiThieu = new Label();
            lbSanPhamMua = new Label();
            txtHoaDonToiThieu = new TextBox();
            cbbSanPhamMua = new ComboBox();
            tlpButton = new TableLayoutPanel();
            btnThoat = new Button();
            btnLamMoi = new Button();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpTren.SuspendLayout();
            tlpDuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamTang).BeginInit();
            tlpDate.SuspendLayout();
            tlpThaoTac.SuspendLayout();
            tlpButton.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpTren, 0, 1);
            tlpall.Controls.Add(tlpDuoi, 0, 2);
            tlpall.Controls.Add(tlpButton, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Margin = new Padding(3, 2, 3, 2);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.4658642F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 18.8172035F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 50.17921F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 14.5161295F));
            tlpall.Size = new Size(802, 308);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 2);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(796, 46);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpTren
            // 
            tlpTren.ColumnCount = 4;
            tlpTren.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTren.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTren.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.5510426F));
            tlpTren.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.6136112F));
            tlpTren.Controls.Add(lbMaGiamGia, 0, 0);
            tlpTren.Controls.Add(lbTenMaGiamGia, 0, 1);
            tlpTren.Controls.Add(lbLoaiMaGiamGia, 2, 0);
            tlpTren.Controls.Add(lbTimKiem, 2, 1);
            tlpTren.Controls.Add(txtMaGiamGia, 1, 0);
            tlpTren.Controls.Add(txtTenMaGiamGia, 1, 1);
            tlpTren.Controls.Add(txtTimKiem, 3, 1);
            tlpTren.Controls.Add(cbbLoaiMaGiamGia, 3, 0);
            tlpTren.Dock = DockStyle.Fill;
            tlpTren.Location = new Point(3, 52);
            tlpTren.Margin = new Padding(3, 2, 3, 2);
            tlpTren.Name = "tlpTren";
            tlpTren.RowCount = 2;
            tlpTren.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTren.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTren.Size = new Size(796, 53);
            tlpTren.TabIndex = 1;
            // 
            // lbMaGiamGia
            // 
            lbMaGiamGia.Anchor = AnchorStyles.Right;
            lbMaGiamGia.AutoSize = true;
            lbMaGiamGia.Location = new Point(122, 5);
            lbMaGiamGia.Name = "lbMaGiamGia";
            lbMaGiamGia.Size = new Size(73, 15);
            lbMaGiamGia.TabIndex = 0;
            lbMaGiamGia.Text = "Mã giảm giá";
            // 
            // lbTenMaGiamGia
            // 
            lbTenMaGiamGia.Anchor = AnchorStyles.Right;
            lbTenMaGiamGia.AutoSize = true;
            lbTenMaGiamGia.Location = new Point(101, 32);
            lbTenMaGiamGia.Name = "lbTenMaGiamGia";
            lbTenMaGiamGia.Size = new Size(94, 15);
            lbTenMaGiamGia.TabIndex = 0;
            lbTenMaGiamGia.Text = "Tên mã giảm giá";
            // 
            // lbLoaiMaGiamGia
            // 
            lbLoaiMaGiamGia.Anchor = AnchorStyles.Right;
            lbLoaiMaGiamGia.AutoSize = true;
            lbLoaiMaGiamGia.Location = new Point(413, 5);
            lbLoaiMaGiamGia.Name = "lbLoaiMaGiamGia";
            lbLoaiMaGiamGia.Size = new Size(127, 15);
            lbLoaiMaGiamGia.TabIndex = 0;
            lbLoaiMaGiamGia.Text = "Chọn loại mã giảm giá";
            // 
            // lbTimKiem
            // 
            lbTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(484, 26);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.Size = new Size(56, 15);
            lbTimKiem.TabIndex = 0;
            lbTimKiem.Text = "Tìm kiếm";
            // 
            // txtMaGiamGia
            // 
            txtMaGiamGia.Location = new Point(201, 2);
            txtMaGiamGia.Margin = new Padding(3, 2, 3, 2);
            txtMaGiamGia.Name = "txtMaGiamGia";
            txtMaGiamGia.Size = new Size(192, 23);
            txtMaGiamGia.TabIndex = 1;
            // 
            // txtTenMaGiamGia
            // 
            txtTenMaGiamGia.Location = new Point(201, 28);
            txtTenMaGiamGia.Margin = new Padding(3, 2, 3, 2);
            txtTenMaGiamGia.Name = "txtTenMaGiamGia";
            txtTenMaGiamGia.Size = new Size(192, 23);
            txtTenMaGiamGia.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(546, 28);
            txtTimKiem.Margin = new Padding(3, 2, 3, 2);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(207, 23);
            txtTimKiem.TabIndex = 1;
            // 
            // cbbLoaiMaGiamGia
            // 
            cbbLoaiMaGiamGia.FormattingEnabled = true;
            cbbLoaiMaGiamGia.Location = new Point(546, 2);
            cbbLoaiMaGiamGia.Margin = new Padding(3, 2, 3, 2);
            cbbLoaiMaGiamGia.Name = "cbbLoaiMaGiamGia";
            cbbLoaiMaGiamGia.Size = new Size(207, 23);
            cbbLoaiMaGiamGia.TabIndex = 2;
            // 
            // tlpDuoi
            // 
            tlpDuoi.ColumnCount = 3;
            tlpDuoi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpDuoi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpDuoi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpDuoi.Controls.Add(dgvSanPhamTang, 1, 0);
            tlpDuoi.Controls.Add(tlpDate, 2, 0);
            tlpDuoi.Controls.Add(tlpThaoTac, 0, 0);
            tlpDuoi.Dock = DockStyle.Fill;
            tlpDuoi.Location = new Point(3, 109);
            tlpDuoi.Margin = new Padding(3, 2, 3, 2);
            tlpDuoi.Name = "tlpDuoi";
            tlpDuoi.RowCount = 1;
            tlpDuoi.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpDuoi.Size = new Size(796, 150);
            tlpDuoi.TabIndex = 2;
            // 
            // dgvSanPhamTang
            // 
            dgvSanPhamTang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPhamTang.Dock = DockStyle.Fill;
            dgvSanPhamTang.Location = new Point(268, 2);
            dgvSanPhamTang.Margin = new Padding(3, 2, 3, 2);
            dgvSanPhamTang.Name = "dgvSanPhamTang";
            dgvSanPhamTang.RowHeadersWidth = 51;
            dgvSanPhamTang.Size = new Size(259, 146);
            dgvSanPhamTang.TabIndex = 0;
            // 
            // tlpDate
            // 
            tlpDate.ColumnCount = 2;
            tlpDate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.080267F));
            tlpDate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.91973F));
            tlpDate.Controls.Add(lbBatDau, 0, 0);
            tlpDate.Controls.Add(lbKetThuc, 0, 1);
            tlpDate.Controls.Add(dtpNgayBatDau, 1, 0);
            tlpDate.Controls.Add(dtpNgayHetHan, 1, 1);
            tlpDate.Dock = DockStyle.Fill;
            tlpDate.Location = new Point(533, 2);
            tlpDate.Margin = new Padding(3, 2, 3, 2);
            tlpDate.Name = "tlpDate";
            tlpDate.RowCount = 2;
            tlpDate.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpDate.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpDate.Size = new Size(260, 146);
            tlpDate.TabIndex = 1;
            // 
            // lbBatDau
            // 
            lbBatDau.Anchor = AnchorStyles.Right;
            lbBatDau.AutoSize = true;
            lbBatDau.Location = new Point(12, 29);
            lbBatDau.Name = "lbBatDau";
            lbBatDau.Size = new Size(47, 15);
            lbBatDau.TabIndex = 0;
            lbBatDau.Text = "Bắt đầu";
            // 
            // lbKetThuc
            // 
            lbKetThuc.Anchor = AnchorStyles.Right;
            lbKetThuc.AutoSize = true;
            lbKetThuc.Location = new Point(10, 102);
            lbKetThuc.Name = "lbKetThuc";
            lbKetThuc.Size = new Size(49, 15);
            lbKetThuc.TabIndex = 0;
            lbKetThuc.Text = "Hết hạn";
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.Anchor = AnchorStyles.Left;
            dtpNgayBatDau.Location = new Point(65, 25);
            dtpNgayBatDau.Margin = new Padding(3, 2, 3, 2);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(192, 23);
            dtpNgayBatDau.TabIndex = 1;
            // 
            // dtpNgayHetHan
            // 
            dtpNgayHetHan.Anchor = AnchorStyles.Left;
            dtpNgayHetHan.Location = new Point(65, 98);
            dtpNgayHetHan.Margin = new Padding(3, 2, 3, 2);
            dtpNgayHetHan.Name = "dtpNgayHetHan";
            dtpNgayHetHan.Size = new Size(191, 23);
            dtpNgayHetHan.TabIndex = 1;
            // 
            // tlpThaoTac
            // 
            tlpThaoTac.ColumnCount = 2;
            tlpThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.3131313F));
            tlpThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.68687F));
            tlpThaoTac.Controls.Add(lbHoaDonToiThieu, 0, 0);
            tlpThaoTac.Controls.Add(lbSanPhamMua, 0, 1);
            tlpThaoTac.Controls.Add(txtHoaDonToiThieu, 1, 0);
            tlpThaoTac.Controls.Add(cbbSanPhamMua, 1, 1);
            tlpThaoTac.Dock = DockStyle.Fill;
            tlpThaoTac.Location = new Point(3, 2);
            tlpThaoTac.Margin = new Padding(3, 2, 3, 2);
            tlpThaoTac.Name = "tlpThaoTac";
            tlpThaoTac.RowCount = 2;
            tlpThaoTac.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThaoTac.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThaoTac.Size = new Size(259, 146);
            tlpThaoTac.TabIndex = 2;
            // 
            // lbHoaDonToiThieu
            // 
            lbHoaDonToiThieu.Anchor = AnchorStyles.Right;
            lbHoaDonToiThieu.AutoSize = true;
            lbHoaDonToiThieu.Location = new Point(5, 21);
            lbHoaDonToiThieu.Name = "lbHoaDonToiThieu";
            lbHoaDonToiThieu.Size = new Size(73, 30);
            lbHoaDonToiThieu.TabIndex = 0;
            lbHoaDonToiThieu.Text = "Hóa đơn tối thiểu";
            // 
            // lbSanPhamMua
            // 
            lbSanPhamMua.Anchor = AnchorStyles.Right;
            lbSanPhamMua.AutoSize = true;
            lbSanPhamMua.Location = new Point(15, 94);
            lbSanPhamMua.Name = "lbSanPhamMua";
            lbSanPhamMua.Size = new Size(63, 30);
            lbSanPhamMua.TabIndex = 0;
            lbSanPhamMua.Text = "Sản phẩm mua";
            // 
            // txtHoaDonToiThieu
            // 
            txtHoaDonToiThieu.Anchor = AnchorStyles.Left;
            txtHoaDonToiThieu.Location = new Point(84, 25);
            txtHoaDonToiThieu.Margin = new Padding(3, 2, 3, 2);
            txtHoaDonToiThieu.Name = "txtHoaDonToiThieu";
            txtHoaDonToiThieu.Size = new Size(172, 23);
            txtHoaDonToiThieu.TabIndex = 1;
            // 
            // cbbSanPhamMua
            // 
            cbbSanPhamMua.Anchor = AnchorStyles.Left;
            cbbSanPhamMua.FormattingEnabled = true;
            cbbSanPhamMua.Location = new Point(84, 98);
            cbbSanPhamMua.Margin = new Padding(3, 2, 3, 2);
            cbbSanPhamMua.Name = "cbbSanPhamMua";
            cbbSanPhamMua.Size = new Size(172, 23);
            cbbSanPhamMua.TabIndex = 2;
            // 
            // tlpButton
            // 
            tlpButton.ColumnCount = 2;
            tlpButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.75302F));
            tlpButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.24698F));
            tlpButton.Controls.Add(btnThoat, 1, 0);
            tlpButton.Controls.Add(btnLamMoi, 0, 0);
            tlpButton.Dock = DockStyle.Fill;
            tlpButton.Location = new Point(3, 263);
            tlpButton.Margin = new Padding(3, 2, 3, 2);
            tlpButton.Name = "tlpButton";
            tlpButton.RowCount = 1;
            tlpButton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButton.Size = new Size(796, 43);
            tlpButton.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(598, 2);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(96, 37);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(487, 2);
            btnLamMoi.Margin = new Padding(3, 2, 3, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(105, 37);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // SuaMaGiamGiaMua1Tang1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 308);
            Controls.Add(tlpall);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SuaMaGiamGiaMua1Tang1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa mã giảm giá mua 1 tặng 1";
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpTren.ResumeLayout(false);
            tlpTren.PerformLayout();
            tlpDuoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamTang).EndInit();
            tlpDate.ResumeLayout(false);
            tlpDate.PerformLayout();
            tlpThaoTac.ResumeLayout(false);
            tlpThaoTac.PerformLayout();
            tlpButton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpTren;
        private TableLayoutPanel tlpDuoi;
        private TableLayoutPanel tlpButton;
        private Label lbMaGiamGia;
        private Label lbTenMaGiamGia;
        private Label lbLoaiMaGiamGia;
        private Label lbTimKiem;
        private DataGridView dgvSanPhamTang;
        private TableLayoutPanel tlpDate;
        private TableLayoutPanel tlpThaoTac;
        private Label lbBatDau;
        private Label lbKetThuc;
        private Label lbHoaDonToiThieu;
        private Label lbSanPhamMua;
        private TextBox txtMaGiamGia;
        private TextBox txtTenMaGiamGia;
        private TextBox txtTimKiem;
        private ComboBox cbbLoaiMaGiamGia;
        private DateTimePicker dtpNgayBatDau;
        private DateTimePicker dtpNgayHetHan;
        private TextBox txtHoaDonToiThieu;
        private ComboBox cbbSanPhamMua;
        private Button btnThoat;
        private Button btnLamMoi;
    }
}