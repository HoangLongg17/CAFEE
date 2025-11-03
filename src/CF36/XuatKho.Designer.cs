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
            tlpThongtin = new TableLayoutPanel();
            lbChonSanPham = new Label();
            txtSoLuong = new TextBox();
            lbxuatSoLuong = new Label();
            txtTimKiem = new TextBox();
            dgvxuatkho = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            tlpall = new TableLayoutPanel();
            piclogo = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnXuat = new Button();
            btnThoat = new Button();
            tlpThongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvxuatkho).BeginInit();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)piclogo).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
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
            tlpThongtin.Location = new Point(3, 106);
            tlpThongtin.Name = "tlpThongtin";
            tlpThongtin.RowCount = 2;
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 42.6666641F));
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 57.3333359F));
            tlpThongtin.Size = new Size(813, 73);
            tlpThongtin.TabIndex = 2;
            // 
            // lbChonSanPham
            // 
            lbChonSanPham.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbChonSanPham.AutoSize = true;
            lbChonSanPham.Location = new Point(3, 11);
            lbChonSanPham.Name = "lbChonSanPham";
            lbChonSanPham.Size = new Size(142, 20);
            lbChonSanPham.TabIndex = 2;
            lbChonSanPham.Text = "Tìm kiếm sản phẩm ";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(409, 34);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(382, 27);
            txtSoLuong.TabIndex = 4;
            // 
            // lbxuatSoLuong
            // 
            lbxuatSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbxuatSoLuong.AutoSize = true;
            lbxuatSoLuong.Location = new Point(409, 11);
            lbxuatSoLuong.Name = "lbxuatSoLuong";
            lbxuatSoLuong.Size = new Size(129, 20);
            lbxuatSoLuong.TabIndex = 5;
            lbxuatSoLuong.Text = "Số lượng xuất kho";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(3, 34);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(380, 27);
            txtTimKiem.TabIndex = 3;
            // 
            // dgvxuatkho
            // 
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
            dgvxuatkho.Location = new Point(3, 186);
            dgvxuatkho.Margin = new Padding(3, 4, 3, 4);
            dgvxuatkho.Name = "dgvxuatkho";
            dgvxuatkho.ReadOnly = true;
            dgvxuatkho.RowHeadersWidth = 51;
            dgvxuatkho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvxuatkho.Size = new Size(813, 421);
            dgvxuatkho.TabIndex = 0;
            dgvxuatkho.CellContentClick += dgvxuatkho_CellContentClick;
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "MaSP";
            MaSP.HeaderText = "Mã sản phẩm";
            MaSP.MinimumWidth = 6;
            MaSP.Name = "MaSP";
            MaSP.ReadOnly = true;
            MaSP.Width = 181;
            // 
            // TenSP
            // 
            TenSP.DataPropertyName = "TenSP";
            TenSP.HeaderText = "Tên";
            TenSP.MinimumWidth = 6;
            TenSP.Name = "TenSP";
            TenSP.ReadOnly = true;
            TenSP.Width = 180;
            // 
            // Size
            // 
            Size.DataPropertyName = "Size";
            Size.HeaderText = "Size";
            Size.MinimumWidth = 6;
            Size.Name = "Size";
            Size.ReadOnly = true;
            Size.Width = 181;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số lượng ";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            SoLuong.Width = 180;
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(piclogo, 0, 0);
            tlpall.Controls.Add(tlpThongtin, 0, 1);
            tlpall.Controls.Add(dgvxuatkho, 0, 2);
            tlpall.Controls.Add(tableLayoutPanel1, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 14.651494F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 11.2375536F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 61.02418F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 12.9283485F));
            tlpall.Size = new Size(819, 703);
            tlpall.TabIndex = 6;
            // 
            // piclogo
            // 
            piclogo.Dock = DockStyle.Fill;
            piclogo.Image = Properties.Resources.logo;
            piclogo.Location = new Point(3, 3);
            piclogo.Name = "piclogo";
            piclogo.Size = new Size(813, 97);
            piclogo.SizeMode = PictureBoxSizeMode.Zoom;
            piclogo.TabIndex = 1;
            piclogo.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 154F));
            tableLayoutPanel1.Controls.Add(btnXuat, 0, 0);
            tableLayoutPanel1.Controls.Add(btnThoat, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 614);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(813, 86);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnXuat
            // 
            btnXuat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuat.Location = new Point(503, 3);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(153, 74);
            btnXuat.TabIndex = 2;
            btnXuat.Text = "Xuất Kho";
            btnXuat.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(662, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(148, 74);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // XuatKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 703);
            Controls.Add(tlpall);
            Margin = new Padding(3, 4, 3, 4);
            Name = "XuatKho";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xuất kho";
            Load += XuatKho_Load_1;
            tlpThongtin.ResumeLayout(false);
            tlpThongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvxuatkho).EndInit();
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)piclogo).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tlpThongtin;
        private Label lbChonSanPham;
        private TextBox txtTimKiem;
        private TextBox txtSoLuong;
        private Label lbxuatSoLuong;
        private Panel panel3;
        private DataGridView dgvxuatkho;
        private PaintEventHandler tlpThongtin_Paint;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn SoLuong;
        private TableLayoutPanel tlpall;
        private PictureBox piclogo;
        private Button btnXuat;
        private Button btnThoat;
        private TableLayoutPanel tableLayoutPanel1;
    }
}