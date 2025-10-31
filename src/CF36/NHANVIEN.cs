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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CF36
{
    public partial class NHANVIEN : Form
    {
        private string _hoten;
        private string nguoidunghientai;
        private string maNhanVien;
        private DateTime? gioBatDau;
        public NHANVIEN(string hoten, string username, string manhanvien)
        {
            InitializeComponent();
            _hoten = hoten;
            nguoidunghientai = username;
            maNhanVien = manhanvien;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblWelcome.Text = $"Chào mừng trở lại, {_hoten}";
        }

        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            timer1.Start();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void bÁNHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BANHANG bANHANG = new BANHANG();
            bANHANG.ShowDialog();
            this.Show();


        }

        private void sẢNPHẨMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemSanPhamNhanVien xemSanPhamNhanVien = new XemSanPhamNhanVien();
            xemSanPhamNhanVien.ShowDialog();
            this.Show();
        }
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            gioBatDau = DateTime.Now;
            lblTrangThai.Text = $"Đang làm việc từ {gioBatDau.Value:HH:mm:ss}";
            btnBatDau.Enabled = false;

        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            if (gioBatDau == null)
            {
                MessageBox.Show("Bạn chưa bắt đầu làm việc.");
                return;
            }

            DateTime gioKetThuc = DateTime.Now;
            TimeSpan thoiGianLam = gioKetThuc - gioBatDau.Value;
            int tongPhut = (int)thoiGianLam.TotalMinutes;

            bool success = ChamCongBUS.Instance.LuuChamCong(maNhanVien, gioBatDau.Value, gioKetThuc, tongPhut);
            if (success)
            {
                MessageBox.Show($"Chấm công thành công. Tổng thời gian làm: {tongPhut} phút.");
                lblTrangThai.Text = "Chưa làm việc";
                gioBatDau = null;
                btnBatDau.Enabled = true;
            }
            else
            {
                MessageBox.Show("Chấm công thất bại.");
            }

        }
        //Chấm công
        private void đỔIMẬTKHẨToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int tongPhut = ChamCongBUS.Instance.TinhTongGioLamTrongNgay(maNhanVien, DateTime.Today);
            string gio = (tongPhut / 60).ToString("00");
            string phut = (tongPhut % 60).ToString("00");
            MessageBox.Show($"Hôm nay bạn đã làm {gio} giờ {phut} phút.");


        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
        // Đổi mật khẩu
        private void đỔIMẬTKHẨUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhauNhanVien main = new DoiMatKhauNhanVien(nguoidunghientai);
            if (main.ShowDialog() == DialogResult.OK)
            {
                this.Close();
                Home login = new Home();
                login.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThoiGian.Text = DateTime.Now.ToString("HH:mm:ss");

        }
    }
}
