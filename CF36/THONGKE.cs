using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Cho SqlConnection, SqlCommand, SqlDataReader
using System.Configuration; // Cho ConfigurationManager

namespace CF36
{
    public partial class THONGKE : Form
    {
        private string connectionString;
        public THONGKE()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QUANLICAFE36"]?.ConnectionString ??
                              "Data Source=DESKTOP-7660KT7;Initial Catalog=QLCF;Integrated Security=True;TrustServerCertificate=True";
        }

        private void THONGKE_Load(object sender, EventArgs e)
        {
            // Load dữ liệu vào ComboBox Loại Sản Phẩm
            LoadLoaiSanPham();
            // Disable các control ban đầu
            dtTuNgay.Enabled = false;
            dtDenNgay.Enabled = false;
            cbbLoaiSanPham.Enabled = false;
            // Đặt mặc định DateTimePicker (dựa trên ngày hiện tại hoặc ví dụ)
            dtTuNgay.Value = new DateTime(DateTime.Now.Year, 1, 1); // Đầu năm
            dtDenNgay.Value = DateTime.Now;
        }
        private void LoadLoaiSanPham()
        {
            cbbLoaiSanPham.Items.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT tenloai FROM LOAISP", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbbLoaiSanPham.Items.Add(reader["tenloai"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load loại sản phẩm: " + ex.Message);
                }
            }
        }

        private void cBTuNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtTuNgay.Enabled = cBTuNgay.Checked;
        }

        private void cBDenNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtDenNgay.Enabled = cBDenNgay.Checked;
        }

        private void cBLoaiSanPham_CheckedChanged(object sender, EventArgs e)
        {
            cbbLoaiSanPham.Enabled = cBLoaiSanPham.Checked;
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            // Xóa dữ liệu cũ trên Chart
            chrThongKe.Series["Series1"].Points.Clear(); // Giả sử Chart name là chrThongKe, Series là "Series1"
            // Xây dựng query động
            string query = @"
                SELECT YEAR(h.Ngaylap) AS Nam, MONTH(h.Ngaylap) AS Thang, SUM(ct.Thanhtien) AS DoanhThu
                FROM CHITIETHD ct
                JOIN HOADON h ON ct.Mahd = h.Mahd
                JOIN KICHCOSP kc ON ct.Idkcsp = kc.id
                JOIN SANPHAM sp ON kc.masp = sp.masp
                WHERE 1=1";
            SqlCommand cmd = new SqlCommand();
            if (cBTuNgay.Checked)
            {
                query += " AND h.Ngaylap >= @tungay";
                cmd.Parameters.AddWithValue("@tungay", dtTuNgay.Value.Date);
            }
            if (cBDenNgay.Checked)
            {
                query += " AND h.Ngaylap <= @denngay";
                cmd.Parameters.AddWithValue("@denngay", dtDenNgay.Value.Date.AddDays(1).AddTicks(-1)); // Đến cuối ngày
            }
            if (cBLoaiSanPham.Checked && cbbLoaiSanPham.SelectedItem != null)
            {
                query += " AND sp.maloai = (SELECT maloai FROM LOAISP WHERE tenloai = @tenloai)";
                cmd.Parameters.AddWithValue("@tenloai", cbbLoaiSanPham.SelectedItem.ToString());
            }
            query += " GROUP BY YEAR(h.Ngaylap), MONTH(h.Ngaylap) ORDER BY Nam, Thang";
            cmd.CommandText = query;
            decimal tongDoanhThu = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    cmd.Connection = con;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int nam = reader.GetInt32(0);
                        int thang = reader.GetInt32(1);
                        decimal doanhThu = reader.GetDecimal(2);
                        // Thêm điểm vào Chart (x-axis: tháng/năm để tránh trùng nếu nhiều năm)
                        chrThongKe.Series["Series1"].Points.AddXY($"{thang}/{nam}", doanhThu);
                        tongDoanhThu += doanhThu;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thống kê: " + ex.Message);
                }
            }
            txtTongTien.Text = tongDoanhThu.ToString("N0") + " VND"; // Format với dấu phẩy và đơn vị
        }
    }
}
