using BUS;
using DTO;
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
    public partial class DoiMatKhauNhanVien : Form
    {
        private TaiKhoanBUS doiMKBUS = new TaiKhoanBUS();
        private string nguoidunghientai;
        public DoiMatKhauNhanVien(string username)
        {
            InitializeComponent();
            nguoidunghientai = username;
            txtTenTaiKhoan.Text = username;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            string oldPass = txtMatKhau.Text.Trim();
            string newPass = txtMatKhauMoi.Text.Trim();
            string confirmPass = txtNhapLaiMatKhauMoi.Text.Trim();

            TaiKhoanDTO dto = new TaiKhoanDTO
            {
                Tk = nguoidunghientai,
                MkCu = oldPass,
                MkMoi = newPass,
                XacNhanMkMoi = confirmPass
            };
            
            string result = doiMKBUS.DoiMatKhau(nguoidunghientai, oldPass, newPass, confirmPass);
            MessageBox.Show(result);
            if (result == "Đổi mật khẩu thành công!")
            {
                MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                
                this.DialogResult= DialogResult.OK;
                this.Close();


               
              
            }
        }

        private void DoiMatKhauNhanVien_Load(object sender, EventArgs e)
        {
           //txtMatKhauMoi.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
