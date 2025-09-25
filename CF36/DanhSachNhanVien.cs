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
    public partial class DanhSachNhanVien : Form
    {
        public DanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            ThemNhanVien themNhanVien = new ThemNhanVien();
            themNhanVien.ShowDialog();
            this.Show();
        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            SuaNhanVien suaNhanVien = new SuaNhanVien();
            suaNhanVien.ShowDialog();
            this.Show();
        }
    }
}
