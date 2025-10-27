using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
        public class TaiKhoanDTO
        {
        public string Tk { get; set; }              // Tên đăng nhập
        public string MkCu { get; set; }            // Mật khẩu cũ
        public string MkMoi { get; set; }           // Mật khẩu mới
        public string XacNhanMkMoi { get; set; }    // Xác nhận mật khẩu mới
    }
    

}
