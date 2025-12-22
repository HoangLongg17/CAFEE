using BUS;
using System;
using System.Windows.Forms;

namespace CF36
{
    public partial class DangNhapNV : Form
    {
        private DangNhapNVBUS userBUS = new DangNhapNVBUS();

        public DangNhapNV()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusernv.Text.Trim();
            string password = txtpasswordnv.Text.Trim();

            // 🛑 Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔐 Login
            var result = userBUS.Login(username, password);

            // ❌ Đăng nhập thất bại
            if (!result.success)
            {
                MessageBox.Show(result.message,
                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Đăng nhập thành công
            MessageBox.Show(result.message,
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 👉 Lấy thẳng từ result.user (KHÔNG query lại DB)
            string manv = result.user.Manv;

            if (string.IsNullOrEmpty(manv))
            {
                MessageBox.Show("Không tìm thấy mã nhân viên.",
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🌍 Lưu user hiện tại (context)
            CurrentUser.Manv = manv;

            // 🚀 Mở form nhân viên
            NHANVIEN nhanvien = new NHANVIEN(
                result.user.Hoten,
                username,
                manv
            );

            this.Hide();
            nhanvien.ShowDialog();
            this.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhapNV_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(
                this,
                Properties.Resources.exit,
                Properties.Resources.delete,
                Properties.Resources.refresh,
                Properties.Resources.done
            );

            UIText.ApplyButtonTextStyle(this);
        }

        private void btnPassword_Click_1(object sender, EventArgs e)
        {
            if (txtpasswordnv.PasswordChar == '*')
            {
                txtpasswordnv.PasswordChar = '\0';
                btnPassword.Text = "🙈";
            }
            else
            {
                txtpasswordnv.PasswordChar = '*';
                btnPassword.Text = "👁️";
            }
        }
    }
}
