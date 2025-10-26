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
using DAO;
using DTO;
namespace CF36
{
    public partial class NHANVIEN : Form
    {
        private string maNhanVien;
        private DateTime? gioBatDau;


        public NHANVIEN(string maNV)
        {
            InitializeComponent();
            maNhanVien = maNV;

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

        private void NHANVIEN_Load(object sender, EventArgs e)
        {

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

        private void đỔIMẬTKHẨToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tongPhut = ChamCongBUS.Instance.TinhTongGioLamTrongNgay(maNhanVien, DateTime.Today);
            string gio = (tongPhut / 60).ToString("00");
            string phut = (tongPhut % 60).ToString("00");
            MessageBox.Show($"Hôm nay bạn đã làm {gio} giờ {phut} phút.");

        }
    }
}
