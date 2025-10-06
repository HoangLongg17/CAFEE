using CF36.DTO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace CF36.DAO
{
    public class ThongKeDAO
    {
        private string connectionString;

        public ThongKeDAO(string connStr)
        {
            connectionString = connStr;
        }

        public List<LoaiSanPhamDTO> LayLoaiSanPham()
        {
            List<LoaiSanPhamDTO> dsLoai = new List<LoaiSanPhamDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT tenloai FROM LOAISP", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dsLoai.Add(new LoaiSanPhamDTO(reader["tenloai"].ToString()));
                }
            }
            return dsLoai;
        }

        public List<ThongKeDTO> LayDoanhThu(DateTime? tuNgay, DateTime? denNgay, string tenLoai)
        {
            List<ThongKeDTO> dsThongKe = new List<ThongKeDTO>();

            string query = @"
                SELECT YEAR(h.Ngaylap) AS Nam, MONTH(h.Ngaylap) AS Thang, SUM(ct.Thanhtien) AS DoanhThu
                FROM CHITIETHD ct
                JOIN HOADON h ON ct.Mahd = h.Mahd
                JOIN KICHCOSP kc ON ct.Idkcsp = kc.id
                JOIN SANPHAM sp ON kc.masp = sp.masp
                WHERE 1=1";

            SqlCommand cmd = new SqlCommand();

            if (tuNgay.HasValue)
            {
                query += " AND h.Ngaylap >= @tungay";
                cmd.Parameters.AddWithValue("@tungay", tuNgay.Value.Date);
            }
            if (denNgay.HasValue)
            {
                query += " AND h.Ngaylap <= @denngay";
                cmd.Parameters.AddWithValue("@denngay", denNgay.Value.Date.AddDays(1).AddTicks(-1));
            }
            if (!string.IsNullOrEmpty(tenLoai))
            {
                query += " AND sp.maloai = (SELECT maloai FROM LOAISP WHERE tenloai = @tenloai)";
                cmd.Parameters.AddWithValue("@tenloai", tenLoai);
            }

            query += " GROUP BY YEAR(h.Ngaylap), MONTH(h.Ngaylap) ORDER BY Nam, Thang";
            cmd.CommandText = query;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int nam = reader.GetInt32(0);
                    int thang = reader.GetInt32(1);
                    decimal doanhThu = reader.GetDecimal(2);
                    dsThongKe.Add(new ThongKeDTO(nam, thang, doanhThu));
                }
            }

            return dsThongKe;
        }
    }
}
