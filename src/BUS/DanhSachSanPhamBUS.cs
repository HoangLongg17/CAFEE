using System;
using System.Collections.Generic;
using DAO;
using DTO;
using System.Data;
using System.Transactions;
namespace BUS
{
    public class DanhSachSanPhamBUS
    {
        private DanhSachSanPhamDAO sanPhamDAO = new DanhSachSanPhamDAO();
        private static DanhSachSanPhamBUS instance;
        public static DanhSachSanPhamBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DanhSachSanPhamBUS();
                return instance;
            }
            private set { instance = value; }
        }

        public List<DanhSachSanPhamDTO> SearchSanPham(string searchType, string searchTerm)
        {
            return DanhSachSanPhamDAO.Instance.SearchSanPham(searchType, searchTerm);
        }

        public bool ToggleTrangThaiSanPham(int idKichCoSP)
        {
            return DanhSachSanPhamDAO.Instance.ToggleTrangThaiSanPham(idKichCoSP);
        }

        public bool DeleteSanPham(int idKichCoSP, string maSP)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // 1. Xóa size (KICHCOSP)
                    bool deleteSizeSuccess = sanPhamDAO.DeleteSanPham(idKichCoSP); // Hàm DeleteSanPham cũ trong DAO chỉ xóa size

                    if (!deleteSizeSuccess) return false;

                    // 2. Kiểm tra còn size nào không
                    int remainingSizes = sanPhamDAO.CountKichCoSP(maSP); // Gọi hàm DAO mới

                    if (remainingSizes == 0)
                    {
                        // 3. Nếu không còn, xóa sản phẩm gốc (SANPHAM)
                        sanPhamDAO.DeleteSanPhamGoc(maSP); // Gọi hàm DAO mới
                    }

                    // 4. Hoàn tất
                    scope.Complete();
                    return true;
                }
                catch (Exception)
                {
                    return false; // Transaction tự rollback nếu lỗi
                }
            }
        }
        public DataTable GetLoaiSanPham()
        {
            return DanhSachSanPhamDAO.Instance.GetLoaiSanPham();
        }
        public List<DanhSachSanPhamDTO> GetAllSanPham()
        {
            return DanhSachSanPhamDAO.Instance.GetAllSanPham();
        }
        public List<int> GetChiTietVoucher(int mavc)
        {
            return DanhSachSanPhamDAO.Instance.GetChiTietVoucher(mavc);
        }
        public DataTable GetSanPhamTable()
        {
            return DanhSachSanPhamDAO.Instance.GetSanPhamTable();
        }
        public DataTable GetSanPhamWithVoucher()
        {
            return DanhSachSanPhamDAO.Instance.GetSanPhamWithVoucher();
        }

    }
}