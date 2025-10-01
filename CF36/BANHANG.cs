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
    public partial class BANHANG : Form
    {
        public BANHANG()
        {
            InitializeComponent();
        }

        private void btnThemKhachHangMoi_Click(object sender, EventArgs e)
        {
            ThemKhachHang themKhachHang = new ThemKhachHang();
            themKhachHang.ShowDialog();
            this.Show();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.ShowDialog();
            this.Show();
        }
    }
}
