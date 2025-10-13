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
            btnThoat = new Button();
            btnQuayLai = new Button();
            btnLamMoi = new Button();
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
            tlpall.Name = "tlpall";
            tlpall.RowCount = 3;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.3669071F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 74.25569F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 9.457093F));
            tlpall.Size = new Size(865, 571);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(859, 87);
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
            tlpBoLoc.Location = new Point(3, 96);
            tlpBoLoc.Name = "tlpBoLoc";
            tlpBoLoc.RowCount = 2;
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 46.0431671F));
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 53.9568329F));
            tlpBoLoc.Size = new Size(859, 417);
            tlpBoLoc.TabIndex = 1;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(3, 195);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(853, 219);
            dgvHoaDon.TabIndex = 2;
            // 
            // tlpThongTin
            // 
            tlpThongTin.ColumnCount = 2;
            tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.3692856F));
            tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.6307144F));
            tlpThongTin.Controls.Add(gbLoc, 0, 0);
            tlpThongTin.Controls.Add(dgvNhanVien, 1, 0);
            tlpThongTin.Dock = DockStyle.Fill;
            tlpThongTin.Location = new Point(3, 3);
            tlpThongTin.Name = "tlpThongTin";
            tlpThongTin.RowCount = 1;
            tlpThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThongTin.Size = new Size(853, 186);
            tlpThongTin.TabIndex = 3;
            // 
            // gbLoc
            // 
            gbLoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            gbLoc.Size = new Size(381, 180);
            gbLoc.TabIndex = 0;
            gbLoc.TabStop = false;
            gbLoc.Text = "Lọc theo";
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
            lbMaHoaDon.Location = new Point(11, 34);
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
            dTPDenNgay.Location = new Point(123, 146);
            dTPDenNgay.Name = "dTPDenNgay";
            dTPDenNgay.Size = new Size(250, 27);
            dTPDenNgay.TabIndex = 5;
            // 
            // cBDenNgay
            // 
            cBDenNgay.AutoSize = true;
            cBDenNgay.Location = new Point(11, 150);
            cBDenNgay.Name = "cBDenNgay";
            cBDenNgay.Size = new Size(94, 24);
            cBDenNgay.TabIndex = 4;
            cBDenNgay.Text = "Đến ngày";
            cBDenNgay.UseVisualStyleBackColor = true;
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
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(390, 3);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(460, 180);
            dgvNhanVien.TabIndex = 1;
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 3;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.40978F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.0861464F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.38766F));
            tlpend.Controls.Add(btnThoat, 2, 0);
            tlpend.Controls.Add(btnQuayLai, 1, 0);
            tlpend.Controls.Add(btnLamMoi, 0, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 519);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(859, 49);
            tlpend.TabIndex = 2;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(746, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(110, 43);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuayLai.Location = new Point(625, 3);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(115, 43);
            btnQuayLai.TabIndex = 1;
            btnQuayLai.Text = "QUAY LẠI";
            btnQuayLai.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(498, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(121, 43);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // LICHSUHOADON
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 571);
            Controls.Add(tlpall);
            Name = "LICHSUHOADON";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lịch sử hóa đơn";
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
    }
}