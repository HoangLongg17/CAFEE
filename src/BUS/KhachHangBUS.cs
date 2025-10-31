using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class KhachHangBUS
    {
        public static List<KhachHangDTO> LayDSKH()
        {
            return KhachHangDAO.layDSKH();
        }
        public static string GetTenKhachHang(int maKH)
        {
            return KhachHangDAO.GetTenKhachHang(maKH);
        }

        public static string GetSDTKhachHang(int maKH)
        {
            return KhachHangDAO.GetSDTKhachHang(maKH);
        }
        public static string LayTenKhachHangTheoSDT(string sdt)
        {
            return KhachHangDAO.LayTenKhachHangTheoSDT(sdt);
        }
        public static bool ThemKH(KhachHangDTO kh)
        {
            try
            {
                KhachHangDAO.themKH(kh);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaKH(int makh)
        {
            try
            {
                KhachHangDAO.xoaKH(makh);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaKH(KhachHangDTO kh)
        {
            try
            {
                KhachHangDAO.suaKH(kh);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<KhachHangDTO> TimKH(string keyword)
        {
            return KhachHangDAO.timTheoTenHoacSDT(keyword);
        }
        public List<KhachHangDTO> TimKiemTheoSDT(string sdt)
        {
            return KhachHangDAO.Instance.TimKiemTheoSDT(sdt);
        }
    }
}
