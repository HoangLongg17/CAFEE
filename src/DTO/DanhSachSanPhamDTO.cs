using System;

namespace DTO
{
    public class DanhSachSanPhamDTO
    {
        // ID này là của KICHCOSP, dùng để sửa/xóa
        public int ID { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string TenLoai { get; set; }
        public string KichCo { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }

        // Thuộc tính này sẽ chuyển đổi bit thành chuỗi
        public string TrangThaiText { get; set; }
    }
}