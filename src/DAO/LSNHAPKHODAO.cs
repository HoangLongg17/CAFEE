using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public static class LSNhapKhoDAO
    {
        private static readonly string connStr =
            ConfigurationManager.ConnectionStrings["QUANLICAFE36"].ConnectionString;

        private static LSNhapKhoDTO MapToDto(SqlDataReader r)
        {
            return new LSNhapKhoDTO
            {
                Mank = Convert.ToInt32(r["Mank"]),
                Ngaynhap = Convert.ToDateTime(r["Ngaynhap"]),
                Tennhacc = r["Tennhacc"].ToString(),
                Tongtien = Convert.ToDecimal(r["Tongtien"])
            };
        }

        private static ChiTietNhapKhoDTO MapToChiTietDto(SqlDataReader r)
        {
            return new ChiTietNhapKhoDTO
            {
                Mank = Convert.ToInt32(r["Mank"]),
                MaSP = r["Masp"].ToString(),
                TenSP = r["Tensp"].ToString(),
                Size = r["Size"].ToString(),
                SoLuongNhap = Convert.ToInt32(r["Soluongnhap"]),
                GiaNhap = Convert.ToDecimal(r["Gianhap"]),
                Thanhtien = Convert.ToDecimal(r["Thanhtien"])   
            };
        }


        public static List<LSNhapKhoDTO> GetAll()
        {
            string sql = @"
                SELECT nk.Mank, nk.Ngaynhap, ncc.Tennhacc,
                       SUM(ct.Soluongnhap * ct.Gianhap) AS Tongtien
                FROM NHAPKHO nk
                JOIN NHACUNGCAP ncc ON nk.Manhacc = ncc.Manhacc
                JOIN CHITIETNHAPKHO ct ON nk.Mank = ct.Mank
                GROUP BY nk.Mank, nk.Ngaynhap, ncc.Tennhacc
                ORDER BY nk.Mank DESC";

            return ExecuteQuery(sql, null, MapToDto);
        }

        public static List<LSNhapKhoDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            string sql = @"
                SELECT nk.Mank, nk.Ngaynhap, ncc.Tennhacc,
                       SUM(ct.Soluongnhap * ct.Gianhap) AS Tongtien
                FROM NHAPKHO nk
                JOIN NHACUNGCAP ncc ON nk.Manhacc = ncc.Manhacc
                JOIN CHITIETNHAPKHO ct ON nk.Mank = ct.Mank
                WHERE CAST(nk.Mank AS NVARCHAR) LIKE @kw
                GROUP BY nk.Mank, nk.Ngaynhap, ncc.Tennhacc
                ORDER BY nk.Mank DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@kw", $"%{keyword.Trim()}%" }
            };

            return ExecuteQuery(sql, parameters, MapToDto);
        }

        public static List<LSNhapKhoDTO> FilterByDate(DateTime from, DateTime to)
        {
            string sql = @"
                SELECT nk.Mank, nk.Ngaynhap, ncc.Tennhacc,
                       SUM(ct.Soluongnhap * ct.Gianhap) AS Tongtien
                FROM NHAPKHO nk
                JOIN NHACUNGCAP ncc ON nk.Manhacc = ncc.Manhacc
                JOIN CHITIETNHAPKHO ct ON nk.Mank = ct.Mank
                WHERE nk.Ngaynhap BETWEEN @from AND @to
                GROUP BY nk.Mank, nk.Ngaynhap, ncc.Tennhacc
                ORDER BY nk.Ngaynhap DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from },
                { "@to", to }
            };

            return ExecuteQuery(sql, parameters, MapToDto);
        }

        public static List<ChiTietNhapKhoDTO> GetChiTietNhapKho()
        {
            string sql = @"
        SELECT nk.Mank, sp.Masp, sp.Tensp, kc.kichco AS Size,
               ct.Soluongnhap, ct.Gianhap,
               (ct.Soluongnhap * ct.Gianhap) AS Thanhtien
        FROM CHITIETNHAPKHO ct
        JOIN NHAPKHO nk ON ct.Mank = nk.Mank
        JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.id
        JOIN SANPHAM sp ON kcsp.Masp = sp.Masp
        JOIN KICHCO kc ON kcsp.Makichco = kc.Makichco
        ORDER BY nk.Mank DESC";

            return ExecuteQuery(sql, null, MapToChiTietDto);
        }

        public static List<ChiTietNhapKhoDTO> GetChiTietNhapKhoTheoNgay(DateTime from, DateTime to)
        {
            string sql = @"
        SELECT nk.Mank, sp.Masp, sp.Tensp, kc.kichco AS Size,
               ct.Soluongnhap, ct.Gianhap,
               (ct.Soluongnhap * ct.Gianhap) AS Thanhtien
        FROM CHITIETNHAPKHO ct
        JOIN NHAPKHO nk ON ct.Mank = nk.Mank
        JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.id
        JOIN SANPHAM sp ON kcsp.Masp = sp.Masp
        JOIN KICHCO kc ON kcsp.Makichco = kc.Makichco
        WHERE nk.Ngaynhap BETWEEN @from AND @to
        ORDER BY nk.Mank DESC";

            var parameters = new Dictionary<string, object>
           {
            { "@from", from },
            { "@to", to }
             };

            return ExecuteQuery(sql, parameters, MapToChiTietDto);
        }
        public static List<ChiTietNhapKhoDTO> GetChiTietNhapKhoTheoMaNK(int maNK)
        {
            string sql = @"
        SELECT nk.Mank, sp.Masp, sp.Tensp, kc.Kichco AS Size,
               ct.Soluongnhap, ct.Gianhap,
               (ct.Soluongnhap * ct.Gianhap) AS Thanhtien
        FROM CHITIETNHAPKHO ct
        JOIN NHAPKHO nk ON ct.Mank = nk.Mank
        JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.Id
        JOIN SANPHAM sp ON kcsp.Masp = sp.Masp
        JOIN KICHCO kc ON kcsp.MaKichco = kc.MaKichco
        WHERE nk.Mank = @maNK";

            var parameters = new Dictionary<string, object>
                {
                    { "@maNK", maNK }
                };

            return ExecuteQuery(sql, parameters, MapToChiTietDto);
        }

        public static List<ChiTietNhapKhoDTO> GetChiTietNhapKhoTheoDanhSach(List<int> maNKList)
        {
            if (maNKList == null || maNKList.Count == 0)
                return new List<ChiTietNhapKhoDTO>();

            string maList = string.Join(",", maNKList);
            string sql = $@"
        SELECT nk.Mank, sp.Masp, sp.Tensp, kc.Kichco AS Size,
               ct.Soluongnhap, ct.Gianhap,
               (ct.Soluongnhap * ct.Gianhap) AS Thanhtien
        FROM CHITIETNHAPKHO ct
        JOIN NHAPKHO nk ON ct.Mank = nk.Mank
        JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.Id
        JOIN SANPHAM sp ON kcsp.Masp = sp.Masp
        JOIN KICHCO kc ON kcsp.MaKichco = kc.MaKichco
        WHERE nk.Mank IN ({maList})
        ORDER BY nk.Mank DESC";

            return ExecuteQuery(sql, null, MapToChiTietDto);
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
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                }

                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(mapFunc(r));
                    }
                }
            }

            return list;
        }
    }
}