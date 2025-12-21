using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LSNhapKhoDTO
    {
        public int Mank { get; set; }
        public DateTime Ngaynhap { get; set; }
        public string Tennhacc { get; set; }
        public decimal Tongtien { get; set; }
    }

    public class ChiTietNhapKhoDTO
    {
        public int Mank { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongNhap { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal Thanhtien { get; set; }
    }
}
