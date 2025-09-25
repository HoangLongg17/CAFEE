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
    public partial class QuanLiMAGIAMGIA : Form
    {
        public QuanLiMAGIAMGIA()
        {
            InitializeComponent();
        }

        private void btnThemMaGiamGia_Click(object sender, EventArgs e)
        {

            ThemMaGiamGia themMaGiamGia = new ThemMaGiamGia();
            themMaGiamGia.Show();
        }

        private void QuanLiMAGIAMGIA_Load(object sender, EventArgs e)
        {

        }

        private void btnSuaMaGiamGia_Click(object sender, EventArgs e)
        {
            SuaMaGiamGia suaMaGiamGia = new SuaMaGiamGia();
            suaMaGiamGia.Show();
        }
    }
}
