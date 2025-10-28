using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SuaSanPhamLoadDTO
    {
        public string TenSP { get; set; }
        public int MaLoai { get; set; }
        public List<KichCoGiaDTO> DanhSachKichCo { get; set; }

        public SuaSanPhamLoadDTO()
        {
            DanhSachKichCo = new List<KichCoGiaDTO>();
        }
    }
}
