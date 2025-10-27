using BUS;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CF36
{
    public partial class DangNhapNV : Form
    {
        public DangNhapNV()
        {
            InitializeComponent();
        }
        private DangNhapNVBUS userBUS = new DangNhapNVBUS();
        private void btnlogin_Click(object sender, EventArgs e)
        {
            var result = userBUS.Login(txtusernv.Text, txtpasswordnv.Text);

            if (!result.isSuccess)
            {
                MessageBox.Show(result.message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string username = txtusernv.Text.Trim();
            NHANVIEN nhanvien = new NHANVIEN(result.user.Hoten, username);


            this.Hide();
            nhanvien.ShowDialog();
            this.Close();


        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {

            if (txtpasswordnv.PasswordChar == '*')
            {
                //Hiện
                txtpasswordnv.PasswordChar = '\0';
                btnPassword.Text = "🙈";

            }
            else
            {
                //Ẩn
                txtpasswordnv.PasswordChar = '*';
                btnPassword.Text = "👁️";

            }
        }

        private void DangNhapNV_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
