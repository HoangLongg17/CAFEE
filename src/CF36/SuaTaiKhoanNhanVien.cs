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
    public partial class SuaTaiKhoanNhanVien : Form
    {
        public SuaTaiKhoanNhanVien()
        {
            InitializeComponent();
        }

        private void SuaTaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);

        }
    }
}
