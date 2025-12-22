using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BanHangDTO
    {
        // Product id (now Masp, product-level). Replaces previous IdKcsp.
        public int Masp { get; set; }

        public string MaSP { get; set; }            // Mã sản phẩm (string)
        public string TenSP { get; set; }           // Tên sản phẩm     
        public int SoLuong { get; set; }            // Số lượng người dùng chọn mua
        public int SoLuongTon { get; set; }         // Số lượng tồn kho hiện tại
        public decimal GiaBan { get; set; }         // Giá bán
        public bool LaSanPhamTang { get; set; }     // Có phải sản phẩm tặng không
        public int Maloai { get; set; }             // Mã loại sản phẩm (để kiểm tra voucher)
        public string DuongDanAnh { get; set; }
        public string TenLoai { get; set; }
        public string TrangThaiText { get; set; }
        public string MaSanPhamGoc { get; set; }
        public decimal GiaGoc { get; set; } // giá gốc chưa giảm
        public decimal TienGiam { get; set; } // số tiền giảm cho sản phẩm này
    }
}