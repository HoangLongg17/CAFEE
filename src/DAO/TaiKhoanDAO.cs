using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TaiKhoanDAO
    {
        // ✅ Kiểm tra mật khẩu cũ có đúng không (so sánh SHA-256)
        public bool KiemTraMatKhauCu(string username, string hashedPassword)
        {
            string query = "SELECT Mk FROM NGUOIDUNG WHERE Tk = @Tk";
            SqlParameter[] parameters = {
                new SqlParameter("@Tk", username)
            };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return false; // Không tìm thấy tài khoản

            string storedHash = dt.Rows[0]["Mk"].ToString();

            // So sánh hash SHA-256 (không phân biệt hoa thường)
            return string.Equals(storedHash, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        // ✅ Cập nhật mật khẩu mới (lưu SHA-256 hash)
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