using System;
using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class LichSuHoaDonBUS
    {
        private LichSuHoaDonDAO lichSuDAO = new LichSuHoaDonDAO();

        public List<LichSuHoaDonDTO> SearchHoaDon(string timKiem, string maNV, DateTime? tuNgay, DateTime? denNgay)
        {
            if (tuNgay.HasValue && denNgay.HasValue && denNgay.Value < tuNgay.Value)
            {
                throw new Exception("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.");
            }

            string finalTimKiem = string.IsNullOrEmpty(timKiem) ? null : timKiem;
            string finalMaNV = string.IsNullOrEmpty(maNV) ? null : maNV;

            return lichSuDAO.SearchHoaDon(finalTimKiem, finalMaNV, tuNgay, denNgay);
        }

        // (THAY ĐỔI)
        public List<NhanVienDTO> GetNhanVienList()
        {
            return lichSuDAO.GetNhanVienList();
        }
    }
}