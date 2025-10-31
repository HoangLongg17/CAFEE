using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetQuaGiamGiaDTO
    {
        public decimal TongTien { get; set; }
        public decimal TienGiam { get; set; }
        public int LoaiVC { get; set; }
        public decimal GiaTri { get; set; }
        public List<BanHangDTO> SanPhamTang { get; set; }
        public string Loi { get; set; } // nếu có lỗi thì gán vào đây

    }
}
