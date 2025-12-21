using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public static class LSNhapKhoDAO
    {
        private static readonly string connStr = GetConnectionString();

        private static string GetConnectionString()
        {
            var cs = ConfigurationManager.ConnectionStrings["QLCH"];
            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
            {
                throw new Exception(
                    "Không tìm thấy connection string 'QLCH'. " +
                    "Kiểm tra App.config / Web.config và đảm bảo đúng project startup.");
            }
            return cs.ConnectionString;
        }

        // ================= MAP DTO =================
        private static LSNhapKhoDTO MapToDto(SqlDataReader r)
        {
            return new LSNhapKhoDTO
            {
                Mank = (int)r["Mank"],
                Ngaynhap = (DateTime)r["Ngaynhap"],
                Tennhacc = r["Tennhacc"].ToString(),
                Tongtien = (decimal)r["Tongtien"]
            };
        }

        private static ChiTietNhapKhoDTO MapToChiTietDto(SqlDataReader r)
        {
            return new ChiTietNhapKhoDTO
            {
                Mank = (int)r["Mank"],
                MaSP = (int)r["Masp"],
                TenSP = r["Tensp"].ToString(),
                SoLuongNhap = (int)r["Soluongnhap"],
                GiaNhap = (decimal)r["Gianhap"],
                Thanhtien = (decimal)r["Thanhtien"]
            };
        }

        // ================= PHIẾU NHẬP =================
        public static List<LSNhapKhoDTO> GetAll()
        {
            string sql = @"
                SELECT nk.Mank, nk.Ngaynhap, ncc.Tennhacc,
                       ISNULL(SUM(ct.Soluongnhap * ct.Gianhap),0) AS Tongtien
                FROM NHAPKHO nk
                JOIN NHACUNGCAP ncc ON nk.Manhacc = ncc.Manhacc
                LEFT JOIN CHITIETNHAPKHO ct ON nk.Mank = ct.Mank
                GROUP BY nk.Mank, nk.Ngaynhap, ncc.Tennhacc
                ORDER BY nk.Mank DESC";

            return ExecuteQuery(sql, null, MapToDto);
        }

        public static List<LSNhapKhoDTO> Search(string keyword)
        {
            string sql = @"
                SELECT nk.Mank, nk.Ngaynhap, ncc.Tennhacc,
                       ISNULL(SUM(ct.Soluongnhap * ct.Gianhap),0) AS Tongtien
                FROM NHAPKHO nk
                JOIN NHACUNGCAP ncc ON nk.Manhacc = ncc.Manhacc
                LEFT JOIN CHITIETNHAPKHO ct ON nk.Mank = ct.Mank
                WHERE CAST(nk.Mank AS NVARCHAR) LIKE @kw
                GROUP BY nk.Mank, nk.Ngaynhap, ncc.Tennhacc
                ORDER BY nk.Mank DESC";

            return ExecuteQuery(sql,
                new Dictionary<string, object> { { "@kw", $"%{keyword}%" } },
                MapToDto);
        }

        public static List<LSNhapKhoDTO> FilterByDate(DateTime from, DateTime to)
        {
            string sql = @"
                SELECT nk.Mank, nk.Ngaynhap, ncc.Tennhacc,
                       ISNULL(SUM(ct.Soluongnhap * ct.Gianhap),0) AS Tongtien
                FROM NHAPKHO nk
                JOIN NHACUNGCAP ncc ON nk.Manhacc = ncc.Manhacc
                LEFT JOIN CHITIETNHAPKHO ct ON nk.Mank = ct.Mank
                WHERE CAST(nk.Ngaynhap AS DATE) BETWEEN @from AND @to
                GROUP BY nk.Mank, nk.Ngaynhap, ncc.Tennhacc
                ORDER BY nk.Ngaynhap DESC";

            return ExecuteQuery(sql,
                new Dictionary<string, object>
                {
                    { "@from", from },
                    { "@to", to }
                },
                MapToDto);
        }

        // ================= CHI TIẾT NHẬP =================
        public static List<ChiTietNhapKhoDTO> GetChiTietNhapKho()
        {
            string sql = @"
                SELECT nk.Mank, sp.Masp, sp.Tensp,
                       ct.Soluongnhap, ct.Gianhap, ct.Thanhtien
                FROM CHITIETNHAPKHO ct
                JOIN NHAPKHO nk ON ct.Mank = nk.Mank
                JOIN SANPHAM sp ON ct.Masp = sp.Masp
                ORDER BY nk.Mank DESC";

            return ExecuteQuery(sql, null, MapToChiTietDto);
        }

        public static List<ChiTietNhapKhoDTO> GetChiTietNhapKhoTheoNgay(DateTime from, DateTime to)
        {
            string sql = @"
                SELECT nk.Mank, sp.Masp, sp.Tensp,
                       ct.Soluongnhap, ct.Gianhap, ct.Thanhtien
                FROM CHITIETNHAPKHO ct
                JOIN NHAPKHO nk ON ct.Mank = nk.Mank
                JOIN SANPHAM sp ON ct.Masp = sp.Masp
                WHERE CAST(nk.Ngaynhap AS DATE) BETWEEN @from AND @to
                ORDER BY nk.Mank DESC";

            return ExecuteQuery(sql,
                new Dictionary<string, object>
                {
                    { "@from", from },
                    { "@to", to }
                },
                MapToChiTietDto);
        }

        public static List<ChiTietNhapKhoDTO> GetChiTietNhapKhoTheoMaNK(int maNK)
        {
            string sql = @"
                SELECT nk.Mank, sp.Masp, sp.Tensp,
                       ct.Soluongnhap, ct.Gianhap, ct.Thanhtien
                FROM CHITIETNHAPKHO ct
                JOIN NHAPKHO nk ON ct.Mank = nk.Mank
                JOIN SANPHAM sp ON ct.Masp = sp.Masp
                WHERE nk.Mank = @maNK";

            return ExecuteQuery(sql,
                new Dictionary<string, object> { { "@maNK", maNK } },
                MapToChiTietDto);
        }

        private static List<T> ExecuteQuery<T>(
            string sql,
            Dictionary<string, object> parameters,
            Func<SqlDataReader, T> mapFunc)
        {
            var list = new List<T>();

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);

                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(mapFunc(r));
            }
            return list;
        }
    }
}
