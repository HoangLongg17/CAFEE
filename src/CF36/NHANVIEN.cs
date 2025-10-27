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
    public partial class NHANVIEN : Form
    {
        private string _hoten;
        private string nguoidunghientai;
        public NHANVIEN(string hoten,string username)
        {
            InitializeComponent();
            _hoten = hoten;
            nguoidunghientai= username;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblWelcome.Text = $"Chào mừng trở lại, {_hoten}";
        }

        private void bÁNHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BANHANG bANHANG = new BANHANG();
            bANHANG.ShowDialog();
            this.Show();
        }

        private void sẢNPHẨMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemSanPhamNhanVien xemSanPhamNhanVien = new XemSanPhamNhanVien();
            xemSanPhamNhanVien.ShowDialog();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đỔIMẬTKHẨUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhauNhanVien main = new DoiMatKhauNhanVien(nguoidunghientai);
            if (main.ShowDialog() == DialogResult.OK)
            {
                this.Close();
                Home login = new Home();
                login.Show();
            }
        }
    }
}
