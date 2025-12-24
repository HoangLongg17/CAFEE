using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DocumentFormat.OpenXml.ExtendedProperties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CF36
{
    public partial class NhanVienKho : Form
    {
        private string _hoten;
        private string nguoidunghientai;
        private string maNhanVien;
        private DateTime? gioBatDau;

        public NhanVienKho(string hoten, string username, string manhanvien)
        {
            InitializeComponent();
            _hoten = hoten;
            nguoidunghientai = username;
            maNhanVien = manhanvien;

        }


        private void btnChamCong_Click(object sender, EventArgs e)
        {
            bool success = ChamCongBUS.Instance.ChamCong(maNhanVien);

            if (success)
            {
                int tongPhut = ChamCongBUS.Instance
                    .TinhTongGioLamTrongNgay(maNhanVien, DateTime.Today);

                MessageBox.Show($"Chấm công thành công. Tổng thời gian làm: {tongPhut} phút.");
                lblTrangThai.Text = "Chưa làm việc";
                gioBatDau = null;
                btnBatDau.Enabled = true;
            }
            else
            {
                MessageBox.Show("Chưa bấm Bắt đầu hoặc đã chấm công.");
            }
        }
        private void NhanVienKho_Load(object sender, EventArgs e)
        {
            timer1.Start();

            // Áp dụng giao diện (icons) nếu có class hỗ trợ như bên form NHANVIEN
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);
        }
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            bool ok = ChamCongBUS.Instance.BatDauLam(maNhanVien);
            if (!ok)
            {
                MessageBox.Show("Không thể bắt đầu làm việc.");
                return;
            }

            gioBatDau = DateTime.Now;
            lblTrangThai.Text = $"Đang làm việc từ {gioBatDau:HH:mm:ss}";
            btnBatDau.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sẢNPHẨMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemSanPhamNhanVien xemSanPhamNhanVien = new XemSanPhamNhanVien();
            xemSanPhamNhanVien.ShowDialog();
            this.Show();
        }

        private void kHOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiKho quanLiKho = new QuanLiKho();
            quanLiKho.ShowDialog();
            this.Show();
        }

        private void tÀIKHOẢNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xEMGIỜLÀMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tongPhut = ChamCongBUS.Instance.TinhTongGioLamTrongNgay(maNhanVien, DateTime.Today);
            string gio = (tongPhut / 60).ToString("00");
            string phut = (tongPhut % 60).ToString("00");
            MessageBox.Show($"Hôm nay bạn đã làm {gio} giờ {phut} phút.");
        }

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

        private void lblTrangThai_Click(object sender, EventArgs e)
        {

        }

        private void tlpall_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void tlpbutton_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
