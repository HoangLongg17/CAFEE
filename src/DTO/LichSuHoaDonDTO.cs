using System;

namespace DTO
{
    // DTO cho grid trên (Danh sách hóa đơn)
    public class LichSuHoaDonDTO
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public decimal TongTien { get; set; }
    }
}