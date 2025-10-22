using System;
using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class DanhSachSanPhamBUS
    {
        private DanhSachSanPhamDAO sanPhamDAO = new DanhSachSanPhamDAO();

        public List<DanhSachSanPhamDTO> SearchSanPham(string searchType, string searchTerm)
        {
            // Nếu searchTerm rỗng, searchType sẽ bị bỏ qua và DAO sẽ tải tất cả
            return sanPhamDAO.SearchSanPham(searchType, searchTerm);
        }
    }
}