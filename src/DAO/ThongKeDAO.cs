using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAO
{
    public class ThongKeDAO
    {
        private DataProvider provider = DataProvider.Instance;

        public List<LoaiSPDTO> GetLoaiSP()
        {
            List<LoaiSPDTO> list = new List<LoaiSPDTO>();
            string query = "SELECT maloai, tenloai FROM LOAISP";
            DataTable data = provider.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new LoaiSPDTO
                {
                    MaLoai = (int)row["maloai"],
                    TenLoai = row["tenloai"].ToString()
                });
            }
            return list;
        }
        public List<HoaDonDTO> GetHoaDonList(DateTime? tuNgay, DateTime? denNgay, int? maLoai)
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            string query;

            SqlParameter paramTuNgay = new SqlParameter("@tuNgay", tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value);
            SqlParameter paramDenNgay = new SqlParameter("@denNgay", denNgay.HasValue ? (object)denNgay.Value : DBNull.Value);

            object[] parameters;

            if (maLoai == null)
            {
                //1. Query GỐC (nếu không lọc loại SP)
                query = @"
            SELECT 
                h.Mahd, h.Ngaylap, n.Hoten AS TenNhanVien, 
                ISNULL(k.Tenkh, N'Khách vãng lai') AS TenKhachHang, h.Tongtien 
            FROM HOADON h
            JOIN NGUOIDUNG n ON h.Mand = n.Mand
            LEFT JOIN KHACHHANG k ON h.Makh = k.Makh
            WHERE 
                (@tuNgay IS NULL OR CAST(h.Ngaylap AS DATE) >= @tuNgay)
                AND (@denNgay IS NULL OR CAST(h.Ngaylap AS DATE) <= @denNgay)
            ORDER BY h.Ngaylap DESC";

                parameters = new object[] { paramTuNgay, paramDenNgay };
            }
            else
            {
                //2. Query MỚI (nếu CÓ lọc loại SP)
                //Phải dùng DISTINCT để hóa đơn không bị lặp lại
                query = @"
            SELECT DISTINCT 
                h.Mahd, h.Ngaylap, n.Hoten AS TenNhanVien, 
                ISNULL(k.Tenkh, N'Khách vãng lai') AS TenKhachHang, h.Tongtien 
            FROM HOADON h
            JOIN NGUOIDUNG n ON h.Mand = n.Mand
            LEFT JOIN KHACHHANG k ON h.Makh = k.Makh
            
            -- Thêm JOIN để lọc loại sản phẩm
            JOIN CHITIETHD ct ON h.Mahd = ct.Mahd
            JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.id
            JOIN SANPHAM sp ON kcsp.masp = sp.masp
            
            WHERE 
                (@tuNgay IS NULL OR CAST(h.Ngaylap AS DATE) >= @tuNgay)
                AND (@denNgay IS NULL OR CAST(h.Ngaylap AS DATE) <= @denNgay)
                AND (sp.maloai = @maLoai) -- Điều kiện lọc mới
            ORDER BY h.Ngaylap DESC";

                //Thêm tham số maLoai
                SqlParameter paramMaLoai = new SqlParameter("@maLoai", maLoai.Value);
                parameters = new object[] { paramTuNgay, paramDenNgay, paramMaLoai };
            }

            //Thực thi query
            DataTable data = provider.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new HoaDonDTO
                {
                    MaHD = (int)row["Mahd"],
                    NgayLap = (DateTime)row["Ngaylap"],
                    TenNhanVien = row["TenNhanVien"].ToString(),
                    TenKH = row["TenKH"].ToString(),
                    TongTien = (decimal)row["Tongtien"]
                });
            }
            return list;
        }
        public List<DoanhThuChartDTO> GetDoanhThuData(DateTime? tuNgay, DateTime? denNgay, int? maLoai)
        {
            List<DoanhThuChartDTO> list = new List<DoanhThuChartDTO>();

            string query = @"
                SELECT 
                    CAST(h.Ngaylap AS DATE) AS Ngay, 
                    SUM(ct.Thanhtien) AS TongDoanhThu
                FROM HOADON h
                JOIN CHITIETHD ct ON h.Mahd = ct.Mahd
                JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.id
                JOIN SANPHAM sp ON kcsp.masp = sp.masp
                WHERE 
                    (@tuNgay IS NULL OR CAST(h.Ngaylap AS DATE) >= @tuNgay)
                    AND (@denNgay IS NULL OR CAST(h.Ngaylap AS DATE) <= @denNgay)
                    AND (@maLoai IS NULL OR sp.maloai = @maLoai)
                GROUP BY CAST(h.Ngaylap AS DATE)
                ORDER BY Ngay";

            SqlParameter paramTuNgay = new SqlParameter("@tuNgay", tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value);
            SqlParameter paramDenNgay = new SqlParameter("@denNgay", denNgay.HasValue ? (object)denNgay.Value : DBNull.Value);
            SqlParameter paramMaLoai = new SqlParameter("@maLoai", maLoai.HasValue ? (object)maLoai.Value : DBNull.Value);

            DataTable data = provider.ExecuteQuery(query, new object[] { paramTuNgay, paramDenNgay, paramMaLoai });

            foreach (DataRow row in data.Rows)
            {
                list.Add(new DoanhThuChartDTO
                {
                    Ngay = (DateTime)row["Ngay"],
                    TongDoanhThu = (decimal)row["TongDoanhThu"]
                });
            }
            return list;
        }
        public List<SanPhamBanChayDTO> GetSanPhamBanChay(DateTime? tuNgay, DateTime? denNgay, int? maLoai)
        {
            List<SanPhamBanChayDTO> list = new List<SanPhamBanChayDTO>();

            // (SỬA LẠI QUERY)
            string query = @"
        SELECT 
            sp.tensp AS TenSP, 
            SUM(ct.Soluong) AS SoLuongBan,
            SUM(ct.Thanhtien) AS TongDoanhThu  -- (BỔ SUNG DÒNG NÀY)
        FROM CHITIETHD ct
        JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.id
        JOIN SANPHAM sp ON kcsp.masp = sp.masp
        JOIN HOADON h ON h.Mahd = ct.Mahd
        WHERE 
            (@tuNgay IS NULL OR CAST(h.Ngaylap AS DATE) >= @tuNgay)
            AND (@denNgay IS NULL OR CAST(h.Ngaylap AS DATE) <= @denNgay)
            AND (@maLoai IS NULL OR sp.maloai = @maLoai)
        GROUP BY sp.tensp
        ORDER BY SoLuongBan DESC"; // Vẫn sắp xếp theo SỐ LƯỢNG

            SqlParameter paramTuNgay = new SqlParameter("@tuNgay", tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value);
            SqlParameter paramDenNgay = new SqlParameter("@denNgay", denNgay.HasValue ? (object)denNgay.Value : DBNull.Value);
            SqlParameter paramMaLoai = new SqlParameter("@maLoai", maLoai.HasValue ? (object)maLoai.Value : DBNull.Value);

            DataTable data = provider.ExecuteQuery(query, new object[] { paramTuNgay, paramDenNgay, paramMaLoai });

            foreach (DataRow row in data.Rows)
            {
                // (SỬA LẠI KHỐI ADD)
                list.Add(new SanPhamBanChayDTO
                {
                    TenSP = row["TenSP"].ToString(),
                    SoLuongBan = (int)row["SoLuongBan"],
                    TongDoanhThu = (decimal)row["TongDoanhThu"] // (BỔ SUNG DÒNG NÀY)
                });
            }
            return list;
        }
    }
}