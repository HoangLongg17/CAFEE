using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
namespace DAO
{
    public class BanHangDAO
    {
        private DataProvider provider = DataProvider.Instance;
        private static BanHangDAO instance;
        public static BanHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BanHangDAO();
                return instance;
            }
        }

        public bool KiemTraSanPhamPhuHopTheoLoai(List<DanhSachSanPhamDTO> danhSach, int maloai)
        {
            foreach (var sp in danhSach)
            {
                if (sp.LaSanPhamTang) continue;

                // ✅ Nếu sản phẩm thuộc đúng dòng (loại), thì hợp lệ
                if (sp.Maloai == maloai)
                    return true;
            }

            return false;
        }
        public DataTable GetSanPhamTangByVoucher(int mavc, int maloaiGoc, int loaiVC)
        {
            string query = @"
            SELECT sp.masp, kc.kichco
            FROM CHITIETVC ct
            JOIN KICHCOSP k ON ct.Idkcsp = k.id
            JOIN SANPHAM sp ON k.masp = sp.masp
            JOIN KICHCO kc ON k.makichco = kc.makichco
            WHERE ct.Mavc = @mavc";

            if (loaiVC == 2) // Mua 1 tặng 1 cùng dòng
            {
                query += " AND sp.maloai = @maloai";
            }

            var parameters = new List<SqlParameter>
            {
            new SqlParameter("@mavc", mavc)
            };

            if (loaiVC == 2)
            {
                parameters.Add(new SqlParameter("@maloai", maloaiGoc));
            }

            return provider.ExecuteQuery(query, parameters.ToArray());
        }
        public DataTable GetSanPhamTangByVoucher(int mavc)
        {
            string query = @"
        SELECT 
            kc.Id AS IdKcsp,
            sp.MaSP,
            sp.TenSP,
            kcsize.kichco AS KichCo,
            kc.GiaBan,
            sp.Maloai,
            l.Tenloai,
            sp.DuongDanAnh,
            kc.trangthaisp AS TrangThaiText,
            kc.soluongton AS SoLuongTon
        FROM CHITIETVC ct
        JOIN KICHCOSP kc ON ct.Idkcsp = kc.Id
        JOIN KICHCO kcsize ON kc.makichco = kcsize.makichco
        JOIN SANPHAM sp ON kc.MaSP = sp.MaSP
        JOIN LOAISP l ON sp.Maloai = l.Maloai
        WHERE ct.Mavc = @mavc
    ";
            SqlParameter[] parameters = {
        new SqlParameter("@mavc", mavc)
    };
            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }
        public void ApDungVoucher(int mavc, int mahd)
        {
            string query = "INSERT INTO APMAVC (Mahd, Mavc) VALUES (@mahd, @mavc)";
            SqlParameter[] parameters = {
            new SqlParameter("@mahd", mahd),
            new SqlParameter("@mavc", mavc)
            };
            provider.ExecuteNonQuery(query, parameters);
        }
        // 1. Tạo hóa đơn
        public int TaoHoaDon(int? makh, string mand, decimal tongTienGoc, decimal tienGiam, decimal tongTienSauGiam)
        {
            string query = @"
            INSERT INTO HOADON (Ngaylap, Makh, Mand, TongTienGoc, TienGiam, TongTien)
            VALUES (@ngaylap, @makh, @mand, @tongTienGoc, @tienGiam, @tongTien);
            SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
            new SqlParameter("@ngaylap", DateTime.Now),
            new SqlParameter("@makh", (object)makh ?? DBNull.Value),
            new SqlParameter("@mand", mand),
            new SqlParameter("@tongTienGoc", tongTienGoc),
            new SqlParameter("@tienGiam", tienGiam),
            new SqlParameter("@tongTien", tongTienSauGiam)
            };

            object result = provider.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        // 2. Thêm chi tiết hóa đơn
        public void ThemChiTietHoaDon(int mahd, BanHangDTO sp)
        {
            if (sp == null)
                throw new ArgumentNullException(nameof(sp));

            if (sp.IdKcsp <= 0 || sp.SoLuong <= 0 || sp.GiaBan < 0)
                throw new ArgumentException("Dữ liệu sản phẩm không hợp lệ.");

            string query = @"
            INSERT INTO CHITIETHD (Mahd, Idkcsp, Soluong, Dongia, IsTang)
            VALUES (@mahd, @idkcsp, @soluong, @dongia, @isTang)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@mahd", mahd),
            new SqlParameter("@idkcsp", sp.IdKcsp),
            new SqlParameter("@soluong", sp.SoLuong),
            new SqlParameter("@dongia", sp.GiaBan),
            new SqlParameter("@isTang", sp.LaSanPhamTang ? 1 : 0)
            };

            provider.ExecuteNonQuery(query, parameters);
        }


        // 3. Trừ tồn kho
        public void TruTonKho(int idkcsp, int soLuong)
        {
            string query = "UPDATE KICHCOSP SET soluongton = soluongton - @soLuong WHERE id = @idkcsp";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@soLuong", soLuong),
                new SqlParameter("@idkcsp", idkcsp)
            };

            provider.ExecuteNonQuery(query, parameters);
        }
        public List<BanHangDTO> LayTatCaSanPham()
        {
            List<BanHangDTO> list = new List<BanHangDTO>();

            string query = @"
                    SELECT 
                        kc.id AS IdKCSP, 
                        sp.masp, 
                        sp.tensp, 
                        l.tenloai AS TenLoai, 
                        k.kichco, 
                        kc.giaban, 
                        sp.duongdananh,
                        sp.maloai,
                        kc.soluongton,
                        CASE WHEN kc.trangthaisp = 1 THEN N'Đang bán' ELSE N'Ngừng bán' END AS TrangThaiText
                    FROM SANPHAM sp
                    JOIN LOAISP l ON sp.maloai = l.maloai
                    JOIN KICHCOSP kc ON sp.masp = kc.masp
                    JOIN KICHCO k ON kc.makichco = k.makichco
                    WHERE kc.trangthaisp = 1";  // ✅ chỉ lấy sản phẩm đang bán


            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new BanHangDTO
                {
                    IdKcsp = Convert.ToInt32(row["IdKCSP"]),
                    MaSP = row["masp"].ToString(),
                    TenSP = row["tensp"].ToString(),
                    TenLoai = row["TenLoai"].ToString(),
                    KichCo = row["kichco"].ToString(),
                    GiaBan = Convert.ToDecimal(row["giaban"]),
                    DuongDanAnh = row["duongdananh"].ToString(),
                    Maloai = Convert.ToInt32(row["maloai"]),
                    SoLuongTon = Convert.ToInt32(row["soluongton"]),
                    TrangThaiText = row["TrangThaiText"].ToString()
                });
            }

            return list;
        }
        public List<BanHangDTO> TimKiemSanPham(string searchType, string keyword)
        {
            List<BanHangDTO> list = new List<BanHangDTO>();

            string query = @"
            SELECT 
            kc.id AS IdKCSP, 
            sp.masp, 
            sp.tensp, 
            l.tenloai AS TenLoai, 
            k.kichco, 
            kc.giaban, 
            sp.duongdananh,
            sp.maloai,
            kc.soluongton,
            CASE WHEN kc.trangthaisp = 1 THEN N'Đang bán' ELSE N'Ngừng bán' END AS TrangThaiText
            FROM SANPHAM sp
            JOIN LOAISP l ON sp.maloai = l.maloai
            JOIN KICHCOSP kc ON sp.masp = kc.masp
            JOIN KICHCO k ON kc.makichco = k.makichco
            WHERE kc.trangthaisp = 1";

            if (searchType == "TenSP")
            {
                query += " AND sp.tensp LIKE @keyword";
            }
            else if (searchType == "MaSP")
            {
                query += " AND sp.masp LIKE @keyword";
            }

            SqlParameter param = new SqlParameter("@keyword", "%" + keyword + "%");
            DataTable dt = provider.ExecuteQuery(query, new SqlParameter[] { param });

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new BanHangDTO
                {
                    IdKcsp = Convert.ToInt32(row["IdKCSP"]),
                    MaSP = row["masp"].ToString(),
                    TenSP = row["tensp"].ToString(),
                    TenLoai = row["TenLoai"].ToString(),
                    KichCo = row["kichco"].ToString(),
                    GiaBan = Convert.ToDecimal(row["giaban"]),
                    DuongDanAnh = row["duongdananh"].ToString(),
                    Maloai = Convert.ToInt32(row["maloai"]),
                    SoLuongTon = Convert.ToInt32(row["soluongton"]),
                    TrangThaiText = row["TrangThaiText"].ToString()
                });
            }

            return list;
        }


    }
}
