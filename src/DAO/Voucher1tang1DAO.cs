using System.Data;
using DTO;
using System;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class Voucher1tang1DAO
    {
        private static Voucher1tang1DAO instance;
        public static Voucher1tang1DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Voucher1tang1DAO();
                return instance;
            }
        }

        private DataProvider provider = DataProvider.Instance;

        private Voucher1tang1DAO() { }

        public static string GetCode(int mavc)
        {
            string query = "SELECT code FROM VOUCHER WHERE mavc = @mavc";
            SqlParameter[] parameters = {
                new SqlParameter("@mavc", mavc)
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result?.ToString() ?? "";
        }

        public bool CheckCodeExists(string code, int? excludeMavc = null)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Code", code),
                new SqlParameter("@ExcludeMavc", (object)excludeMavc ?? DBNull.Value)
            };

            object result = provider.ExecuteScalarStoredProcedure("sp_CheckVoucherCodeExists", parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        public int InsertVoucher(string code, string tenMa, int loaiVC, int maloai, decimal dieuKien, DateTime ngaybd, DateTime ngaykt)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Code", code),
                new SqlParameter("@TenMaGiamGia", (object)tenMa ?? DBNull.Value),
                new SqlParameter("@Giatri", 0m),
                new SqlParameter("@Ngaybd", ngaybd),
                new SqlParameter("@Ngaykt", ngaykt),
                new SqlParameter("@DieuKien", (object)dieuKien ?? DBNull.Value),
                new SqlParameter("@Maloaivc", loaiVC),
                new SqlParameter("@Maloai", (object)maloai ?? DBNull.Value)
            };

            object result = provider.ExecuteScalarStoredProcedure("sp_InsertVoucher", parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public int GetVoucherId(string code)
        {
            SqlParameter[] parameters = { new SqlParameter("@Code", code) };
            object result = provider.ExecuteScalarStoredProcedure("sp_GetIdFromCode", parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // Now accepts Masp (int)
        public int InsertChiTietVC(int mavc, int masp)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Mavc", mavc),
                new SqlParameter("@Masp", masp)
            };
            object result = provider.ExecuteScalarStoredProcedure("sp_InsertChiTietVC", parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // NEW: resolve IdKcsp from Masp + Size using stored procedure sp_GetIdKcspByMaSPAndSize
        public int GetIdkcsp(string maSP, string kichco)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@MaSP", maSP ?? string.Empty),
                new SqlParameter("@Size", kichco ?? string.Empty)
            };

            object result = provider.ExecuteScalarStoredProcedure("sp_GetIdKcspByMaSPAndSize", parameters);
            return result != null && int.TryParse(result.ToString(), out int id) ? id : -1;
        }

        public DataRow GetVoucherByID(int mavc)
        {
            SqlParameter[] parameters = { new SqlParameter("@Mavc", mavc) };
            DataTable dt = provider.ExecuteStoredProcedure("sp_GetVoucherById", parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataTable GetSanPhamTangByVoucher(int mavc)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Mavc", mavc),
                new SqlParameter("@MaLoai", DBNull.Value),
                new SqlParameter("@LoaiVC", DBNull.Value)
            };
            return provider.ExecuteStoredProcedure("sp_GetSanPhamTangByVoucher", parameters);
        }

        public DataTable SearchSanPhamTang(string keyword)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", keyword ?? string.Empty)
            };
            return provider.ExecuteStoredProcedure("sp_SearchSanPhamTang", parameters);
        }

        public bool UpdateVoucher(int mavc, string code, string tenMaGiamGia, int loaiVC, int maloai, decimal dieuKien)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Mavc", mavc),
                new SqlParameter("@Code", code),
                new SqlParameter("@TenMaGiamGia", (object)tenMaGiamGia ?? DBNull.Value),
                new SqlParameter("@Giatri", 0m),
                new SqlParameter("@Ngaybd", DateTime.Today),
                new SqlParameter("@Ngaykt", DateTime.Today),
                new SqlParameter("@DieuKien", dieuKien),
                new SqlParameter("@Maloaivc", loaiVC),
                new SqlParameter("@Maloai", maloai)
            };

            object res = provider.ExecuteScalarStoredProcedure("sp_UpdateVoucher", parameters);
            return res != null && Convert.ToInt32(res) > 0;
        }

        public bool DeleteChiTietVC(int mavc)
        {
            SqlParameter[] parameters = { new SqlParameter("@Mavc", mavc) };
            provider.ExecuteNonQueryStoredProcedure("sp_DeleteChiTietVC", parameters);
            return true;
        }

        public DataTable TimSanPhamTangTheoLoai(int maloai)
        {
            SqlParameter[] parameters = { new SqlParameter("@Maloai", maloai) };
            return provider.ExecuteStoredProcedure("sp_TimSanPhamTangTheoLoai", parameters);
        }
    }
}