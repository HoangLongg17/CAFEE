namespace CF36
{
    partial class XuatKho
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
            panel2 = new Panel();
            tlpThongtin = new TableLayoutPanel();
            lbChonSanPham = new Label();
            txtSoLuong = new TextBox();
            lbxuatSoLuong = new Label();
            txtTimKiem = new TextBox();
            panel3 = new Panel();
            dgvxuatkho = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            picLogo = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnXuat = new Button();
            btnThoat = new Button();
            panel2.SuspendLayout();
            tlpThongtin.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvxuatkho).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(tlpThongtin);
            panel2.Location = new Point(3, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(678, 82);
            panel2.TabIndex = 1;
            // 
            // tlpThongtin
            // 
            tlpThongtin.ColumnCount = 2;
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpThongtin.Controls.Add(lbChonSanPham, 0, 0);
            tlpThongtin.Controls.Add(txtSoLuong, 1, 1);
            tlpThongtin.Controls.Add(lbxuatSoLuong, 1, 0);
            tlpThongtin.Controls.Add(txtTimKiem, 0, 1);
            tlpThongtin.Dock = DockStyle.Fill;
            tlpThongtin.Location = new Point(0, 0);
            tlpThongtin.Margin = new Padding(3, 2, 3, 2);
            tlpThongtin.Name = "tlpThongtin";
            tlpThongtin.RowCount = 2;
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 20.930233F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 28.125F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 23.4375F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 27.1929817F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tlpThongtin.Size = new Size(678, 82);
            tlpThongtin.TabIndex = 2;
            // 
            // lbChonSanPham
            // 
            lbChonSanPham.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbChonSanPham.AutoSize = true;
            lbChonSanPham.Location = new Point(3, 19);
            lbChonSanPham.Name = "lbChonSanPham";
            lbChonSanPham.Size = new Size(114, 15);
            lbChonSanPham.TabIndex = 2;
            lbChonSanPham.Text = "Tìm kiếm sản phẩm ";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Dock = DockStyle.Fill;
            txtSoLuong.Location = new Point(342, 36);
            txtSoLuong.Margin = new Padding(3, 2, 3, 2);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(333, 23);
            txtSoLuong.TabIndex = 4;
            // 
            // lbxuatSoLuong
            // 
            lbxuatSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbxuatSoLuong.AutoSize = true;
            lbxuatSoLuong.Location = new Point(342, 19);
            lbxuatSoLuong.Name = "lbxuatSoLuong";
            lbxuatSoLuong.Size = new Size(103, 15);
            lbxuatSoLuong.TabIndex = 5;
            lbxuatSoLuong.Text = "Số lượng xuất kho";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(3, 36);
            txtTimKiem.Margin = new Padding(3, 2, 3, 2);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(333, 23);
            txtTimKiem.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvxuatkho);
            panel3.Location = new Point(3, 152);
            panel3.Name = "panel3";
            panel3.Size = new Size(678, 228);
            panel3.TabIndex = 2;
            // 
            // dgvxuatkho
            // 
            dgvxuatkho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvxuatkho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvxuatkho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvxuatkho.Columns.AddRange(new DataGridViewColumn[] { MaSP, TenSP, Size, SoLuong });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvxuatkho.DefaultCellStyle = dataGridViewCellStyle2;
            dgvxuatkho.Dock = DockStyle.Fill;
            dgvxuatkho.Location = new Point(0, 0);
            dgvxuatkho.Name = "dgvxuatkho";
            dgvxuatkho.ReadOnly = true;
            dgvxuatkho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvxuatkho.Size = new Size(678, 228);
            dgvxuatkho.TabIndex = 0;
            dgvxuatkho.CellContentClick += dgvxuatkho_CellContentClick;
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "MaSP";
            MaSP.HeaderText = "Mã sản phẩm";
            MaSP.Name = "MaSP";
            MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            TenSP.DataPropertyName = "TenSP";
            TenSP.HeaderText = "Tên";
            TenSP.Name = "TenSP";
            TenSP.ReadOnly = true;
            // 
            // Size
            // 
            Size.DataPropertyName = "Size";
            Size.HeaderText = "Size";
            Size.Name = "Size";
            Size.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số lượng ";
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(picLogo);
            panel1.Location = new Point(3, 1);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 67);
            panel1.TabIndex = 4;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(0, 0);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(678, 67);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.766917F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 93.2330856F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            tableLayoutPanel1.Controls.Add(btnXuat, 1, 0);
            tableLayoutPanel1.Controls.Add(btnThoat, 2, 0);
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(3, 383);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(678, 45);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // btnXuat
            // 
            btnXuat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuat.Location = new Point(470, 2);
            btnXuat.Margin = new Padding(3, 2, 3, 2);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(110, 34);
            btnXuat.TabIndex = 2;
            btnXuat.Text = "Xuất Kho";
            btnXuat.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(586, 2);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(89, 34);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // XuatKho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 430);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "XuatKho";
            Text = "Xuất kho";
            panel2.ResumeLayout(false);
            tlpThongtin.ResumeLayout(false);
            tlpThongtin.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvxuatkho).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private TableLayoutPanel tlpThongtin;
        private Label lbChonSanPham;
        private TextBox txtTimKiem;
        private TextBox txtSoLuong;
        private Label lbxuatSoLuong;
        private Panel panel3;
        private DataGridView dgvxuatkho;
        private Panel panel1;
        private PictureBox picLogo;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnXuat;
        private Button btnThoat;
        private PaintEventHandler tlpThongtin_Paint;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn SoLuong;
    }
}