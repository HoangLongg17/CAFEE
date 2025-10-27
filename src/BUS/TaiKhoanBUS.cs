using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAO dao = new TaiKhoanDAO();
      
        public List<string> KiemTraMatKhauMoi(string password, string confirmPassword)
        {
            List<string> errors = new List<string>();

            // 1️⃣ Không để trống
            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add("Mật khẩu không được để trống");
                return errors;
            }

            // 2️⃣ Độ dài tối thiểu
            if (password.Length < 6)
            {
                errors.Add("Mật khẩu phải có ít nhất 6 ký tự");
            }

            // 3️⃣ Không có khoảng trắng
            if (password.Contains(" "))
            {
                errors.Add("Mật khẩu không được chứa khoảng trắng giữa các ký tự");
            }

            // 4️⃣ Không có ký tự có dấu tiếng Việt
            if (Vietnamese(password))
            {
                errors.Add("Mật khẩu không được chứa ký tự có dấu");
            }

            // 5️⃣ Phải có ít nhất 1 chữ hoa
            if (!password.Any(char.IsUpper))
            {
                errors.Add("Mật khẩu phải chứa ít nhất 1 chữ cái in hoa (A-Z)");
            }

            // 6️⃣ Phải có ít nhất 1 chữ thường
            if (!password.Any(char.IsLower))
            {
                errors.Add("Mật khẩu phải chứa ít nhất 1 chữ cái thường (a-z)");
            }

            // 7️⃣ Phải có ít nhất 1 số
            if (!password.Any(char.IsDigit))
            {
                errors.Add("Mật khẩu phải chứa ít nhất 1 chữ số (0-9)");
            }

            // 8️⃣ Phải có ít nhất 1 ký tự đặc biệt
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                errors.Add("Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt (ví dụ: @, #, $, !)");
            }

            // 9️⃣ Kiểm tra xác nhận mật khẩu
            if (password != confirmPassword)
            {
                errors.Add("Mật khẩu xác nhận không khớp");
            }

            return errors;
        }
        private bool Vietnamese(string input)
        {
            string pattern = @"[À-ỹ]";
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
        }
        public string DoiMatKhau(string username, string oldPassword, string newPassword, string confirmPassword)
        {
            List<string> errors = new List<string>();

            // 1️⃣ Kiểm tra trống toàn bộ
            if (string.IsNullOrWhiteSpace(oldPassword) &&
                string.IsNullOrWhiteSpace(newPassword) &&
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "Vui lòng nhập đầy đủ thông tin.";
            }

            // 2️⃣ Kiểm tra trống từng ô
            if (string.IsNullOrWhiteSpace(oldPassword))
                errors.Add("Chưa nhập mật khẩu cũ.");
            if (string.IsNullOrWhiteSpace(newPassword))
                errors.Add("Chưa nhập mật khẩu mới.");
            if (string.IsNullOrWhiteSpace(confirmPassword))
                errors.Add("Chưa nhập xác nhận mật khẩu mới.");

            if (errors.Count > 0)
                return string.Join("\n", errors);

            // 3️⃣ Kiểm tra mật khẩu cũ có đúng không
            if (!dao.KiemTraMatKhauCu(username, oldPassword))
                return "Mật khẩu cũ không đúng.";

            // 4️⃣ Kiểm tra quy tắc của mật khẩu mới
            var mkErrors = KiemTraMatKhauMoi(newPassword, confirmPassword);
            if (mkErrors.Count > 0)
                return string.Join("\n", mkErrors);

            // 5️⃣ Hash và cập nhật
            string hashed = BCrypt.Net.BCrypt.HashPassword(newPassword);
            bool updated = dao.CapNhatMatKhau(username, hashed);

            return updated ? "Đổi mật khẩu thành công!" : "Đổi mật khẩu thất bại!";
        }

    
    }
}
    

