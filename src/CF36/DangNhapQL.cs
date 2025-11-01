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

namespace CF36
{
    public partial class DangNhapQL : Form
    {
        public DangNhapQL()
        {
            InitializeComponent();
        }

        private DangNhapQLBUS userBUS = new DangNhapQLBUS();
        public static string MaNguoiDungDangNhap;
        private void btnlogin_Click(object sender, EventArgs e)
        {
            var result = userBUS.Login(txtusernv.Text, txtpasswordnv.Text);

            if (!result.isSuccess)
            {
                MessageBox.Show(result.message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MaNguoiDungDangNhap = result.user.Mand;
            CurrentUser.Mand = result.user.Mand;
            string username = txtusernv.Text.Trim();
            QuanLi ql = new QuanLi(result.user.Hoten, username);
            this.Hide();
            ql.ShowDialog();
            this.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void DangNhapQL_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnPassword_Click_1(object sender, EventArgs e)
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

        private void DangNhapQL_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);
        }

        private void tlpfrmDNADMIN_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
