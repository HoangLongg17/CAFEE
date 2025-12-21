using System;
using System.Collections.Generic;

namespace DTO
{
    public class DanhSachSanPhamDTO
    {
        public int IdKcsp { get; set; }                // ID của KICHCOSP
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int Maloai { get; set; }
        public string TenLoai { get; set; }
        public string KichCo { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; } = 1;
        public int SoLuongTon { get; set; }
        public string DuongDanAnh { get; set; }
        public string TrangThaiText { get; set; }      // chuyển đổi bit thành chuỗi
        public bool LaSanPhamTang { get; set; } = false;
        public string MaSanPhamGoc { get; set; }       // sản phẩm tặng thuộc về mã nào
        public decimal GiaGoc { get; set; }            // giá gốc
        public decimal TienGiam { get; set; }          // tiền giảm cho sản phẩm
    }

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
    }

    public class DoanhThuChartDTO
    {
        public DateTime Ngay { get; set; }
        public decimal TongDoanhThu { get; set; }
    }
}
