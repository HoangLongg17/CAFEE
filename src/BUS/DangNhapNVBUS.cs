using DAO;
using DTO;
using System.Security.Cryptography;
using System.Text;

namespace BUS
{
    public class DangNhapNVBUS
    {
        private DangNhapNVDAO userDAO = new DangNhapNVDAO();

        public static string HashPasswordSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public (bool success, string message, DangNhapNVDTO user) Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return (false, "Tên đăng nhập hoặc mật khẩu không được để trống!", null);

            DangNhapNVDTO user = userDAO.DangNhap(username.Trim());

            if (user == null)
                return (false, "Tên đăng nhập không tồn tại!", null);

            string hashedInput = HashPasswordSHA256(password.Trim());

            if (user.Mk != hashedInput)
                return (false, "Mật khẩu không chính xác!", null);

            return (true, $"Xin chào {user.Hoten}", user);
        }

        public string GetEmployeeIDByUsername(string username)
        {
            return userDAO.DangNhap(username)?.Manv;
        }
    }
}
