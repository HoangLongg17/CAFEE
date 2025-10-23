using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using DTO;
namespace BUS
{
    public class Voucher1tang1BUS
    {
        private static Voucher1tang1BUS instance;
        public static Voucher1tang1BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new Voucher1tang1BUS();
                return instance;
            }
        }

        private Voucher1tang1BUS() { }

        // Thêm mã giảm giá mua 1 tặng 1
        public bool ThemVoucher(string code, string tenMa, int loaiVC, int maloai, decimal dieuKien, List<(string masp, string kichco)> dsSanPhamTang)
        {
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(tenMa))
                throw new ArgumentException("Mã và tên mã không được để trống.");

            int result = Voucher1tang1DAO.Instance.InsertVoucher(code, tenMa, loaiVC, maloai, dieuKien);
            if (result <= 0) return false;

            int mavc = Voucher1tang1DAO.Instance.GetVoucherId(code);
            if (mavc <= 0) return false;

            if (loaiVC == 4 && dsSanPhamTang != null)
            {
                foreach (var item in dsSanPhamTang)
                {
                    int idkcsp = Voucher1tang1DAO.Instance.GetIdkcsp(item.masp, item.kichco);
                    if (idkcsp > 0)
                    {
                        Voucher1tang1DAO.Instance.InsertChiTietVC(mavc, idkcsp);
                    }
                }
            }

            return true;
        }
        // Tìm kiếm sản phẩm tặng theo từ khóa
        public DataTable TimSanPhamTang(string keyword)
        {
            return Voucher1tang1DAO.Instance.SearchSanPhamTang(keyword);
        }
        public bool SuaVoucher(int mavc, string code, int loaiVC, int maloai, decimal dieuKien, List<(string masp, string kichco)> dsSanPhamTang)
        {
            bool updated = Voucher1tang1DAO.Instance.UpdateVoucher(mavc, code, loaiVC, maloai, dieuKien);
            if (!updated) return false;

            // Xóa chi tiết cũ nếu là loại 4
            Voucher1tang1DAO.Instance.DeleteChiTietVC(mavc);

            if (loaiVC == 4 && dsSanPhamTang != null)
            {
                foreach (var item in dsSanPhamTang)
                {
                    int idkcsp = Voucher1tang1DAO.Instance.GetIdkcsp(item.masp, item.kichco);
                    if (idkcsp > 0)
                    {
                        Voucher1tang1DAO.Instance.InsertChiTietVC(mavc, idkcsp);
                    }
                }
            }

            return true;
        }
        public DataRow GetVoucherByID(int mavc)
        {
            return Voucher1tang1DAO.Instance.GetVoucherByID(mavc);
        }

        public DataTable GetSanPhamTangByVoucher(int mavc)
        {
            return Voucher1tang1DAO.Instance.GetSanPhamTangByVoucher(mavc);
        }
    }
}
