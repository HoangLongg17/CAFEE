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
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            GiaNhap = new DataGridViewTextBoxColumn();
            panelBottom = new FlowLayoutPanel();
            btnDong = new Button();
            btnLamMoi = new Button();
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
            tlpMain.Margin = new Padding(3, 4, 3, 4);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tlpMain.Size = new Size(914, 600);
            tlpMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(908, 53);
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
            dgvChiTiet.Location = new Point(3, 57);
            dgvChiTiet.Margin = new Padding(3, 4, 3, 4);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.Size = new Size(908, 472);
            dgvChiTiet.TabIndex = 1;
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "MaSP";
            MaSP.HeaderText = "Mã SP";
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
            SoLuong.DataPropertyName = "SoLuongNhap";
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // GiaNhap
            // 
            GiaNhap.DataPropertyName = "GiaNhap";
            GiaNhap.HeaderText = "Giá nhập";
            GiaNhap.MinimumWidth = 6;
            GiaNhap.Name = "GiaNhap";
            GiaNhap.ReadOnly = true;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnDong);
            panelBottom.Controls.Add(btnLamMoi);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.FlowDirection = FlowDirection.RightToLeft;
            panelBottom.Location = new Point(3, 537);
            panelBottom.Margin = new Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(908, 59);
            panelBottom.TabIndex = 2;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(791, 4);
            btnDong.Margin = new Padding(3, 4, 3, 4);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(114, 40);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng";
            btnDong.Click += btnDong_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(671, 4);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(114, 40);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // LichSuChiTietNhapKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(tlpMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LichSuChiTietNhapKho";
            Text = "Chi tiết nhập kho";
            Load += LichSuChiTietNhapKho_Load_1;
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
