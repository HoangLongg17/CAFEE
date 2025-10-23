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

        // Phương thức này xử lý tất cả trường hợp: tải tất cả và tìm kiếm
        public List<DanhSachSanPhamDTO> SearchSanPham(string searchType, string searchTerm)
        {
            List<DanhSachSanPhamDTO> list = new List<DanhSachSanPhamDTO>();

            // Câu query gốc
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
                    // Xử lý chuyển đổi bit sang string
                    TrangThaiText = (bool)row["trangthaisp"] ? "Đang bán" : "Ngừng bán"
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
    }
}