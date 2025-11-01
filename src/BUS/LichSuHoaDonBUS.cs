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
        public List<ChiTietLichSuDTO> GetChiTietHoaDon(int maHD)
        {
            return lichSuDAO.GetChiTietHoaDon(maHD);
        }
        // (BỔ SUNG HÀM 1) Lấy DTO đầy đủ cho form chi tiết
        public HoaDonDayDuDTO GetHoaDonDayDu(int maHD)
        {
            // 1. Lấy thông tin cơ bản
            HoaDonDayDuDTO dto = lichSuDAO.GetThongTinCoBanHD(maHD);
            if (dto == null) return null;

            // 2. (SỬA) Lấy danh sách món BÁN (từ CHITIETHD)
            dto.Items = lichSuDAO.GetChiTietHoaDon(maHD);

            // 3. (BỔ SUNG) Lấy danh sách món TẶNG (từ CHITIETVC)
            List<ChiTietLichSuDTO> itemsTang = lichSuDAO.GetChiTietVoucherTang(maHD);

            // Gộp 2 danh sách lại
            dto.Items.AddRange(itemsTang);

            // 4. Lấy danh sách voucher
            dto.VouchersSuDung = lichSuDAO.GetVouchersSuDung(maHD);

            return dto;
        }

        // (BỔ SUNG HÀM 2) Lấy báo cáo khách hàng của nhân viên
        public List<KhachHangCuaNVDTO> GetKhachHangCuaNhanVien(string maNV)
        {
            return lichSuDAO.GetKhachHangCuaNhanVien(maNV);
        }
    }
}