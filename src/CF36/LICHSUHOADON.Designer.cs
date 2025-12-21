namespace CF36
{
    partial class LICHSUHOADON
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
            dgvHoaDon = new DataGridView();
            gbLoc = new GroupBox();
            btnXuatPDF = new Button();
            btnLocDuLieu = new Button();
            txtTimKiem = new TextBox();
            lbMaHoaDon = new Label();
            dTPTuNgay = new DateTimePicker();
            dTPDenNgay = new DateTimePicker();
            cBDenNgay = new CheckBox();
            cBTuNgay = new CheckBox();
            txtMaNhanVien = new TextBox();
            cBNhanVienBan = new CheckBox();
            tlpend = new TableLayoutPanel();
            btnLamMoi = new Button();
            btnThoat = new Button();
            btnQuayLai = new Button();
            tabLS = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tlpthongtin = new TableLayoutPanel();
            dgvNhanVien = new DataGridView();
            tlploc = new TableLayoutPanel();
            tlpLSTH = new TableLayoutPanel();
            tlpbolocLSTH = new TableLayoutPanel();
            dgvNhanVienTH = new DataGridView();
            dgvHDTH = new DataGridView();
            gbLocTH = new GroupBox();
            lbTim = new Label();
            btnloc = new Button();
            txtTim = new TextBox();
            txtMaNVTH = new TextBox();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            ckbDenNgay = new CheckBox();
            ckbNVTH = new CheckBox();
            ckbTuNgay = new CheckBox();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            gbLoc.SuspendLayout();
            tlpend.SuspendLayout();
            tabLS.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tlpthongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            tlploc.SuspendLayout();
            tlpLSTH.SuspendLayout();
            tlpbolocLSTH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVienTH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHDTH).BeginInit();
            gbLocTH.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpBoLoc, 0, 1);
            tlpall.Controls.Add(tlpend, 0, 2);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 3;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.3669071F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 74.25569F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 9.457093F));
            tlpall.Size = new Size(1206, 693);
            tlpall.TabIndex = 0;
            tlpall.Paint += tlpall_Paint;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(1200, 107);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpBoLoc
            // 
            tlpBoLoc.ColumnCount = 1;
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.8132F));
            tlpBoLoc.Controls.Add(tabLS, 0, 0);
            tlpBoLoc.Dock = DockStyle.Fill;
            tlpBoLoc.Location = new Point(3, 116);
            tlpBoLoc.Name = "tlpBoLoc";
            tlpBoLoc.RowCount = 2;
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 98.42519F));
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 1.57480311F));
            tlpBoLoc.Size = new Size(1200, 508);
            tlpBoLoc.TabIndex = 1;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(3, 230);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(1174, 222);
            dgvHoaDon.TabIndex = 2;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;
            // 
            // gbLoc
            // 
            gbLoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbLoc.Controls.Add(btnXuatPDF);
            gbLoc.Controls.Add(btnLocDuLieu);
            gbLoc.Controls.Add(txtTimKiem);
            gbLoc.Controls.Add(lbMaHoaDon);
            gbLoc.Controls.Add(dTPTuNgay);
            gbLoc.Controls.Add(dTPDenNgay);
            gbLoc.Controls.Add(cBDenNgay);
            gbLoc.Controls.Add(cBTuNgay);
            gbLoc.Controls.Add(txtMaNhanVien);
            gbLoc.Controls.Add(cBNhanVienBan);
            gbLoc.Location = new Point(3, 3);
            gbLoc.Name = "gbLoc";
            gbLoc.Size = new Size(581, 215);
            gbLoc.TabIndex = 0;
            gbLoc.TabStop = false;
            gbLoc.Text = "Lọc theo";
            // 
            // btnXuatPDF
            // 
            btnXuatPDF.Anchor = AnchorStyles.None;
            btnXuatPDF.Location = new Point(428, 113);
            btnXuatPDF.Name = "btnXuatPDF";
            btnXuatPDF.Size = new Size(124, 57);
            btnXuatPDF.TabIndex = 3;
            btnXuatPDF.Text = "XUẤT FILE PDF";
            btnXuatPDF.UseVisualStyleBackColor = true;
            btnXuatPDF.Click += btnXuatPDF_Click;
            // 
            // btnLocDuLieu
            // 
            btnLocDuLieu.Location = new Point(428, 31);
            btnLocDuLieu.Margin = new Padding(3, 4, 3, 4);
            btnLocDuLieu.Name = "btnLocDuLieu";
            btnLocDuLieu.Size = new Size(124, 51);
            btnLocDuLieu.TabIndex = 8;
            btnLocDuLieu.Text = "Lọc dữ liệu";
            btnLocDuLieu.UseVisualStyleBackColor = true;
            btnLocDuLieu.Click += btnLocDuLieu_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(87, 31);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(286, 27);
            txtTimKiem.TabIndex = 7;
            // 
            // lbMaHoaDon
            // 
            lbMaHoaDon.AutoSize = true;
            lbMaHoaDon.Location = new Point(11, 35);
            lbMaHoaDon.Name = "lbMaHoaDon";
            lbMaHoaDon.Size = new Size(70, 20);
            lbMaHoaDon.TabIndex = 6;
            lbMaHoaDon.Text = "Tìm kiếm";
            // 
            // dTPTuNgay
            // 
            dTPTuNgay.Location = new Point(123, 109);
            dTPTuNgay.Name = "dTPTuNgay";
            dTPTuNgay.Size = new Size(250, 27);
            dTPTuNgay.TabIndex = 5;
            // 
            // dTPDenNgay
            // 
            dTPDenNgay.Location = new Point(123, 147);
            dTPDenNgay.Name = "dTPDenNgay";
            dTPDenNgay.Size = new Size(250, 27);
            dTPDenNgay.TabIndex = 5;
            // 
            // cBDenNgay
            // 
            cBDenNgay.AutoSize = true;
            cBDenNgay.Location = new Point(11, 149);
            cBDenNgay.Name = "cBDenNgay";
            cBDenNgay.Size = new Size(94, 24);
            cBDenNgay.TabIndex = 4;
            cBDenNgay.Text = "Đến ngày";
            cBDenNgay.UseVisualStyleBackColor = true;
            cBDenNgay.CheckedChanged += cBDenNgay_CheckedChanged;
            // 
            // cBTuNgay
            // 
            cBTuNgay.AutoSize = true;
            cBTuNgay.Location = new Point(11, 113);
            cBTuNgay.Name = "cBTuNgay";
            cBTuNgay.Size = new Size(84, 24);
            cBTuNgay.TabIndex = 2;
            cBTuNgay.Text = "Từ ngày";
            cBTuNgay.UseVisualStyleBackColor = true;
            cBTuNgay.CheckedChanged += cBTuNgay_CheckedChanged;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(143, 71);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(230, 27);
            txtMaNhanVien.TabIndex = 1;
            txtMaNhanVien.Text = "Nhập mã nhân viên";
            // 
            // cBNhanVienBan
            // 
            cBNhanVienBan.AutoSize = true;
            cBNhanVienBan.Location = new Point(11, 73);
            cBNhanVienBan.Name = "cBNhanVienBan";
            cBNhanVienBan.Size = new Size(126, 24);
            cBNhanVienBan.TabIndex = 0;
            cBNhanVienBan.Text = "Nhân viên bán";
            cBNhanVienBan.UseVisualStyleBackColor = true;
            cBNhanVienBan.CheckedChanged += cBNhanVienBan_CheckedChanged;
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 3;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.916667F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11F));
            tlpend.Controls.Add(btnLamMoi, 0, 0);
            tlpend.Controls.Add(btnThoat, 2, 0);
            tlpend.Controls.Add(btnQuayLai, 1, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 630);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(1200, 60);
            tlpend.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(812, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(121, 54);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1070, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(126, 54);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuayLai.Location = new Point(939, 3);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(125, 54);
            btnQuayLai.TabIndex = 1;
            btnQuayLai.Text = "QUAY LẠI";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // tabLS
            // 
            tabLS.Controls.Add(tabPage1);
            tabLS.Controls.Add(tabPage2);
            tabLS.Dock = DockStyle.Fill;
            tabLS.Location = new Point(3, 3);
            tabLS.Name = "tabLS";
            tabLS.SelectedIndex = 0;
            tabLS.Size = new Size(1194, 494);
            tabLS.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tlpthongtin);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1186, 461);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Lịch sử hóa đơn";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tlpLSTH);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1186, 461);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Lịch sử trả hàng";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tlpthongtin
            // 
            tlpthongtin.ColumnCount = 1;
            tlpthongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpthongtin.Controls.Add(dgvHoaDon, 0, 1);
            tlpthongtin.Controls.Add(tlploc, 0, 0);
            tlpthongtin.Dock = DockStyle.Fill;
            tlpthongtin.Location = new Point(3, 3);
            tlpthongtin.Name = "tlpthongtin";
            tlpthongtin.RowCount = 2;
            tlpthongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpthongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpthongtin.Size = new Size(1180, 455);
            tlpthongtin.TabIndex = 0;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(590, 3);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(581, 215);
            dgvNhanVien.TabIndex = 1;
            dgvNhanVien.SelectionChanged += dgvNhanVien_SelectionChanged;
            // 
            // tlploc
            // 
            tlploc.ColumnCount = 2;
            tlploc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlploc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlploc.Controls.Add(dgvNhanVien, 1, 0);
            tlploc.Controls.Add(gbLoc, 0, 0);
            tlploc.Dock = DockStyle.Fill;
            tlploc.Location = new Point(3, 3);
            tlploc.Name = "tlploc";
            tlploc.RowCount = 1;
            tlploc.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlploc.Size = new Size(1174, 221);
            tlploc.TabIndex = 0;
            // 
            // tlpLSTH
            // 
            tlpLSTH.ColumnCount = 1;
            tlpLSTH.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpLSTH.Controls.Add(dgvHDTH, 0, 1);
            tlpLSTH.Controls.Add(tlpbolocLSTH, 0, 0);
            tlpLSTH.Dock = DockStyle.Fill;
            tlpLSTH.Location = new Point(3, 3);
            tlpLSTH.Name = "tlpLSTH";
            tlpLSTH.RowCount = 2;
            tlpLSTH.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpLSTH.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpLSTH.Size = new Size(1180, 455);
            tlpLSTH.TabIndex = 0;
            // 
            // tlpbolocLSTH
            // 
            tlpbolocLSTH.ColumnCount = 2;
            tlpbolocLSTH.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpbolocLSTH.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpbolocLSTH.Controls.Add(dgvNhanVienTH, 1, 0);
            tlpbolocLSTH.Controls.Add(gbLocTH, 0, 0);
            tlpbolocLSTH.Dock = DockStyle.Fill;
            tlpbolocLSTH.Location = new Point(3, 3);
            tlpbolocLSTH.Name = "tlpbolocLSTH";
            tlpbolocLSTH.RowCount = 1;
            tlpbolocLSTH.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpbolocLSTH.Size = new Size(1174, 221);
            tlpbolocLSTH.TabIndex = 0;
            // 
            // dgvNhanVienTH
            // 
            dgvNhanVienTH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVienTH.Dock = DockStyle.Fill;
            dgvNhanVienTH.Location = new Point(590, 3);
            dgvNhanVienTH.Name = "dgvNhanVienTH";
            dgvNhanVienTH.RowHeadersWidth = 51;
            dgvNhanVienTH.Size = new Size(581, 215);
            dgvNhanVienTH.TabIndex = 0;
            // 
            // dgvHDTH
            // 
            dgvHDTH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHDTH.Dock = DockStyle.Fill;
            dgvHDTH.Location = new Point(3, 230);
            dgvHDTH.Name = "dgvHDTH";
            dgvHDTH.RowHeadersWidth = 51;
            dgvHDTH.Size = new Size(1174, 222);
            dgvHDTH.TabIndex = 0;
            // 
            // gbLocTH
            // 
            gbLocTH.Controls.Add(ckbNVTH);
            gbLocTH.Controls.Add(ckbTuNgay);
            gbLocTH.Controls.Add(ckbDenNgay);
            gbLocTH.Controls.Add(dtpEnd);
            gbLocTH.Controls.Add(dtpStart);
            gbLocTH.Controls.Add(txtMaNVTH);
            gbLocTH.Controls.Add(txtTim);
            gbLocTH.Controls.Add(btnloc);
            gbLocTH.Controls.Add(lbTim);
            gbLocTH.Dock = DockStyle.Fill;
            gbLocTH.Location = new Point(3, 3);
            gbLocTH.Name = "gbLocTH";
            gbLocTH.Size = new Size(581, 215);
            gbLocTH.TabIndex = 1;
            gbLocTH.TabStop = false;
            gbLocTH.Text = "Lọc theo";
            // 
            // lbTim
            // 
            lbTim.AutoSize = true;
            lbTim.Location = new Point(17, 33);
            lbTim.Name = "lbTim";
            lbTim.Size = new Size(70, 20);
            lbTim.TabIndex = 0;
            lbTim.Text = "Tìm kiếm";
            // 
            // btnloc
            // 
            btnloc.Location = new Point(455, 144);
            btnloc.Name = "btnloc";
            btnloc.Size = new Size(120, 48);
            btnloc.TabIndex = 1;
            btnloc.Text = "Lọc dữ liệu";
            btnloc.UseVisualStyleBackColor = true;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(175, 30);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(250, 27);
            txtTim.TabIndex = 2;
            // 
            // txtMaNVTH
            // 
            txtMaNVTH.Location = new Point(175, 71);
            txtMaNVTH.Name = "txtMaNVTH";
            txtMaNVTH.Size = new Size(250, 27);
            txtMaNVTH.TabIndex = 2;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(175, 117);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(250, 27);
            dtpStart.TabIndex = 3;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(175, 165);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(250, 27);
            dtpEnd.TabIndex = 3;
            // 
            // ckbDenNgay
            // 
            ckbDenNgay.AutoSize = true;
            ckbDenNgay.Location = new Point(17, 169);
            ckbDenNgay.Name = "ckbDenNgay";
            ckbDenNgay.Size = new Size(94, 24);
            ckbDenNgay.TabIndex = 4;
            ckbDenNgay.Text = "Đến ngày";
            ckbDenNgay.UseVisualStyleBackColor = true;
            // 
            // ckbNVTH
            // 
            ckbNVTH.AutoSize = true;
            ckbNVTH.Location = new Point(17, 73);
            ckbNVTH.Name = "ckbNVTH";
            ckbNVTH.Size = new Size(119, 24);
            ckbNVTH.TabIndex = 4;
            ckbNVTH.Text = "Nhân viên trả";
            ckbNVTH.UseVisualStyleBackColor = true;
            // 
            // ckbTuNgay
            // 
            ckbTuNgay.AutoSize = true;
            ckbTuNgay.Location = new Point(17, 121);
            ckbTuNgay.Name = "ckbTuNgay";
            ckbTuNgay.Size = new Size(84, 24);
            ckbTuNgay.TabIndex = 4;
            ckbTuNgay.Text = "Từ ngày";
            ckbTuNgay.UseVisualStyleBackColor = true;
            // 
            // LICHSUHOADON
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 693);
            Controls.Add(tlpall);
            Name = "LICHSUHOADON";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lịch sử hóa đơn & trả hàng";
            Load += LICHSUHOADON_Load;
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpBoLoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            gbLoc.ResumeLayout(false);
            gbLoc.PerformLayout();
            tlpend.ResumeLayout(false);
            tabLS.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tlpthongtin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            tlploc.ResumeLayout(false);
            tlpLSTH.ResumeLayout(false);
            tlpbolocLSTH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVienTH).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHDTH).EndInit();
            gbLocTH.ResumeLayout(false);
            gbLocTH.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpBoLoc;
        private DataGridView dgvHoaDon;
        private TableLayoutPanel tlpend;
        private Button btnThoat;
        private Button btnQuayLai;
        private GroupBox gbLoc;
        private DateTimePicker dTPTuNgay;
        private DateTimePicker dTPDenNgay;
        private CheckBox cBDenNgay;
        private CheckBox cBTuNgay;
        private TextBox txtMaNhanVien;
        private CheckBox cBNhanVienBan;
        private TextBox txtTimKiem;
        private Label lbMaHoaDon;
        private Button btnLamMoi;
        private Button btnLocDuLieu;
        private Button btnXuatPDF;
        private TabControl tabLS;
        private TabPage tabPage1;
        private TableLayoutPanel tlpthongtin;
        private DataGridView dgvNhanVien;
        private TabPage tabPage2;
        private TableLayoutPanel tlploc;
        private TableLayoutPanel tlpLSTH;
        private DataGridView dgvHDTH;
        private TableLayoutPanel tlpbolocLSTH;
        private DataGridView dgvNhanVienTH;
        private GroupBox gbLocTH;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private TextBox txtMaNVTH;
        private TextBox txtTim;
        private Button btnloc;
        private Label lbTim;
        private CheckBox ckbNVTH;
        private CheckBox ckbTuNgay;
        private CheckBox ckbDenNgay;
    }
}