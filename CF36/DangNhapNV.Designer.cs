namespace CF36
{
    partial class DangNhapNV
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
            tlpthan = new TableLayoutPanel();
            lbusername = new Label();
            pntendangnhap = new Panel();
            txtusernv = new TextBox();
            lbiconuser = new Label();
            pnpasswordnv = new Panel();
            button1 = new Button();
            txtpasswordnv = new TextBox();
            lbiconpassword = new Label();
            lbpassword = new Label();
            pnbutton = new Panel();
            btnlogin = new Button();
            btnexit = new Button();
            tlpfrmDNADMIN = new TableLayoutPanel();
            lblogo = new Label();
            lblognhanvien = new Label();
            tlpthan.SuspendLayout();
            pntendangnhap.SuspendLayout();
            pnpasswordnv.SuspendLayout();
            pnbutton.SuspendLayout();
            tlpfrmDNADMIN.SuspendLayout();
            SuspendLayout();
            // 
            // tlpthan
            // 
            tlpthan.ColumnCount = 2;
            tlpthan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpthan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlpthan.Controls.Add(lbusername, 0, 0);
            tlpthan.Controls.Add(pntendangnhap, 1, 0);
            tlpthan.Controls.Add(pnpasswordnv, 1, 1);
            tlpthan.Controls.Add(lbpassword, 0, 1);
            tlpthan.Controls.Add(pnbutton, 1, 2);
            tlpthan.Dock = DockStyle.Fill;
            tlpthan.Location = new Point(3, 117);
            tlpthan.Name = "tlpthan";
            tlpthan.RowCount = 4;
            tlpthan.RowStyles.Add(new RowStyle());
            tlpthan.RowStyles.Add(new RowStyle());
            tlpthan.RowStyles.Add(new RowStyle());
            tlpthan.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpthan.Size = new Size(794, 330);
            tlpthan.TabIndex = 2;
            // 
            // lbusername
            // 
            lbusername.AutoSize = true;
            lbusername.Dock = DockStyle.Right;
            lbusername.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbusername.Location = new Point(162, 0);
            lbusername.Name = "lbusername";
            lbusername.Size = new Size(112, 82);
            lbusername.TabIndex = 0;
            lbusername.Text = "Tên đăng nhập";
            lbusername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pntendangnhap
            // 
            pntendangnhap.Controls.Add(txtusernv);
            pntendangnhap.Controls.Add(lbiconuser);
            pntendangnhap.Dock = DockStyle.Fill;
            pntendangnhap.Location = new Point(280, 3);
            pntendangnhap.Name = "pntendangnhap";
            pntendangnhap.Size = new Size(511, 76);
            pntendangnhap.TabIndex = 1;
            // 
            // txtusernv
            // 
            txtusernv.Location = new Point(59, 22);
            txtusernv.Name = "txtusernv";
            txtusernv.Size = new Size(335, 27);
            txtusernv.TabIndex = 1;
            txtusernv.Text = "nv_phuc";
            // 
            // lbiconuser
            // 
            lbiconuser.Location = new Point(3, 9);
            lbiconuser.Name = "lbiconuser";
            lbiconuser.Size = new Size(50, 50);
            lbiconuser.TabIndex = 0;
            // 
            // pnpasswordnv
            // 
            pnpasswordnv.Controls.Add(button1);
            pnpasswordnv.Controls.Add(txtpasswordnv);
            pnpasswordnv.Controls.Add(lbiconpassword);
            pnpasswordnv.Dock = DockStyle.Fill;
            pnpasswordnv.Location = new Point(280, 85);
            pnpasswordnv.Name = "pnpasswordnv";
            pnpasswordnv.Size = new Size(511, 76);
            pnpasswordnv.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(279, 22);
            button1.Name = "button1";
            button1.Size = new Size(60, 35);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = true;
            // 
            // txtpasswordnv
            // 
            txtpasswordnv.Location = new Point(59, 26);
            txtpasswordnv.Name = "txtpasswordnv";
            txtpasswordnv.Size = new Size(214, 27);
            txtpasswordnv.TabIndex = 4;
            txtpasswordnv.Text = "Nv!12345";
            // 
            // lbiconpassword
            // 
            lbiconpassword.Location = new Point(3, 12);
            lbiconpassword.Name = "lbiconpassword";
            lbiconpassword.Size = new Size(50, 50);
            lbiconpassword.TabIndex = 3;
            // 
            // lbpassword
            // 
            lbpassword.AutoSize = true;
            lbpassword.Dock = DockStyle.Right;
            lbpassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbpassword.Location = new Point(199, 82);
            lbpassword.Name = "lbpassword";
            lbpassword.Size = new Size(75, 82);
            lbpassword.TabIndex = 3;
            lbpassword.Text = "Mật khẩu";
            lbpassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnbutton
            // 
            pnbutton.Controls.Add(btnlogin);
            pnbutton.Controls.Add(btnexit);
            pnbutton.Dock = DockStyle.Fill;
            pnbutton.Location = new Point(280, 167);
            pnbutton.Name = "pnbutton";
            pnbutton.Size = new Size(511, 77);
            pnbutton.TabIndex = 4;
            // 
            // btnlogin
            // 
            btnlogin.BackColor = Color.DarkRed;
            btnlogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogin.ForeColor = Color.White;
            btnlogin.Location = new Point(0, 0);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(112, 77);
            btnlogin.TabIndex = 0;
            btnlogin.Text = "ĐĂNG NHẬP";
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // btnexit
            // 
            btnexit.BackColor = Color.DarkRed;
            btnexit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnexit.ForeColor = Color.White;
            btnexit.Location = new Point(196, 3);
            btnexit.Name = "btnexit";
            btnexit.Size = new Size(112, 71);
            btnexit.TabIndex = 0;
            btnexit.Text = "THOÁT";
            btnexit.UseVisualStyleBackColor = false;
            btnexit.Click += btnexit_Click;
            // 
            // tlpfrmDNADMIN
            // 
            tlpfrmDNADMIN.ColumnCount = 1;
            tlpfrmDNADMIN.ColumnStyles.Add(new ColumnStyle());
            tlpfrmDNADMIN.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpfrmDNADMIN.Controls.Add(lblogo, 0, 0);
            tlpfrmDNADMIN.Controls.Add(lblognhanvien, 0, 1);
            tlpfrmDNADMIN.Controls.Add(tlpthan, 0, 2);
            tlpfrmDNADMIN.Dock = DockStyle.Fill;
            tlpfrmDNADMIN.Location = new Point(0, 0);
            tlpfrmDNADMIN.Name = "tlpfrmDNADMIN";
            tlpfrmDNADMIN.RowCount = 3;
            tlpfrmDNADMIN.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6297112F));
            tlpfrmDNADMIN.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tlpfrmDNADMIN.RowStyles.Add(new RowStyle(SizeType.Percent, 74.27938F));
            tlpfrmDNADMIN.Size = new Size(800, 450);
            tlpfrmDNADMIN.TabIndex = 1;
            // 
            // lblogo
            // 
            lblogo.AutoSize = true;
            lblogo.Dock = DockStyle.Fill;
            lblogo.Location = new Point(3, 0);
            lblogo.Name = "lblogo";
            lblogo.Size = new Size(794, 74);
            lblogo.TabIndex = 0;
            // 
            // lblognhanvien
            // 
            lblognhanvien.AutoSize = true;
            lblognhanvien.Dock = DockStyle.Fill;
            lblognhanvien.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblognhanvien.Location = new Point(3, 74);
            lblognhanvien.Name = "lblognhanvien";
            lblognhanvien.Size = new Size(794, 40);
            lblognhanvien.TabIndex = 1;
            lblognhanvien.Text = "ĐĂNG NHẬP NHÂN VIÊN";
            lblognhanvien.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DangNhapNV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpfrmDNADMIN);
            Name = "DangNhapNV";
            Text = "DangNhapNV";
            tlpthan.ResumeLayout(false);
            tlpthan.PerformLayout();
            pntendangnhap.ResumeLayout(false);
            pntendangnhap.PerformLayout();
            pnpasswordnv.ResumeLayout(false);
            pnpasswordnv.PerformLayout();
            pnbutton.ResumeLayout(false);
            tlpfrmDNADMIN.ResumeLayout(false);
            tlpfrmDNADMIN.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpthan;
        private Label lbusername;
        private Panel pntendangnhap;
        private TextBox txtusernv;
        private Label lbiconuser;
        private Panel pnpasswordnv;
        private Button button1;
        private TextBox txtpasswordnv;
        private Label lbiconpassword;
        private Label lbpassword;
        private Panel pnbutton;
        private Button btnlogin;
        private Button btnexit;
        private TableLayoutPanel tlpfrmDNADMIN;
        private Label lblogo;
        private Label lblognhanvien;
    }
}