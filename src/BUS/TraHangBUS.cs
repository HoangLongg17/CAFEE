using System.Collections.Generic;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class TraHangBUS
    {
        private TraHangDAO dao = new TraHangDAO();

        public DataTable GetDanhSachHoaDon(string tuKhoa = "")
        {
            return dao.GetDanhSachHoaDon(tuKhoa);
        }

        public List<ChiTietTraHangDTO> GetChiTietHoaDon(int maHD)
        {
            return dao.GetChiTietHoaDon(maHD);
        }

        public int TaoTraHang(int maHD, string manv, string lyDo, List<ChiTietTraHangDTO> chiTiet)
        {
            // Tạo phiếu trả hàng
            int maTra = dao.ThemTraHang(maHD, manv, lyDo);

            // Thêm chi tiết và cập nhật tồn kho
            foreach (var item in chiTiet)
            {
                dao.ThemChiTietTraHang(maTra, item.Masp, item.SoLuong, item.DonGia);
            }

            return maTra;
        }
    }
}
