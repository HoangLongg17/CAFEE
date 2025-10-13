using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace DTO
{
    public class KhoDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Size { get; set; }
        public int SoLuong { get; set; }

        public int SoLuongNhap { get; set; }
        public decimal GiaNhap { get; set; }
        public int? MaNCC { get; set; }
        public decimal ThanhTien { get; set; }

    }

}
