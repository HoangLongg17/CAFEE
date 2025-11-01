using System;

namespace DTO
{
    public class DanhSachSanPhamDTO
    {
        // ID này là của KICHCOSP, dùng để sửa/xóa
        public int IdKcsp { get; set; }
        public int ID { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int Maloai { get; set; }
        public string TenLoai { get; set; }
        public string KichCo { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; } = 1;
        public int SoLuongTon { get; set; }
        public string DuongDanAnh { get; set; }
        // Thuộc tính này sẽ chuyển đổi bit thành chuỗi
        public string TrangThaiText { get; set; }
        public bool LaSanPhamTang { get; set; } = false;
        public string MaSanPhamGoc { get; set; } // dùng để đánh dấu sản phẩm tặng thuộc về mã nào
        public decimal GiaGoc { get; set; } // giá gốc chưa giảm
        public decimal TienGiam { get; set; } // số tiền giảm cho sản phẩm này
    }
}