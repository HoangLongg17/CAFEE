using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KichCoSPDTO
    {
        public int ID { get; set; } // <-- BỔ SUNG DÒNG NÀY
        public string MaSP { get; set; }
        public int MaKichCo { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public int CanhBaoTonKho { get; set; }
        public bool TrangThaiSP { get; set; }
    }
}
