using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DangNhapNVDTO
    {
        public string Manv { get; set; }
        public string Tk { get; set; }
        public string Mk { get; set; }
        public string Hoten { get; set; }
        // Thêm thuộc tính Vị trí để phân quyền
        public string Vitri { get; set; }

    }
}
