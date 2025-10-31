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
        public List<ChiTietLichSuDTO> GetChiTietHoaDon(int maHD)
        {
            List<ChiTietLichSuDTO> list = new List<ChiTietLichSuDTO>();
            string query = @"
        SELECT 
            sp.tensp, 
            kc.kichco, 
            ct.Soluong, 
            ct.Dongia, 
            ct.Thanhtien 
        FROM CHITIETHD ct
        JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.id
        JOIN SANPHAM sp ON kcsp.masp = sp.masp
        JOIN KICHCO kc ON kcsp.makichco = kc.makichco
        WHERE ct.Mahd = @maHD";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@maHD", maHD)
            };

            DataTable data = provider.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new ChiTietLichSuDTO
                {
                    TenSP = row["tensp"].ToString(),
                    KichCo = row["kichco"].ToString(),
                    SoLuong = (int)row["Soluong"],
                    DonGia = (decimal)row["Dongia"],
                    ThanhTien = (decimal)row["Thanhtien"]
                });
            }
            return list;
        }
        // (BỔ SUNG HÀM 1) Lấy thông tin cơ bản của HĐ
        public HoaDonDayDuDTO GetThongTinCoBanHD(int maHD)
        {
            HoaDonDayDuDTO dto = null;
            string query = @"
        SELECT 
            h.Mahd, h.Ngaylap, h.Tongtien, 
            n.Hoten AS TenNhanVien, 
            ISNULL(k.Tenkh, N'Khách vãng lai') AS TenKhachHang, 
            k.Sdt, 
            ISNULL(k.Tichdiem, 0) AS TichDiem
        FROM HOADON h
        JOIN NGUOIDUNG n ON h.Mand = n.Mand
        LEFT JOIN KHACHHANG k ON h.Makh = k.Makh
        WHERE h.Mahd = @maHD";

            SqlParameter[] param = { new SqlParameter("@maHD", maHD) };
            DataTable data = provider.ExecuteQuery(query, param);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                dto = new HoaDonDayDuDTO
                {
                    MaHD = (int)row["Mahd"],
                    NgayLap = (DateTime)row["Ngaylap"],
                    TenNhanVien = row["TenNhanVien"].ToString(),
                    TenKhachHang = row["TenKhachHang"].ToString(),
                    SdtKhachHang = row["Sdt"]?.ToString(), // Xử lý null
                    TichDiem = (int)row["TichDiem"],
                    TongTienCuoiCung = (decimal)row["Tongtien"]
                };
            }
            return dto;
        }

        // (BỔ SUNG HÀM 2) Lấy danh sách voucher đã dùng
        public List<string> GetVouchersSuDung(int maHD)
        {
            List<string> vouchers = new List<string>();
            string query = @"
        SELECT v.Code 
        FROM APMAVC a
        JOIN VOUCHER v ON a.Mavc = v.Mavc
        WHERE a.Mahd = @maHD";

            SqlParameter[] param = { new SqlParameter("@maHD", maHD) };
            DataTable data = provider.ExecuteQuery(query, param);

            foreach (DataRow row in data.Rows)
            {
                vouchers.Add(row["Code"].ToString());
            }
            return vouchers;
        }
        // (BỔ SUNG HÀM MỚI NÀY VÀO LichSuHoaDonDAO.cs)
        public List<KhachHangCuaNVDTO> GetKhachHangCuaNhanVien(string maNV)
        {
            List<KhachHangCuaNVDTO> list = new List<KhachHangCuaNVDTO>();
            string query = @"
        SELECT 
            k.Tenkh, 
            k.Sdt, 
            SUM(h.Tongtien) as TongChiTieu 
        FROM HOADON h
        JOIN KHACHHANG k ON h.Makh = k.Makh
        WHERE h.Mand = @maNV AND h.Makh IS NOT NULL
        GROUP BY k.Tenkh, k.Sdt
        ORDER BY TongChiTieu DESC";

            SqlParameter[] param = { new SqlParameter("@maNV", maNV) };
            DataTable data = provider.ExecuteQuery(query, param); // Giả sử ông dùng DataProvider

            foreach (DataRow row in data.Rows)
            {
                list.Add(new KhachHangCuaNVDTO
                {
                    TenKH = row["Tenkh"].ToString(),
                    Sdt = row["Sdt"].ToString(),
                    TongChiTieu = (decimal)row["TongChiTieu"]
                });
            }
            return list;
        }
    }
}