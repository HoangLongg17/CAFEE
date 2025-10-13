namespace CF36
{
    partial class ThanhToan
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
            tLPall = new TableLayoutPanel();
            picLogo = new PictureBox();
            tlpthan = new TableLayoutPanel();
            pnThanhToan = new Panel();
            tlpend = new TableLayoutPanel();
            btnThoat = new Button();
            btnQuayLai = new Button();
            tlpThoiTIen = new TableLayoutPanel();
            lbTienKhachDua = new Label();
            lbTienTraLai = new Label();
            txtTienKhachDua = new TextBox();
            txtTienTraLai = new TextBox();
            btnThanhtoan = new Button();
            lbTongTien = new Label();
            flpSanPham = new FlowLayoutPanel();
            tLPall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpthan.SuspendLayout();
            pnThanhToan.SuspendLayout();
            tlpend.SuspendLayout();
            tlpThoiTIen.SuspendLayout();
            SuspendLayout();
            // 
            // tLPall
            // 
            tLPall.ColumnCount = 1;
            tLPall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tLPall.Controls.Add(picLogo, 0, 0);
            tLPall.Controls.Add(tlpthan, 0, 1);
            tLPall.Dock = DockStyle.Fill;
            tLPall.Location = new Point(0, 0);
            tLPall.Name = "tLPall";
            tLPall.RowCount = 2;
            tLPall.RowStyles.Add(new RowStyle(SizeType.Percent, 14.821764F));
            tLPall.RowStyles.Add(new RowStyle(SizeType.Percent, 85.17824F));
            tLPall.Size = new Size(800, 533);
            tLPall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(794, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpthan
            // 
            tlpthan.ColumnCount = 2;
            tlpthan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.576828F));
            tlpthan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.423172F));
            tlpthan.Controls.Add(pnThanhToan, 1, 0);
            tlpthan.Controls.Add(flpSanPham, 0, 0);
            tlpthan.Dock = DockStyle.Fill;
            tlpthan.Location = new Point(3, 82);
            tlpthan.Name = "tlpthan";
            tlpthan.RowCount = 1;
            tlpthan.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpthan.Size = new Size(794, 448);
            tlpthan.TabIndex = 1;
            // 
            // pnThanhToan
            // 
            pnThanhToan.Controls.Add(tlpend);
            pnThanhToan.Controls.Add(tlpThoiTIen);
            pnThanhToan.Controls.Add(lbTongTien);
            pnThanhToan.Dock = DockStyle.Fill;
            pnThanhToan.Location = new Point(349, 3);
            pnThanhToan.Name = "pnThanhToan";
            pnThanhToan.Size = new Size(442, 442);
            pnThanhToan.TabIndex = 0;
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 2;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.6425323F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.3574677F));
            tlpend.Controls.Add(btnThoat, 1, 0);
            tlpend.Controls.Add(btnQuayLai, 0, 0);
            tlpend.Dock = DockStyle.Top;
            tlpend.Location = new Point(0, 232);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 2;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpend.Size = new Size(442, 125);
            tlpend.TabIndex = 2;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(218, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(133, 56);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuayLai.Location = new Point(89, 3);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(123, 56);
            btnQuayLai.TabIndex = 1;
            btnQuayLai.Text = "QUAY LẠI";
            btnQuayLai.UseVisualStyleBackColor = true;
            // 
            // tlpThoiTIen
            // 
            tlpThoiTIen.ColumnCount = 2;
            tlpThoiTIen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.22172F));
            tlpThoiTIen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.77828F));
            tlpThoiTIen.Controls.Add(lbTienKhachDua, 0, 0);
            tlpThoiTIen.Controls.Add(lbTienTraLai, 0, 1);
            tlpThoiTIen.Controls.Add(txtTienKhachDua, 1, 0);
            tlpThoiTIen.Controls.Add(txtTienTraLai, 1, 1);
            tlpThoiTIen.Controls.Add(btnThanhtoan, 1, 2);
            tlpThoiTIen.Dock = DockStyle.Top;
            tlpThoiTIen.Location = new Point(0, 72);
            tlpThoiTIen.Name = "tlpThoiTIen";
            tlpThoiTIen.RowCount = 3;
            tlpThoiTIen.RowStyles.Add(new RowStyle(SizeType.Percent, 23.75F));
            tlpThoiTIen.RowStyles.Add(new RowStyle(SizeType.Percent, 23.75F));
            tlpThoiTIen.RowStyles.Add(new RowStyle(SizeType.Percent, 51.875F));
            tlpThoiTIen.Size = new Size(442, 160);
            tlpThoiTIen.TabIndex = 1;
            // 
            // lbTienKhachDua
            // 
            lbTienKhachDua.Anchor = AnchorStyles.Right;
            lbTienKhachDua.AutoSize = true;
            lbTienKhachDua.Location = new Point(26, 9);
            lbTienKhachDua.Name = "lbTienKhachDua";
            lbTienKhachDua.Size = new Size(109, 20);
            lbTienKhachDua.TabIndex = 0;
            lbTienKhachDua.Text = "Tiền khách đưa";
            // 
            // lbTienTraLai
            // 
            lbTienTraLai.Anchor = AnchorStyles.Right;
            lbTienTraLai.AutoSize = true;
            lbTienTraLai.Location = new Point(56, 47);
            lbTienTraLai.Name = "lbTienTraLai";
            lbTienTraLai.Size = new Size(79, 20);
            lbTienTraLai.TabIndex = 1;
            lbTienTraLai.Text = "Tiền trả lại";
            // 
            // txtTienKhachDua
            // 
            txtTienKhachDua.Anchor = AnchorStyles.Left;
            txtTienKhachDua.Location = new Point(141, 5);
            txtTienKhachDua.Name = "txtTienKhachDua";
            txtTienKhachDua.Size = new Size(298, 27);
            txtTienKhachDua.TabIndex = 3;
            // 
            // txtTienTraLai
            // 
            txtTienTraLai.Anchor = AnchorStyles.Left;
            txtTienTraLai.Location = new Point(141, 43);
            txtTienTraLai.Name = "txtTienTraLai";
            txtTienTraLai.Size = new Size(298, 27);
            txtTienTraLai.TabIndex = 3;
            // 
            // btnThanhtoan
            // 
            btnThanhtoan.Location = new Point(141, 79);
            btnThanhtoan.Name = "btnThanhtoan";
            btnThanhtoan.Size = new Size(157, 78);
            btnThanhtoan.TabIndex = 2;
            btnThanhtoan.Text = "THANH TOÁN";
            btnThanhtoan.UseVisualStyleBackColor = true;
            // 
            // lbTongTien
            // 
            lbTongTien.Dock = DockStyle.Top;
            lbTongTien.Location = new Point(0, 0);
            lbTongTien.Name = "lbTongTien";
            lbTongTien.Size = new Size(442, 72);
            lbTongTien.TabIndex = 0;
            lbTongTien.Text = "Tổng tiền";
            lbTongTien.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpSanPham
            // 
            flpSanPham.Dock = DockStyle.Top;
            flpSanPham.Location = new Point(3, 3);
            flpSanPham.Name = "flpSanPham";
            flpSanPham.Size = new Size(340, 442);
            flpSanPham.TabIndex = 1;
            // 
            // ThanhToan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 533);
            Controls.Add(tLPall);
            Name = "ThanhToan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thanh toán";
            tLPall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpthan.ResumeLayout(false);
            pnThanhToan.ResumeLayout(false);
            tlpend.ResumeLayout(false);
            tlpThoiTIen.ResumeLayout(false);
            tlpThoiTIen.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tLPall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpthan;
        private Panel pnThanhToan;
        private TableLayoutPanel tlpThoiTIen;
        private Label lbTongTien;
        private Label lbTienKhachDua;
        private Label lbTienTraLai;
        private Button btnThanhtoan;
        private FlowLayoutPanel flpSanPham;
        private TableLayoutPanel tlpend;
        private Button btnThoat;
        private Button btnQuayLai;
        private TextBox txtTienKhachDua;
        private TextBox txtTienTraLai;
    }
}