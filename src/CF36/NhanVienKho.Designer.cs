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
            tlpall = new TableLayoutPanel();
            tlpthan = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            sẢNPHẨMToolStripMenuItem = new ToolStripMenuItem();
            kHOToolStripMenuItem = new ToolStripMenuItem();
            tÀIKHOẢNToolStripMenuItem = new ToolStripMenuItem();
            picLogo = new PictureBox();
            tlpbutton = new TableLayoutPanel();
            btnThoat = new Button();
            btnBatDauLam = new Button();
            btnChamCong = new Button();
            lbTime = new Label();
            tlpall.SuspendLayout();
            tlpthan.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpbutton.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpall.Controls.Add(tlpthan, 0, 1);
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 2;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 18.1981983F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 81.8018F));
            tlpall.Size = new Size(1108, 555);
            tlpall.TabIndex = 0;
            // 
            // tlpthan
            // 
            tlpthan.ColumnCount = 1;
            tlpthan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpthan.Controls.Add(menuStrip1, 0, 0);
            tlpthan.Controls.Add(tlpbutton, 0, 1);
            tlpthan.Dock = DockStyle.Fill;
            tlpthan.Location = new Point(3, 104);
            tlpthan.Name = "tlpthan";
            tlpthan.RowCount = 2;
            tlpthan.RowStyles.Add(new RowStyle(SizeType.Percent, 81.02679F));
            tlpthan.RowStyles.Add(new RowStyle(SizeType.Percent, 18.9732151F));
            tlpthan.Size = new Size(1102, 448);
            tlpthan.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sẢNPHẨMToolStripMenuItem, kHOToolStripMenuItem, tÀIKHOẢNToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(260, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // sẢNPHẨMToolStripMenuItem
            // 
            sẢNPHẨMToolStripMenuItem.Name = "sẢNPHẨMToolStripMenuItem";
            sẢNPHẨMToolStripMenuItem.Size = new Size(98, 24);
            sẢNPHẨMToolStripMenuItem.Text = "SẢN PHẨM";
            // 
            // kHOToolStripMenuItem
            // 
            kHOToolStripMenuItem.Name = "kHOToolStripMenuItem";
            kHOToolStripMenuItem.Size = new Size(54, 24);
            kHOToolStripMenuItem.Text = "KHO";
            // 
            // tÀIKHOẢNToolStripMenuItem
            // 
            tÀIKHOẢNToolStripMenuItem.Name = "tÀIKHOẢNToolStripMenuItem";
            tÀIKHOẢNToolStripMenuItem.Size = new Size(100, 24);
            tÀIKHOẢNToolStripMenuItem.Text = "TÀI KHOẢN";
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(1102, 95);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 2;
            picLogo.TabStop = false;
            // 
            // tlpbutton
            // 
            tlpbutton.ColumnCount = 5;
            tlpbutton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpbutton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpbutton.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 173F));
            tlpbutton.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 157F));
            tlpbutton.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 151F));
            tlpbutton.Controls.Add(btnThoat, 4, 0);
            tlpbutton.Controls.Add(btnBatDauLam, 3, 0);
            tlpbutton.Controls.Add(btnChamCong, 2, 0);
            tlpbutton.Controls.Add(lbTime, 0, 0);
            tlpbutton.Dock = DockStyle.Fill;
            tlpbutton.Location = new Point(3, 366);
            tlpbutton.Name = "tlpbutton";
            tlpbutton.RowCount = 1;
            tlpbutton.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpbutton.Size = new Size(1096, 79);
            tlpbutton.TabIndex = 1;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(947, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(146, 70);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnBatDauLam
            // 
            btnBatDauLam.Location = new Point(790, 3);
            btnBatDauLam.Name = "btnBatDauLam";
            btnBatDauLam.Size = new Size(151, 73);
            btnBatDauLam.TabIndex = 0;
            btnBatDauLam.Text = "Bắt đầu làm";
            btnBatDauLam.UseVisualStyleBackColor = true;
            // 
            // btnChamCong
            // 
            btnChamCong.Location = new Point(617, 3);
            btnChamCong.Name = "btnChamCong";
            btnChamCong.Size = new Size(167, 73);
            btnChamCong.TabIndex = 0;
            btnChamCong.Text = "Chấm công";
            btnChamCong.UseVisualStyleBackColor = true;
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Dock = DockStyle.Fill;
            lbTime.Location = new Point(3, 0);
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(301, 79);
            lbTime.TabIndex = 1;
            lbTime.Text = "Hiển thị giờ ở đây";
            lbTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NhanVienKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 555);
            Controls.Add(tlpall);
            MainMenuStrip = menuStrip1;
            Name = "NhanVienKho";
            Text = "Nhân viên kho";
            tlpall.ResumeLayout(false);
            tlpthan.ResumeLayout(false);
            tlpthan.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
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
        private Button btnBatDauLam;
        private PictureBox picLogo;
        private Button btnChamCong;
        private Label lbTime;
    }
}