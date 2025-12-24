using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAO dao = new TaiKhoanDAO();

        // 🔹 Hàm kiểm tra mật khẩu mới
        public List<string> KiemTraMatKhauMoi(string password, string confirmPassword)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add("Mật khẩu không được để trống");
                return errors;
            }

            else if (password.Length < 6)
                errors.Add("Mật khẩu phải có ít nhất 6 ký tự");

            else if (password.Contains(" "))
                errors.Add("Mật khẩu không được chứa khoảng trắng giữa các ký tự");

            else if (Vietnamese(password))
                errors.Add("Mật khẩu không được chứa ký tự có dấu");

            else if (!password.Any(char.IsUpper))
                errors.Add("Mật khẩu phải chứa ít nhất 1 chữ cái in hoa (A-Z)");

            else if (!password.Any(char.IsLower))
                errors.Add("Mật khẩu phải chứa ít nhất 1 chữ cái thường (a-z)");

            else if (!password.Any(char.IsDigit))
                errors.Add("Mật khẩu phải chứa ít nhất 1 chữ số (0-9)");

            else if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                errors.Add("Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt (ví dụ: @, #, $, !)");

            else if (password != confirmPassword)
                errors.Add("Mật khẩu xác nhận không khớp");

            return errors;
        }

        // 🔹 Hàm kiểm tra có ký tự tiếng Việt
        private bool Vietnamese(string input)
        {
            string pattern = @"[À-ỹ]";
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
        }

        // Hash helper reused for login
        private string HashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // chuyển mỗi byte sang dạng hex
                }
                return builder.ToString();
            }
        }

        // 🔹 Hàm đổi mật khẩu chính
        public string DoiMatKhau(string username, string oldPassword, string newPassword, string confirmPassword)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(oldPassword) &&
                string.IsNullOrWhiteSpace(newPassword) &&
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            if (string.IsNullOrWhiteSpace(oldPassword))
                errors.Add("Chưa nhập mật khẩu cũ.");
            if (string.IsNullOrWhiteSpace(newPassword))
                errors.Add("Chưa nhập mật khẩu mới.");
            if (string.IsNullOrWhiteSpace(confirmPassword))
                errors.Add("Chưa nhập xác nhận mật khẩu mới.");

            if (errors.Count > 0)
                return string.Join("\n", errors);

            // 1️⃣ Hash mật khẩu cũ để so sánh trong DB
            string oldHashed = HashSHA256(oldPassword);
            if (!dao.KiemTraMatKhauCu(username, oldHashed))
                return "Mật khẩu cũ không đúng.";

            // 2️⃣ Kiểm tra quy tắc của mật khẩu mới
            var mkErrors = KiemTraMatKhauMoi(newPassword, confirmPassword);
            if (mkErrors.Count > 0)
                return string.Join("\n", mkErrors);

            // 3️⃣ Hash mật khẩu mới và cập nhật
            string newHashed = HashSHA256(newPassword);
            bool updated = dao.CapNhatMatKhau(username, newHashed);

            return updated ? "Đổi mật khẩu thành công!" : "Đổi mật khẩu thất bại!";
        }

        // Authenticate and return NhanVienDTO or null
        public NhanVienDTO Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
                return null;

            string hashed = HashSHA256(password);
            return dao.DangNhap(username, hashed);
        }
    }
}
