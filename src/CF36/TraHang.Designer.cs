namespace CF36
{
    partial class TraHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tlpall = new TableLayoutPanel();
            picLogo = new PictureBox();
            tlpContent = new TableLayoutPanel();
            dgvHoaDon = new DataGridView();
            dgvChiTietTraHang = new DataGridView();
            lblLyDo = new Label();
            txtLyDo = new TextBox();
            btnTraHang = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();

            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietTraHang).BeginInit();
            SuspendLayout();

            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpContent, 0, 1);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.RowCount = 2;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tlpall.Size = new Size(1125, 588);
            tlpall.TabIndex = 0;

            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;

            // 
            // tlpContent
            // 
            tlpContent.ColumnCount = 2;
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpContent.Controls.Add(dgvHoaDon, 0, 0);
            tlpContent.Controls.Add(dgvChiTietTraHang, 0, 1);
            tlpContent.Controls.Add(lblLyDo, 1, 0);
            tlpContent.Controls.Add(txtLyDo, 1, 1);
            tlpContent.Controls.Add(btnTraHang, 1, 2);
            tlpContent.Controls.Add(lblTimKiem, 0, 2);
            tlpContent.Controls.Add(txtTimKiem, 0, 3);
            tlpContent.Controls.Add(btnTimKiem, 0, 4);
            tlpContent.Dock = DockStyle.Fill;
            tlpContent.Location = new Point(3, 111);
            tlpContent.RowCount = 5;
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 40F)); // dgvHoaDon
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 30F)); // dgvChiTietTraHang
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 10F)); // btn / label
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 10F)); // txt tim kiem
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 10F)); // btn tim kiem
            tlpContent.Size = new Size(1119, 474);

            // 
            // dgvHoaDon
            // 
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.MultiSelect = false;

            // 
            // dgvChiTietTraHang
            // 
            dgvChiTietTraHang.Dock = DockStyle.Fill;
            dgvChiTietTraHang.ReadOnly = true;
            dgvChiTietTraHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietTraHang.MultiSelect = false;

            // 
            // lblLyDo
            // 
            lblLyDo.Text = "Lý do trả hàng:";
            lblLyDo.Dock = DockStyle.Fill;
            lblLyDo.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // txtLyDo
            // 
            txtLyDo.Dock = DockStyle.Fill;
            txtLyDo.Multiline = true;

            // 
            // btnTraHang
            // 
            btnTraHang.Text = "Thực hiện trả hàng";
            btnTraHang.Dock = DockStyle.Fill;
            btnTraHang.BackColor = Color.LightCoral;

            // 
            // lblTimKiem
            // 
            lblTimKiem.Text = "Tìm hóa đơn:";
            lblTimKiem.Dock = DockStyle.Fill;
            lblTimKiem.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // txtTimKiem
            // 
            txtTimKiem.Dock = DockStyle.Fill;

            // 
            // btnTimKiem
            // 
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Dock = DockStyle.Fill;

            // 
            // TraHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 588);
            Controls.Add(tlpall);
            Name = "TraHang";
            Text = "Trả Hàng";

            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpContent.ResumeLayout(false);
            tlpContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietTraHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpContent;
        private DataGridView dgvHoaDon;
        private DataGridView dgvChiTietTraHang;
        private Label lblLyDo;
        private TextBox txtLyDo;
        private Button btnTraHang;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
    }
}
