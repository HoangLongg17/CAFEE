using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Text.RegularExpressions;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    public class NhanVienBUS
    {
        public static bool themNV(NhanVienDTO nv)
        {

            if (nv.Luong < 0)
            {
                MessageBox.Show("Lương (tiền lương theo giờ hoặc lương cố định) không được là số âm.", "Lỗi Kiểm tra Dữ liệu");
                return false;
            }

            if (!Regex.IsMatch(nv.Sdt, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại phải từ 10 đến 11 số và chỉ chứa số.", "Lỗi Kiểm tra Dữ liệu");
                return false;
            }

            if (!Regex.IsMatch(nv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng.", "Lỗi Kiểm tra Dữ liệu");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nv.Hoten) || string.IsNullOrWhiteSpace(nv.Tk) || string.IsNullOrWhiteSpace(nv.Mk))
            {
                MessageBox.Show("Họ tên, Tên tài khoản và Mật khẩu không được để trống.", "Lỗi Kiểm tra Dữ liệu");
                return false;
            }

            try
            {
                NhanVienDAO.themNV(nv);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi DAO khi thêm nhân viên: " + ex.Message, "Lỗi Database");
                return false;
            }
        }

        public static bool SuaNV(NhanVienDTO nv)
        {
            if (nv.Luong < 0)
            {
                MessageBox.Show("Lương không được là số âm.", "Lỗi Kiểm tra Dữ liệu");
                return false;
            }

            if (!Regex.IsMatch(nv.Sdt, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại phải từ 10 đến 11 số và chỉ chứa số.", "Lỗi Kiểm tra Dữ liệu");
                return false;
            }

            if (!Regex.IsMatch(nv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng.", "Lỗi Kiểm tra Dữ liệu");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nv.Hoten) || string.IsNullOrWhiteSpace(nv.Tk) || string.IsNullOrWhiteSpace(nv.Mk))
            {
                MessageBox.Show("Họ tên, Tên tài khoản và Mật khẩu không được để trống.", "Lỗi Kiểm tra Dữ liệu");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nv.Mand))
            {
                MessageBox.Show("Không tìm thấy Mã nhân viên để sửa.", "Lỗi Nghiệp vụ");
                return false;
            }

            try
            {
                NhanVienDAO.SuaNV(nv);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi DAO khi sửa nhân viên: " + ex.Message, "Lỗi Database");
                return false;
            }
        }

        public static bool XoaNV(string maNV)
        {
            try
            {
                NhanVienDAO.XoaNV(maNV);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi DAO khi xóa nhân viên: " + ex.Message, "Lỗi Database");
                return false;
            }
        }

        public static NhanVienDTO LayNhanVienTheoID(string id)
        {
            return NhanVienDAO.LayNhanVienTheoID(id);
        }

        public static DataTable LayDanhSachNhanVien()
        {
            return NhanVienDAO.LayDanhSachNhanVien();
        }

        public static DataTable TimKiemNhanVien(string keyword)
        {
            return NhanVienDAO.TimKiemNhanVien(keyword);
        }

        public static List<NhanVienDTO> LayNhanVienTheoGio()
        {
            return NhanVienDAO.LayNhanVienTheoGio();
        }
    }
}
