namespace CF36
{
    partial class SuaNhanVien
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
            tlpThongTin = new TableLayoutPanel();
            lbMaNhanVien = new Label();
            lbTenNhanVien = new Label();
            lbSoDienThoai = new Label();
            lbEmail = new Label();
            lbTenTaiKhoan = new Label();
            lbMatKhau = new Label();
            lbViTri = new Label();
            lbLuongTheoGio = new Label();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtTenNhanVien = new TextBox();
            txtMaNhanVien = new TextBox();
            txtTenTaiKhoan = new TextBox();
            txtMatKhau = new TextBox();
            txtLuongTheoGio = new TextBox();
            cbbViTri = new ComboBox();
            lbNgaySinh = new Label();
            dTPNgaySinh = new DateTimePicker();
            txtSTK = new TextBox();
            cbbNganHang = new ComboBox();
            lbNganHang = new Label();
            lbChonNganHang = new Label();
            tlpbutton = new TableLayoutPanel();
            btnThoat = new Button();
            btnLamMoi = new Button();
            btnLuu = new Button();
            tlpall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tlpThongTin.SuspendLayout();
            tlpbutton.SuspendLayout();
            SuspendLayout();
            // 
            // tlpall
            // 
            tlpall.ColumnCount = 1;
            tlpall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpall.Controls.Add(picLogo, 0, 0);
            tlpall.Controls.Add(tlpThongTin, 0, 1);
            tlpall.Controls.Add(tlpbutton, 0, 2);
            tlpall.Dock = DockStyle.Fill;
            tlpall.Location = new Point(0, 0);
            tlpall.Margin = new Padding(3, 2, 3, 2);
            tlpall.Name = "tlpall";
            tlpall.RowCount = 4;
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 16.2222214F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 55.77778F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 22.2222214F));
            tlpall.RowStyles.Add(new RowStyle(SizeType.Percent, 5.55555534F));
            tlpall.Size = new Size(700, 338);
            tlpall.TabIndex = 0;
            tlpall.Paint += tlpall_Paint;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 2);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(694, 50);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // tlpThongTin
            // 
            tlpThongTin.ColumnCount = 4;
            tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.9685535F));
            tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.8110828F));
            tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.7430735F));
            tlpThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.760704F));
            tlpThongTin.Controls.Add(lbMaNhanVien, 0, 0);
            tlpThongTin.Controls.Add(lbTenNhanVien, 0, 1);
            tlpThongTin.Controls.Add(lbSoDienThoai, 0, 2);
            tlpThongTin.Controls.Add(lbEmail, 0, 3);
            tlpThongTin.Controls.Add(lbTenTaiKhoan, 2, 0);
            tlpThongTin.Controls.Add(lbMatKhau, 2, 1);
            tlpThongTin.Controls.Add(lbViTri, 2, 2);
            tlpThongTin.Controls.Add(lbLuongTheoGio, 2, 3);
            tlpThongTin.Controls.Add(txtSoDienThoai, 1, 2);
            tlpThongTin.Controls.Add(txtEmail, 1, 3);
            tlpThongTin.Controls.Add(txtTenNhanVien, 1, 1);
            tlpThongTin.Controls.Add(txtMaNhanVien, 1, 0);
            tlpThongTin.Controls.Add(txtTenTaiKhoan, 3, 0);
            tlpThongTin.Controls.Add(txtMatKhau, 3, 1);
            tlpThongTin.Controls.Add(txtLuongTheoGio, 3, 3);
            tlpThongTin.Controls.Add(cbbViTri, 3, 2);
            tlpThongTin.Controls.Add(lbNgaySinh, 0, 4);
            tlpThongTin.Controls.Add(dTPNgaySinh, 1, 4);
            tlpThongTin.Controls.Add(txtSTK, 3, 5);
            tlpThongTin.Controls.Add(cbbNganHang, 3, 4);
            tlpThongTin.Controls.Add(lbNganHang, 2, 5);
            tlpThongTin.Controls.Add(lbChonNganHang, 2, 4);
            tlpThongTin.Dock = DockStyle.Fill;
            tlpThongTin.Location = new Point(3, 56);
            tlpThongTin.Margin = new Padding(3, 2, 3, 2);
            tlpThongTin.Name = "tlpThongTin";
            tlpThongTin.RowCount = 6;
            tlpThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6153851F));
            tlpThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 16.9230766F));
            tlpThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 17.6923084F));
            tlpThongTin.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0873356F));
            tlpThongTin.Size = new Size(694, 184);
            tlpThongTin.TabIndex = 1;
            // 
            // lbMaNhanVien
            // 
            lbMaNhanVien.Anchor = AnchorStyles.Right;
            lbMaNhanVien.AutoSize = true;
            lbMaNhanVien.Location = new Point(90, 6);
            lbMaNhanVien.Name = "lbMaNhanVien";
            lbMaNhanVien.Size = new Size(79, 15);
            lbMaNhanVien.TabIndex = 0;
            lbMaNhanVien.Text = "Mã nhân viên";
            // 
            // lbTenNhanVien
            // 
            lbTenNhanVien.Anchor = AnchorStyles.Right;
            lbTenNhanVien.AutoSize = true;
            lbTenNhanVien.Location = new Point(88, 33);
            lbTenNhanVien.Name = "lbTenNhanVien";
            lbTenNhanVien.Size = new Size(81, 15);
            lbTenNhanVien.TabIndex = 0;
            lbTenNhanVien.Text = "Tên nhân viên";
            // 
            // lbSoDienThoai
            // 
            lbSoDienThoai.Anchor = AnchorStyles.Right;
            lbSoDienThoai.AutoSize = true;
            lbSoDienThoai.Location = new Point(93, 60);
            lbSoDienThoai.Name = "lbSoDienThoai";
            lbSoDienThoai.Size = new Size(76, 15);
            lbSoDienThoai.TabIndex = 0;
            lbSoDienThoai.Text = "Số điện thoại";
            // 
            // lbEmail
            // 
            lbEmail.Anchor = AnchorStyles.Right;
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(133, 89);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(36, 15);
            lbEmail.TabIndex = 0;
            lbEmail.Text = "Email";
            // 
            // lbTenTaiKhoan
            // 
            lbTenTaiKhoan.Anchor = AnchorStyles.Right;
            lbTenTaiKhoan.AutoSize = true;
            lbTenTaiKhoan.Location = new Point(370, 6);
            lbTenTaiKhoan.Name = "lbTenTaiKhoan";
            lbTenTaiKhoan.Size = new Size(78, 15);
            lbTenTaiKhoan.TabIndex = 1;
            lbTenTaiKhoan.Text = "Tên tài khoản";
            // 
            // lbMatKhau
            // 
            lbMatKhau.Anchor = AnchorStyles.Right;
            lbMatKhau.AutoSize = true;
            lbMatKhau.Location = new Point(391, 33);
            lbMatKhau.Name = "lbMatKhau";
            lbMatKhau.Size = new Size(57, 15);
            lbMatKhau.TabIndex = 1;
            lbMatKhau.Text = "Mật khẩu";
            // 
            // lbViTri
            // 
            lbViTri.Anchor = AnchorStyles.Right;
            lbViTri.AutoSize = true;
            lbViTri.Location = new Point(417, 60);
            lbViTri.Name = "lbViTri";
            lbViTri.Size = new Size(31, 15);
            lbViTri.TabIndex = 1;
            lbViTri.Text = "Vị trí";
            // 
            // lbLuongTheoGio
            // 
            lbLuongTheoGio.Anchor = AnchorStyles.Right;
            lbLuongTheoGio.AutoSize = true;
            lbLuongTheoGio.Location = new Point(360, 89);
            lbLuongTheoGio.Name = "lbLuongTheoGio";
            lbLuongTheoGio.Size = new Size(88, 15);
            lbLuongTheoGio.TabIndex = 1;
            lbLuongTheoGio.Text = "Lương theo giờ";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Anchor = AnchorStyles.Left;
            txtSoDienThoai.Location = new Point(175, 56);
            txtSoDienThoai.Margin = new Padding(3, 2, 3, 2);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(165, 23);
            txtSoDienThoai.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left;
            txtEmail.Location = new Point(175, 85);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(165, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtTenNhanVien
            // 
            txtTenNhanVien.Anchor = AnchorStyles.Left;
            txtTenNhanVien.Location = new Point(175, 29);
            txtTenNhanVien.Margin = new Padding(3, 2, 3, 2);
            txtTenNhanVien.Name = "txtTenNhanVien";
            txtTenNhanVien.Size = new Size(165, 23);
            txtTenNhanVien.TabIndex = 2;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Anchor = AnchorStyles.Left;
            txtMaNhanVien.Location = new Point(175, 2);
            txtMaNhanVien.Margin = new Padding(3, 2, 3, 2);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(165, 23);
            txtMaNhanVien.TabIndex = 2;
            // 
            // txtTenTaiKhoan
            // 
            txtTenTaiKhoan.Anchor = AnchorStyles.Left;
            txtTenTaiKhoan.Location = new Point(454, 2);
            txtTenTaiKhoan.Margin = new Padding(3, 2, 3, 2);
            txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            txtTenTaiKhoan.Size = new Size(173, 23);
            txtTenTaiKhoan.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Anchor = AnchorStyles.Left;
            txtMatKhau.Location = new Point(454, 29);
            txtMatKhau.Margin = new Padding(3, 2, 3, 2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(173, 23);
            txtMatKhau.TabIndex = 3;
            // 
            // txtLuongTheoGio
            // 
            txtLuongTheoGio.Anchor = AnchorStyles.Left;
            txtLuongTheoGio.Location = new Point(454, 85);
            txtLuongTheoGio.Margin = new Padding(3, 2, 3, 2);
            txtLuongTheoGio.Name = "txtLuongTheoGio";
            txtLuongTheoGio.Size = new Size(173, 23);
            txtLuongTheoGio.TabIndex = 3;
            // 
            // cbbViTri
            // 
            cbbViTri.Anchor = AnchorStyles.Left;
            cbbViTri.FormattingEnabled = true;
            cbbViTri.Location = new Point(454, 56);
            cbbViTri.Margin = new Padding(3, 2, 3, 2);
            cbbViTri.Name = "cbbViTri";
            cbbViTri.Size = new Size(173, 23);
            cbbViTri.TabIndex = 4;
            cbbViTri.SelectedIndexChanged += cbbViTri_SelectedIndexChanged;
            // 
            // lbNgaySinh
            // 
            lbNgaySinh.Anchor = AnchorStyles.Right;
            lbNgaySinh.AutoSize = true;
            lbNgaySinh.Location = new Point(109, 120);
            lbNgaySinh.Name = "lbNgaySinh";
            lbNgaySinh.Size = new Size(60, 15);
            lbNgaySinh.TabIndex = 5;
            lbNgaySinh.Text = "Ngày sinh";
            // 
            // dTPNgaySinh
            // 
            dTPNgaySinh.Anchor = AnchorStyles.Left;
            dTPNgaySinh.Location = new Point(175, 116);
            dTPNgaySinh.Margin = new Padding(3, 2, 3, 2);
            dTPNgaySinh.Name = "dTPNgaySinh";
            dTPNgaySinh.Size = new Size(165, 23);
            dTPNgaySinh.TabIndex = 6;
            // 
            // txtSTK
            // 
            txtSTK.Anchor = AnchorStyles.Left;
            txtSTK.Location = new Point(454, 152);
            txtSTK.Margin = new Padding(3, 2, 3, 2);
            txtSTK.Name = "txtSTK";
            txtSTK.Size = new Size(173, 23);
            txtSTK.TabIndex = 8;
            // 
            // cbbNganHang
            // 
            cbbNganHang.Anchor = AnchorStyles.Left;
            cbbNganHang.FormattingEnabled = true;
            cbbNganHang.Location = new Point(454, 116);
            cbbNganHang.Margin = new Padding(3, 2, 3, 2);
            cbbNganHang.Name = "cbbNganHang";
            cbbNganHang.Size = new Size(173, 23);
            cbbNganHang.TabIndex = 10;
            cbbNganHang.SelectedIndexChanged += cbbNganHang_SelectedIndexChanged;
            // 
            // lbNganHang
            // 
            lbNganHang.Anchor = AnchorStyles.Right;
            lbNganHang.AutoSize = true;
            lbNganHang.Location = new Point(351, 149);
            lbNganHang.Name = "lbNganHang";
            lbNganHang.Size = new Size(97, 30);
            lbNganHang.TabIndex = 7;
            lbNganHang.Text = "Số tài khoản/Mã thẻ";
            // 
            // lbChonNganHang
            // 
            lbChonNganHang.Anchor = AnchorStyles.Right;
            lbChonNganHang.AutoSize = true;
            lbChonNganHang.Location = new Point(382, 120);
            lbChonNganHang.Name = "lbChonNganHang";
            lbChonNganHang.Size = new Size(66, 15);
            lbChonNganHang.TabIndex = 9;
            lbChonNganHang.Text = "Ngân hàng";
            // 
            // tlpbutton
            // 
            tlpbutton.ColumnCount = 4;
            tlpbutton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpbutton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.5163727F));
            tlpbutton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.3576822F));
            tlpbutton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpbutton.Controls.Add(btnThoat, 3, 0);
            tlpbutton.Controls.Add(btnLamMoi, 2, 0);
            tlpbutton.Controls.Add(btnLuu, 1, 0);
            tlpbutton.Dock = DockStyle.Fill;
            tlpbutton.Location = new Point(3, 244);
            tlpbutton.Margin = new Padding(3, 2, 3, 2);
            tlpbutton.Name = "tlpbutton";
            tlpbutton.RowCount = 1;
            tlpbutton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpbutton.Size = new Size(694, 71);
            tlpbutton.TabIndex = 2;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(521, 2);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(99, 38);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(422, 2);
            btnLamMoi.Margin = new Padding(3, 2, 3, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(93, 38);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.Location = new Point(321, 2);
            btnLuu.Margin = new Padding(3, 2, 3, 2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(95, 38);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "LƯU";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // SuaNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(tlpall);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SuaNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa thông tin nhân viên";
            Load += SuaNhanVien_Load;
            tlpall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tlpThongTin.ResumeLayout(false);
            tlpThongTin.PerformLayout();
            tlpbutton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpall;
        private PictureBox picLogo;
        private TableLayoutPanel tlpThongTin;
        private Label lbMaNhanVien;
        private Label lbTenNhanVien;
        private Label lbSoDienThoai;
        private Label lbEmail;
        private Label lbTenTaiKhoan;
        private Label lbMatKhau;
        private Label lbViTri;
        private Label lbLuongTheoGio;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private TextBox txtTenNhanVien;
        private TextBox txtMaNhanVien;
        private TextBox txtTenTaiKhoan;
        private TextBox txtMatKhau;
        private TextBox txtLuongTheoGio;
        private ComboBox cbbViTri;
        private Label lbNgaySinh;
        private DateTimePicker dTPNgaySinh;
        private TableLayoutPanel tlpbutton;
        private Button btnThoat;
        private Button btnLamMoi;
        private Button btnLuu;
        private Label lbNganHang;
        private TextBox txtSTK;
        private Label lbChonNganHang;
        private ComboBox cbbNganHang;
    }
}