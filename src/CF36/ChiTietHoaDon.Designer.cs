namespace CF36
{
    partial class ChiTietHoaDon
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
            dgvChiTiet = new DataGridView();
            btnThoat = new Button();
            dgvThongTinChung = new DataGridView();
            btnXuatPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvThongTinChung).BeginInit();
            SuspendLayout();
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(12, 83);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.Size = new Size(494, 276);
            dgvChiTiet.TabIndex = 0;
            dgvChiTiet.CellFormatting += dgvChiTiet_CellFormatting;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(933, 407);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(96, 32);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dgvThongTinChung
            // 
            dgvThongTinChung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongTinChung.Location = new Point(535, 83);
            dgvThongTinChung.Name = "dgvThongTinChung";
            dgvThongTinChung.Size = new Size(494, 276);
            dgvThongTinChung.TabIndex = 2;
            // 
            // btnXuatPDF
            // 
            btnXuatPDF.Location = new Point(816, 407);
            btnXuatPDF.Margin = new Padding(3, 2, 3, 2);
            btnXuatPDF.Name = "btnXuatPDF";
            btnXuatPDF.Size = new Size(96, 32);
            btnXuatPDF.TabIndex = 3;
            btnXuatPDF.Text = "XUẤT PDF";
            btnXuatPDF.UseVisualStyleBackColor = true;
            btnXuatPDF.Click += btnXuatPDF_Click;
            // 
            // ChiTietHoaDon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 450);
            Controls.Add(btnXuatPDF);
            Controls.Add(dgvThongTinChung);
            Controls.Add(btnThoat);
            Controls.Add(dgvChiTiet);
            Name = "ChiTietHoaDon";
            Text = "ChiTietHoaDon";
            Load += ChiTietHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvThongTinChung).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvChiTiet;
        private Button btnThoat;
        private DataGridView dgvThongTinChung;
        private Button btnXuatPDF;
    }
}