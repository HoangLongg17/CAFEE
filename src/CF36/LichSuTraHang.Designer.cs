namespace CF36
{
    partial class LichSuTraHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.DataGridView dgvDanhSachTraHang;
        private System.Windows.Forms.DataGridView dgvChiTietTraHang;

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
            tlpMain = new TableLayoutPanel();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            dgvDanhSachTraHang = new DataGridView();
            dgvChiTietTraHang = new DataGridView();
            tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachTraHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietTraHang).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(lblTimKiem, 0, 0);
            tlpMain.Controls.Add(txtTimKiem, 0, 1);
            tlpMain.Controls.Add(dgvDanhSachTraHang, 0, 2);
            tlpMain.Controls.Add(dgvChiTietTraHang, 0, 3);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMain.Size = new Size(800, 450);
            tlpMain.TabIndex = 0;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Dock = DockStyle.Fill;
            lblTimKiem.Location = new Point(3, 0);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(794, 25);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm theo mã trả hàng / nhân viên / khách hàng:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Dock = DockStyle.Fill;
            txtTimKiem.Location = new Point(3, 28);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(794, 23);
            txtTimKiem.TabIndex = 1;
            // 
            // dgvDanhSachTraHang
            // 
            dgvDanhSachTraHang.AllowUserToAddRows = false;
            dgvDanhSachTraHang.AllowUserToDeleteRows = false;
            dgvDanhSachTraHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachTraHang.Dock = DockStyle.Fill;
            dgvDanhSachTraHang.Location = new Point(3, 58);
            dgvDanhSachTraHang.MultiSelect = false;
            dgvDanhSachTraHang.Name = "dgvDanhSachTraHang";
            dgvDanhSachTraHang.ReadOnly = true;
            dgvDanhSachTraHang.RowHeadersWidth = 51;
            dgvDanhSachTraHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachTraHang.Size = new Size(794, 191);
            dgvDanhSachTraHang.TabIndex = 2;
            // 
            // dgvChiTietTraHang
            // 
            dgvChiTietTraHang.AllowUserToAddRows = false;
            dgvChiTietTraHang.AllowUserToDeleteRows = false;
            dgvChiTietTraHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietTraHang.Dock = DockStyle.Fill;
            dgvChiTietTraHang.Location = new Point(3, 255);
            dgvChiTietTraHang.MultiSelect = false;
            dgvChiTietTraHang.Name = "dgvChiTietTraHang";
            dgvChiTietTraHang.ReadOnly = true;
            dgvChiTietTraHang.RowHeadersWidth = 51;
            dgvChiTietTraHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietTraHang.Size = new Size(794, 192);
            dgvChiTietTraHang.TabIndex = 3;
            // 
            // LichSuTraHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpMain);
            Name = "LichSuTraHang";
            Text = "Lịch Sử Trả Hàng";
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachTraHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietTraHang).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
