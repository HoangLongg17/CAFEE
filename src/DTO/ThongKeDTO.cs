using System;
using System.Collections.Generic;

namespace DTO
{

    public class LoaiSPDTO
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
    }

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

        public List<DanhSachSanPhamDTO> SanPhamMua { get; set; } = new();
        public List<DanhSachSanPhamDTO> SanPhamTang { get; set; } = new();
        public List<DanhSachSanPhamDTO> SanPhamDuocGiam { get; set; } = new(); // Thêm

        // Các property Text để hiển thị trong DGV hoặc PDF
        public string SanPhamMuaText => SanPhamMua != null ? string.Join(", ", SanPhamMua.Select(p => p.TenSP)) : "";
        public string SanPhamTangText => SanPhamTang != null ? string.Join(", ", SanPhamTang.Select(p => p.TenSP)) : "";
        public string SanPhamDuocGiamText => SanPhamDuocGiam != null ? string.Join(", ", SanPhamDuocGiam.Select(p => p.TenSP)) : "";
    }

    public class DoanhThuChartDTO
    {
        public DateTime Ngay { get; set; }
        public decimal TongDoanhThu { get; set; }
    }
}
