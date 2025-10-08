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

            decimal tongTien = 0;
            int demThanhCong = 0;
            var thongBaoLoi = new List<string>();

            foreach (var kho in danhSachKho)
            {
                // Kiểm tra dữ liệu cơ bản
                if (string.IsNullOrWhiteSpace(kho.MaSP))
                {
                    thongBaoLoi.Add($"• Sản phẩm thiếu mã SP.");
                    continue;
                }
                if (string.IsNullOrWhiteSpace(kho.Size))
                {
                    thongBaoLoi.Add($"• {kho.MaSP}: Chưa chọn size.");
                    continue;
                }
                if (kho.SoLuongNhap <= 0)
                {
                    thongBaoLoi.Add($"• {kho.MaSP}: Số lượng phải > 0.");
                    continue;
                }
                if (!kho.MaNCC.HasValue)
                {
                    thongBaoLoi.Add($"• {kho.MaSP}: Chưa chọn nhà cung cấp.");
                    continue;
                }
                if (kho.GiaNhap < 0)
                {
                    thongBaoLoi.Add($"• {kho.MaSP}: Giá nhập không hợp lệ.");
                    continue;
                }

                try
                {
                    bool inserted = KhoDAO.InsertNhapKho(kho);
                    bool updated = KhoDAO.UpdateSoLuong(kho);

                    if (!inserted || !updated)
                    {
                        thongBaoLoi.Add($"• {kho.MaSP}: Lỗi khi lưu dữ liệu.");
                        continue;
                    }

                    tongTien += TinhTongTien(kho.SoLuongNhap, kho.GiaNhap);
                    demThanhCong++;
                }
                catch
                {
                    thongBaoLoi.Add($"• {kho.MaSP}: Lỗi hệ thống khi thêm tồn kho.");
                }
            }

            if (demThanhCong == 0)
            {
                string msg = thongBaoLoi.Count > 0
                    ? "Không thêm được sản phẩm nào:\n" + string.Join("\n", thongBaoLoi)
                    : "Không có sản phẩm hợp lệ để thêm.";
                return (false, msg, 0);
            }

            string msgTongHop = $"Thêm thành công {demThanhCong}/{danhSachKho.Count()} sản phẩm.";
            if (thongBaoLoi.Count > 0)
                msgTongHop += "\nMột số sản phẩm bị lỗi:\n" + string.Join("\n", thongBaoLoi);

            return (true, msgTongHop, tongTien);
        }


    }
}