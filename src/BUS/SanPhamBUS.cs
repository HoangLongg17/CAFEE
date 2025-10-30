using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class SanPhamBUS
    {
        public static List<SanPhamDTO> LayTatCa()
        {
            return SanPhamDAO.LayTatCaSanPham();
        }
    }
}
