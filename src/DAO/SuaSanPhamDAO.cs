using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAO
{
    public class SuaSanPhamDAO
    {
        private DataProvider provider = DataProvider.Instance;

        // 1. Lấy danh sách Loại SP (Tương tự form Thêm)
        public List<LoaiSPDTO> GetLoaiSP()
        {
            List<LoaiSPDTO> list = new List<LoaiSPDTO>();
            string query = "SELECT maloai, tenloai FROM LOAISP";
            DataTable data = provider.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new LoaiSPDTO { MaLoai = (int)row["maloai"], TenLoai = row["tenloai"].ToString() });
            }
            return list;
        }

        // 2. Lấy KichCoMap (Tương tự form Thêm)
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

        // 3. Lấy thông tin sản phẩm và các size/giá của nó
        public SuaSanPhamLoadDTO GetSanPhamBaseInfo(string maSP)
        {
            SuaSanPhamLoadDTO dto = new SuaSanPhamLoadDTO();

            // Lấy thông tin cơ bản
            string querySP = "SELECT tensp, maloai FROM SANPHAM WHERE masp = @maSP";
            SqlParameter[] paramSP = { new SqlParameter("@maSP", maSP) };
            DataTable dataSP = provider.ExecuteQuery(querySP, paramSP);

            if (dataSP.Rows.Count == 0) return null; // Không tìm thấy SP

            dto.TenSP = dataSP.Rows[0]["tensp"].ToString();
            dto.MaLoai = (int)dataSP.Rows[0]["maloai"];

            // Lấy thông tin các size/giá (để fill lên form)
            string querySize = @"
                SELECT kc.kichco, kcsp.giaban 
                FROM KICHCOSP kcsp
                JOIN KICHCO kc ON kcsp.makichco = kc.makichco
                WHERE kcsp.masp = @maSP";

            SqlParameter[] paramSize = { new SqlParameter("@maSP", maSP) };
            DataTable dataSize = provider.ExecuteQuery(querySize, paramSize);

            foreach (DataRow row in dataSize.Rows)
            {
                dto.DanhSachKichCo.Add(new KichCoGiaDTO
                {
                    KichCo = row["kichco"].ToString()[0],
                    GiaBan = (decimal)row["giaban"]
                });
            }
            return dto;
        }

        // --- CÁC HÀM LƯU FORM (cập nhật) ---

        // (MỚI) 1. Lấy DANH SÁCH size/giá hiện tại của SP
        public List<KichCoSPDTO> GetKichCoSPList(string maSP)
        {
            List<KichCoSPDTO> list = new List<KichCoSPDTO>();
            string query = "SELECT id, makichco, giaban, soluongton, canhbaotonkho, trangthaisp FROM KICHCOSP WHERE masp = @maSP";
            SqlParameter[] param = { new SqlParameter("@maSP", maSP) };
            DataTable data = provider.ExecuteQuery(query, param);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new KichCoSPDTO
                {
                    ID = (int)row["id"],
                    MaSP = maSP,
                    MaKichCo = (int)row["makichco"],
                    GiaBan = (decimal)row["giaban"],
                    SoLuongTon = (int)row["soluongton"],
                    CanhBaoTonKho = (int)row["canhbaotonkho"],
                    TrangThaiSP = (bool)row["trangthaisp"]
                });
            }
            return list;
        }

        // 2. Cập nhật bảng SANPHAM (Giữ nguyên)
        public bool UpdateSanPham(SanPhamDTO sp)
        {
            string query = "UPDATE SANPHAM SET tensp = @tensp, maloai = @maloai WHERE masp = @masp";
            SqlParameter[] param = {
                new SqlParameter("@tensp", sp.TenSP),
                new SqlParameter("@maloai", sp.MaLoai),
                new SqlParameter("@masp", sp.MaSP)
            };
            int result = provider.ExecuteNonQuery(query, param);
            return result > 0;
        }

        // (MỚI) 3. Cập nhật GIÁ BÁN của một KICHCOSP
        public bool UpdateKichCoSP(string maSP, int maKichCo, decimal giaBan)
        {
            // Chỉ cập nhật giá, giữ nguyên ID, tồn kho...
            string query = "UPDATE KICHCOSP SET giaban = @giaban WHERE masp = @masp AND makichco = @makichco";
            SqlParameter[] param = {
                new SqlParameter("@giaban", giaBan),
                new SqlParameter("@masp", maSP),
                new SqlParameter("@makichco", maKichCo)
            };
            int result = provider.ExecuteNonQuery(query, param);
            return result > 0;
        }

        // (MỚI) 4. Xóa MỘT KICHCOSP
        public bool DeleteSpecificKichCoSP(string maSP, int maKichCo)
        {
            string query = "DELETE FROM KICHCOSP WHERE masp = @masp AND makichco = @makichco";
            SqlParameter[] param = {
                new SqlParameter("@masp", maSP),
                new SqlParameter("@makichco", maKichCo)
            };
            int result = provider.ExecuteNonQuery(query, param);
            return result > 0;
        }

        // 5. Thêm KICHCOSP (Giữ nguyên từ code ThemSanPhamDAO)
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