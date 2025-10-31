using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BanHangDTO
    {
        public int IdKcsp { get; set; }             // ID sản phẩm theo kích cỡ (khóa chính của KICHCOSP)
        public string MaSP { get; set; }            // Mã sản phẩm
        public string TenSP { get; set; }           // Tên sản phẩm
        public string KichCo { get; set; }          // Kích cỡ (S, M, L)
        public int SoLuong { get; set; }            // Số lượng người dùng chọn mua
        public int SoLuongTon { get; set; }         // Số lượng tồn kho hiện tại
        public decimal GiaBan { get; set; }         // Giá bán theo kích cỡ
        public bool LaSanPhamTang { get; set; }     // Có phải sản phẩm tặng không
        public int Maloai { get; set; }             // Mã loại sản phẩm (để kiểm tra voucher)
        public string DuongDanAnh { get; set; }
        public string TenLoai { get; set; }
        public string TrangThaiText { get; set; }
        public string MaSanPhamGoc { get; set; }
    }
}
