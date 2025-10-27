using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TaiKhoanDAO
    {
        // ✅ Kiểm tra mật khẩu cũ có đúng không
        public bool KiemTraMatKhauCu(string username, string password)
        {
            string query = "SELECT Mk FROM NGUOIDUNG WHERE Tk = @Tk";
            SqlParameter[] parameters = {
                new SqlParameter("@Tk", username)
            };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return false; // Không tìm thấy tài khoản

            string hashed = dt.Rows[0]["Mk"].ToString();

            // So sánh hash
            return BCrypt.Net.BCrypt.Verify(password, hashed);
        }

        // ✅ Cập nhật mật khẩu mới (hash sẵn)
        public bool CapNhatMatKhau(string username, string newHashedPassword)
        {
            string query = "UPDATE NGUOIDUNG SET Mk = @Mk WHERE Tk = @Tk";
            SqlParameter[] parameters = {
                new SqlParameter("@Mk", newHashedPassword),
                new SqlParameter("@Tk", username)
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

    }
}
