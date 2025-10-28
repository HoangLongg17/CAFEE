using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // Hoặc System.Data.SqlClient
using DTO;

namespace DAO
{
    public class DanhSachSanPhamDAO
    {
        private DataProvider provider = DataProvider.Instance;
        private static DanhSachSanPhamDAO instance;
        public static DanhSachSanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DanhSachSanPhamDAO();
                return instance;
            }
        }
        public DataTable GetLoaiSanPham()
        {
            string query = "SELECT maloai, tenloai FROM LOAISP";
            return provider.ExecuteQuery(query);
        }

        public List<DanhSachSanPhamDTO> GetAllSanPham()
        {
            string query = @"
        SELECT 
            kcsp.id, 
            sp.masp, 
            sp.tensp, 
            l.tenloai, 
            kc.kichco, 
            kcsp.giaban, 
            kcsp.soluongton, 
            kcsp.trangthaisp
        FROM KICHCOSP kcsp
        JOIN SANPHAM sp ON kcsp.masp = sp.masp
        JOIN LOAISP l ON sp.maloai = l.maloai
        JOIN KICHCO kc ON kcsp.makichco = kc.makichco
        ORDER BY sp.masp, kcsp.makichco";

            DataTable data = provider.ExecuteQuery(query);
            List<DanhSachSanPhamDTO> list = new List<DanhSachSanPhamDTO>();

            foreach (DataRow row in data.Rows)
            {
                list.Add(new DanhSachSanPhamDTO
                {
                    ID = (int)row["id"],
                    MaSP = row["masp"].ToString(),
                    TenSP = row["tensp"].ToString(),
                    TenLoai = row["tenloai"].ToString(),
                    KichCo = row["kichco"].ToString(),
                    GiaBan = (decimal)row["giaban"],
                    SoLuongTon = (int)row["soluongton"],
                    TrangThaiText = (bool)row["trangthaisp"] ? "Đang bán" : "Ngừng bán"
                });
            }

            return list;
        }
        public DataTable GetSanPhamTable()
        {
            var list = DanhSachSanPhamDAO.Instance.GetAllSanPham();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã sản phẩm");
            dt.Columns.Add("Tên sản phẩm");
            dt.Columns.Add("Loại");
            dt.Columns.Add("Size");
            dt.Columns.Add("Giá bán", typeof(decimal));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Trạng thái");

            foreach (var sp in list)
            {
                dt.Rows.Add(sp.MaSP, sp.TenSP, sp.TenLoai, sp.KichCo, sp.GiaBan, sp.SoLuongTon, sp.TrangThaiText);
            }

            return dt;
        }
        public DataTable GetSanPhamWithVoucher()
        {
            string query = @"
        SELECT 
            sp.masp AS [Mã sản phẩm],
            sp.tensp AS [Tên sản phẩm],
            l.tenloai AS [Loại],
            kc.kichco AS [Size],
            kcsp.giaban AS [Giá bán],
            kcsp.soluongton AS [Số lượng],
            CASE WHEN kcsp.trangthaisp = 1 THEN N'Đang bán' ELSE N'Ngừng bán' END AS [Trạng thái],
            ISNULL(voucherList.Vouchers, N'Không có') AS [Voucher liên quan]
        FROM KICHCOSP kcsp
        JOIN SANPHAM sp ON kcsp.masp = sp.masp
        JOIN LOAISP l ON sp.maloai = l.maloai
        JOIN KICHCO kc ON kcsp.makichco = kc.makichco
        LEFT JOIN (
            SELECT ct.Idkcsp, STRING_AGG(v.Code, ', ') AS Vouchers
            FROM CHITIETVC ct
            JOIN VOUCHER v ON ct.Mavc = v.Mavc
            GROUP BY ct.Idkcsp
        ) voucherList ON kcsp.id = voucherList.Idkcsp
        ORDER BY sp.masp, kcsp.makichco";

            return provider.ExecuteQuery(query);
        }
        // Phương thức này xử lý tất cả trường hợp: tải tất cả và tìm kiếm
        public List<DanhSachSanPhamDTO> SearchSanPham(string searchType, string searchTerm)
        {
            List<DanhSachSanPhamDTO> list = new List<DanhSachSanPhamDTO>();

            // Câu query gốc có thêm duongdananh
            string query = @"
        SELECT 
            kcsp.id, 
            sp.masp, 
            sp.tensp, 
            sp.duongdananh, 
            l.tenloai, 
            kc.kichco, 
            kcsp.giaban, 
            kcsp.soluongton, 
            kcsp.trangthaisp
        FROM KICHCOSP kcsp
        JOIN SANPHAM sp ON kcsp.masp = sp.masp
        JOIN LOAISP l ON sp.maloai = l.maloai
        JOIN KICHCO kc ON kcsp.makichco = kc.makichco";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Thêm điều kiện WHERE nếu có tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                string condition = "";
                switch (searchType)
                {
                    case "MaSP":
                        condition = " WHERE sp.masp LIKE @searchTerm";
                        break;
                    case "TenSP":
                        condition = " WHERE sp.tensp LIKE @searchTerm";
                        break;
                    case "LoaiSP":
                        condition = " WHERE l.tenloai LIKE @searchTerm";
                        break;
                }
                query += condition;
                parameters.Add(new SqlParameter("@searchTerm", $"%{searchTerm}%"));
            }

            query += " ORDER BY sp.masp, kcsp.makichco";

            DataTable data = provider.ExecuteQuery(query, parameters.ToArray());

            foreach (DataRow row in data.Rows)
            {
                list.Add(new DanhSachSanPhamDTO
                {
                    ID = (int)row["id"],
                    MaSP = row["masp"].ToString(),
                    TenSP = row["tensp"].ToString(),
                    TenLoai = row["tenloai"].ToString(),
                    KichCo = row["kichco"].ToString(),
                    GiaBan = (decimal)row["giaban"],
                    SoLuongTon = (int)row["soluongton"],
                    TrangThaiText = (bool)row["trangthaisp"] ? "Đang bán" : "Ngừng bán",
                    DuongDanAnh = row["duongdananh"]?.ToString() // thêm dòng này
                });
            }

            return list;
        }
        public bool ToggleTrangThaiSanPham(int idKichCoSP)
        {
            // Lật bit: trangthaisp = 1 - trangthaisp
            string query = "UPDATE KICHCOSP SET trangthaisp = 1 - trangthaisp WHERE id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", idKichCoSP)
            };

            // Giả sử provider.ExecuteNonQuery() trả về số dòng bị ảnh hưởng
            int result = provider.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public List<int> GetChiTietVoucher(int mavc)
        {
            string query = "SELECT Idkcsp FROM CHITIETVC WHERE Mavc = @Mavc";
            SqlParameter[] parameters = { new SqlParameter("@Mavc", mavc) };
            DataTable dt = provider.ExecuteQuery(query, parameters);

            List<int> result = new List<int>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(Convert.ToInt32(row["Idkcsp"]));
            }
            return result;
        }

        public bool DeleteSanPham(int idKichCoSP)
        {
            // Xóa sản phẩm-kích cỡ cụ thể
            string query = "DELETE FROM KICHCOSP WHERE id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", idKichCoSP)
            };

            int result = provider.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        // (BỔ SUNG MỚI 1) Hàm đếm số size còn lại
        public int CountKichCoSP(string maSP)
        {
            string query = "SELECT COUNT(*) FROM KICHCOSP WHERE masp = @maSP";
            SqlParameter[] param = { new SqlParameter("@maSP", maSP) };
            return (int)provider.ExecuteScalar(query, param);
        }

        // (BỔ SUNG MỚI 2) Hàm xóa sản phẩm gốc (bảng SANPHAM)
        public bool DeleteSanPhamGoc(string maSP)
        {
            string query = "DELETE FROM SANPHAM WHERE masp = @maSP";
            SqlParameter[] param = { new SqlParameter("@maSP", maSP) };
            int result = provider.ExecuteNonQuery(query, param);
            return result > 0;
        }
    }
}