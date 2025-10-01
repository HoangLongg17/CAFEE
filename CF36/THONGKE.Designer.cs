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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tlpall = new TableLayoutPanel();
            picLogo = new PictureBox();
            tlpBoLoc = new TableLayoutPanel();
            tlpphai = new TableLayoutPanel();
            cbbLoaiSanPham = new ComboBox();
            lbTong = new Label();
            txtTongTien = new TextBox();
            cBLoaiSanPham = new CheckBox();
            gBThoiGian = new GroupBox();
            btnLocDuLieu = new Button();
            cBDenNgay = new CheckBox();
            cBTuNgay = new CheckBox();
            dtDenNgay = new DateTimePicker();
            dtTuNgay = new DateTimePicker();
            tlpDuLieu = new TableLayoutPanel();
            dgvHoaDon = new DataGridView();
            chrThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpBoLoc.SuspendLayout();
            tlpphai.SuspendLayout();
            gBThoiGian.SuspendLayout();
            tlpDuLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chrThongKe).BeginInit();
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
            tlpall.Margin = new Padding(3, 2, 3, 2);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 3;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 14.1342754F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 24.9116611F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 60.9540634F));
            tlpall.Size = new Size(751, 424);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 2);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(745, 55);
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
            tlpBoLoc.Location = new Point(3, 61);
            tlpBoLoc.Margin = new Padding(3, 2, 3, 2);
            tlpBoLoc.Name = "tlpBoLoc";
            tlpBoLoc.RowCount = 1;
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpBoLoc.Size = new Size(745, 101);
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
            tlpphai.Location = new Point(374, 2);
            tlpphai.Margin = new Padding(3, 2, 3, 2);
            tlpphai.Name = "tlpphai";
            tlpphai.RowCount = 2;
            tlpphai.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpphai.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpphai.Size = new Size(368, 97);
            tlpphai.TabIndex = 1;
            // 
            // cbbLoaiSanPham
            // 
            cbbLoaiSanPham.Anchor = AnchorStyles.Left;
            cbbLoaiSanPham.FormattingEnabled = true;
            cbbLoaiSanPham.Location = new Point(130, 12);
            cbbLoaiSanPham.Margin = new Padding(3, 2, 3, 2);
            cbbLoaiSanPham.Name = "cbbLoaiSanPham";
            cbbLoaiSanPham.Size = new Size(182, 23);
            cbbLoaiSanPham.TabIndex = 1;
            // 
            // lbTong
            // 
            lbTong.Anchor = AnchorStyles.Left;
            lbTong.AutoSize = true;
            lbTong.Location = new Point(3, 65);
            lbTong.Name = "lbTong";
            lbTong.Size = new Size(92, 15);
            lbTong.TabIndex = 2;
            lbTong.Text = "Tổng doanh thu";
            // 
            // txtTongTien
            // 
            txtTongTien.Anchor = AnchorStyles.Left;
            txtTongTien.Location = new Point(130, 61);
            txtTongTien.Margin = new Padding(3, 2, 3, 2);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(180, 23);
            txtTongTien.TabIndex = 3;
            // 
            // cBLoaiSanPham
            // 
            cBLoaiSanPham.Anchor = AnchorStyles.Left;
            cBLoaiSanPham.AutoSize = true;
            cBLoaiSanPham.Location = new Point(3, 14);
            cBLoaiSanPham.Margin = new Padding(3, 2, 3, 2);
            cBLoaiSanPham.Name = "cBLoaiSanPham";
            cBLoaiSanPham.Size = new Size(103, 19);
            cBLoaiSanPham.TabIndex = 4;
            cBLoaiSanPham.Text = "Loại sản phẩm";
            cBLoaiSanPham.UseVisualStyleBackColor = true;
            cBLoaiSanPham.CheckedChanged += cBLoaiSanPham_CheckedChanged;
            // 
            // gBThoiGian
            // 
            gBThoiGian.Anchor = AnchorStyles.Right;
            gBThoiGian.Controls.Add(btnLocDuLieu);
            gBThoiGian.Controls.Add(cBDenNgay);
            gBThoiGian.Controls.Add(cBTuNgay);
            gBThoiGian.Controls.Add(dtDenNgay);
            gBThoiGian.Controls.Add(dtTuNgay);
            gBThoiGian.Location = new Point(3, 3);
            gBThoiGian.Margin = new Padding(3, 2, 3, 2);
            gBThoiGian.Name = "gBThoiGian";
            gBThoiGian.Padding = new Padding(3, 2, 3, 2);
            gBThoiGian.Size = new Size(365, 94);
            gBThoiGian.TabIndex = 0;
            gBThoiGian.TabStop = false;
            gBThoiGian.Text = "Lọc theo ngày";
            // 
            // btnLocDuLieu
            // 
            btnLocDuLieu.Location = new Point(6, 69);
            btnLocDuLieu.Name = "btnLocDuLieu";
            btnLocDuLieu.Size = new Size(75, 23);
            btnLocDuLieu.TabIndex = 2;
            btnLocDuLieu.Text = "Lọc dữ liệu";
            btnLocDuLieu.UseVisualStyleBackColor = true;
            btnLocDuLieu.Click += btnLocDuLieu_Click;
            // 
            // cBDenNgay
            // 
            cBDenNgay.AutoSize = true;
            cBDenNgay.Location = new Point(24, 45);
            cBDenNgay.Margin = new Padding(3, 2, 3, 2);
            cBDenNgay.Name = "cBDenNgay";
            cBDenNgay.Size = new Size(76, 19);
            cBDenNgay.TabIndex = 1;
            cBDenNgay.Text = "Đến ngày";
            cBDenNgay.UseVisualStyleBackColor = true;
            cBDenNgay.CheckedChanged += cBDenNgay_CheckedChanged;
            // 
            // cBTuNgay
            // 
            cBTuNgay.AutoSize = true;
            cBTuNgay.Location = new Point(24, 20);
            cBTuNgay.Margin = new Padding(3, 2, 3, 2);
            cBTuNgay.Name = "cBTuNgay";
            cBTuNgay.Size = new Size(68, 19);
            cBTuNgay.TabIndex = 1;
            cBTuNgay.Text = "Từ ngày";
            cBTuNgay.UseVisualStyleBackColor = true;
            cBTuNgay.CheckedChanged += cBTuNgay_CheckedChanged;
            // 
            // dtDenNgay
            // 
            dtDenNgay.Location = new Point(119, 43);
            dtDenNgay.Margin = new Padding(3, 2, 3, 2);
            dtDenNgay.Name = "dtDenNgay";
            dtDenNgay.Size = new Size(219, 23);
            dtDenNgay.TabIndex = 0;
            // 
            // dtTuNgay
            // 
            dtTuNgay.Location = new Point(119, 16);
            dtTuNgay.Margin = new Padding(3, 2, 3, 2);
            dtTuNgay.Name = "dtTuNgay";
            dtTuNgay.Size = new Size(219, 23);
            dtTuNgay.TabIndex = 0;
            // 
            // tlpDuLieu
            // 
            tlpDuLieu.ColumnCount = 2;
            tlpDuLieu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDuLieu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDuLieu.Controls.Add(dgvHoaDon, 1, 0);
            tlpDuLieu.Controls.Add(chrThongKe, 0, 0);
            tlpDuLieu.Dock = DockStyle.Fill;
            tlpDuLieu.Location = new Point(3, 166);
            tlpDuLieu.Margin = new Padding(3, 2, 3, 2);
            tlpDuLieu.Name = "tlpDuLieu";
            tlpDuLieu.RowCount = 1;
            tlpDuLieu.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpDuLieu.Size = new Size(745, 256);
            tlpDuLieu.TabIndex = 2;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(375, 2);
            dgvHoaDon.Margin = new Padding(3, 2, 3, 2);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(367, 252);
            dgvHoaDon.TabIndex = 0;
            // 
            // chrThongKe
            // 
            chartArea1.Name = "ChartArea1";
            chrThongKe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chrThongKe.Legends.Add(legend1);
            chrThongKe.Location = new Point(3, 3);
            chrThongKe.Name = "chrThongKe";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chrThongKe.Series.Add(series1);
            chrThongKe.Size = new Size(366, 250);
            chrThongKe.TabIndex = 1;
            chrThongKe.Text = "chart1";
            // 
            // THONGKE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 424);
            Controls.Add(tlpall);
            Margin = new Padding(3, 2, 3, 2);
            Name = "THONGKE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê";
            Load += THONGKE_Load;
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpBoLoc.ResumeLayout(false);
            tlpphai.ResumeLayout(false);
            tlpphai.PerformLayout();
            gBThoiGian.ResumeLayout(false);
            gBThoiGian.PerformLayout();
            tlpDuLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)chrThongKe).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpBoLoc;
        private GroupBox gBThoiGian;
        private CheckBox cBDenNgay;
        private CheckBox cBTuNgay;
        private DateTimePicker dtDenNgay;
        private DateTimePicker dtTuNgay;
        private TableLayoutPanel tlpphai;
        private ComboBox cbbLoaiSanPham;
        private Label lbTong;
        private TextBox txtTongTien;
        private TableLayoutPanel tlpDuLieu;
        private DataGridView dgvHoaDon;
        private CheckBox cBLoaiSanPham;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrThongKe;
        private Button btnLocDuLieu;
    }
}