using System;

namespace DTO
{
    // DTO cho ComboBox Loại sản phẩm
    public class LoaiSPDTO
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
    }

    // DTO cho DataGridView Hóa đơn
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public decimal TongTien { get; set; }
    }

    // DTO cho dữ liệu biểu đồ
    public class DoanhThuChartDTO
    {
        public DateTime Ngay { get; set; }
        public decimal TongDoanhThu { get; set; }
    }
}