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
        public string TenKH { get; set; }
        public string SDTKH { get; set; }

        public decimal TongTienGoc { get; set; }
        public decimal TienGiam { get; set; }
        public decimal TongTien { get; set; }

        public string MaVoucher { get; set; }
        public int? PhanTramGiam { get; set; }
        public int? LoaiVoucher { get; set; }

        public List<DanhSachSanPhamDTO> SanPhamTang { get; set; }

    }

    // DTO cho dữ liệu biểu đồ
    public class DoanhThuChartDTO
    {
        public DateTime Ngay { get; set; }
        public decimal TongDoanhThu { get; set; }
    }
}