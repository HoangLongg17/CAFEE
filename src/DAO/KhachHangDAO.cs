using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
namespace DAO
{
    public class KhachHangDAO
    {
        public static List<KhachHangDTO> layDSKH()
        {
            List<KhachHangDTO> dsKH = new List<KhachHangDTO>();
            string query = "SELECT * FROM KHACHHANG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                KhachHangDTO kh = new KhachHangDTO(row);
                dsKH.Add(kh);
            }
            return dsKH;
        }

        public static void themKH(KhachHangDTO kh)
        {
            string sql = "INSERT INTO KHACHHANG (Tenkh, Sdt, Tichdiem) VALUES (@Tenkh, @Sdt, @Tichdiem)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Tenkh", kh.Tenkh),
                new SqlParameter("@Sdt", kh.Sdt),
                new SqlParameter("@Tichdiem", kh.Tichdiem)
            };
            DataProvider.Instance.ExecuteNonQuery(sql, parameters);
        }
        public static void xoaKH(int makh)
        {
            string sql = "DELETE FROM KHACHHANG WHERE Makh = @Makh";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Makh", makh)
            };
            DataProvider.Instance.ExecuteNonQuery(sql, parameters);
        }

        public static void suaKH(KhachHangDTO kh)
        {
            string sql = "UPDATE KHACHHANG SET Tenkh = @Tenkh, Sdt = @Sdt, Tichdiem = @Tichdiem WHERE Makh = @Makh";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Makh", kh.Makh),
                new SqlParameter("@Tenkh", kh.Tenkh),
                new SqlParameter("@Sdt", kh.Sdt),
                new SqlParameter("@Tichdiem", kh.Tichdiem)
            };
            DataProvider.Instance.ExecuteNonQuery(sql, parameters);
        }
        public static List<KhachHangDTO> timTheoTenHoacSDT(string keyword)
        {
            List<KhachHangDTO> dsKH = new List<KhachHangDTO>();
            string sql = "SELECT * FROM KHACHHANG WHERE Tenkh LIKE @Keyword OR Sdt LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, parameters);
            foreach (DataRow row in data.Rows)
            {
                KhachHangDTO kh = new KhachHangDTO(row);
                dsKH.Add(kh);
            }
            return dsKH;
        }

    }
}
