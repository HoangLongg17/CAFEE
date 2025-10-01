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
    public partial class QuanLiKhachHang : Form
    {
        public QuanLiKhachHang()
        {
            InitializeComponent();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            ThemKhachHang themKhachHang = new ThemKhachHang();
            themKhachHang.ShowDialog();
            this.Show();
        }

        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            SuaKhachHang suaKhachHang = new SuaKhachHang();
            suaKhachHang.ShowDialog();
            this.Show();
        }
    }
}
