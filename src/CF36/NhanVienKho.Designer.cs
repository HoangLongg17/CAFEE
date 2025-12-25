namespace CF36
{
    partial class NhanVienKho
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
            components = new System.ComponentModel.Container();
            tlpall = new System.Windows.Forms.TableLayoutPanel();
            picLogo = new System.Windows.Forms.PictureBox();
            tlpthan = new System.Windows.Forms.TableLayoutPanel();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            sẢNPHẨMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            kHOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tÀIKHOẢNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            xEMGIỜLÀMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            đỔIMẬTKHẨUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tlpbutton = new System.Windows.Forms.TableLayoutPanel();
            lblTrangThai = new System.Windows.Forms.Label();
            btnThoat = new System.Windows.Forms.Button();
            btnBatDau = new System.Windows.Forms.Button();
            btnChamCong = new System.Windows.Forms.Button();
            lbTime = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpthan.SuspendLayout();
            menuStrip1.SuspendLayout();
            tlpbutton.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpthan, 0, 1);
            tlpall.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpall.Location = new System.Drawing.Point(0, 0);
            tlpall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 2;
            tlpall.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.198198F));
            tlpall.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.8018F));
            tlpall.Size = new System.Drawing.Size(970, 416);
            tlpall.TabIndex = 0;
            tlpall.Paint += tlpall_Paint;
            // 
            // picLogo
            // 
            picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            picLogo.Image = global::CF36.Properties.Resources.logo;
            picLogo.Location = new System.Drawing.Point(3, 2);
            picLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new System.Drawing.Size(964, 71);
            picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 2;
            picLogo.TabStop = false;
            // 
            // tlpthan
            // 
            tlpthan.ColumnCount = 1;
            tlpthan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpthan.Controls.Add(menuStrip1, 0, 0);
            tlpthan.Controls.Add(tlpbutton, 0, 1);
            tlpthan.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpthan.Location = new System.Drawing.Point(3, 77);
            tlpthan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tlpthan.Name = "tlpthan";
            tlpthan.RowCount = 3;
            tlpthan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.02679F));
            tlpthan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.973215F));
            tlpthan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tlpthan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tlpthan.Size = new System.Drawing.Size(964, 337);
            tlpthan.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { sẢNPHẨMToolStripMenuItem, kHOToolStripMenuItem, tÀIKHOẢNToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(259, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // sẢNPHẨMToolStripMenuItem
            // 
            sẢNPHẨMToolStripMenuItem.Name = "sẢNPHẨMToolStripMenuItem";
            sẢNPHẨMToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            sẢNPHẨMToolStripMenuItem.Text = "SẢN PHẨM";
            sẢNPHẨMToolStripMenuItem.Click += sẢNPHẨMToolStripMenuItem_Click;
            // 
            // kHOToolStripMenuItem
            // 
            kHOToolStripMenuItem.Name = "kHOToolStripMenuItem";
            kHOToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            kHOToolStripMenuItem.Text = "KHO";
            kHOToolStripMenuItem.Click += kHOToolStripMenuItem_Click;
            // 
            // tÀIKHOẢNToolStripMenuItem
            // 
            tÀIKHOẢNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { xEMGIỜLÀMToolStripMenuItem, đỔIMẬTKHẨUToolStripMenuItem });
            tÀIKHOẢNToolStripMenuItem.Name = "tÀIKHOẢNToolStripMenuItem";
            tÀIKHOẢNToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            tÀIKHOẢNToolStripMenuItem.Text = "TÀI KHOẢN";
            tÀIKHOẢNToolStripMenuItem.Click += tÀIKHOẢNToolStripMenuItem_Click;
            // 
            // xEMGIỜLÀMToolStripMenuItem
            // 
            xEMGIỜLÀMToolStripMenuItem.Name = "xEMGIỜLÀMToolStripMenuItem";
            xEMGIỜLÀMToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            xEMGIỜLÀMToolStripMenuItem.Text = "XEM GIỜ LÀM";
            xEMGIỜLÀMToolStripMenuItem.Click += xEMGIỜLÀMToolStripMenuItem_Click;
            // 
            // đỔIMẬTKHẨUToolStripMenuItem
            // 
            đỔIMẬTKHẨUToolStripMenuItem.Name = "đỔIMẬTKHẨUToolStripMenuItem";
            đỔIMẬTKHẨUToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            đỔIMẬTKHẨUToolStripMenuItem.Text = "ĐỔI MẬT KHẨU";
            đỔIMẬTKHẨUToolStripMenuItem.Click += đỔIMẬTKHẨUToolStripMenuItem_Click;
            // 
            // tlpbutton
            // 
            tlpbutton.ColumnCount = 5;
            tlpbutton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpbutton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpbutton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            tlpbutton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            tlpbutton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            tlpbutton.Controls.Add(lblTrangThai, 1, 0);
            tlpbutton.Controls.Add(btnThoat, 4, 0);
            tlpbutton.Controls.Add(btnBatDau, 3, 0);
            tlpbutton.Controls.Add(btnChamCong, 2, 0);
            tlpbutton.Controls.Add(lbTime, 0, 0);
            tlpbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpbutton.Location = new System.Drawing.Point(3, 258);
            tlpbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tlpbutton.Name = "tlpbutton";
            tlpbutton.RowCount = 1;
            tlpbutton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpbutton.Size = new System.Drawing.Size(958, 56);
            tlpbutton.TabIndex = 1;
            tlpbutton.Paint += tlpbutton_Paint;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new System.Drawing.Point(271, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(75, 20);
            lblTrangThai.TabIndex = 4;
            lblTrangThai.Text = "Trạng thái";
            lblTrangThai.Click += lblTrangThai_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new System.Drawing.Point(827, 2);
            btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new System.Drawing.Size(128, 51);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnBatDau
            // 
            btnBatDau.Location = new System.Drawing.Point(690, 2);
            btnBatDau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnBatDau.Name = "btnBatDau";
            btnBatDau.Size = new System.Drawing.Size(131, 51);
            btnBatDau.TabIndex = 0;
            btnBatDau.Text = "Bắt đầu làm";
            btnBatDau.UseVisualStyleBackColor = true;
            btnBatDau.Click += btnBatDau_Click;
            // 
            // btnChamCong
            // 
            btnChamCong.Location = new System.Drawing.Point(539, 2);
            btnChamCong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnChamCong.Name = "btnChamCong";
            btnChamCong.Size = new System.Drawing.Size(145, 51);
            btnChamCong.TabIndex = 0;
            btnChamCong.Text = "Chấm công";
            btnChamCong.UseVisualStyleBackColor = true;
            btnChamCong.Click += btnChamCong_Click;
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Dock = System.Windows.Forms.DockStyle.Fill;
            lbTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            lbTime.Location = new System.Drawing.Point(3, 0);
            lbTime.Name = "lbTime";
            lbTime.Size = new System.Drawing.Size(262, 56);
            lbTime.TabIndex = 1;
            lbTime.Text = "00:00:00";
            lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // NhanVienKho
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(970, 416);
            Controls.Add(tlpall);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Text = "Nhân viên kho";
            Load += NhanVienKho_Load_1;
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpthan.ResumeLayout(false);
            tlpthan.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tlpbutton.ResumeLayout(false);
            tlpbutton.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sẢNPHẨMToolStripMenuItem;
        private ToolStripMenuItem kHOToolStripMenuItem;
        private ToolStripMenuItem tÀIKHOẢNToolStripMenuItem;
        private TableLayoutPanel tlpthan;
        private TableLayoutPanel tlpbutton;
        private Button btnThoat;
        private Button btnBatDau;
        private PictureBox picLogo;
        private Button btnChamCong;
        private Label lbTime;
        private ToolStripMenuItem xEMGIỜLÀMToolStripMenuItem;
        private ToolStripMenuItem đỔIMẬTKHẨUToolStripMenuItem;
        private Label lblTrangThai;
        private System.Windows.Forms.Timer timer1;
    }
}