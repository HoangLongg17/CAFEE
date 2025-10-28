namespace CF36
{
    partial class LichSuChamCong
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
            piclogo = new PictureBox();
            tlpBoLoc = new TableLayoutPanel();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            txtTimKiem = new TextBox();
            lbTimKiem = new Label();
            tlpend = new TableLayoutPanel();
            btnThoat = new Button();
            dgvLSChamCong = new DataGridView();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)piclogo).BeginInit();
            tlpBoLoc.SuspendLayout();
            tlpend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLSChamCong).BeginInit();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(piclogo, 0, 0);
            tlpall.Controls.Add(tlpBoLoc, 0, 1);
            tlpall.Controls.Add(tlpend, 0, 3);
            tlpall.Controls.Add(dgvLSChamCong, 0, 2);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.4410057F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 18.7620888F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 50.6769829F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 14.50677F));
            tlpall.Size = new Size(800, 517);
            tlpall.TabIndex = 0;
            // 
            // piclogo
            // 
            piclogo.Dock = DockStyle.Fill;
            piclogo.Image = Properties.Resources.logo;
            piclogo.Location = new Point(3, 3);
            piclogo.Name = "piclogo";
            piclogo.Size = new Size(794, 78);
            piclogo.SizeMode = PictureBoxSizeMode.Zoom;
            piclogo.TabIndex = 0;
            piclogo.TabStop = false;
            // 
            // tlpBoLoc
            // 
            tlpBoLoc.ColumnCount = 2;
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBoLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBoLoc.Controls.Add(dtpTuNgay, 1, 0);
            tlpBoLoc.Controls.Add(dtpDenNgay, 1, 1);
            tlpBoLoc.Controls.Add(txtTimKiem, 0, 1);
            tlpBoLoc.Controls.Add(lbTimKiem, 0, 0);
            tlpBoLoc.Dock = DockStyle.Fill;
            tlpBoLoc.Location = new Point(3, 87);
            tlpBoLoc.Name = "tlpBoLoc";
            tlpBoLoc.RowCount = 2;
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpBoLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpBoLoc.Size = new Size(794, 90);
            tlpBoLoc.TabIndex = 1;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Anchor = AnchorStyles.Left;
            dtpTuNgay.Location = new Point(400, 9);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(250, 27);
            dtpTuNgay.TabIndex = 0;
            dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Anchor = AnchorStyles.Left;
            dtpDenNgay.Location = new Point(400, 54);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(250, 27);
            dtpDenNgay.TabIndex = 0;
            dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Dock = DockStyle.Right;
            txtTimKiem.Location = new Point(269, 48);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(125, 27);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // lbTimKiem
            // 
            lbTimKiem.Anchor = AnchorStyles.Right;
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(344, 12);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.Size = new Size(50, 20);
            lbTimKiem.TabIndex = 2;
            lbTimKiem.Text = "label1";
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 2;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.75315F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.246851F));
            tlpend.Controls.Add(btnThoat, 1, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 443);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpend.Size = new Size(794, 71);
            tlpend.TabIndex = 1;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(668, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(123, 65);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dgvLSChamCong
            // 
            dgvLSChamCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLSChamCong.Dock = DockStyle.Fill;
            dgvLSChamCong.Location = new Point(3, 183);
            dgvLSChamCong.Name = "dgvLSChamCong";
            dgvLSChamCong.RowHeadersWidth = 51;
            dgvLSChamCong.Size = new Size(794, 254);
            dgvLSChamCong.TabIndex = 2;
            // 
            // LichSuChamCong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 517);
            Controls.Add(tlpall);
            Name = "LichSuChamCong";
            Text = "LichSuChamCong";
            Load += LichSuChamCong_Load;
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)piclogo).EndInit();
            tlpBoLoc.ResumeLayout(false);
            tlpBoLoc.PerformLayout();
            tlpend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLSChamCong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox piclogo;
        private TableLayoutPanel tlpBoLoc;
        private TableLayoutPanel tlpend;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private TextBox txtTimKiem;
        private Label lbTimKiem;
        private Button btnThoat;
        private DataGridView dgvLSChamCong;
    }
}