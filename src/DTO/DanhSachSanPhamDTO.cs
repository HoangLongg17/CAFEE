using System;
namespace DTO
{
    public class DanhSachSanPhamDTO
    {
        // Numeric product id (was previously IdKcsp). Use Masp across the codebase now.
        public int Masp { get; set; }

        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int Maloai { get; set; }
        public string TenLoai { get; set; }

        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; } = 1;
        public int SoLuongTon { get; set; }
        public string DuongDanAnh { get; set; }
        public string TrangThaiText { get; set; }

        public bool LaSanPhamTang { get; set; } = false;
        public string MaSanPhamGoc { get; set; } 
        public decimal GiaGoc { get; set; } 
        public decimal TienGiam { get; set; } 
        public int? LoaiVoucher { get; set; }  
        public decimal? PhanTramGiam { get; set; } 
    }
}