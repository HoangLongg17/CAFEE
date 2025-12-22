using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    // Thông tin chi tiết từng sản phẩm trả hàng
    public class ChiTietTraHangDTO
    {
        public int Masp { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }

    // Thông tin phiếu trả hàng
    public class TraHangDTO
    {
        public int MaTra { get; set; }
        public int MaHD { get; set; }
        public DateTime NgayTra { get; set; }
        public string NhanVien { get; set; }
        public string LyDoTra { get; set; }
        public List<ChiTietTraHangDTO> ChiTiet { get; set; }

        public TraHangDTO()
        {
            ChiTiet = new List<ChiTietTraHangDTO>();
        }
    }
}