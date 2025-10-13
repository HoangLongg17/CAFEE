using DAO;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class KhoBUS
    {
        public static List<KhoDTO> LayTatCa()
        {
            try
            {
                return KhoDAO.GetAll();
            }
            catch (Exception)
            {
                return new List<KhoDTO>();
            }
        }

        public static List<KhoDTO> TimKiem(string keyword)
        {
            try
            {
                return KhoDAO.Search(keyword);
            }
            catch (Exception)
            {
                return new List<KhoDTO>();
            }
        }

        public static DataTable LayNhaCungCap()
        {
            try
            {
                return KhoDAO.LayNhaCungCap();
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public static decimal TinhTongTien(int soLuong, decimal giaNhap)
        {
            return soLuong * giaNhap;
        }

        public static (bool success, string message, decimal tongTien) ThemTonKho(KhoDTO kho)
        {
            if (string.IsNullOrWhiteSpace(kho.MaSP) || string.IsNullOrWhiteSpace(kho.Size))
                return (false, "Vui lòng chọn sản phẩm và size.", 0);

            if (kho.SoLuongNhap <= 0)
                return (false, "Số lượng nhập phải lớn hơn 0.", 0);

            if (!kho.MaNCC.HasValue)
                return (false, "Vui lòng chọn nhà cung cấp.", 0);

            if (kho.GiaNhap < 0)
                return (false, "Giá nhập không hợp lệ.", 0);

            try
            {
                bool inserted = KhoDAO.InsertNhapKho(kho);
                if (!inserted)
                    return (false, "Không lưu được bản ghi nhập kho.", 0);

                bool updated = KhoDAO.UpdateSoLuong(kho);
                if (!updated)
                    return (false, "Không cập nhật được số lượng tồn.", 0);

                decimal tong = TinhTongTien(kho.SoLuongNhap, kho.GiaNhap);
                return (true, "Thêm tồn kho thành công.", tong);
            }
            catch (Exception ex)
            {
                var userMessage = "Có lỗi trong quá trình thêm tồn kho. Vui lòng thử lại hoặc liên hệ quản trị.";

                return (false, userMessage, 0);
            }
        }
    }
}