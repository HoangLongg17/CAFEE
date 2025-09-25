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
    public partial class DANHSACHSANPHAM : Form
    {
        public DANHSACHSANPHAM()
        {
            InitializeComponent();
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            ThemSanPham themSanPham = new ThemSanPham();
            themSanPham.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaSanPham suaSanPham = new SuaSanPham();
            suaSanPham.Show();
        }
    }
}
