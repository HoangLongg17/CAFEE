namespace CF36
{
    partial class QuanLiKho
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
            txtTimKiem = new TextBox();
            lbTimKiem = new Label();
            btnThemKho = new Button();
            dgvKho = new DataGridView();
            tlpend = new TableLayoutPanel();
            btnThoat = new Button();
            btnLamMoi = new Button();
            btnLichSuKho = new Button();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKho).BeginInit();
            tlpend.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpBoLoc, 0, 1);
            tlpall.Controls.Add(dgvKho, 0, 2);
            tlpall.Controls.Add(tlpend, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 17.5555553F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 22.4444447F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 46.4444427F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 13.333333F));
            tlpall.Size = new Size(800, 450);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(794, 73);
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
            tlpBoLoc.Controls.Add(txtTimKiem, 2, 0);
            tlpBoLoc.Controls.Add(lbTimKiem, 1, 0);
            tlpBoLoc.Controls.Add(btnThemKho, 3, 1);
            tlpBoLoc.Controls.Add(btnLichSuKho, 2, 1);
            tlpBoLoc.Dock = DockStyle.Fill;
            tlpBoLoc.Location = new Point(3, 82);
            tlpBoLoc.Name = "tlpBoLoc";
            tlpBoLoc.RowCount = 2;
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 34.7368431F));
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 65.26316F));
            tlpBoLoc.Size = new Size(794, 95);
            tlpBoLoc.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Left;
            txtTimKiem.Location = new Point(399, 3);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(192, 27);
            txtTimKiem.TabIndex = 0;
            // 
            // lbTimKiem
            // 
            lbTimKiem.Anchor = AnchorStyles.Right;
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(323, 6);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.Size = new Size(70, 20);
            lbTimKiem.TabIndex = 1;
            lbTimKiem.Text = "Tìm kiếm";
            // 
            // btnThemKho
            // 
            btnThemKho.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnThemKho.Location = new Point(597, 36);
            btnThemKho.Name = "btnThemKho";
            btnThemKho.Size = new Size(146, 56);
            btnThemKho.TabIndex = 2;
            btnThemKho.Text = "Thêm tồn kho";
            btnThemKho.UseVisualStyleBackColor = true;
            btnThemKho.Click += btnThemKho_Click;
            // 
            // dgvKho
            // 
            dgvKho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKho.Dock = DockStyle.Fill;
            dgvKho.Location = new Point(3, 183);
            dgvKho.Name = "dgvKho";
            dgvKho.RowHeadersWidth = 51;
            dgvKho.Size = new Size(794, 203);
            dgvKho.TabIndex = 2;
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 4;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.3979836F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.47607F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpend.Controls.Add(btnThoat, 3, 0);
            tlpend.Controls.Add(btnLamMoi, 2, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 392);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(794, 55);
            tlpend.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(597, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 49);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(490, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(101, 49);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnLichSuKho
            // 
            btnLichSuKho.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLichSuKho.Location = new Point(453, 36);
            btnLichSuKho.Name = "btnLichSuKho";
            btnLichSuKho.Size = new Size(138, 56);
            btnLichSuKho.TabIndex = 3;
            btnLichSuKho.Text = "Lịch sử nhập kho";
            btnLichSuKho.UseVisualStyleBackColor = true;
            btnLichSuKho.Click += btnLichSuKho_Click;
            // 
            // QuanLiKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpall);
            Name = "QuanLiKho";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lí kho";
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpBoLoc.ResumeLayout(false);
            tlpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKho).EndInit();
            tlpend.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpBoLoc;
        private TextBox txtTimKiem;
        private Label lbTimKiem;
        private Button btnThemKho;
        private DataGridView dgvKho;
        private TableLayoutPanel tlpend;
        private Button btnThoat;
        private Button btnLamMoi;
        private Button btnLichSuKho;
    }
}