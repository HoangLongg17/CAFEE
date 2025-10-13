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
    public partial class ThemMaGiamGia : Form
    {
        public ThemMaGiamGia()
        {
            InitializeComponent();
        }

        private void btnThemMaGiamGia1tang1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThemMaGiamGia1tang1 themMaGiamGia1Tang1 = new ThemMaGiamGia1tang1();
            themMaGiamGia1Tang1.ShowDialog();
            this.Show();
        }
    }
}
