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
        private string _hoten;
        private string nguoidunghientai;
        public QuanLi(string hoten, string username)
        {
            InitializeComponent();
            _hoten = hoten;
            nguoidunghientai = username;

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblWelcome.Text = $"Chào mừng trở lại, {_hoten}".ToUpper();
        }

        private void tÌMHÓAĐƠNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void QuanLi_Load(object sender, EventArgs e)
        {
            timer1.Start();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);

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
            DoiMatKhauQuanLi main = new DoiMatKhauQuanLi(nguoidunghientai);
            if (main.ShowDialog() == DialogResult.OK)
            {
                this.Close();
                Home login = new Home();
                login.Show();
            }
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

        private void lịchSửNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LichSuNhapKho lichSuNhapKho = new LichSuNhapKho();
            lichSuNhapKho.ShowDialog();
            this.Show();


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lịchSửChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LichSuChamCong lichSuChamCong = new LichSuChamCong();
            lichSuChamCong.ShowDialog();
            this.Show();
        }

        private void bThoiGian_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bThoiGian.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void mÃGIẢMGIÁToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chiTiếtTrảHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TraHang frmTraHang = new TraHang();
            frmTraHang.Show();
        }

        private void lịchSửTrảHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LichSuTraHang frmLichSuTraHang = new LichSuTraHang();
            frmLichSuTraHang.Show();
        }
    }

}
