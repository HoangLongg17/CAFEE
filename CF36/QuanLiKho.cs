using BUS;
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
            this.Load += QuanLiKho_Load; 
            InitializeComponent();
            this.txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

        }
        private void QuanLiKho_Load(object sender, EventArgs e)
        {
            dgvKho.AutoGenerateColumns = false;
            dgvKho.DataSource = KhoBUS.LayTatCa();
        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvKho.DataSource = KhoBUS.TimKiem(txtTimKiem.Text);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            dgvKho.DataSource = KhoBUS.LayTatCa();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemKho_Click(object sender, EventArgs e)
        {
            ThemTonKho themTonKho = new ThemTonKho();
            themTonKho.Show();
        }

        
    }
}
