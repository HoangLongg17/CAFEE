using DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DangNhapNVDAO
    {
        public DangNhapNVDTO DangNhap(string username)
        {
            string query = @"
                SELECT Manv, Tk, Mk, Hoten, Vitri
                FROM NHANVIEN
                WHERE Tk = @Tk";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Tk", username)
            };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new DangNhapNVDTO
            {
                Manv = row["Manv"].ToString(),
                Tk = row["Tk"].ToString(),
                Mk = row["Mk"].ToString(),
                Hoten = row["Hoten"].ToString(),
                Vitri = row["Vitri"].ToString() 
            };
        }
    }
}
