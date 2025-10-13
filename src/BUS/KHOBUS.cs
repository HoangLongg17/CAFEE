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
                var list = KhoDAO.GetAll();
                foreach (var item in list)
                {
                    item.IsLowStock = item.SoLuong < item.CanhBaoTonKho;

                }
                return list;
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
                var list = KhoDAO.Search(keyword);
                foreach (var item in list)
                {
                    item.IsLowStock = item.SoLuong < item.CanhBaoTonKho;

                }
                return list;
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

        public static (bool success, string message, decimal tongTien) ThemTonKho(IEnumerable<KhoDTO> danhSachKho)
        {
            if (danhSachKho == null || !danhSachKho.Any())
                return (false, "Không có sản phẩm nào được chọn.", 0);

            int? maNCC = danhSachKho.First().MaNCC;
            if (!maNCC.HasValue)
                return (false, "Chưa chọn nhà cung cấp.", 0);

            int maNK;
            try
            {
                maNK = KhoDAO.InsertPhieuNhap(maNCC.Value);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi tạo phiếu nhập: " + ex.Message, 0);
            }

            decimal tongTien = 0;
            int demThanhCong = 0;
            List<string> loi = new();

            foreach (var kho in danhSachKho)
            {
                if (string.IsNullOrWhiteSpace(kho.MaSP) || string.IsNullOrWhiteSpace(kho.Size) || kho.SoLuongNhap <= 0)
                {
                    loi.Add($"• {kho.MaSP}: Dữ liệu không hợp lệ.");
                    continue;
                }

                try
                {
                    bool insertedCT = KhoDAO.InsertChiTietNhapKho(maNK, kho);
                    bool updatedSL = KhoDAO.UpdateSoLuong(kho);

                    if (insertedCT && updatedSL)
                    {
                        tongTien += kho.SoLuongNhap * kho.GiaNhap;
                        demThanhCong++;
                    }
                    else
                    {
                        loi.Add($"• {kho.MaSP}: Không thể lưu chi tiết nhập kho.");
                    }
                }
                catch (Exception ex)
                {
                    loi.Add($"• {kho.MaSP}: Lỗi khi thêm chi tiết nhập kho ({ex.Message}).");
                }
            }

            if (demThanhCong == 0)
                return (false, "Không thêm được sản phẩm nào.", 0);

            string msg = $"Tạo phiếu nhập #{maNK} thành công ({demThanhCong}/{danhSachKho.Count()}).";
            if (loi.Count > 0)
                msg += "\nMột số lỗi:\n" + string.Join("\n", loi);

            return (true, msg, tongTien);
        }



    }
}
