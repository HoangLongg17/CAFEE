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
    public partial class SuaSanPham : Form
    {
        public SuaSanPham()
        {
            InitializeComponent();
        }

        private void SuaSanPham_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);

        }
    }
}
