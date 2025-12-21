using System;
using System.Collections.Generic;
using System.Linq;
using DAO;
using DTO;

namespace BUS
{
    public class ThongKeBUS
    {
        private readonly ThongKeDAO thongKeDAO = new ThongKeDAO();

        public List<LoaiSPDTO> GetLoaiSP() => thongKeDAO.GetLoaiSP();

        public List<HoaDonDTO> GetHoaDon(DateTime? tuNgay, DateTime? denNgay, int? maLoai)
        {
            if (tuNgay.HasValue && denNgay.HasValue && denNgay < tuNgay)
                throw new Exception("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.");
            return thongKeDAO.GetHoaDonList(tuNgay, denNgay, maLoai);
        }

        public List<DoanhThuChartDTO> GetDoanhThu(DateTime? tuNgay, DateTime? denNgay, int? maLoai)
        {
            if (tuNgay.HasValue && denNgay.HasValue && denNgay < tuNgay)
                throw new Exception("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.");
            return thongKeDAO.GetDoanhThuData(tuNgay, denNgay, maLoai);
        }

        public decimal CalculateTotalRevenue(List<DoanhThuChartDTO> chartData)
        {
            return chartData.Sum(x => x.TongDoanhThu);
        }

        public List<DanhSachSanPhamDTO> GetSanPhamBanChay(DateTime? tuNgay, DateTime? denNgay, int? maLoai)
        {
            if (tuNgay.HasValue && denNgay.HasValue && denNgay < tuNgay)
                throw new Exception("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.");
            return thongKeDAO.GetSanPhamBanChay(tuNgay, denNgay, maLoai);
        }
    }
}
