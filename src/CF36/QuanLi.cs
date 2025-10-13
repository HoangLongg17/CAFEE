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
    public partial class QuanLi : Form
    {
        public QuanLi()
        {
            InitializeComponent();
        }

        private void tÌMHÓAĐƠNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void QuanLi_Load(object sender, EventArgs e)
        {

        }

        private void dANHSÁCHSẢNPHẨMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DANHSACHSANPHAM dANHSACHSANPHAM = new DANHSACHSANPHAM();
            dANHSACHSANPHAM.ShowDialog();
            this.Show();
        }

        private void dANHSÁCHMÃGIẢMGIÁToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiMAGIAMGIA quanLiMAGIAMGIA = new QuanLiMAGIAMGIA();
            quanLiMAGIAMGIA.ShowDialog();
            this.Show();
        }


        private void dANHSÁCHNHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DanhSachNhanVien danhSachNhanVien = new DanhSachNhanVien();
            danhSachNhanVien.ShowDialog();
            this.Show();
        }

        private void đỔIMẬTKHẨUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoiMatKhauQuanLi doiMatKhauQuanLi = new DoiMatKhauQuanLi();
            doiMatKhauQuanLi.ShowDialog();
            this.Show();
        }

        private void xEMKHOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiKho quanLiKho = new QuanLiKho();
            quanLiKho.ShowDialog();
            this.Show();
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            THONGKE tHONGKE = new THONGKE();
            tHONGKE.ShowDialog();
            this.Show();
        }

        private void lịchSửHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LICHSUHOADON lICHSUHOADON = new LICHSUHOADON();
            lICHSUHOADON.ShowDialog();
            this.Show();
        }

        private void quảnLíKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiKhachHang quanLiKhachHang = new QuanLiKhachHang();
            quanLiKhachHang.ShowDialog();
            this.Show();
        }

        private void bÁNHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BANHANG bANHANG = new BANHANG();
            bANHANG.ShowDialog();
            this.Show();
        }
    }
}
