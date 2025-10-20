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
        // ✅ Lấy danh sách kho
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

        // ✅ Tìm kiếm
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

        // ✅ Lấy danh sách nhà cung cấp
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

        // ✅ Tính tổng tiền (chỉ dùng cho giao diện)
        public static decimal TinhTongTien(int soLuong, decimal giaNhap)
        {
            return soLuong * giaNhap;
        }

        // ✅ Nghiệp vụ thêm phiếu nhập kho
        public static (bool success, string message, decimal tongTien) ThemTonKho(IEnumerable<KhoDTO> danhSachKho)
        {
            if (danhSachKho == null || !danhSachKho.Any())
                return (false, "Không có sản phẩm nào được chọn.", 0);

            int? maNCC = danhSachKho.First().MaNCC;
            if (!maNCC.HasValue)
                return (false, "Chưa chọn nhà cung cấp.", 0);

            // Kiểm tra dữ liệu hợp lệ
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
    }
}
