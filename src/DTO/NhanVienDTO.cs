using System;
using System.Data;

namespace DTO
{
    public class NhanVienDTO
    {
            // Main property aligned with DB column
            public string Manv { get; set; }
            // Backwards-compatible alias (some code may still use Mand)
            public string Mand { get { return Manv; } set { Manv = value; } }


            public string Tk { get; set; }
            public string Mk { get; set; }
            public string Vitri { get; set; }
            public string Hoten { get; set; }
            public string Sdt { get; set; }
            public string Email { get; set; }
            public DateTime NgaySinh { get; set; }
            public string Diachi { get; set; }
            public decimal Luong { get; set; }
            public string Bank { get; set; }
            public string Stk { get; set; }
            public string Ten { get { return Hoten; } set { Hoten = value; } }
            public string Pos { get { return Vitri; } set { Vitri = value; } }

            public NhanVienDTO() { }
            public NhanVienDTO(DataRow row)
            {

                this.Manv = row["Manv"].ToString();
                this.Tk = row["Tk"].ToString();
                this.Mk = row["Mk"].ToString();
                this.Vitri = row["Vitri"].ToString();
                this.Hoten = row["Hoten"].ToString();
                this.Sdt = row.IsNull("Sdt") ? string.Empty : row["Sdt"].ToString();
                this.Email = row.IsNull("email") ? string.Empty : row["email"].ToString();
                this.NgaySinh = row.IsNull("Ngsinh") ? DateTime.MinValue : Convert.ToDateTime(row["Ngsinh"]);
                this.Diachi = row.IsNull("Diachi") ? string.Empty : row["Diachi"].ToString();
                this.Luong = row.IsNull("Luong") ?0m : Convert.ToDecimal(row["Luong"]);
                this.Bank = row.IsNull("Bank") ? string.Empty : row["Bank"].ToString();
                this.Stk = row.IsNull("stk") ? string.Empty : row["stk"].ToString();
            }
    }
}
