using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class SanPhamDAO
    {
        private static readonly string connStr =
            ConfigurationManager.ConnectionStrings["QUANLICAFE36"].ConnectionString;

        public static List<SanPhamDTO> LayTatCaSanPham()
        {
            var list = new List<SanPhamDTO>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT kc.id AS IdKCSP, sp.masp, sp.tensp, l.tenloai, k.kichco, kc.giaban, sp.duongdananh
                    FROM SANPHAM sp
                    JOIN LOAISP l ON sp.maloai = l.maloai
                    JOIN KICHCOSP kc ON sp.masp = kc.masp
                    JOIN KICHCO k ON kc.makichco = k.makichco
                    WHERE kc.trangthaisp = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new SanPhamDTO
                    {
                        IdKCSP = Convert.ToInt32(r["IdKCSP"]),
                        MaSP = r["masp"].ToString(),
                        TenSP = r["tensp"].ToString(),
                        Loai = r["tenloai"].ToString(),
                        KichCo = r["kichco"].ToString(),
                        GiaBan = Convert.ToDecimal(r["giaban"]),
                        DuongDanAnh = r["duongdananh"] != DBNull.Value ? r["duongdananh"].ToString() : ""
                    });
                }

                r.Close();
            }

            return list;
        }
    }
}