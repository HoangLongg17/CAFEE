namespace CF36
{
    partial class THONGKE
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
            tlpBoLoc = new TableLayoutPanel();
            tlpphai = new TableLayoutPanel();
            cbbLoaiSanPham = new ComboBox();
            lbTong = new Label();
            txtTongTien = new TextBox();
            cBLoaiSanPham = new CheckBox();
            gBThoiGian = new GroupBox();
            cBDenNgay = new CheckBox();
            cBTuNgay = new CheckBox();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            tlpDuLieu = new TableLayoutPanel();
            dgvHoaDon = new DataGridView();
            lbBieuDo = new Label();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpBoLoc.SuspendLayout();
            tlpphai.SuspendLayout();
            gBThoiGian.SuspendLayout();
            tlpDuLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpBoLoc, 0, 1);
            tlpall.Controls.Add(tlpDuLieu, 0, 2);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 3;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 14.1342754F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 24.9116611F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 60.9540634F));
            tlpall.Size = new Size(858, 566);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(852, 74);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpBoLoc
            // 
            tlpBoLoc.ColumnCount = 2;
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.88263F));
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.11737F));
            tlpBoLoc.Controls.Add(tlpphai, 1, 0);
            tlpBoLoc.Controls.Add(gBThoiGian, 0, 0);
            tlpBoLoc.Dock = DockStyle.Fill;
            tlpBoLoc.Location = new Point(3, 83);
            tlpBoLoc.Name = "tlpBoLoc";
            tlpBoLoc.RowCount = 1;
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpBoLoc.Size = new Size(852, 135);
            tlpBoLoc.TabIndex = 1;
            // 
            // tlpphai
            // 
            tlpphai.ColumnCount = 2;
            tlpphai.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.6793365F));
            tlpphai.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.32066F));
            tlpphai.Controls.Add(cbbLoaiSanPham, 1, 0);
            tlpphai.Controls.Add(lbTong, 0, 1);
            tlpphai.Controls.Add(txtTongTien, 1, 1);
            tlpphai.Controls.Add(cBLoaiSanPham, 0, 0);
            tlpphai.Dock = DockStyle.Fill;
            tlpphai.Location = new Point(428, 3);
            tlpphai.Name = "tlpphai";
            tlpphai.RowCount = 2;
            tlpphai.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpphai.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpphai.Size = new Size(421, 129);
            tlpphai.TabIndex = 1;
            // 
            // cbbLoaiSanPham
            // 
            cbbLoaiSanPham.Anchor = AnchorStyles.Left;
            cbbLoaiSanPham.FormattingEnabled = true;
            cbbLoaiSanPham.Location = new Point(149, 18);
            cbbLoaiSanPham.Name = "cbbLoaiSanPham";
            cbbLoaiSanPham.Size = new Size(208, 28);
            cbbLoaiSanPham.TabIndex = 1;
            // 
            // lbTong
            // 
            lbTong.Anchor = AnchorStyles.Left;
            lbTong.AutoSize = true;
            lbTong.Location = new Point(3, 86);
            lbTong.Name = "lbTong";
            lbTong.Size = new Size(114, 20);
            lbTong.TabIndex = 2;
            lbTong.Text = "Tổng doanh thu";
            // 
            // txtTongTien
            // 
            txtTongTien.Anchor = AnchorStyles.Left;
            txtTongTien.Location = new Point(149, 83);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(205, 27);
            txtTongTien.TabIndex = 3;
            // 
            // cBLoaiSanPham
            // 
            cBLoaiSanPham.Anchor = AnchorStyles.Left;
            cBLoaiSanPham.AutoSize = true;
            cBLoaiSanPham.Location = new Point(3, 20);
            cBLoaiSanPham.Name = "cBLoaiSanPham";
            cBLoaiSanPham.Size = new Size(127, 24);
            cBLoaiSanPham.TabIndex = 4;
            cBLoaiSanPham.Text = "Loại sản phẩm";
            cBLoaiSanPham.UseVisualStyleBackColor = true;
            // 
            // gBThoiGian
            // 
            gBThoiGian.Anchor = AnchorStyles.Right;
            gBThoiGian.Controls.Add(cBDenNgay);
            gBThoiGian.Controls.Add(cBTuNgay);
            gBThoiGian.Controls.Add(dateTimePicker2);
            gBThoiGian.Controls.Add(dateTimePicker1);
            gBThoiGian.Location = new Point(3, 5);
            gBThoiGian.Name = "gBThoiGian";
            gBThoiGian.Size = new Size(419, 125);
            gBThoiGian.TabIndex = 0;
            gBThoiGian.TabStop = false;
            gBThoiGian.Text = "Lọc theo ngày";
            // 
            // cBDenNgay
            // 
            cBDenNgay.AutoSize = true;
            cBDenNgay.Location = new Point(27, 95);
            cBDenNgay.Name = "cBDenNgay";
            cBDenNgay.Size = new Size(94, 24);
            cBDenNgay.TabIndex = 1;
            cBDenNgay.Text = "Đến ngày";
            cBDenNgay.UseVisualStyleBackColor = true;
            // 
            // cBTuNgay
            // 
            cBTuNgay.AutoSize = true;
            cBTuNgay.Location = new Point(27, 26);
            cBTuNgay.Name = "cBTuNgay";
            cBTuNgay.Size = new Size(84, 24);
            cBTuNgay.TabIndex = 1;
            cBTuNgay.Text = "Từ ngày";
            cBTuNgay.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(136, 92);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(136, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 0;
            // 
            // tlpDuLieu
            // 
            tlpDuLieu.ColumnCount = 2;
            tlpDuLieu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDuLieu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDuLieu.Controls.Add(dgvHoaDon, 1, 0);
            tlpDuLieu.Controls.Add(lbBieuDo, 0, 0);
            tlpDuLieu.Dock = DockStyle.Fill;
            tlpDuLieu.Location = new Point(3, 224);
            tlpDuLieu.Name = "tlpDuLieu";
            tlpDuLieu.RowCount = 1;
            tlpDuLieu.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpDuLieu.Size = new Size(852, 339);
            tlpDuLieu.TabIndex = 2;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(429, 3);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(420, 333);
            dgvHoaDon.TabIndex = 0;
            // 
            // lbBieuDo
            // 
            lbBieuDo.AutoSize = true;
            lbBieuDo.Dock = DockStyle.Fill;
            lbBieuDo.Location = new Point(3, 0);
            lbBieuDo.Name = "lbBieuDo";
            lbBieuDo.Size = new Size(420, 339);
            lbBieuDo.TabIndex = 1;
            lbBieuDo.Text = "Biểu đồ sẽ nằm ở đây";
            lbBieuDo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // THONGKE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 566);
            Controls.Add(tlpall);
            Name = "THONGKE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê";
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpBoLoc.ResumeLayout(false);
            tlpphai.ResumeLayout(false);
            tlpphai.PerformLayout();
            gBThoiGian.ResumeLayout(false);
            gBThoiGian.PerformLayout();
            tlpDuLieu.ResumeLayout(false);
            tlpDuLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpBoLoc;
        private GroupBox gBThoiGian;
        private CheckBox cBDenNgay;
        private CheckBox cBTuNgay;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TableLayoutPanel tlpphai;
        private ComboBox cbbLoaiSanPham;
        private Label lbTong;
        private TextBox txtTongTien;
        private TableLayoutPanel tlpDuLieu;
        private DataGridView dgvHoaDon;
        private CheckBox cBLoaiSanPham;
        private Label lbBieuDo;
    }
}