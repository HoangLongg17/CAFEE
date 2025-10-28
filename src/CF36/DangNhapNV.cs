using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var result = userBUS.Login(username, password);

            if (!result.isSuccess)
            {
                MessageBox.Show(result.message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ✅ Lấy mã nhân viên bằng hàm đúng
            string mand = userBUS.GetEmployeeIDByUsername(username);

            if (string.IsNullOrEmpty(mand))
            {
                MessageBox.Show("Không tìm thấy mã nhân viên tương ứng.");
                return;
            }

            // Gán thông tin người dùng hiện tại
            CurrentUser.Mand = mand;

            // Tạo form nhân viên
            NHANVIEN nhanvien = new NHANVIEN(result.user.Hoten, username, mand);

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
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
        }

        private void btnPassword_Click_1(object sender, EventArgs e)
        {
            if (txtpasswordnv.PasswordChar == '*')
            {
                // Hiện mật khẩu
                txtpasswordnv.PasswordChar = '\0';
                btnPassword.Text = "🙈";
            }
            else
            {
                // Ẩn mật khẩu
                txtpasswordnv.PasswordChar = '*';
                btnPassword.Text = "👁️";
            }
        }
    }
}
