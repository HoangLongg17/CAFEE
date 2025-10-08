using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace DAO
{
    public class KhoDAO
    {
        private static readonly string connStr =
            ConfigurationManager.ConnectionStrings["QUANLICAFE36"].ConnectionString;

        private static KhoDTO MapToKho(SqlDataReader r)
        {
            return new KhoDTO
            {
                MaSP = r["masp"]?.ToString(),
                TenSP = r["tensp"]?.ToString(),
                Size = r["kichco"]?.ToString(),
                SoLuong = Convert.ToInt32(r["soluongton"]),
                CanhBaoTonKho = Convert.ToInt32(r["canhbaotonkho"])
            };
        }


        public static List<KhoDTO> GetAll()
        {
            var list = new List<KhoDTO>();
            string sql = @"
            SELECT k.masp, s.tensp, kc.kichco, k.soluongton, k.canhbaotonkho
                FROM KICHCOSP k
                JOIN SANPHAM s ON k.masp = s.masp
                JOIN KICHCO kc ON k.makichco = kc.makichco";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(MapToKho(r));
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy dữ liệu kho.", ex);
            }
        }

        public static List<KhoDTO> Search(string keyword)
        {
            var list = new List<KhoDTO>();
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();

            string sql = @"
                SELECT k.masp, s.tensp, kc.kichco, k.soluongton
                FROM KICHCOSP k
                JOIN SANPHAM s ON k.masp = s.masp
                JOIN KICHCO kc ON k.makichco = kc.makichco
                WHERE k.masp LIKE @kw OR s.tensp LIKE @kw";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(MapToKho(r));
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm kho.", ex);
            }
        }

        public static DataTable LayNhaCungCap()
        {
            string sql = "SELECT Manhacc, Tennhacc FROM NHACUNGCAP";
            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp.", ex);
            }
        }

        public static bool UpdateSoLuong(KhoDTO kho)
        {
            string sql = @"
                UPDATE KICHCOSP
                SET soluongton = ISNULL(soluongton,0) + @add
                WHERE masp = @masp 
                  AND makichco = (SELECT makichco FROM KICHCO WHERE kichco = @size)";
            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@add", kho.SoLuongNhap);
                    cmd.Parameters.AddWithValue("@masp", kho.MaSP);
                    cmd.Parameters.AddWithValue("@size", kho.Size ?? "");
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật số lượng tồn.", ex);
            }
        }

        public static bool InsertNhapKho(KhoDTO kho)
        {
            string sql = @"
                INSERT INTO NHAPKHO(Idkcsp, Soluongnhap, Gianhap, Manhacc, Ngaynhap)
                VALUES (
                  (SELECT TOP 1 kc.id
                   FROM KICHCOSP kc
                   JOIN KICHCO c ON kc.makichco = c.makichco
                   WHERE kc.masp = @masp AND c.kichco = @size),
                  @qty, @gianhap, @mancc, @ngay)";
            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@masp", kho.MaSP);
                    cmd.Parameters.AddWithValue("@size", kho.Size ?? "");
                    cmd.Parameters.AddWithValue("@qty", kho.SoLuongNhap);
                    cmd.Parameters.AddWithValue("@gianhap", kho.GiaNhap);
                    if (kho.MaNCC.HasValue)
                        cmd.Parameters.AddWithValue("@mancc", kho.MaNCC.Value);
                    else
                        cmd.Parameters.AddWithValue("@mancc", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ngay", DateTime.Now);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu nhập kho.", ex);
            }
        }
    }
}
