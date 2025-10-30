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
        public int IdMua { get; set; }           // Sản phẩm mua (KICHCOSP.Id)
        public int IdTang { get; set; }          // Sản phẩm tặng (KICHCOSP.Id)

        // Thông tin hiển thị (không bắt buộc, dùng cho UI)
        public string TenSanPhamMua { get; set; }
        public string SizeMua { get; set; }
        public string TenSanPhamTang { get; set; }
        public string SizeTang { get; set; }

    }
}
