using System;

namespace DTO
{
    public class ChamCongDTO
    {
        public int Id { get; set; }                  // Idcc
        public string Manv { get; set; }             // Mã nhân viên
        public string TenNhanVien { get; set; }      // Hoten
        public DateTime Ngay { get; set; }            // Ngày làm
        public DateTime GioBatDau { get; set; }       // Giờ bắt đầu
        public DateTime? GioKetThuc { get; set; }     // Giờ kết thúc
        public int? TongThoiGian { get; set; }        // Phút
        public decimal Luong { get; set; }            // Lương theo giờ (giả định)
        public decimal TongLuong { get; set; }        // Tổng lương ngày
    }
}
