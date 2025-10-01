namespace CF36
{
    partial class NHANVIEN
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
            tlpall = new TableLayoutPanel();
            picLogo = new PictureBox();
            menuStrip1 = new MenuStrip();
            bÁNHÀNGToolStripMenuItem = new ToolStripMenuItem();
            sẢNPHẨMToolStripMenuItem = new ToolStripMenuItem();
            tÀIKHOẢNToolStripMenuItem = new ToolStripMenuItem();
            đỔIMẬTKHẨToolStripMenuItem = new ToolStripMenuItem();
            đỔIMẬTKHẨUToolStripMenuItem = new ToolStripMenuItem();
            tlpend = new TableLayoutPanel();
            btnThoat = new Button();
            btnBatDau = new Button();
            btnChamCong = new Button();
            lbThoiGian = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            menuStrip1.SuspendLayout();
            tlpend.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(menuStrip1, 0, 1);
            tlpall.Controls.Add(tlpend, 0, 3);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 14.9171267F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 8.441559F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 59.52381F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0995674F));
            tlpall.Size = new Size(800, 462);
            tlpall.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(794, 62);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { bÁNHÀNGToolStripMenuItem, sẢNPHẨMToolStripMenuItem, tÀIKHOẢNToolStripMenuItem });
            menuStrip1.Location = new Point(0, 68);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // bÁNHÀNGToolStripMenuItem
            // 
            bÁNHÀNGToolStripMenuItem.Name = "bÁNHÀNGToolStripMenuItem";
            bÁNHÀNGToolStripMenuItem.Size = new Size(99, 24);
            bÁNHÀNGToolStripMenuItem.Text = "BÁN HÀNG";
            bÁNHÀNGToolStripMenuItem.Click += bÁNHÀNGToolStripMenuItem_Click;
            // 
            // sẢNPHẨMToolStripMenuItem
            // 
            sẢNPHẨMToolStripMenuItem.Name = "sẢNPHẨMToolStripMenuItem";
            sẢNPHẨMToolStripMenuItem.Size = new Size(98, 24);
            sẢNPHẨMToolStripMenuItem.Text = "SẢN PHẨM";
            sẢNPHẨMToolStripMenuItem.Click += sẢNPHẨMToolStripMenuItem_Click;
            // 
            // tÀIKHOẢNToolStripMenuItem
            // 
            tÀIKHOẢNToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đỔIMẬTKHẨToolStripMenuItem, đỔIMẬTKHẨUToolStripMenuItem });
            tÀIKHOẢNToolStripMenuItem.Name = "tÀIKHOẢNToolStripMenuItem";
            tÀIKHOẢNToolStripMenuItem.Size = new Size(100, 24);
            tÀIKHOẢNToolStripMenuItem.Text = "TÀI KHOẢN";
            // 
            // đỔIMẬTKHẨToolStripMenuItem
            // 
            đỔIMẬTKHẨToolStripMenuItem.Name = "đỔIMẬTKHẨToolStripMenuItem";
            đỔIMẬTKHẨToolStripMenuItem.Size = new Size(224, 26);
            đỔIMẬTKHẨToolStripMenuItem.Text = "XEM GIỜ LÀM VIỆC";
            // 
            // đỔIMẬTKHẨUToolStripMenuItem
            // 
            đỔIMẬTKHẨUToolStripMenuItem.Name = "đỔIMẬTKHẨUToolStripMenuItem";
            đỔIMẬTKHẨUToolStripMenuItem.Size = new Size(224, 26);
            đỔIMẬTKHẨUToolStripMenuItem.Text = "ĐỔI MẬT KHẨU";
            // 
            // tlpend
            // 
            tlpend.ColumnCount = 4;
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpend.Controls.Add(btnThoat, 3, 0);
            tlpend.Controls.Add(btnBatDau, 2, 0);
            tlpend.Controls.Add(btnChamCong, 1, 0);
            tlpend.Controls.Add(lbThoiGian, 0, 0);
            tlpend.Dock = DockStyle.Fill;
            tlpend.Location = new Point(3, 385);
            tlpend.Name = "tlpend";
            tlpend.RowCount = 1;
            tlpend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpend.Size = new Size(794, 74);
            tlpend.TabIndex = 2;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(597, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(194, 68);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnBatDau
            // 
            btnBatDau.Location = new Point(399, 3);
            btnBatDau.Name = "btnBatDau";
            btnBatDau.Size = new Size(192, 68);
            btnBatDau.TabIndex = 1;
            btnBatDau.Text = "BẮT ĐẦU LÀM";
            btnBatDau.UseVisualStyleBackColor = true;
            // 
            // btnChamCong
            // 
            btnChamCong.Location = new Point(201, 3);
            btnChamCong.Name = "btnChamCong";
            btnChamCong.Size = new Size(192, 68);
            btnChamCong.TabIndex = 0;
            btnChamCong.Text = "CHẤM CÔNG";
            btnChamCong.UseVisualStyleBackColor = true;
            // 
            // lbThoiGian
            // 
            lbThoiGian.AutoSize = true;
            lbThoiGian.Dock = DockStyle.Fill;
            lbThoiGian.Location = new Point(3, 0);
            lbThoiGian.Name = "lbThoiGian";
            lbThoiGian.Size = new Size(192, 74);
            lbThoiGian.TabIndex = 2;
            lbThoiGian.Text = "Hiển thị giờ ở đây";
            lbThoiGian.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NHANVIEN
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 462);
            Controls.Add(tlpall);
            MainMenuStrip = menuStrip1;
            Name = "NHANVIEN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhân viên";
            tlpall.ResumeLayout(false);
            tlpall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tlpend.ResumeLayout(false);
            tlpend.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem bÁNHÀNGToolStripMenuItem;
        private ToolStripMenuItem sẢNPHẨMToolStripMenuItem;
        private ToolStripMenuItem tÀIKHOẢNToolStripMenuItem;
        private TableLayoutPanel tlpend;
        private Button btnThoat;
        private Button btnChamCong;
        private ToolStripMenuItem đỔIMẬTKHẨToolStripMenuItem;
        private ToolStripMenuItem đỔIMẬTKHẨUToolStripMenuItem;
        private Button btnBatDau;
        private Label lbThoiGian;
        private System.Windows.Forms.Timer timer1;
    }
}