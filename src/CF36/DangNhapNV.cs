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
            string username = txtusernv.Text;
            string password = txtpasswordnv.Text;

            // Kiểm tra thông tin đăng nhập
            if (DangNhapNVBUS.Instance.Login(username, password))
            {
                // Giả sử bạn đã kiểm tra thông tin đăng nhập thành công và lấy được EmployeeID
                int mand = DangNhapNVBUS.Instance.GetEmployeeIDByUsername(username);

                // Thiết lập thông tin người dùng hiện tại
                CurrentUser.Mand = mand;
                CurrentUser.Tk = username;

                // Chuyển đến form chính hoặc thực hiện các hành động khác
                NHANVIEN quanLi = new NHANVIEN();
                this.Hide();
                quanLi.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
