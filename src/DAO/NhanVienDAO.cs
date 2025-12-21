using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DAO
{
    public class NhanVienDAO
    {
        public static List<NhanVienDTO> layDSNhanVien()
        {
            List<NhanVienDTO> dsNV = new List<NhanVienDTO>();
            try
            {
                string query = "SELECT * FROM NHANVIEN";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        NhanVienDTO nv = new NhanVienDTO(row);

                        dsNV.Add(nv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lấy danh sách nhân viên (List): " + ex.Message);
            }
            return dsNV;
        }

        public static void XoaNV(string maNV)
        {
            string sql = "DELETE FROM NHANVIEN WHERE Manv=@Manv";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Manv", maNV)
            };
            DataProvider.Instance.ExecuteNonQuery(sql, parameters);
        }

        public static void SuaNV(NhanVienDTO nv)
        {
            string sql = @"
                UPDATE NHANVIEN SET 
                    Hoten=@Hoten, Sdt=@Sdt, email=@Email, Vitri=@Vitri, Luong=@Luong, 
                    Tk=@Tk, Mk=@Mk, Bank=@Bank, stk=@Stk, Ngsinh=@Ngsinh
                WHERE Manv=@Manv";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Manv", nv.Mand),
                new SqlParameter("@Hoten", nv.Hoten),
                new SqlParameter("@Sdt", nv.Sdt),
                new SqlParameter("@Email", nv.Email),
                new SqlParameter("@Vitri", nv.Pos),
                new SqlParameter("@Luong", nv.Luong),
                new SqlParameter("@Tk", nv.Tk),
                new SqlParameter("@Mk", nv.Mk),
                new SqlParameter("@Bank", nv.Bank ?? (object)DBNull.Value),
                new SqlParameter("@Stk", nv.Stk ?? (object)DBNull.Value),
                new SqlParameter("@Ngsinh", nv.NgaySinh),
            };
            DataProvider.Instance.ExecuteNonQuery(sql, parameters);
        }

        public static DataTable LayDanhSachNhanVien()
        {
            string query = "SELECT Manv AS Mand, Hoten, Sdt, email, Vitri, Luong, Tk, Mk, Bank, stk, Ngsinh FROM NHANVIEN";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public static DataTable TimKiemNhanVien(string keyword)
        {
            string query = "SELECT * FROM NHANVIEN WHERE Hoten LIKE @Keyword OR Sdt LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm nhân viên: " + ex.Message);
                return null;
            }
        }

        public static List<NhanVienDTO> LayNhanVienTheoGio()
        {
            List<NhanVienDTO> dsNV = new List<NhanVienDTO>();
            try
            {
                string query = "SELECT * FROM NHANVIEN WHERE Luong > 0";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow row in data.Rows)
                {
                    NhanVienDTO nv = new NhanVienDTO(row);
                    dsNV.Add(nv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lấy danh sách nhân viên theo giờ: " + ex.Message);
            }
            return dsNV;
        }

        public static void themNV(NhanVienDTO hs)
        {
            string sql = @"
                INSERT INTO NHANVIEN (Manv, Hoten, Sdt, email, Vitri, Luong, Tk, Mk, Bank, stk, Ngsinh) 
                VALUES (@Manv, @Hoten, @Sdt, @Email, @Vitri, @Luong, @Tk, @Mk, @Bank, @Stk, @Ngsinh)";

            SqlParameter[] parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@Manv", hs.Mand);
            parameters[1] = new SqlParameter("@Hoten", hs.Hoten);
            parameters[2] = new SqlParameter("@Sdt", hs.Sdt);
            parameters[3] = new SqlParameter("@Email", hs.Email);
            parameters[4] = new SqlParameter("@Vitri", hs.Pos);
            parameters[5] = new SqlParameter("@Luong", hs.Luong);
            parameters[6] = new SqlParameter("@Tk", hs.Tk);
            parameters[7] = new SqlParameter("@Mk", hs.Mk);
            parameters[8] = new SqlParameter("@Bank", hs.Bank ?? (object)DBNull.Value);
            parameters[9] = new SqlParameter("@Stk", hs.Stk ?? (object)DBNull.Value);
            parameters[10] = new SqlParameter("@Ngsinh", hs.NgaySinh);

            DataProvider.Instance.ExecuteNonQuery(sql, parameters);
        }

        public static NhanVienDTO LayNhanVienTheoID(string id)
        {
            string query = "SELECT * FROM NHANVIEN WHERE Manv = @Manv";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Manv", id)
            };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);
            if (data.Rows.Count > 0)
            {
                return new NhanVienDTO(data.Rows[0]);
            }
            return null;
        }
        public static string LayTenNhanVien(string mand)
        {
            string query = "SELECT Hoten FROM NHANVIEN WHERE Manv = @manv";
            SqlParameter[] parameters = { new SqlParameter("@manv", mand) };
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Hoten"].ToString();
            }

            return "Không xác định";
        }
        // thêm nhân viên
        public static bool KiemTraTonTaiMaNV(string maNV)
        {
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE Manv = @Manv";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Manv", maNV)
            };
            // ExecuteScalar sẽ trả về giá trị đầu tiên của hàng đầu tiên (là COUNT(*))
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);

            // Nếu COUNT(*) > 0, mã đã tồn tại
            if (result != null && Convert.ToInt32(result) > 0)
            {
                return true;
            }
            return false;
        }
        public static bool KiemTraTonTaiTenTaiKhoan(string tenTaiKhoan)
        {
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE Tk = @Tk";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Tk", tenTaiKhoan)
            };
            // ExecuteScalar trả về số lượng bản ghi có Tk trùng
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);

            // Nếu COUNT(*) > 0, tên tài khoản đã tồn tại
            if (result != null && Convert.ToInt32(result) > 0)
            {
                return true;
            }
            return false;
        }
        public static bool KiemTraTonTaiSdt(string sdt)
        {
            // Dùng COUNT(*) để kiểm tra số lượng bản ghi có Sdt trùng khớp
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE Sdt = @Sdt";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Sdt", sdt)
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);

            return result != null && Convert.ToInt32(result) > 0;
        }
        public static bool KiemTraTonTaiEmail(string email)
        {
            // Dùng COUNT(*) để kiểm tra số lượng bản ghi có Email trùng khớp
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE Email = @Email";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Email", email)
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);

            return result != null && Convert.ToInt32(result) > 0;
        }
        // sửa nhân viên
        public static bool KiemTraTonTaiTenTaiKhoanKhac(string tenTaiKhoan, string mandCanLoaiTru)
        {
            // Tìm COUNT(*) của các bản ghi có Tk trùng với tenTaiKhoan VÀ Manv KHÁC với mandCanLoaiTru
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE Tk = @Tk AND Manv != @ManvCanLoaiTru";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Tk", tenTaiKhoan),
        new SqlParameter("@ManvCanLoaiTru", mandCanLoaiTru)
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);

            // Nếu COUNT > 0, có một nhân viên khác đang sử dụng Tk này
            return result != null && Convert.ToInt32(result) > 0;
        }
        public static bool KiemTraTonTaiSdtKhac(string sdt, string mandCanLoaiTru)
        {
            // Tìm COUNT(*) các bản ghi có Sdt trùng VÀ Manv KHÁC với ManvCanLoaiTru
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE Sdt = @Sdt AND Manv != @ManvCanLoaiTru";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Sdt", sdt),
        new SqlParameter("@ManvCanLoaiTru", mandCanLoaiTru)
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);

            return result != null && Convert.ToInt32(result) > 0;
        }

        public static bool KiemTraTonTaiEmailKhac(string email, string mandCanLoaiTru)
        {
            // Tìm COUNT(*) các bản ghi có Email trùng VÀ Manv KHÁC với ManvCanLoaiTru
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE Email = @Email AND Manv != @ManvCanLoaiTru";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Email", email),
        new SqlParameter("@ManvCanLoaiTru", mandCanLoaiTru)
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);

            return result != null && Convert.ToInt32(result) > 0;
        }
    }
}
