using System;
using System.Collections.Generic;
using DAO;
using DTO;
using System.Data;
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

        public bool DeleteSanPham(int idKichCoSP)
        {
            return DanhSachSanPhamDAO.Instance.DeleteSanPham(idKichCoSP);
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