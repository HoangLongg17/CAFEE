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
    public partial class NHANVIEN : Form
    {
        public NHANVIEN()
        {
            InitializeComponent();
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
    }
}
