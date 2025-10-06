using CF36.BUS;
using CF36.DTO;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace CF36
{
    public partial class THONGKE : Form
    {
        private string connectionString;
        private ThongKeBUS thongKeBUS;

        public THONGKE()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QUANLICAFE36"]?.ConnectionString ??
                              "Data Source=DESKTOP-7660KT7;Initial Catalog=QLCF;Integrated Security=True;TrustServerCertificate=True";
            thongKeBUS = new ThongKeBUS(connectionString);
        }

        private void THONGKE_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            dtTuNgay.Enabled = false;
            dtDenNgay.Enabled = false;
            cbbLoaiSanPham.Enabled = false;
            dtTuNgay.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtDenNgay.Value = DateTime.Now;
        }

        private void LoadLoaiSanPham()
        {
            cbbLoaiSanPham.Items.Clear();
            List<LoaiSanPhamDTO> dsLoai = thongKeBUS.GetLoaiSanPham();
            foreach (var loai in dsLoai)
            {
                cbbLoaiSanPham.Items.Add(loai.TenLoai);
            }
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            chrThongKe.Series["Series1"].Points.Clear();
            DateTime? tuNgay = cBTuNgay.Checked ? dtTuNgay.Value.Date : (DateTime?)null;
            DateTime? denNgay = cBDenNgay.Checked ? dtDenNgay.Value.Date : (DateTime?)null;
            string tenLoai = (cBLoaiSanPham.Checked && cbbLoaiSanPham.SelectedItem != null)
                            ? cbbLoaiSanPham.SelectedItem.ToString()
                            : null;

            List<ThongKeDTO> dsThongKe = thongKeBUS.GetThongKe(tuNgay, denNgay, tenLoai);
            decimal tongDoanhThu = 0;

            foreach (var item in dsThongKe)
            {
                chrThongKe.Series["Series1"].Points.AddXY($"{item.Thang}/{item.Nam}", item.DoanhThu);
                tongDoanhThu += item.DoanhThu;
            }

            txtTongTien.Text = tongDoanhThu.ToString("N0") + " VND";
        }

        private void cBTuNgay_CheckedChanged(object sender, EventArgs e) => dtTuNgay.Enabled = cBTuNgay.Checked;
        private void cBDenNgay_CheckedChanged(object sender, EventArgs e) => dtDenNgay.Enabled = cBDenNgay.Checked;
        private void cBLoaiSanPham_CheckedChanged(object sender, EventArgs e) => cbbLoaiSanPham.Enabled = cBLoaiSanPham.Checked;
    }
}
