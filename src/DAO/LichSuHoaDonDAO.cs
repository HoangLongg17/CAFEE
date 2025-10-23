using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAO
{
    public class LichSuHoaDonDAO
    {
        private DataProvider provider = DataProvider.Instance;

        // 1. Tìm kiếm/Lọc hóa đơn (Giữ nguyên)
        public List<LichSuHoaDonDTO> SearchHoaDon(string timKiem, string maNV, DateTime? tuNgay, DateTime? denNgay)
        {
            List<LichSuHoaDonDTO> list = new List<LichSuHoaDonDTO>();

            string query = @"
                SELECT 
                    h.Mahd, 
                    h.Ngaylap, 
                    n.Hoten AS TenNhanVien, 
                    ISNULL(k.Tenkh, N'Khách vãng lai') AS TenKhachHang, 
                    h.Tongtien 
                FROM HOADON h
                JOIN NGUOIDUNG n ON h.Mand = n.Mand
                LEFT JOIN KHACHHANG k ON h.Makh = k.Makh
                WHERE 
                    (@timKiem IS NULL OR 
                     k.Tenkh LIKE @timKiemLike OR 
                     k.Sdt LIKE @timKiemLike OR 
                     CAST(h.Mahd AS VARCHAR(10)) = @timKiem)
                AND 
                    (@maNV IS NULL OR h.Mand = @maNV)
                AND 
                    (@tuNgay IS NULL OR CAST(h.Ngaylap AS DATE) >= @tuNgay)
                AND 
                    (@denNgay IS NULL OR CAST(h.Ngaylap AS DATE) <= @denNgay)
                ORDER BY h.Ngaylap DESC";

            object paramTimKiem = string.IsNullOrEmpty(timKiem) ? DBNull.Value : (object)timKiem;
            object paramTimKiemLike = string.IsNullOrEmpty(timKiem) ? DBNull.Value : (object)($"%{timKiem}%");
            object paramMaNV = string.IsNullOrEmpty(maNV) ? DBNull.Value : (object)maNV;
            object paramTuNgay = tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value;
            object paramDenNgay = denNgay.HasValue ? (object)denNgay.Value : DBNull.Value;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@timKiem", paramTimKiem),
                new SqlParameter("@timKiemLike", paramTimKiemLike),
                new SqlParameter("@maNV", paramMaNV),
                new SqlParameter("@tuNgay", paramTuNgay),
                new SqlParameter("@denNgay", paramDenNgay)
            };

            DataTable data = provider.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new LichSuHoaDonDTO
                {
                    MaHD = (int)row["Mahd"],
                    NgayLap = (DateTime)row["Ngaylap"],
                    TenNhanVien = row["TenNhanVien"].ToString(),
                    TenKhachHang = row["TenKhachHang"].ToString(),
                    TongTien = (decimal)row["Tongtien"]
                });
            }
            return list;
        }

        // 2. (THAY ĐỔI) Lấy danh sách nhân viên
        public List<NhanVienDTO> GetNhanVienList()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            string query = "SELECT Mand, Hoten, Vitri FROM NGUOIDUNG WHERE Vitri = N'NhanVien'";

            DataTable data = provider.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new NhanVienDTO
                {
                    Mand = row["Mand"].ToString(),
                    Hoten = row["Hoten"].ToString(),
                    Vitri = row["Vitri"].ToString()
                });
            }
            return list;
        }
    }
}