using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChamCongDTO
    {
        public int Id { get; set; }
        public string MaND { get; set; }              // Mã nhân viên
        public string TenNhanVien { get; set; }       // Tên nhân viên
        public DateTime Ngay { get; set; }            // Ngày làm việc
        public DateTime GioBatDau { get; set; }       // Giờ bắt đầu
        public DateTime? GioKetThuc { get; set; }     // Giờ kết thúc (nullable)
        public int? TongThoiGian { get; set; }        // Tổng thời gian làm (phút, nullable)
        public decimal Luong { get; set; }
        public decimal? TongLuong { get; set; }        // Tổng lương trong ngày (nullable)


    }
}
