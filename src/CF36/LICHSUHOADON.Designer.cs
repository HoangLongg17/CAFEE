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
            tlpThongTin = new TableLayoutPanel();
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
            dgvNhanVien = new DataGridView();
            tlpend = new TableLayoutPanel();
            btnLamMoi = new Button();
            btnThoat = new Button();
            btnQuayLai = new Button();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            tlpThongTin.SuspendLayout();
            gbLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            tlpend.SuspendLayout();
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
            tlpall.Margin = new Padding(3, 2, 3, 2);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 3;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.3669071F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 74.25569F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 9.457093F));
            tlpall.Size = new Size(1055, 428);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 2);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(1049, 65);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpBoLoc
            // 
            tlpBoLoc.ColumnCount = 1;
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.8132F));
            tlpBoLoc.Controls.Add(dgvHoaDon, 0, 1);
            tlpBoLoc.Controls.Add(tlpThongTin, 0, 0);
            tlpBoLoc.Dock = DockStyle.Fill;
            tlpBoLoc.Location = new Point(3, 71);
            tlpBoLoc.Margin = new Padding(3, 2, 3, 2);
            tlpBoLoc.Name = "tlpBoLoc";
            tlpBoLoc.RowCount = 2;
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 46.0431671F));
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 53.9568329F));
            tlpBoLoc.Size = new Size(1049, 313);
            tlpBoLoc.TabIndex = 1;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(3, 146);
            dgvHoaDon.Margin = new Padding(3, 2, 3, 2);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(1043, 165);
            dgvHoaDon.TabIndex = 2;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;
            // 
            // tlpThongTin
            // 
            tlpThongTin.ColumnCount = 2;
            tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.3692856F));
            tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.6307144F));
            tlpThongTin.Controls.Add(gbLoc, 0, 0);
            tlpThongTin.Controls.Add(dgvNhanVien, 1, 0);
            tlpThongTin.Dock = DockStyle.Fill;
            tlpThongTin.Location = new Point(3, 2);
            tlpThongTin.Margin = new Padding(3, 2, 3, 2);
            tlpThongTin.Name = "tlpThongTin";
            tlpThongTin.RowCount = 1;
            tlpThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThongTin.Size = new Size(1043, 140);
            tlpThongTin.TabIndex = 3;
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
            gbLoc.Location = new Point(3, 2);
            gbLoc.Margin = new Padding(3, 2, 3, 2);
            gbLoc.Name = "gbLoc";
            gbLoc.Padding = new Padding(3, 2, 3, 2);
            gbLoc.Size = new Size(467, 136);
            gbLoc.TabIndex = 0;
            gbLoc.TabStop = false;
            gbLoc.Text = "Lọc theo";
            // 
            // btnXuatPDF
            // 
            btnXuatPDF.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnXuatPDF.Location = new Point(333, 82);
            btnXuatPDF.Margin = new Padding(3, 2, 3, 2);
            btnXuatPDF.Name = "btnXuatPDF";
            btnXuatPDF.Size = new Size(128, 50);
            btnXuatPDF.TabIndex = 3;
            btnXuatPDF.Text = "XUẤT FILE PDF";
            btnXuatPDF.UseVisualStyleBackColor = true;
            btnXuatPDF.Click += btnXuatPDF_Click;
            // 
            // btnLocDuLieu
            // 
            btnLocDuLieu.Location = new Point(333, 26);
            btnLocDuLieu.Name = "btnLocDuLieu";
            btnLocDuLieu.Size = new Size(128, 52);
            btnLocDuLieu.TabIndex = 8;
            btnLocDuLieu.Text = "Lọc dữ liệu";
            btnLocDuLieu.UseVisualStyleBackColor = true;
            btnLocDuLieu.Click += btnLocDuLieu_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(76, 23);
            txtTimKiem.Margin = new Padding(3, 2, 3, 2);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(251, 23);
            txtTimKiem.TabIndex = 7;
            // 
            // lbMaHoaDon
            // 
            lbMaHoaDon.AutoSize = true;
            lbMaHoaDon.Location = new Point(10, 26);
            lbMaHoaDon.Name = "lbMaHoaDon";
            lbMaHoaDon.Size = new Size(56, 15);
            lbMaHoaDon.TabIndex = 6;
            lbMaHoaDon.Text = "Tìm kiếm";
            // 
            // dTPTuNgay
            // 
            dTPTuNgay.Location = new Point(108, 82);
            dTPTuNgay.Margin = new Padding(3, 2, 3, 2);
            dTPTuNgay.Name = "dTPTuNgay";
            dTPTuNgay.Size = new Size(219, 23);
            dTPTuNgay.TabIndex = 5;
            // 
            // dTPDenNgay
            // 
            dTPDenNgay.Location = new Point(108, 110);
            dTPDenNgay.Margin = new Padding(3, 2, 3, 2);
            dTPDenNgay.Name = "dTPDenNgay";
            dTPDenNgay.Size = new Size(219, 23);
            dTPDenNgay.TabIndex = 5;
            // 
            // cBDenNgay
            // 
            cBDenNgay.AutoSize = true;
            cBDenNgay.Location = new Point(10, 112);
            cBDenNgay.Margin = new Padding(3, 2, 3, 2);
            cBDenNgay.Name = "cBDenNgay";
            cBDenNgay.Size = new Size(76, 19);
            cBDenNgay.TabIndex = 4;
            cBDenNgay.Text = "Đến ngày";
            cBDenNgay.UseVisualStyleBackColor = true;
            cBDenNgay.CheckedChanged += cBDenNgay_CheckedChanged;
            // 
            // cBTuNgay
            // 
            cBTuNgay.AutoSize = true;
            cBTuNgay.Location = new Point(10, 85);
            cBTuNgay.Margin = new Padding(3, 2, 3, 2);
            cBTuNgay.Name = "cBTuNgay";
            cBTuNgay.Size = new Size(68, 19);
            cBTuNgay.TabIndex = 2;
            cBTuNgay.Text = "Từ ngày";
            cBTuNgay.UseVisualStyleBackColor = true;
            cBTuNgay.CheckedChanged += cBTuNgay_CheckedChanged;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(125, 53);
            txtMaNhanVien.Margin = new Padding(3, 2, 3, 2);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(202, 23);
            txtMaNhanVien.TabIndex = 1;
            txtMaNhanVien.Text = "Nhập mã nhân viên";
            // 
            // cBNhanVienBan
            // 
            cBNhanVienBan.AutoSize = true;
            cBNhanVienBan.Location = new Point(10, 55);
            cBNhanVienBan.Margin = new Padding(3, 2, 3, 2);
            cBNhanVienBan.Name = "cBNhanVienBan";
            cBNhanVienBan.Size = new Size(103, 19);
            cBNhanVienBan.TabIndex = 0;
            cBNhanVienBan.Text = "Nhân viên bán";
            cBNhanVienBan.UseVisualStyleBackColor = true;
            cBNhanVienBan.CheckedChanged += cBNhanVienBan_CheckedChanged;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(476, 2);
            dgvNhanVien.Margin = new Padding(3, 2, 3, 2);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(564, 136);
            dgvNhanVien.TabIndex = 1;
            dgvNhanVien.SelectionChanged += dgvNhanVien_SelectionChanged;
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 3;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.40978F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.0861464F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.38766F));
            tlpend.Controls.Add(btnLamMoi, 0, 0);
            tlpend.Controls.Add(btnThoat, 2, 0);
            tlpend.Controls.Add(btnQuayLai, 1, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 388);
            tlpend.Margin = new Padding(3, 2, 3, 2);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(1049, 38);
            tlpend.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(651, 2);
            btnLamMoi.Margin = new Padding(3, 2, 3, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(106, 32);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(910, 2);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(96, 32);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuayLai.Location = new Point(803, 2);
            btnQuayLai.Margin = new Padding(3, 2, 3, 2);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(101, 32);
            btnQuayLai.TabIndex = 1;
            btnQuayLai.Text = "QUAY LẠI";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // LICHSUHOADON
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 428);
            Controls.Add(tlpall);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LICHSUHOADON";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lịch sử hóa đơn";
            Load += LICHSUHOADON_Load;
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpBoLoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            tlpThongTin.ResumeLayout(false);
            gbLoc.ResumeLayout(false);
            gbLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            tlpend.ResumeLayout(false);
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
        private TableLayoutPanel tlpThongTin;
        private GroupBox gbLoc;
        private DateTimePicker dTPTuNgay;
        private DateTimePicker dTPDenNgay;
        private CheckBox cBDenNgay;
        private CheckBox cBTuNgay;
        private TextBox txtMaNhanVien;
        private CheckBox cBNhanVienBan;
        private DataGridView dgvNhanVien;
        private TextBox txtTimKiem;
        private Label lbMaHoaDon;
        private Button btnLamMoi;
        private Button btnLocDuLieu;
        private Button btnXuatPDF;
    }
}