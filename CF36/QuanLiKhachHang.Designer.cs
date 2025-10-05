namespace CF36
{
    partial class QuanLiKhachHang
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
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnThemKhachHang = new Button();
            btnSuaKhachHang = new Button();
            dgvKhachHang = new DataGridView();
            tlpend = new TableLayoutPanel();
            btnThoat = new Button();
            btnQuayLai = new Button();
            btnLamMoi = new Button();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            tlpend.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpBoLoc, 0, 1);
            tlpall.Controls.Add(dgvKhachHang, 0, 2);
            tlpall.Controls.Add(tlpend, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 15.92233F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 19.61165F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 53.00971F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 11.84466F));
            tlpall.Size = new Size(800, 515);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(794, 75);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpBoLoc
            // 
            tlpBoLoc.ColumnCount = 4;
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBoLoc.Controls.Add(lbTimKiem, 1, 0);
            tlpBoLoc.Controls.Add(txtTimKiem, 2, 0);
            tlpBoLoc.Controls.Add(btnThemKhachHang, 3, 1);
            tlpBoLoc.Controls.Add(btnSuaKhachHang, 2, 1);
            tlpBoLoc.Dock = DockStyle.Fill;
            tlpBoLoc.Location = new Point(3, 84);
            tlpBoLoc.Name = "tlpBoLoc";
            tlpBoLoc.RowCount = 2;
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 34.3434334F));
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 65.65656F));
            tlpBoLoc.Size = new Size(794, 94);
            tlpBoLoc.TabIndex = 1;
            // 
            // lbTimKiem
            // 
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(201, 0);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.Size = new Size(70, 20);
            lbTimKiem.TabIndex = 0;
            lbTimKiem.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(399, 3);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(190, 27);
            txtTimKiem.TabIndex = 1;
            // 
            // btnThemKhachHang
            // 
            btnThemKhachHang.Location = new Point(597, 35);
            btnThemKhachHang.Name = "btnThemKhachHang";
            btnThemKhachHang.Size = new Size(193, 56);
            btnThemKhachHang.TabIndex = 2;
            btnThemKhachHang.Text = "Thêm khách hàng";
            btnThemKhachHang.UseVisualStyleBackColor = true;
            btnThemKhachHang.Click += btnThemKhachHang_Click;
            // 
            // btnSuaKhachHang
            // 
            btnSuaKhachHang.Location = new Point(399, 35);
            btnSuaKhachHang.Name = "btnSuaKhachHang";
            btnSuaKhachHang.Size = new Size(191, 56);
            btnSuaKhachHang.TabIndex = 3;
            btnSuaKhachHang.Text = "Sửa thông tin";
            btnSuaKhachHang.UseVisualStyleBackColor = true;
            btnSuaKhachHang.Click += btnSuaKhachHang_Click;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.Location = new Point(3, 184);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(794, 265);
            dgvKhachHang.TabIndex = 2;
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 3;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.62469F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6246853F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6246853F));
            tlpend.Controls.Add(btnThoat, 2, 0);
            tlpend.Controls.Add(btnQuayLai, 1, 0);
            tlpend.Controls.Add(btnLamMoi, 0, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 455);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(794, 57);
            tlpend.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(664, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(127, 51);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(532, 3);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(125, 51);
            btnQuayLai.TabIndex = 1;
            btnQuayLai.Text = "QUAY LẠI";
            btnQuayLai.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(396, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(130, 51);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // QuanLiKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 515);
            Controls.Add(tlpall);
            Name = "QuanLiKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lí khách hàng";
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpBoLoc.ResumeLayout(false);
            tlpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            tlpend.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpBoLoc;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private Button btnThemKhachHang;
        private Button btnSuaKhachHang;
        private DataGridView dgvKhachHang;
        private TableLayoutPanel tlpend;
        private Button btnThoat;
        private Button btnQuayLai;
        private Button btnLamMoi;
    }
}