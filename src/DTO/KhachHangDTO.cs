using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public KhachHangDTO(int makh, string tenkh, string sdt, int tichdiem)
        {
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Sdt = sdt;
            this.Tichdiem = tichdiem;
        }

        public KhachHangDTO(DataRow row)
        {
            this.Makh = (int)row["Makh"];
            this.Tenkh = row["Tenkh"].ToString();
            this.Sdt = row["Sdt"].ToString();
            this.Tichdiem = (int)row["Tichdiem"];
        }

        public int Makh { get; set; }
        public string Tenkh { get; set; }
        public string Sdt { get; set; }
        public int Tichdiem { get; set; }

    }
}
