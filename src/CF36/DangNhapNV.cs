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
        public DangNhapNV()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusernv.Text.Trim();
            string password = txtpasswordnv.Text.Trim();

            // Kiểm tra thông tin đăng nhập
            bool isValid = DangNhapNVBUS.Instance.Login(username, password);

            if (!isValid)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                return;
            }

            // Lấy mã nhân viên từ username
            string mand = DangNhapNVBUS.Instance.GetEmployeeIDByUsername(username);

            if (string.IsNullOrEmpty(mand))
            {
                MessageBox.Show("Không tìm thấy mã nhân viên tương ứng.");
                return;
            }

            // Gán thông tin người dùng hiện tại
            CurrentUser.Mand = mand;
            CurrentUser.Tk = username;

            // Mở giao diện nhân viên
            this.Hide();
            NHANVIEN frmNV = new NHANVIEN(mand);
            frmNV.ShowDialog();
            this.Show();

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhapNV_Load(object sender, EventArgs e)
        {

        }
    }
}
