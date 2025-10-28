using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // Hoặc System.Data.SqlClient
using DTO;

namespace DAO
{
    public class ThemSanPhamDAO
    {
        private DataProvider provider = DataProvider.Instance;

        // 1. Lấy danh sách Loại Sản Phẩm
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

        // 2. Lấy map Kích cỡ (S -> 1, M -> 2, L -> 3)
        // Rất quan trọng để biết S, M, L là mã nào trong DB
        public Dictionary<char, int> GetKichCoMap()
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            string query = "SELECT makichco, kichco FROM KICHCO";
            DataTable data = provider.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                map.Add(row["kichco"].ToString()[0], (int)row["makichco"]);
            }
            return map;
        }

        // 3. Kiểm tra Mã SP đã tồn tại chưa
        public bool CheckMaSPExists(string maSP)
        {
            string query = "SELECT COUNT(*) FROM SANPHAM WHERE masp = @maSP";
            SqlParameter[] param = { new SqlParameter("@maSP", maSP) };

            // Giả sử DataProvider của ông có ExecuteScalar
            int count = (int)provider.ExecuteScalar(query, param);
            return count > 0;
        }

        // 4. Thêm vào bảng SANPHAM
        public bool InsertSanPham(SanPhamDTO sp)
        {
            string query = "INSERT INTO SANPHAM (masp, tensp, maloai, duongdananh) VALUES (@masp, @tensp, @maloai, @duongdananh)";
            SqlParameter[] param = {
            new SqlParameter("@masp", sp.MaSP),
            new SqlParameter("@tensp", sp.TenSP),
            new SqlParameter("@maloai", sp.MaLoai),
            new SqlParameter("@duongdananh", sp.DuongDanAnh ?? "")
            };
            int result = provider.ExecuteNonQuery(query, param);
            return result > 0;
        }

        // 5. Thêm vào bảng KICHCOSP
        public bool InsertKichCoSP(KichCoSPDTO kcsp)
        {
            string query = @"
                INSERT INTO KICHCOSP (masp, makichco, giaban, soluongton, canhbaotonkho, trangthaisp) 
                VALUES (@masp, @makichco, @giaban, @soluongton, @canhbaotonkho, @trangthaisp)";

            SqlParameter[] param = {
                new SqlParameter("@masp", kcsp.MaSP),
                new SqlParameter("@makichco", kcsp.MaKichCo),
                new SqlParameter("@giaban", kcsp.GiaBan),
                new SqlParameter("@soluongton", kcsp.SoLuongTon),
                new SqlParameter("@canhbaotonkho", kcsp.CanhBaoTonKho),
                new SqlParameter("@trangthaisp", kcsp.TrangThaiSP)
            };
            int result = provider.ExecuteNonQuery(query, param);
            return result > 0;
        }
    }
}