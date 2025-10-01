namespace CF36
{
    partial class LichSuNhapKho
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
            tlpThongtin = new TableLayoutPanel();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            dgvLichSuNhapKho = new DataGridView();
            tlpend = new TableLayoutPanel();
            btnLamMoi = new Button();
            btnThoat = new Button();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpThongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuNhapKho).BeginInit();
            tlpend.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpThongtin, 0, 1);
            tlpall.Controls.Add(dgvLichSuNhapKho, 0, 2);
            tlpall.Controls.Add(tlpend, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 13.333333F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 51.77778F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.88889F));
            tlpall.Size = new Size(800, 450);
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
            // tlpThongtin
            // 
            tlpThongtin.ColumnCount = 4;
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.380352F));
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.4937019F));
            tlpThongtin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpThongtin.Controls.Add(lbTimKiem, 1, 0);
            tlpThongtin.Controls.Add(txtTimKiem, 2, 0);
            tlpThongtin.Dock = DockStyle.Fill;
            tlpThongtin.Location = new Point(3, 84);
            tlpThongtin.Name = "tlpThongtin";
            tlpThongtin.RowCount = 1;
            tlpThongtin.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpThongtin.Size = new Size(794, 54);
            tlpThongtin.TabIndex = 1;
            // 
            // lbTimKiem
            // 
            lbTimKiem.Anchor = AnchorStyles.Right;
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(263, 17);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.Size = new Size(70, 20);
            lbTimKiem.TabIndex = 0;
            lbTimKiem.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Left;
            txtTimKiem.Location = new Point(339, 13);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(252, 27);
            txtTimKiem.TabIndex = 1;
            // 
            // dgvLichSuNhapKho
            // 
            dgvLichSuNhapKho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSuNhapKho.Dock = DockStyle.Fill;
            dgvLichSuNhapKho.Location = new Point(3, 144);
            dgvLichSuNhapKho.Name = "dgvLichSuNhapKho";
            dgvLichSuNhapKho.RowHeadersWidth = 51;
            dgvLichSuNhapKho.Size = new Size(794, 227);
            dgvLichSuNhapKho.TabIndex = 2;
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 2;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.63476F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.3652391F));
            tlpend.Controls.Add(btnLamMoi, 0, 0);
            tlpend.Controls.Add(btnThoat, 1, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 377);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpend.Size = new Size(794, 70);
            tlpend.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(548, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(121, 64);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(675, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(113, 64);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // LichSuNhapKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpall);
            Name = "LichSuNhapKho";
            Text = "LichSuNhapKho";
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpThongtin.ResumeLayout(false);
            tlpThongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuNhapKho).EndInit();
            tlpend.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpThongtin;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private DataGridView dgvLichSuNhapKho;
        private TableLayoutPanel tlpend;
        private Button btnLamMoi;
        private Button btnThoat;
    }
}