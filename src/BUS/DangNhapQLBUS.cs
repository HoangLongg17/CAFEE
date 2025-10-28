using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BUS
{
    public class DangNhapQLBUS
    {
        private DangNhapQLDAO userDAO = new DangNhapQLDAO();
        public static string HashPasswordSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                    builder.Append(b.ToString("x2")); // chuyển sang dạng hex
                return builder.ToString();
            }
        }

        public (bool isSuccess, string message, DangNhapQLDTO user) Login(string username, string password)
        {

            username = username.Trim();
            password = password.Trim();


            // --- Kiểm tra đầu vào ---
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
                return (false, "Tên đăng nhập và mật khẩu không được để trống!", null);
            if (string.IsNullOrWhiteSpace(username))
                return (false, "Tên đăng nhập không được để trống!", null);
            if (string.IsNullOrWhiteSpace(password))
                return (false, "Mật khẩu không được để trống!", null);

            // --- Lấy thông tin người dùng từ DB ---
            DangNhapQLDTO user = userDAO.Dangnhap(username);

            if (user == null)
                return (false, "Tên đăng nhập không tồn tại!", null);

            if (user == null)
                return (false, "Tên đăng nhập không tồn tại!", null);

            //  So sánh mật khẩu 
            string hashedInput = HashPasswordSHA256(password);

            if (user.Mk != hashedInput)
                return (false, "Mật khẩu không chính xác!", null);

            // --- Thành công ---
            return (true, $"Đăng nhập thành công! Xin chào {user.Hoten}", user);
        }

    }
}
