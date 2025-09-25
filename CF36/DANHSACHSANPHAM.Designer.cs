namespace CF36
{
    partial class DANHSACHSANPHAM
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
            tlpDSSP = new TableLayoutPanel();
            picLogo = new PictureBox();
            pndgv = new Panel();
            dgvDanhSachSanPham = new DataGridView();
            pnButton = new Panel();
            btnQuayLai = new Button();
            btnThoat = new Button();
            tlpTimKiem = new TableLayoutPanel();
            btnTim = new Button();
            txtTimKiem = new TextBox();
            cbbLoaiTimKiem = new ComboBox();
            lbLoaiTimKiem = new Label();
            btnThemSanPham = new Button();
            btnSua = new Button();
            tlpDSSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pndgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSanPham).BeginInit();
            pnButton.SuspendLayout();
            tlpTimKiem.SuspendLayout();
            SuspendLayout();
            // 
            // tlpDSSP
            // 
            tlpDSSP.ColumnCount = 1;
            tlpDSSP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpDSSP.Controls.Add(picLogo, 0, 0);
            tlpDSSP.Controls.Add(pndgv, 0, 2);
            tlpDSSP.Controls.Add(pnButton, 0, 3);
            tlpDSSP.Controls.Add(tlpTimKiem, 0, 1);
            tlpDSSP.Dock = DockStyle.Fill;
            tlpDSSP.Location = new Point(0, 0);
            tlpDSSP.Name = "tlpDSSP";
            tlpDSSP.RowCount = 4;
            tlpDSSP.RowStyles.Add(new RowStyle(SizeType.Percent, 19.1413231F));
            tlpDSSP.RowStyles.Add(new RowStyle(SizeType.Percent, 20.035778F));
            tlpDSSP.RowStyles.Add(new RowStyle(SizeType.Percent, 49.7316628F));
            tlpDSSP.RowStyles.Add(new RowStyle(SizeType.Percent, 10.9974051F));
            tlpDSSP.Size = new Size(800, 559);
            tlpDSSP.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Top;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(794, 101);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // pndgv
            // 
            pndgv.Controls.Add(dgvDanhSachSanPham);
            pndgv.Dock = DockStyle.Fill;
            pndgv.Location = new Point(3, 222);
            pndgv.Name = "pndgv";
            pndgv.Size = new Size(794, 272);
            pndgv.TabIndex = 4;
            // 
            // dgvDanhSachSanPham
            // 
            dgvDanhSachSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDanhSachSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSanPham.Location = new Point(0, 3);
            dgvDanhSachSanPham.Name = "dgvDanhSachSanPham";
            dgvDanhSachSanPham.RowHeadersWidth = 51;
            dgvDanhSachSanPham.Size = new Size(794, 269);
            dgvDanhSachSanPham.TabIndex = 0;
            // 
            // pnButton
            // 
            pnButton.Controls.Add(btnQuayLai);
            pnButton.Controls.Add(btnThoat);
            pnButton.Dock = DockStyle.Fill;
            pnButton.Location = new Point(3, 500);
            pnButton.Name = "pnButton";
            pnButton.Size = new Size(794, 56);
            pnButton.TabIndex = 5;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuayLai.Location = new Point(555, 0);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(113, 53);
            btnQuayLai.TabIndex = 1;
            btnQuayLai.Text = "QUAY LẠI";
            btnQuayLai.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnThoat.Location = new Point(674, 0);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(117, 53);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // tlpTimKiem
            // 
            tlpTimKiem.ColumnCount = 4;
            tlpTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.4030228F));
            tlpTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.4710331F));
            tlpTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTimKiem.Controls.Add(btnTim, 3, 0);
            tlpTimKiem.Controls.Add(txtTimKiem, 2, 0);
            tlpTimKiem.Controls.Add(cbbLoaiTimKiem, 1, 0);
            tlpTimKiem.Controls.Add(lbLoaiTimKiem, 0, 0);
            tlpTimKiem.Controls.Add(btnThemSanPham, 3, 1);
            tlpTimKiem.Controls.Add(btnSua, 2, 1);
            tlpTimKiem.Dock = DockStyle.Fill;
            tlpTimKiem.Location = new Point(3, 110);
            tlpTimKiem.Name = "tlpTimKiem";
            tlpTimKiem.RowCount = 2;
            tlpTimKiem.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTimKiem.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTimKiem.Size = new Size(794, 106);
            tlpTimKiem.TabIndex = 6;
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Left;
            btnTim.Location = new Point(597, 3);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 47);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Location = new Point(363, 13);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(228, 27);
            txtTimKiem.TabIndex = 1;
            // 
            // cbbLoaiTimKiem
            // 
            cbbLoaiTimKiem.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbLoaiTimKiem.FormattingEnabled = true;
            cbbLoaiTimKiem.Location = new Point(201, 12);
            cbbLoaiTimKiem.Name = "cbbLoaiTimKiem";
            cbbLoaiTimKiem.Size = new Size(156, 28);
            cbbLoaiTimKiem.TabIndex = 0;
            // 
            // lbLoaiTimKiem
            // 
            lbLoaiTimKiem.Anchor = AnchorStyles.Right;
            lbLoaiTimKiem.AutoSize = true;
            lbLoaiTimKiem.Location = new Point(88, 16);
            lbLoaiTimKiem.Name = "lbLoaiTimKiem";
            lbLoaiTimKiem.Size = new Size(107, 20);
            lbLoaiTimKiem.TabIndex = 3;
            lbLoaiTimKiem.Text = "Tìm kiếm theo:";
            // 
            // btnThemSanPham
            // 
            btnThemSanPham.Anchor = AnchorStyles.Left;
            btnThemSanPham.Location = new Point(597, 56);
            btnThemSanPham.Name = "btnThemSanPham";
            btnThemSanPham.Size = new Size(155, 47);
            btnThemSanPham.TabIndex = 4;
            btnThemSanPham.Text = "Thêm sản phẩm";
            btnThemSanPham.UseVisualStyleBackColor = true;
            btnThemSanPham.Click += btnThemSanPham_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Right;
            btnSua.Location = new Point(441, 56);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 47);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa sản phẩm";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // DANHSACHSANPHAM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 559);
            Controls.Add(tlpDSSP);
            Name = "DANHSACHSANPHAM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lí sản phẩm";
            tlpDSSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pndgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSanPham).EndInit();
            pnButton.ResumeLayout(false);
            tlpTimKiem.ResumeLayout(false);
            tlpTimKiem.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpDSSP;
        private PictureBox picLogo;
        private Panel pndgv;
        private DataGridView dgvDanhSachSanPham;
        private Panel pnButton;
        private Button btnQuayLai;
        private Button btnThoat;
        private TableLayoutPanel tlpTimKiem;
        private ComboBox cbbLoaiTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private Label lbLoaiTimKiem;
        private Button btnThemSanPham;
        private Button btnSua;
    }
}