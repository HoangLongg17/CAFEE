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
    public partial class QuanLiKho : Form
    {
        public QuanLiKho()
        {
            InitializeComponent();
        }

        private void btnThemKho_Click(object sender, EventArgs e)
        {
            ThemTonKho themTonKho = new ThemTonKho();
            themTonKho.Show();
        }

        private void btnLichSuKho_Click(object sender, EventArgs e)
        {
            LichSuNhapKho lichSuNhapKho = new LichSuNhapKho();
            lichSuNhapKho.Show();
        }
    }
}
