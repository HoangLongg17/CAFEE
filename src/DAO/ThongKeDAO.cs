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

            string query = @"
            SELECT 
            h.Mahd, h.Ngaylap, 
            h.TongTienGoc, h.TienGiam, h.TongTien,
            ISNULL(k.Tenkh, N'Khách vãng lai') AS TenKH,
            ISNULL(k.Sdt, '') AS SDTKH,
            n.Hoten AS TenNhanVien,
            v.Code AS MaVoucher,
            v.Giatri AS GiaTriGiam,
            v.Maloaivc AS LoaiVoucher
            FROM HOADON h
            LEFT JOIN KHACHHANG k ON h.Makh = k.Makh
            JOIN NGUOIDUNG n ON h.Mand = n.Mand
            LEFT JOIN APMAVC ap ON h.Mahd = ap.Mahd
            LEFT JOIN VOUCHER v ON ap.Mavc = v.Mavc
            WHERE 
            (@tuNgay IS NULL OR CAST(h.Ngaylap AS DATE) >= @tuNgay)
            AND (@denNgay IS NULL OR CAST(h.Ngaylap AS DATE) <= @denNgay)
            ORDER BY h.Ngaylap DESC";

            SqlParameter paramTuNgay = new SqlParameter("@tuNgay", tuNgay.HasValue ? (object)tuNgay.Value : DBNull.Value);
            SqlParameter paramDenNgay = new SqlParameter("@denNgay", denNgay.HasValue ? (object)denNgay.Value : DBNull.Value);

            DataTable data = provider.ExecuteQuery(query, new object[] { paramTuNgay, paramDenNgay });

            foreach (DataRow row in data.Rows)
            {
                int maHD = (int)row["Mahd"];

                HoaDonDTO hoaDon = new HoaDonDTO
                {
                    MaHD = maHD,
                    NgayLap = (DateTime)row["Ngaylap"],
                    TenNhanVien = row["TenNhanVien"].ToString(),
                    TenKH = row["TenKH"].ToString(),
                    SDTKH = row["SDTKH"].ToString(),
                    TongTienGoc = (decimal)row["TongTienGoc"],
                    TienGiam = (decimal)row["TienGiam"],
                    TongTien = (decimal)row["TongTien"],
                    MaVoucher = row["MaVoucher"]?.ToString(),
                    PhanTramGiam = null,
                    LoaiVoucher = row["LoaiVoucher"] != DBNull.Value ? (int?)row["LoaiVoucher"] : null,
                    SanPhamMua = GetSanPhamMua(maHD),
                    SanPhamTang = GetSanPhamTang(maHD),
                    SanPhamDuocGiam = (row["LoaiVoucher"] != DBNull.Value && ((int)row["LoaiVoucher"] == 1 || (int)row["LoaiVoucher"] == 3))
                    ? GetSanPhamDuocGiam(maHD)
                    : new List<DanhSachSanPhamDTO>()
                };


                list.Add(hoaDon);
            }

            return list;
        }

        private decimal TinhTongTienGoc(int maHD)
        {
            string query = "SELECT SUM(Soluong * Dongia) FROM CHITIETHD WHERE Mahd = @maHD";
            SqlParameter param = new SqlParameter("@maHD", maHD);
            object result = provider.ExecuteScalar(query, new SqlParameter[] { param });
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }
        private List<DanhSachSanPhamDTO> GetSanPhamMua(int maHD)
        {
            string query = @"
            SELECT 
            sp.tensp AS TenSP,
            kc.kichco AS KichCo,
            ct.Soluong,
            kcsp.id AS IdKcsp,
            sp.maloai AS Maloai,
            sp.masp AS MaSP,
            sp.duongdananh AS DuongDanAnh,
            CASE WHEN kcsp.trangthaisp = 1 THEN N'Đang bán' ELSE N'Ngừng bán' END AS TrangThaiText
            FROM CHITIETHD ct
            JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.id
            JOIN SANPHAM sp ON kcsp.masp = sp.masp
            JOIN KICHCO kc ON kcsp.makichco = kc.makichco
            WHERE ct.Mahd = @maHD
            AND ct.Idkcsp NOT IN (
            SELECT vc.Idkcsp
            FROM APMAVC ap
            JOIN VOUCHER v ON ap.Mavc = v.Mavc
            JOIN CHITIETVC vc ON vc.Mavc = v.Mavc
            WHERE ap.Mahd = @maHD AND v.Maloaivc IN (2,4)
            )";

            SqlParameter param = new SqlParameter("@maHD", maHD);
            DataTable data = provider.ExecuteQuery(query, new SqlParameter[] { param });

            List<DanhSachSanPhamDTO> list = new List<DanhSachSanPhamDTO>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DanhSachSanPhamDTO
                {
                    TenSP = row["TenSP"].ToString(),
                    KichCo = row["KichCo"].ToString(),
                    SoLuong = (int)row["Soluong"],
                    IdKcsp = (int)row["IdKcsp"],
                    Maloai = (int)row["Maloai"],
                    MaSP = row["MaSP"].ToString(),
                    DuongDanAnh = row["DuongDanAnh"].ToString(),
                    TrangThaiText = row["TrangThaiText"].ToString(),
                    LaSanPhamTang = false
                });
            }
            return list;
        }

        private List<DanhSachSanPhamDTO> GetSanPhamTang(int maHD)
        {
            string query = @"
            SELECT 
            sp.tensp AS TenSP,
            kc.kichco AS KichCo,
            kcsp.id AS IdKcsp,
            sp.maloai AS Maloai,
            sp.masp AS MaSP,
            sp.duongdananh AS DuongDanAnh
            FROM APMAVC ap
            JOIN VOUCHER v ON ap.Mavc = v.Mavc
            JOIN CHITIETVC vc ON vc.Mavc = v.Mavc
            JOIN KICHCOSP kcsp ON vc.Idkcsp = kcsp.id
            JOIN SANPHAM sp ON kcsp.masp = sp.masp
            JOIN KICHCO kc ON kcsp.makichco = kc.makichco
            WHERE ap.Mahd = @maHD
            AND v.Maloaivc IN (2,4)"; // chỉ lấy voucher loại tặng

            SqlParameter param = new SqlParameter("@maHD", maHD);
            DataTable data = provider.ExecuteQuery(query, new SqlParameter[] { param });

            List<DanhSachSanPhamDTO> list = new List<DanhSachSanPhamDTO>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DanhSachSanPhamDTO
                {
                    TenSP = row["TenSP"].ToString(),
                    KichCo = row["KichCo"].ToString(),
                    SoLuong = 1, // mặc định 1 sản phẩm tặng
                    IdKcsp = (int)row["IdKcsp"],
                    Maloai = (int)row["Maloai"],
                    MaSP = row["MaSP"].ToString(),
                    DuongDanAnh = row["DuongDanAnh"].ToString(),
                    LaSanPhamTang = true
                });
            }
            return list;
        }
        private List<DanhSachSanPhamDTO> GetSanPhamDuocGiam(int maHD)
        {
            string query = @"
            SELECT 
            sp.tensp AS TenSP, kc.kichco AS KichCo, ct.Soluong,
            kcsp.id AS IdKcsp, sp.maloai AS Maloai, sp.masp AS MaSP,
            sp.duongdananh AS DuongDanAnh
            FROM CHITIETHD ct
            JOIN KICHCOSP kcsp ON ct.Idkcsp = kcsp.id
            JOIN SANPHAM sp ON kcsp.masp = sp.masp
            JOIN KICHCO kc ON kcsp.makichco = kc.makichco
            WHERE ct.Mahd = @maHD
            AND ct.Dongia < kcsp.giaban";
            SqlParameter param = new SqlParameter("@maHD", maHD);
            DataTable data = provider.ExecuteQuery(query, new SqlParameter[] { param });

            List<DanhSachSanPhamDTO> list = new List<DanhSachSanPhamDTO>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DanhSachSanPhamDTO
                {
                    TenSP = row["TenSP"].ToString(),
                    KichCo = row["KichCo"].ToString(),
                    SoLuong = (int)row["Soluong"],
                    IdKcsp = (int)row["IdKcsp"],
                    Maloai = (int)row["Maloai"],
                    MaSP = row["MaSP"].ToString(),
                    DuongDanAnh = row["DuongDanAnh"].ToString(),
                    LaSanPhamTang = false
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
                list.Add(new SanPhamBanChayDTO
                {
                    TenSP = row["TenSP"].ToString(),
                    SoLuongBan = (int)row["SoLuongBan"],
                    TongDoanhThu = (decimal)row["TongDoanhThu"]
                });
            }
            return list;
        }
    }
}