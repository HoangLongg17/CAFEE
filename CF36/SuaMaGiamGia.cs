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
    public partial class SuaMaGiamGia : Form
    {
        public SuaMaGiamGia()
        {
            InitializeComponent();
        }

        private void btnSuaMaGiamGiaMua1Tang1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SuaMaGiamGiaMua1Tang1 suaMaGiamGiaMua1Tang1 = new SuaMaGiamGiaMua1Tang1();
            suaMaGiamGiaMua1Tang1.ShowDialog();
            this.Show();
        }
    }
}
