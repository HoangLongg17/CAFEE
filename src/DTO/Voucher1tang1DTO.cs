using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Voucher1tang1DTO
    {
        public int ID { get; set; }              // ID dòng chi tiết
        public int Mavc { get; set; }            // Mã voucher
        public string? TenMaGiamGia { get; set; }

        // Use product-level Masp (no more KICHCOSP.Id / sizes)
        public int MaspMua { get; set; }         // Masp của sản phẩm mua
        public int MaspTang { get; set; }        // Masp của sản phẩm tặng

        // Thông tin hiển thị (không bắt buộc, dùng cho UI)
        public string TenSanPhamMua { get; set; }
        public string TenSanPhamTang { get; set; }
        public decimal? DieuKien { get; set; }
    }
}