namespace CF36
{
    partial class BANHANG
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
            tlpThan = new TableLayoutPanel();
            pnSanPham = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lbTongTien = new Label();
            txtTongTien = new TextBox();
            btnThemMaGiamGia = new Button();
            fLPSanPhamDaChon = new FlowLayoutPanel();
            tlpThanhToan = new TableLayoutPanel();
            btnThanhToan = new Button();
            btnThemGioHang = new Button();
            lbThemKhachHang = new Label();
            pnKhachHang = new Panel();
            btnThemKhachHangMoi = new Button();
            txtTimKhachHang = new TextBox();
            pnDanhSach = new Panel();
            fLPSanPham = new FlowLayoutPanel();
            tlpBoLoc = new TableLayoutPanel();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            cbbLoaiSanPham = new ComboBox();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpThan.SuspendLayout();
            pnSanPham.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tlpThanhToan.SuspendLayout();
            pnKhachHang.SuspendLayout();
            pnDanhSach.SuspendLayout();
            tlpBoLoc.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpThan, 0, 1);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 2;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 12.2082586F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 87.79174F));
            tlpall.Size = new Size(1132, 557);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(1126, 62);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpThan
            // 
            tlpThan.ColumnCount = 2;
            tlpThan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.18828F));
            tlpThan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.81172F));
            tlpThan.Controls.Add(pnSanPham, 0, 0);
            tlpThan.Controls.Add(pnDanhSach, 1, 0);
            tlpThan.Dock = DockStyle.Fill;
            tlpThan.Location = new Point(3, 71);
            tlpThan.Name = "tlpThan";
            tlpThan.RowCount = 1;
            tlpThan.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpThan.Size = new Size(1126, 483);
            tlpThan.TabIndex = 1;
            // 
            // pnSanPham
            // 
            pnSanPham.Controls.Add(tableLayoutPanel1);
            pnSanPham.Controls.Add(fLPSanPhamDaChon);
            pnSanPham.Controls.Add(tlpThanhToan);
            pnSanPham.Dock = DockStyle.Fill;
            pnSanPham.Location = new Point(3, 3);
            pnSanPham.Name = "pnSanPham";
            pnSanPham.Size = new Size(424, 477);
            pnSanPham.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.9150925F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.0849075F));
            tableLayoutPanel1.Controls.Add(lbTongTien, 0, 0);
            tableLayoutPanel1.Controls.Add(txtTongTien, 1, 0);
            tableLayoutPanel1.Controls.Add(btnThemMaGiamGia, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 172);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(424, 111);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // lbTongTien
            // 
            lbTongTien.Anchor = AnchorStyles.Right;
            lbTongTien.AutoSize = true;
            lbTongTien.Location = new Point(82, 17);
            lbTongTien.Name = "lbTongTien";
            lbTongTien.Size = new Size(80, 20);
            lbTongTien.TabIndex = 0;
            lbTongTien.Text = "Tổng cộng";
            // 
            // txtTongTien
            // 
            txtTongTien.Anchor = AnchorStyles.Left;
            txtTongTien.Location = new Point(168, 14);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(251, 27);
            txtTongTien.TabIndex = 1;
            // 
            // btnThemMaGiamGia
            // 
            btnThemMaGiamGia.Anchor = AnchorStyles.Left;
            btnThemMaGiamGia.Location = new Point(168, 58);
            btnThemMaGiamGia.Name = "btnThemMaGiamGia";
            btnThemMaGiamGia.Size = new Size(150, 50);
            btnThemMaGiamGia.TabIndex = 2;
            btnThemMaGiamGia.Text = "Mã giảm giá";
            btnThemMaGiamGia.UseVisualStyleBackColor = true;
            // 
            // fLPSanPhamDaChon
            // 
            fLPSanPhamDaChon.Dock = DockStyle.Top;
            fLPSanPhamDaChon.Location = new Point(0, 0);
            fLPSanPhamDaChon.Name = "fLPSanPhamDaChon";
            fLPSanPhamDaChon.Size = new Size(424, 172);
            fLPSanPhamDaChon.TabIndex = 3;
            // 
            // tlpThanhToan
            // 
            tlpThanhToan.ColumnCount = 2;
            tlpThanhToan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.9150925F));
            tlpThanhToan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.0849075F));
            tlpThanhToan.Controls.Add(btnThanhToan, 1, 1);
            tlpThanhToan.Controls.Add(btnThemGioHang, 0, 1);
            tlpThanhToan.Controls.Add(lbThemKhachHang, 0, 0);
            tlpThanhToan.Controls.Add(pnKhachHang, 1, 0);
            tlpThanhToan.Dock = DockStyle.Bottom;
            tlpThanhToan.Location = new Point(0, 283);
            tlpThanhToan.Name = "tlpThanhToan";
            tlpThanhToan.RowCount = 2;
            tlpThanhToan.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThanhToan.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThanhToan.Size = new Size(424, 194);
            tlpThanhToan.TabIndex = 0;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThanhToan.Location = new Point(271, 100);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(150, 68);
            btnThanhToan.TabIndex = 0;
            btnThanhToan.Text = "THANH TOÁN";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnThemGioHang
            // 
            btnThemGioHang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemGioHang.Location = new Point(24, 100);
            btnThemGioHang.Name = "btnThemGioHang";
            btnThemGioHang.Size = new Size(138, 68);
            btnThemGioHang.TabIndex = 1;
            btnThemGioHang.Text = "THÊM GIỎ";
            btnThemGioHang.UseVisualStyleBackColor = true;
            // 
            // lbThemKhachHang
            // 
            lbThemKhachHang.Anchor = AnchorStyles.Right;
            lbThemKhachHang.AutoSize = true;
            lbThemKhachHang.Location = new Point(6, 38);
            lbThemKhachHang.Name = "lbThemKhachHang";
            lbThemKhachHang.Size = new Size(156, 20);
            lbThemKhachHang.TabIndex = 2;
            lbThemKhachHang.Text = "Tìm/Thêm khách hàng";
            // 
            // pnKhachHang
            // 
            pnKhachHang.Anchor = AnchorStyles.Left;
            pnKhachHang.Controls.Add(btnThemKhachHangMoi);
            pnKhachHang.Controls.Add(txtTimKhachHang);
            pnKhachHang.Location = new Point(168, 3);
            pnKhachHang.Name = "pnKhachHang";
            pnKhachHang.Size = new Size(253, 91);
            pnKhachHang.TabIndex = 3;
            // 
            // btnThemKhachHangMoi
            // 
            btnThemKhachHangMoi.Anchor = AnchorStyles.Left;
            btnThemKhachHangMoi.Location = new Point(150, 23);
            btnThemKhachHangMoi.Name = "btnThemKhachHangMoi";
            btnThemKhachHangMoi.Size = new Size(101, 45);
            btnThemKhachHangMoi.TabIndex = 1;
            btnThemKhachHangMoi.Text = "Thêm mới";
            btnThemKhachHangMoi.UseVisualStyleBackColor = true;
            btnThemKhachHangMoi.Click += btnThemKhachHangMoi_Click;
            // 
            // txtTimKhachHang
            // 
            txtTimKhachHang.Anchor = AnchorStyles.Left;
            txtTimKhachHang.Location = new Point(3, 32);
            txtTimKhachHang.Name = "txtTimKhachHang";
            txtTimKhachHang.Size = new Size(147, 27);
            txtTimKhachHang.TabIndex = 0;
            // 
            // pnDanhSach
            // 
            pnDanhSach.Controls.Add(fLPSanPham);
            pnDanhSach.Controls.Add(tlpBoLoc);
            pnDanhSach.Dock = DockStyle.Fill;
            pnDanhSach.Location = new Point(433, 3);
            pnDanhSach.Name = "pnDanhSach";
            pnDanhSach.Size = new Size(690, 477);
            pnDanhSach.TabIndex = 1;
            // 
            // fLPSanPham
            // 
            fLPSanPham.AutoScroll = true;
            fLPSanPham.Dock = DockStyle.Fill;
            fLPSanPham.Location = new Point(0, 41);
            fLPSanPham.Name = "fLPSanPham";
            fLPSanPham.Size = new Size(690, 436);
            fLPSanPham.TabIndex = 1;
            // 
            // tlpBoLoc
            // 
            tlpBoLoc.ColumnCount = 3;
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.637681F));
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.144928F));
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.217392F));
            tlpBoLoc.Controls.Add(lbTimKiem, 0, 0);
            tlpBoLoc.Controls.Add(txtTimKiem, 1, 0);
            tlpBoLoc.Controls.Add(cbbLoaiSanPham, 2, 0);
            tlpBoLoc.Dock = DockStyle.Top;
            tlpBoLoc.Location = new Point(0, 0);
            tlpBoLoc.Name = "tlpBoLoc";
            tlpBoLoc.RowCount = 1;
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBoLoc.Size = new Size(690, 41);
            tlpBoLoc.TabIndex = 0;
            // 
            // lbTimKiem
            // 
            lbTimKiem.Anchor = AnchorStyles.Right;
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(28, 10);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.Size = new Size(70, 20);
            lbTimKiem.TabIndex = 0;
            lbTimKiem.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Left;
            txtTimKiem.Location = new Point(104, 7);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(337, 27);
            txtTimKiem.TabIndex = 1;
            // 
            // cbbLoaiSanPham
            // 
            cbbLoaiSanPham.Anchor = AnchorStyles.Left;
            cbbLoaiSanPham.FormattingEnabled = true;
            cbbLoaiSanPham.Location = new Point(450, 6);
            cbbLoaiSanPham.Name = "cbbLoaiSanPham";
            cbbLoaiSanPham.Size = new Size(234, 28);
            cbbLoaiSanPham.TabIndex = 2;
            // 
            // BANHANG
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 557);
            Controls.Add(tlpall);
            Name = "BANHANG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bán hàng";
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpThan.ResumeLayout(false);
            pnSanPham.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tlpThanhToan.ResumeLayout(false);
            tlpThanhToan.PerformLayout();
            pnKhachHang.ResumeLayout(false);
            pnKhachHang.PerformLayout();
            pnDanhSach.ResumeLayout(false);
            tlpBoLoc.ResumeLayout(false);
            tlpBoLoc.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpThan;
        private Panel pnSanPham;
        private TableLayoutPanel tlpThanhToan;
        private Panel pnDanhSach;
        private TableLayoutPanel tlpBoLoc;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private ComboBox cbbLoaiSanPham;
        private FlowLayoutPanel fLPSanPham;
        private Button btnThanhToan;
        private Button btnThemGioHang;
        private Label lbThemKhachHang;
        private Panel pnKhachHang;
        private Button btnThemKhachHangMoi;
        private TextBox txtTimKhachHang;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lbTongTien;
        private TextBox txtTongTien;
        private Button btnThemMaGiamGia;
        private FlowLayoutPanel fLPSanPhamDaChon;
    }
}