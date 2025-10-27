using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
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

        private Voucher1tang1DAO() { }

        // Thêm mã giảm giá mua 1 tặng 1
        public int InsertVoucher(string code, string tenMa, int loaiVC, int maloai, decimal dieuKien)
        {
            string query = "INSERT INTO VOUCHER (Code, Giatri, Ngaybd, Ngaykt, DieuKien, Maloaivc, maloai) " +
                           "VALUES (@Code, 0, GETDATE(), '2025-12-31', @DieuKien, @LoaiVC, @MaLoai)";
            SqlParameter[] parameters = {
            new SqlParameter("@Code", code),
            new SqlParameter("@DieuKien", dieuKien),
            new SqlParameter("@LoaiVC", loaiVC),
            new SqlParameter("@MaLoai", maloai)
            };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        // Lấy mã voucher vừa thêm
        public int GetVoucherId(string code)
        {
            string query = "SELECT TOP 1 Mavc FROM VOUCHER WHERE Code = @Code ORDER BY Mavc DESC";
            SqlParameter[] parameters = {
            new SqlParameter("@Code", code)
        };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // Thêm chi tiết sản phẩm tặng cho mã voucher
        public int InsertChiTietVC(int mavc, int idkcsp)
        {
            string query = "INSERT INTO CHITIETVC (Mavc, Idkcsp) VALUES (@Mavc, @Idkcsp)";
            SqlParameter[] parameters = {
            new SqlParameter("@Mavc", mavc),
            new SqlParameter("@Idkcsp", idkcsp)
        };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        // Tìm Idkcsp từ masp và size
        public int GetIdkcsp(string masp, string kichco)
        {
            string query = "SELECT TOP 1 kc.Id FROM KICHCOSP kc " +
                           "JOIN SANPHAM sp ON kc.masp = sp.masp " +
                           "JOIN KICHCO kc2 ON kc.makichco = kc2.makichco " +
                           "WHERE kc2.kichco = @Size AND sp.masp = @MaSP";
            SqlParameter[] parameters = {
            new SqlParameter("@Size", kichco),
            new SqlParameter("@MaSP", masp)
        };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }
        public DataRow GetVoucherByID(int mavc)
        {
            string query = "SELECT * FROM VOUCHER WHERE Mavc = @Mavc AND Maloaivc IN (2, 4)";
            SqlParameter[] parameters = { new SqlParameter("@Mavc", mavc) };
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataTable GetSanPhamTangByVoucher(int mavc)
        {
            string query = @"SELECT sp.masp, sp.tensp, kc2.kichco
                     FROM CHITIETVC ct
                     JOIN KICHCOSP kc ON ct.Idkcsp = kc.Id
                     JOIN SANPHAM sp ON kc.masp = sp.masp
                     JOIN KICHCO kc2 ON kc.makichco = kc2.makichco
                     WHERE ct.Mavc = @Mavc";
            SqlParameter[] parameters = { new SqlParameter("@Mavc", mavc) };
            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }
        // Lấy danh sách sản phẩm tặng theo từ khóa
        public DataTable SearchSanPhamTang(string keyword)
        {
            string query = "SELECT sp.masp, sp.tensp, kc2.kichco " +
                           "FROM SANPHAM sp " +
                           "JOIN KICHCOSP kc ON sp.masp = kc.masp " +
                           "JOIN KICHCO kc2 ON kc.makichco = kc2.makichco " +
                           "WHERE sp.tensp LIKE N'%' + @Keyword + '%'";
            SqlParameter[] parameters = {
            new SqlParameter("@Keyword", keyword)
        };
            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }
        public bool UpdateVoucher(int mavc, string code, int loaiVC, int maloai, decimal dieuKien)
        {
            string query = @"UPDATE VOUCHER SET 
                     Code = @Code, Maloaivc = @LoaiVC, maloai = @MaLoai, DieuKien = @DieuKien 
                     WHERE Mavc = @Mavc";

            SqlParameter[] parameters = {
            new SqlParameter("@Code", code),
            new SqlParameter("@LoaiVC", loaiVC),
            new SqlParameter("@MaLoai", maloai),
            new SqlParameter("@DieuKien", dieuKien),
            new SqlParameter("@Mavc", mavc)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
        // Xóa dòng mã 1 tặng 1 theo ID
        public bool DeleteVoucher1Tang1(int id)
        {
            string query = "DELETE FROM VOUCHER1TANG1 WHERE ID = @ID";
            SqlParameter[] parameters = { new SqlParameter("@ID", id) };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
        public bool DeleteChiTietVC(int mavc)
        {
            string query = "DELETE FROM CHITIETVC WHERE Mavc = @Mavc";
            SqlParameter[] parameters = { new SqlParameter("@Mavc", mavc) };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

    }
}
