using System;
using System.Collections.Generic;
using System.Linq;
using DAO;
using DTO;

namespace BUS
{
    public class ThongKeBUS
    {
        private ThongKeDAO thongKeDAO = new ThongKeDAO();

        public List<LoaiSPDTO> GetLoaiSP()
        {
            return thongKeDAO.GetLoaiSP();
        }

        public List<HoaDonDTO> GetHoaDon(DateTime? tuNgay, DateTime? denNgay, int? maLoai)
        {
            if (tuNgay.HasValue && denNgay.HasValue && denNgay.Value < tuNgay.Value)
            {
                throw new Exception("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.");
            }
            //Truyền maLoai xuống DAO
            return thongKeDAO.GetHoaDonList(tuNgay, denNgay, maLoai);
        }

        public List<DoanhThuChartDTO> GetDoanhThu(DateTime? tuNgay, DateTime? denNgay, int? maLoai)
        {
            if (tuNgay.HasValue && denNgay.HasValue && denNgay.Value < tuNgay.Value)
            {
                throw new Exception("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.");
            }
            return thongKeDAO.GetDoanhThuData(tuNgay, denNgay, maLoai);
        }

        //Logic nghiệp vụ: Tính tổng từ danh sách đã lấy về
        public decimal CalculateTotalRevenue(List<DoanhThuChartDTO> chartData)
        {
            return chartData.Sum(item => item.TongDoanhThu);
        }
        public List<SanPhamBanChayDTO> GetSanPhamBanChay(DateTime? tuNgay, DateTime? denNgay, int? maLoai)
        {
            if (tuNgay.HasValue && denNgay.HasValue && denNgay.Value < tuNgay.Value)
            {
                throw new Exception("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.");
            }
            return thongKeDAO.GetSanPhamBanChay(tuNgay, denNgay, maLoai);
        }
    }
}