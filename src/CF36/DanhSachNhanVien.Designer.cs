namespace CF36
{
    partial class DanhSachNhanVien
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
            tlpTimKiem = new TableLayoutPanel();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            lbLocTheo = new Label();
            cbbLoaiNhanVien = new ComboBox();
            btnThemNhanVien = new Button();
            btnSuaNhanVien = new Button();
            dgvNhanVien = new DataGridView();
            tlpend = new TableLayoutPanel();
            btnThoat = new Button();
            btnQuayLai = new Button();
            btnLamMoi = new Button();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            tlpend.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpTimKiem, 0, 1);
            tlpall.Controls.Add(dgvNhanVien, 0, 2);
            tlpall.Controls.Add(tlpend, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Margin = new Padding(3, 2, 3, 2);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 17.81076F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 19.48052F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 50.2782936F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 12.8014841F));
            tlpall.Size = new Size(1105, 451);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 2);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(1099, 76);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpTimKiem
            // 
            tlpTimKiem.ColumnCount = 5;
            tlpTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.2810459F));
            tlpTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.2679729F));
            tlpTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.87039F));
            tlpTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.6059017F));
            tlpTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 148F));
            tlpTimKiem.Controls.Add(lbTimKiem, 0, 0);
            tlpTimKiem.Controls.Add(txtTimKiem, 1, 0);
            tlpTimKiem.Controls.Add(lbLocTheo, 2, 0);
            tlpTimKiem.Controls.Add(cbbLoaiNhanVien, 3, 0);
            tlpTimKiem.Controls.Add(btnThemNhanVien, 4, 1);
            tlpTimKiem.Controls.Add(btnSuaNhanVien, 3, 1);
            tlpTimKiem.Dock = DockStyle.Fill;
            tlpTimKiem.Location = new Point(3, 82);
            tlpTimKiem.Margin = new Padding(3, 2, 3, 2);
            tlpTimKiem.Name = "tlpTimKiem";
            tlpTimKiem.RowCount = 2;
            tlpTimKiem.RowStyles.Add(new RowStyle(SizeType.Percent, 35.7142868F));
            tlpTimKiem.RowStyles.Add(new RowStyle(SizeType.Percent, 64.28571F));
            tlpTimKiem.Size = new Size(1099, 83);
            tlpTimKiem.TabIndex = 1;
            tlpTimKiem.Paint += tlpTimKiem_Paint;
            // 
            // lbTimKiem
            // 
            lbTimKiem.Anchor = AnchorStyles.Right;
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(123, 7);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.Size = new Size(57, 15);
            lbTimKiem.TabIndex = 0;
            lbTimKiem.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Location = new Point(186, 3);
            txtTimKiem.Margin = new Padding(3, 2, 3, 2);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(262, 23);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // lbLocTheo
            // 
            lbLocTheo.Anchor = AnchorStyles.Right;
            lbLocTheo.AutoSize = true;
            lbLocTheo.Location = new Point(650, 7);
            lbLocTheo.Name = "lbLocTheo";
            lbLocTheo.Size = new Size(53, 15);
            lbLocTheo.TabIndex = 4;
            lbLocTheo.Text = "Lọc theo";
            // 
            // cbbLoaiNhanVien
            // 
            cbbLoaiNhanVien.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbLoaiNhanVien.FormattingEnabled = true;
            cbbLoaiNhanVien.Location = new Point(709, 3);
            cbbLoaiNhanVien.Margin = new Padding(3, 2, 3, 2);
            cbbLoaiNhanVien.Name = "cbbLoaiNhanVien";
            cbbLoaiNhanVien.Size = new Size(237, 23);
            cbbLoaiNhanVien.TabIndex = 5;
            cbbLoaiNhanVien.SelectedIndexChanged += cbbLoaiNhanVien_SelectedIndexChanged;
            // 
            // btnThemNhanVien
            // 
            btnThemNhanVien.Location = new Point(952, 31);
            btnThemNhanVien.Margin = new Padding(3, 2, 3, 2);
            btnThemNhanVien.Name = "btnThemNhanVien";
            btnThemNhanVien.Size = new Size(144, 43);
            btnThemNhanVien.TabIndex = 2;
            btnThemNhanVien.Text = "Thêm nhân viên mới";
            btnThemNhanVien.UseVisualStyleBackColor = true;
            btnThemNhanVien.Click += btnThemNhanVien_Click;
            // 
            // btnSuaNhanVien
            // 
            btnSuaNhanVien.Location = new Point(709, 31);
            btnSuaNhanVien.Margin = new Padding(3, 2, 3, 2);
            btnSuaNhanVien.Name = "btnSuaNhanVien";
            btnSuaNhanVien.Size = new Size(125, 43);
            btnSuaNhanVien.TabIndex = 3;
            btnSuaNhanVien.Text = "Sửa thông tin";
            btnSuaNhanVien.UseVisualStyleBackColor = true;
            btnSuaNhanVien.Click += btnSuaNhanVien_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(3, 169);
            dgvNhanVien.Margin = new Padding(3, 2, 3, 2);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(1099, 221);
            dgvNhanVien.TabIndex = 2;
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 3;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.7952652F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.645132F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.452261F));
            tlpend.Controls.Add(btnThoat, 2, 0);
            tlpend.Controls.Add(btnQuayLai, 1, 0);
            tlpend.Controls.Add(btnLamMoi, 0, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 394);
            tlpend.Margin = new Padding(3, 2, 3, 2);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(1099, 55);
            tlpend.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(931, 2);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(102, 44);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuayLai.Location = new Point(825, 2);
            btnQuayLai.Margin = new Padding(3, 2, 3, 2);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(100, 44);
            btnQuayLai.TabIndex = 1;
            btnQuayLai.Text = "Xóa";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(707, 2);
            btnLamMoi.Margin = new Padding(3, 2, 3, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(112, 44);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // DanhSachNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 451);
            Controls.Add(tlpall);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DanhSachNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lí nhân viên";
            Load += DanhSachNhanVien_Load;
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpTimKiem.ResumeLayout(false);
            tlpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            tlpend.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpTimKiem;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private Button btnThemNhanVien;
        private Button btnSuaNhanVien;
        private Label lbLocTheo;
        private ComboBox cbbLoaiNhanVien;
        private DataGridView dgvNhanVien;
        private TableLayoutPanel tlpend;
        private Button btnThoat;
        private Button btnQuayLai;
        private Button btnLamMoi;
    }
}