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

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        list.Add(MapToKho(r));
                }
            }
            return list;
        }

        public static List<KhoDTO> Search(string keyword)
        {
            var list = new List<KhoDTO>();
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            string sql = @"
                SELECT k.masp, s.tensp, kc.kichco, k.soluongton, k.canhbaotonkho
                FROM KICHCOSP k
                JOIN SANPHAM s ON k.masp = s.masp
                JOIN KICHCO kc ON k.makichco = kc.makichco
                WHERE k.masp LIKE @kw OR s.tensp LIKE @kw";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        list.Add(MapToKho(r));
                }
            }
            return list;
        }

        public static DataTable LayNhaCungCap()
        {
            string sql = "SELECT Manhacc, Tennhacc FROM NHACUNGCAP";
            using (var conn = new SqlConnection(connStr))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int LaySoLuongHienTai(SqlConnection conn, SqlTransaction trans, string maSP, string size)
        {
            string sql = @"
                SELECT ISNULL(soluongton, 0)
                FROM KICHCOSP
                WHERE masp = @masp
                  AND makichco = (SELECT makichco FROM KICHCO WHERE kichco = @size)";

            using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
            {
                cmd.Parameters.AddWithValue("@masp", maSP);
                cmd.Parameters.AddWithValue("@size", size ?? "");
                object result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
            }
        }

        public static bool LuuPhieuNhapKho(int maNCC, List<KhoDTO> danhSach)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string sqlInsertPhieu = @"
                        INSERT INTO NHAPKHO (Manhacc, Ngaynhap)
                        OUTPUT INSERTED.Mank
                        VALUES (@mancc, GETDATE())";

                    int maNK;
                    using (SqlCommand cmd = new SqlCommand(sqlInsertPhieu, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@mancc", maNCC);
                        maNK = (int)cmd.ExecuteScalar();
                    }

                    foreach (var kho in danhSach)
                    {
                        string sqlCT = @"
                            INSERT INTO CHITIETNHAPKHO (Mank, Idkcsp, Soluongnhap, Gianhap)
                            VALUES (
                                @mank,
                                (SELECT TOP 1 kc.id
                                 FROM KICHCOSP kc
                                 JOIN KICHCO c ON kc.makichco = c.makichco
                                 WHERE kc.masp = @masp AND c.kichco = @size),
                                @soluong,
                                @gianhap
                            )";

                        using (SqlCommand cmd = new SqlCommand(sqlCT, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@mank", maNK);
                            cmd.Parameters.AddWithValue("@masp", kho.MaSP);
                            cmd.Parameters.AddWithValue("@size", kho.Size ?? "");
                            cmd.Parameters.AddWithValue("@soluong", kho.SoLuongNhap);
                            cmd.Parameters.AddWithValue("@gianhap", kho.GiaNhap);
                            cmd.ExecuteNonQuery();
                        }

                        int soLuongHienTai = LaySoLuongHienTai(conn, trans, kho.MaSP, kho.Size);
                        int soLuongMoi = soLuongHienTai + kho.SoLuongNhap;

                        string sqlUpdate = @"
                            UPDATE KICHCOSP
                            SET soluongton = @soluong
                            WHERE masp = @masp
                              AND makichco = (SELECT makichco FROM KICHCO WHERE kichco = @size)";
                        using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@soluong", soLuongMoi);
                            cmd.Parameters.AddWithValue("@masp", kho.MaSP);
                            cmd.Parameters.AddWithValue("@size", kho.Size ?? "");
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Lỗi khi lưu phiếu nhập: " + ex.Message);
                }
            }
        }
    }
}
