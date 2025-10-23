using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VoucherDTO
    {
        public int Mavc { get; set; }                  // Mã voucher
        public string Code { get; set; }               // Mã giảm giá
        public decimal Giatri { get; set; }            // Giá trị giảm (theo % hoặc số tiền)
        public DateTime Ngaybd { get; set; }           // Ngày bắt đầu
        public DateTime Ngaykt { get; set; }           // Ngày kết thúc
        public decimal? DieuKien { get; set; }         // Giá trị đơn hàng tối thiểu (nếu có)
        public int Maloaivc { get; set; }              // Loại mã giảm giá (Giảm %, Mua 1 tặng 1,…)
        public int? Maloai { get; set; }               // Áp dụng cho loại sản phẩm nào (nếu có)

        public VoucherDTO() { }

        public VoucherDTO(int mavc, string code, decimal giatri, DateTime ngaybd, DateTime ngaykt, decimal? dieuKien, int maloaivc, int? maloai)
        {
            Mavc = mavc;
            Code = code;
            Giatri = giatri;
            Ngaybd = ngaybd;
            Ngaykt = ngaykt;
            DieuKien = dieuKien;
            Maloaivc = maloaivc;
            Maloai = maloai;
        }

    }
}
