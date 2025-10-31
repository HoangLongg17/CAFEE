namespace CF36
{
    partial class ThemTonKho
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tlpend = new TableLayoutPanel();
            btnThem = new Button();
            btnThoat = new Button();
            picLogo = new PictureBox();
            tlpall = new TableLayoutPanel();
            dgvThemkho = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            tlpThongtin = new TableLayoutPanel();
            lbChonNhaCungCap = new Label();
            lbChonSanPham = new Label();
            txtTimKiem = new TextBox();
            txtSoLuong = new TextBox();
            lbGiaNhap = new Label();
            cbbNhaCungCap = new ComboBox();
            lbNhapSoLuong = new Label();
            txtGiaNhap = new TextBox();
            lbltongtien = new Label();
            texttongtien = new TextBox();
            tlpend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThemkho).BeginInit();
            tlpThongtin.SuspendLayout();
            SuspendLayout();
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 3;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.85787F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.8934F));
            tlpend.Controls.Add(btnThem, 1, 0);
            tlpend.Controls.Add(btnThoat, 2, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 512);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(776, 58);
            tlpend.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Location = new Point(507, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(126, 52);
            btnThem.TabIndex = 1;
            btnThem.Text = "THÊM";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(639, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(134, 52);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click_1;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(776, 89);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(dgvThemkho, 0, 2);
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpThongtin, 0, 1);
            tlpall.Controls.Add(tlpend, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.5384617F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 37.787056F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 34.4467659F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 10.9615383F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlpall.Size = new Size(782, 573);
            tlpall.TabIndex = 0;
            // 
            // dgvThemkho
            // 
            dgvThemkho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvThemkho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvThemkho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThemkho.Columns.AddRange(new DataGridViewColumn[] { MaSP, TenSP, Size, SoLuong });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvThemkho.DefaultCellStyle = dataGridViewCellStyle2;
            dgvThemkho.Dock = DockStyle.Fill;
            dgvThemkho.Location = new Point(3, 315);
            dgvThemkho.Name = "dgvThemkho";
            dgvThemkho.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvThemkho.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvThemkho.RowHeadersWidth = 51;
            dgvThemkho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThemkho.Size = new Size(776, 191);
            dgvThemkho.TabIndex = 4;
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "MaSP";
            MaSP.HeaderText = "Mã sản phẩm";
            MaSP.MinimumWidth = 6;
            MaSP.Name = "MaSP";
            MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            TenSP.DataPropertyName = "TenSP";
            TenSP.HeaderText = "Tên sản phẩm";
            TenSP.MinimumWidth = 6;
            TenSP.Name = "TenSP";
            TenSP.ReadOnly = true;
            // 
            // Size
            // 
            Size.DataPropertyName = "Size";
            Size.HeaderText = "Size";
            Size.MinimumWidth = 6;
            Size.Name = "Size";
            Size.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // tlpThongtin
            // 
            tlpThongtin.ColumnCount = 2;
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpThongtin.Controls.Add(lbChonNhaCungCap, 0, 0);
            tlpThongtin.Controls.Add(lbChonSanPham, 0, 2);
            tlpThongtin.Controls.Add(txtTimKiem, 0, 3);
            tlpThongtin.Controls.Add(txtSoLuong, 1, 3);
            tlpThongtin.Controls.Add(lbGiaNhap, 1, 0);
            tlpThongtin.Controls.Add(cbbNhaCungCap, 0, 1);
            tlpThongtin.Controls.Add(lbNhapSoLuong, 1, 2);
            tlpThongtin.Controls.Add(txtGiaNhap, 1, 1);
            tlpThongtin.Controls.Add(lbltongtien, 1, 4);
            tlpThongtin.Controls.Add(texttongtien, 1, 5);
            tlpThongtin.Dock = DockStyle.Fill;
            tlpThongtin.Location = new Point(3, 98);
            tlpThongtin.Name = "tlpThongtin";
            tlpThongtin.RowCount = 6;
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 20.930233F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 28.125F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 23.4375F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 27.1929817F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tlpThongtin.Size = new Size(776, 211);
            tlpThongtin.TabIndex = 1;
            tlpThongtin.Paint += tlpThongtin_Paint;
            // 
            // lbChonNhaCungCap
            // 
            lbChonNhaCungCap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbChonNhaCungCap.AutoSize = true;
            lbChonNhaCungCap.Location = new Point(3, 10);
            lbChonNhaCungCap.Name = "lbChonNhaCungCap";
            lbChonNhaCungCap.Size = new Size(135, 20);
            lbChonNhaCungCap.TabIndex = 0;
            lbChonNhaCungCap.Text = "Chọn nhà cung cấp";
            // 
            // lbChonSanPham
            // 
            lbChonSanPham.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbChonSanPham.AutoSize = true;
            lbChonSanPham.Location = new Point(3, 85);
            lbChonSanPham.Name = "lbChonSanPham";
            lbChonSanPham.Size = new Size(142, 20);
            lbChonSanPham.TabIndex = 2;
            lbChonSanPham.Text = "Tìm kiếm sản phẩm ";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(3, 108);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(380, 27);
            txtTimKiem.TabIndex = 3;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(391, 108);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(380, 27);
            txtSoLuong.TabIndex = 4;
            // 
            // lbGiaNhap
            // 
            lbGiaNhap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbGiaNhap.AutoSize = true;
            lbGiaNhap.Location = new Point(391, 10);
            lbGiaNhap.Name = "lbGiaNhap";
            lbGiaNhap.Size = new Size(68, 20);
            lbGiaNhap.TabIndex = 6;
            lbGiaNhap.Text = "Giá nhập";
            lbGiaNhap.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbbNhaCungCap
            // 
            cbbNhaCungCap.FormattingEnabled = true;
            cbbNhaCungCap.Location = new Point(3, 33);
            cbbNhaCungCap.Name = "cbbNhaCungCap";
            cbbNhaCungCap.Size = new Size(380, 28);
            cbbNhaCungCap.TabIndex = 1;
            // 
            // lbNhapSoLuong
            // 
            lbNhapSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbNhapSoLuong.AutoSize = true;
            lbNhapSoLuong.Location = new Point(391, 85);
            lbNhapSoLuong.Name = "lbNhapSoLuong";
            lbNhapSoLuong.Size = new Size(162, 20);
            lbNhapSoLuong.TabIndex = 5;
            lbNhapSoLuong.Text = "Số lượng nhập vào kho";
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Location = new Point(391, 33);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(380, 27);
            txtGiaNhap.TabIndex = 7;
            // 
            // lbltongtien
            // 
            lbltongtien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbltongtien.AutoSize = true;
            lbltongtien.Location = new Point(391, 148);
            lbltongtien.Name = "lbltongtien";
            lbltongtien.Size = new Size(72, 20);
            lbltongtien.TabIndex = 9;
            lbltongtien.Text = "Tổng tiền";
            lbltongtien.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // texttongtien
            // 
            texttongtien.Location = new Point(391, 171);
            texttongtien.Name = "texttongtien";
            texttongtien.ReadOnly = true;
            texttongtien.Size = new Size(380, 27);
            texttongtien.TabIndex = 13;
            // 
            // ThemTonKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 573);
            Controls.Add(tlpall);
            Name = "ThemTonKho";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm tồn kho";
            Load += ThemTonKho_Load;
            tlpend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThemkho).EndInit();
            tlpThongtin.ResumeLayout(false);
            tlpThongtin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpend;
        private Button btnThoat;
        private Button btnThem;
        private PictureBox picLogo;
        private TableLayoutPanel tlpall;
        private DataGridView dgvThemkho;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn SoLuong;
        private TableLayoutPanel tlpThongtin;
        private Label lbChonNhaCungCap;
        private Label lbChonSanPham;
        private TextBox txtTimKiem;
        private TextBox txtSoLuong;
        private Label lbGiaNhap;
        private ComboBox cbbNhaCungCap;
        private Label lbNhapSoLuong;
        private TextBox txtGiaNhap;
        private Label lbltongtien;
        private TextBox texttongtien;
    }
}