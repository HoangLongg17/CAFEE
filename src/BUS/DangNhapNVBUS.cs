using DAO;
using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace BUS
{
    public class DangNhapNVBUS
    {
        private DangNhapNVDAO userDAO = new DangNhapNVDAO();
        public (bool isSuccess, string message, DangNhapNVDTO user) Login(string username, string password)
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
            DangNhapNVDTO user = userDAO.Dangnhap(username);

            if (user == null)
                return (false, "Tên đăng nhập không tồn tại!", null);

            // --- So sánh mật khẩu ---
            bool match = BCrypt.Net.BCrypt.Verify(password, user.Mk);

            if (!match)
                return (false, "Mật khẩu không chính xác!", null);

            // --- Thành công ---
            return (true, $"Đăng nhập thành công! Xin chào {user.Hoten}", user);
        }

        public string GetEmployeeIDByUsername(string username)
        {
            var user = userDAO.Dangnhap(username);
            return user?.Mand;
        }
    }
}
