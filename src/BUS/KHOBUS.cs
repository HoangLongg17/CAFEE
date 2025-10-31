using DAO;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

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
                    item.IsLowStock = item.SoLuong < item.CanhBaoTonKho;

                return list;
            }
            catch
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
                    item.IsLowStock = item.SoLuong < item.CanhBaoTonKho;

                return list;
            }
            catch
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
            catch
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

            var invalids = danhSachKho
                .Where(k => string.IsNullOrWhiteSpace(k.MaSP)
                            || string.IsNullOrWhiteSpace(k.Size)
                            || k.SoLuongNhap <= 0
                            || k.GiaNhap <= 0M)
                .ToList();

            if (invalids.Any())
            {
                string loi = string.Join("\n", invalids.Select(k =>
                    $"• {k.MaSP} ({k.Size}) - SL: {k.SoLuongNhap}, Giá: {k.GiaNhap}"));
                return (false, "Một hoặc nhiều sản phẩm chưa hợp lệ:\n" + loi, 0);
            }

            decimal tongTien = danhSachKho.Sum(k => k.SoLuongNhap * k.GiaNhap);

            try
            {
                bool ok = KhoDAO.LuuPhieuNhapKho(maNCC.Value, danhSachKho.ToList());
                if (ok)
                    return (true, $"Tạo phiếu nhập thành công (Tổng tiền: {tongTien:N0} đ)", tongTien);
                return (false, "Không thể lưu phiếu nhập.", 0);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi nhập kho: " + ex.Message, 0);
            }
        }
        public static (bool success, string message) XuatKho(IEnumerable<KhoDTO> danhSachKho)
        {
            if (danhSachKho == null || !danhSachKho.Any())
                return (false, "Không có sản phẩm nào được chọn để xuất.");

            // Kiểm tra dữ liệu đầu vào
            var invalids = danhSachKho
                .Where(k => string.IsNullOrWhiteSpace(k.MaSP)
                            || string.IsNullOrWhiteSpace(k.Size)
                            || k.SoLuongXuat <= 0)
                .ToList();

            if (invalids.Any())
            {
                string loi = string.Join("\n", invalids.Select(k =>
                    $"• {k.MaSP} ({k.Size}) - SL xuất: {k.SoLuongXuat}"));
                return (false, "Một hoặc nhiều sản phẩm chưa hợp lệ:\n" + loi);
            }

            try
            {
                bool ok = KhoDAO.LuuPhieuXuatKho(danhSachKho.ToList());
                if (ok)
                    return (true, "Xuất kho thành công!");
                return (false, "Không thể lưu phiếu xuất kho.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi xuất kho: " + ex.Message);
            }
        }

    }
}
