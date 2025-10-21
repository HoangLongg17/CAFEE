namespace CF36
{
    partial class LichSuChiTietNhapKho
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
            tlpMain = new TableLayoutPanel();
            lblTitle = new Label();
            dgvChiTiet = new DataGridView();
            panelBottom = new FlowLayoutPanel();
            btnDong = new Button();
            btnLamMoi = new Button();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            GiaNhap = new DataGridViewTextBoxColumn();
            tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(lblTitle, 0, 0);
            tlpMain.Controls.Add(dgvChiTiet, 0, 1);
            tlpMain.Controls.Add(panelBottom, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpMain.Size = new Size(800, 450);
            tlpMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(794, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CHI TIẾT PHIẾU NHẬP";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Columns.AddRange(new DataGridViewColumn[] { MaSP, TenSP, Size, SoLuong, GiaNhap });
            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.Location = new Point(3, 43);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.Size = new Size(794, 354);
            dgvChiTiet.TabIndex = 1;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnDong);
            panelBottom.Controls.Add(btnLamMoi);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.FlowDirection = FlowDirection.RightToLeft;
            panelBottom.Location = new Point(3, 403);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(794, 44);
            panelBottom.TabIndex = 2;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(691, 3);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(100, 30);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng";
            btnDong.Click += btnDong_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(585, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 30);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "MaSP";
            MaSP.HeaderText = "Mã SP";
            MaSP.Name = "MaSP";
            MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            TenSP.DataPropertyName = "TenSP";
            TenSP.HeaderText = "Tên sản phẩm";
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
            SoLuong.DataPropertyName = "SoLuongNhap";
            SoLuong.HeaderText = "Số lượng";
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // GiaNhap
            // 
            GiaNhap.DataPropertyName = "GiaNhap";
            GiaNhap.HeaderText = "Giá nhập";
            GiaNhap.Name = "GiaNhap";
            GiaNhap.ReadOnly = true;
            // 
            // LichSuChiTietNhapKho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpMain);
            Name = "LichSuChiTietNhapKho";
            Text = "Chi tiết nhập kho";
            tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Label lblTitle;
        private DataGridView dgvChiTiet;
        private FlowLayoutPanel panelBottom;
        private Button btnDong;
        private Button btnLamMoi;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn GiaNhap;
    }
}
