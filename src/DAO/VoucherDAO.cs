using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO;
using System.Data;
namespace DAO
{
    public class VoucherDAO
    {
        private static VoucherDAO instance;
        public static VoucherDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new VoucherDAO();
                return instance;
            }
        }

        private DataProvider provider = DataProvider.Instance;

        public bool AddVoucher(VoucherDTO voucher)
        {
            string query = @"INSERT INTO VOUCHER 
                (Code, Giatri, Ngaybd, Ngaykt, DieuKien, Maloaivc, maloai) 
                VALUES (@Code, @Giatri, @Ngaybd, @Ngaykt, @DieuKien, @Maloaivc, @Maloai)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Code", voucher.Code),
                new SqlParameter("@Giatri", voucher.Giatri),
                new SqlParameter("@Ngaybd", voucher.Ngaybd),
                new SqlParameter("@Ngaykt", voucher.Ngaykt),
                new SqlParameter("@DieuKien", (object)voucher.DieuKien ?? DBNull.Value),
                new SqlParameter("@Maloaivc", voucher.Maloaivc),
                new SqlParameter("@Maloai", (object)voucher.Maloai ?? DBNull.Value)
            };

            int result = provider.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool AddVoucherChiTiet(int mavc, int idkcsp)
        {
            string query = "INSERT INTO CHITIETVC (Mavc, Idkcsp) VALUES (@Mavc, @Idkcsp)";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Mavc", mavc),
        new SqlParameter("@Idkcsp", idkcsp)
            };
            return provider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateVoucher(VoucherDTO voucher)
        {
            string query = @"UPDATE VOUCHER SET 
                Code = @Code, Giatri = @Giatri, Ngaybd = @Ngaybd, Ngaykt = @Ngaykt, 
                DieuKien = @DieuKien, Maloaivc = @Maloaivc, maloai = @Maloai 
                WHERE Mavc = @Mavc";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Code", voucher.Code),
                new SqlParameter("@Giatri", voucher.Giatri),
                new SqlParameter("@Ngaybd", voucher.Ngaybd),
                new SqlParameter("@Ngaykt", voucher.Ngaykt),
                new SqlParameter("@DieuKien", (object)voucher.DieuKien ?? DBNull.Value),
                new SqlParameter("@Maloaivc", voucher.Maloaivc),
                new SqlParameter("@Maloai", (object)voucher.Maloai ?? DBNull.Value),
                new SqlParameter("@Mavc", voucher.Mavc)
            };

            int result = provider.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteVoucher(int mavc)
        {
            string query = "DELETE FROM VOUCHER WHERE Mavc = @Mavc";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Mavc", mavc)
            };
            int result = provider.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public DataTable GetAllVouchers()
        {
            string query = "SELECT * FROM VOUCHER";
            return provider.ExecuteQuery(query);
        }
        public DataTable GetAllVouchersWithJoin()
        {
            string query = @"
        SELECT 
            v.Mavc,
            v.Code,
            v.Giatri,
            v.Ngaybd,
            v.Ngaykt,
            v.DieuKien,
            v.Maloaivc,
            kv.Tenloai AS TenLoaiVoucher,
            v.maloai,
            lsp_mua.tenloai AS TenLoaiSanPhamApDung,
            lsp_tang.TenLoaiSanPhamTang
        FROM VOUCHER v
        JOIN KIEUVC kv ON v.Maloaivc = kv.Maloaivc
        LEFT JOIN LOAISP lsp_mua ON v.maloai = lsp_mua.maloai
        LEFT JOIN (
            SELECT vc.Mavc, MIN(lsp.tenloai) AS TenLoaiSanPhamTang
            FROM CHITIETVC ct
            JOIN KICHCOSP kc ON ct.Idkcsp = kc.Id
            JOIN SANPHAM sp ON kc.masp = sp.masp
            JOIN LOAISP lsp ON sp.maloai = lsp.maloai
            JOIN VOUCHER vc ON ct.Mavc = vc.Mavc
            GROUP BY vc.Mavc
        ) lsp_tang ON v.Mavc = lsp_tang.Mavc
    ";

            return provider.ExecuteQuery(query);
        }
        public DataTable GetVouchersByTypeWithJoin(int maloaivc)
        {
            string query = @"
        SELECT 
            v.Mavc,
            v.Code,
            v.Giatri,
            v.Ngaybd,
            v.Ngaykt,
            v.DieuKien,
            v.Maloaivc,
            kv.Tenloai AS TenLoaiVoucher,
            v.maloai,
            lsp_mua.tenloai AS TenLoaiSanPhamApDung,
            lsp_tang.TenLoaiSanPhamTang
        FROM VOUCHER v
        JOIN KIEUVC kv ON v.Maloaivc = kv.Maloaivc
        LEFT JOIN LOAISP lsp_mua ON v.maloai = lsp_mua.maloai
        LEFT JOIN (
            SELECT vc.Mavc, MIN(lsp.tenloai) AS TenLoaiSanPhamTang
            FROM CHITIETVC ct
            JOIN KICHCOSP kc ON ct.Idkcsp = kc.Id
            JOIN SANPHAM sp ON kc.masp = sp.masp
            JOIN LOAISP lsp ON sp.maloai = lsp.maloai
            JOIN VOUCHER vc ON ct.Mavc = vc.Mavc
            GROUP BY vc.Mavc
        ) lsp_tang ON v.Mavc = lsp_tang.Mavc
        WHERE v.Maloaivc = @Maloaivc";

            SqlParameter[] parameters = {
        new SqlParameter("@Maloaivc", maloaivc)
    };

            return provider.ExecuteQuery(query, parameters);
        }
        public VoucherDTO GetVoucherByID(int mavc)
        {
            string query = "SELECT * FROM VOUCHER WHERE Mavc = @Mavc";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Mavc", mavc)
            };
            DataTable data = provider.ExecuteQuery(query, parameters);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new VoucherDTO
                {
                    Mavc = (int)row["Mavc"],
                    Code = row["Code"].ToString(),
                    Giatri = (decimal)row["Giatri"],
                    Ngaybd = (DateTime)row["Ngaybd"],
                    Ngaykt = (DateTime)row["Ngaykt"],
                    DieuKien = row["DieuKien"] != DBNull.Value ? (decimal?)row["DieuKien"] : null,
                    Maloaivc = (int)row["Maloaivc"],
                    Maloai = row["maloai"] != DBNull.Value ? (int?)row["maloai"] : null
                };
            }
            return null;
        }

        public bool CheckCodeExists(string code, int? excludeMavc = null)
        {
            string query = "SELECT COUNT(*) FROM VOUCHER WHERE Code = @Code";

            if (excludeMavc.HasValue)
            {
                query += " AND Mavc != @Mavc";
            }

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Code", code)
            };

            if (excludeMavc.HasValue)
            {
                parameters.Add(new SqlParameter("@Mavc", excludeMavc.Value));
            }

            object result = provider.ExecuteScalar(query, parameters.ToArray());
            return Convert.ToInt32(result) > 0;
        }
        public DataTable GetVouchersByType(int maloaivc)
        {
            string query = "SELECT * FROM VOUCHER WHERE Maloaivc = @Maloaivc";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Maloaivc", maloaivc)
            };
            return provider.ExecuteQuery(query, parameters);
        }

        public DataTable GetVouchersByDateRange(DateTime from, DateTime to)
        {
            string query = @"SELECT * FROM VOUCHER 
                             WHERE Ngaybd >= @FromDate AND Ngaykt <= @ToDate";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FromDate", from),
                new SqlParameter("@ToDate", to)
            };
            return provider.ExecuteQuery(query, parameters);
        }

        public DataTable GetVoucherTypes()
        {
            string query = "SELECT * FROM KIEUVC";
            return provider.ExecuteQuery(query);
        }
        public int AddVoucherAndReturnID(VoucherDTO voucher)
        {
            string query = @"INSERT INTO VOUCHER (Code, Giatri, Ngaybd, Ngaykt, DieuKien, Maloaivc, maloai)
                     OUTPUT INSERTED.Mavc
                     VALUES (@Code, @Giatri, @Ngaybd, @Ngaykt, @DieuKien, @Maloaivc, @Maloai)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Code", voucher.Code),
        new SqlParameter("@Giatri", voucher.Giatri),
        new SqlParameter("@Ngaybd", voucher.Ngaybd),
        new SqlParameter("@Ngaykt", voucher.Ngaykt),
        new SqlParameter("@DieuKien", (object)voucher.DieuKien ?? DBNull.Value),
        new SqlParameter("@Maloaivc", voucher.Maloaivc),
        new SqlParameter("@Maloai", (object)voucher.Maloai ?? DBNull.Value)
            };

            object result = provider.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }
        public int UpdateVoucherAndReturnAffectedRows(VoucherDTO voucher)
        {
            string query = @"UPDATE VOUCHER SET 
        Code = @Code, 
        Giatri = @Giatri, 
        Ngaybd = @Ngaybd, 
        Ngaykt = @Ngaykt, 
        DieuKien = @DieuKien, 
        Maloaivc = @Maloaivc, 
        maloai = @Maloai 
        WHERE Mavc = @Mavc";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Code", voucher.Code),
        new SqlParameter("@Giatri", voucher.Giatri),
        new SqlParameter("@Ngaybd", voucher.Ngaybd),
        new SqlParameter("@Ngaykt", voucher.Ngaykt),
        new SqlParameter("@DieuKien", (object)voucher.DieuKien ?? DBNull.Value),
        new SqlParameter("@Maloaivc", voucher.Maloaivc),
        new SqlParameter("@Maloai", (object)voucher.Maloai ?? DBNull.Value),
        new SqlParameter("@Mavc", voucher.Mavc)
            };

            return provider.ExecuteNonQuery(query, parameters);
        }
        public bool UpdateVoucherChiTiet(int mavc, List<int> idkcspList)
        {
            // Xóa chi tiết cũ
            string deleteQuery = "DELETE FROM CHITIETVC WHERE Mavc = @Mavc";
            SqlParameter[] deleteParams = { new SqlParameter("@Mavc", mavc) };
            provider.ExecuteNonQuery(deleteQuery, deleteParams);

            // Thêm lại chi tiết mới
            foreach (int idkcsp in idkcspList)
            {
                string insertQuery = "INSERT INTO CHITIETVC (Mavc, Idkcsp) VALUES (@Mavc, @Idkcsp)";
                SqlParameter[] insertParams = {
            new SqlParameter("@Mavc", mavc),
            new SqlParameter("@Idkcsp", idkcsp)
        };
                provider.ExecuteNonQuery(insertQuery, insertParams);
            }

            return true;
        }
    }
}
