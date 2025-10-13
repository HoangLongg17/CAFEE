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
            tlpend.Location = new Point(3, 383);
            tlpend.Margin = new Padding(3, 2, 3, 2);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(678, 45);
            tlpend.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Location = new Point(442, 2);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 34);
            btnThem.TabIndex = 1;
            btnThem.Text = "THÊM";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(558, 2);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(117, 34);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 2);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(678, 67);
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
            tlpall.Margin = new Padding(3, 2, 3, 2);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.5384617F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 37.787056F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 34.4467659F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 10.9615383F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpall.Size = new Size(684, 430);
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
            dgvThemkho.Location = new Point(3, 235);
            dgvThemkho.Margin = new Padding(3, 2, 3, 2);
            dgvThemkho.Name = "dgvThemkho";
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
            dgvThemkho.Size = new Size(678, 144);
            dgvThemkho.TabIndex = 4;
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "MaSP";
            MaSP.HeaderText = "Mã sản phẩm";
            MaSP.Name = "MaSP";
            // 
            // TenSP
            // 
            TenSP.DataPropertyName = "TenSP";
            TenSP.HeaderText = "Tên sản phẩm";
            TenSP.Name = "TenSP";
            // 
            // Size
            // 
            Size.DataPropertyName = "Size";
            Size.HeaderText = "Size";
            Size.Name = "Size";
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số lượng";
            SoLuong.Name = "SoLuong";
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
            tlpThongtin.Location = new Point(3, 73);
            tlpThongtin.Margin = new Padding(3, 2, 3, 2);
            tlpThongtin.Name = "tlpThongtin";
            tlpThongtin.RowCount = 6;
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 20.930233F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 28.125F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 23.4375F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 27.1929817F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tlpThongtin.Size = new Size(678, 158);
            tlpThongtin.TabIndex = 1;
            tlpThongtin.Paint += tlpThongtin_Paint;
            // 
            // lbChonNhaCungCap
            // 
            lbChonNhaCungCap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbChonNhaCungCap.AutoSize = true;
            lbChonNhaCungCap.Location = new Point(3, 8);
            lbChonNhaCungCap.Name = "lbChonNhaCungCap";
            lbChonNhaCungCap.Size = new Size(111, 15);
            lbChonNhaCungCap.TabIndex = 0;
            lbChonNhaCungCap.Text = "Chọn nhà cung cấp";
            // 
            // lbChonSanPham
            // 
            lbChonSanPham.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbChonSanPham.AutoSize = true;
            lbChonSanPham.Location = new Point(3, 64);
            lbChonSanPham.Name = "lbChonSanPham";
            lbChonSanPham.Size = new Size(114, 15);
            lbChonSanPham.TabIndex = 2;
            lbChonSanPham.Text = "Tìm kiếm sản phẩm ";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(3, 81);
            txtTimKiem.Margin = new Padding(3, 2, 3, 2);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(333, 23);
            txtTimKiem.TabIndex = 3;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(342, 81);
            txtSoLuong.Margin = new Padding(3, 2, 3, 2);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(333, 23);
            txtSoLuong.TabIndex = 4;
            // 
            // lbGiaNhap
            // 
            lbGiaNhap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbGiaNhap.AutoSize = true;
            lbGiaNhap.Location = new Point(342, 8);
            lbGiaNhap.Name = "lbGiaNhap";
            lbGiaNhap.Size = new Size(54, 15);
            lbGiaNhap.TabIndex = 6;
            lbGiaNhap.Text = "Giá nhập";
            lbGiaNhap.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbbNhaCungCap
            // 
            cbbNhaCungCap.FormattingEnabled = true;
            cbbNhaCungCap.Location = new Point(3, 25);
            cbbNhaCungCap.Margin = new Padding(3, 2, 3, 2);
            cbbNhaCungCap.Name = "cbbNhaCungCap";
            cbbNhaCungCap.Size = new Size(333, 23);
            cbbNhaCungCap.TabIndex = 1;
            // 
            // lbNhapSoLuong
            // 
            lbNhapSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbNhapSoLuong.AutoSize = true;
            lbNhapSoLuong.Location = new Point(342, 64);
            lbNhapSoLuong.Name = "lbNhapSoLuong";
            lbNhapSoLuong.Size = new Size(129, 15);
            lbNhapSoLuong.TabIndex = 5;
            lbNhapSoLuong.Text = "Số lượng nhập vào kho";
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Location = new Point(342, 25);
            txtGiaNhap.Margin = new Padding(3, 2, 3, 2);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(333, 23);
            txtGiaNhap.TabIndex = 7;
            // 
            // lbltongtien
            // 
            lbltongtien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbltongtien.AutoSize = true;
            lbltongtien.Location = new Point(342, 111);
            lbltongtien.Name = "lbltongtien";
            lbltongtien.Size = new Size(57, 15);
            lbltongtien.TabIndex = 9;
            lbltongtien.Text = "Tổng tiền";
            lbltongtien.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // texttongtien
            // 
            texttongtien.Location = new Point(342, 128);
            texttongtien.Margin = new Padding(3, 2, 3, 2);
            texttongtien.Name = "texttongtien";
            texttongtien.ReadOnly = true;
            texttongtien.Size = new Size(333, 23);
            texttongtien.TabIndex = 13;
            // 
            // ThemTonKho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 430);
            Controls.Add(tlpall);
            Margin = new Padding(3, 2, 3, 2);
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