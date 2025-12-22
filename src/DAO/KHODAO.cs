using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DTO;

namespace DAO
{
    public class KhoDAO
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["QUANLICHTL"].ConnectionString;

        // --- PHẦN 1: TỒN KHO ---
        public static List<SanPhamTonKhoDTO> LayDanhSachTonKho()
        {
            var list = new List<SanPhamTonKhoDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_LayDanhSachTonKho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new SanPhamTonKhoDTO
                            {
                                MaSP = Convert.ToInt32(r["Masp"]),
                                TenSP = r["Tensp"].ToString(),
                                SoLuongTon = Convert.ToInt32(r["Soluongton"]),
                                CanhBaoTon = Convert.ToInt32(r["Canhbaotonkho"]),
                                GiaBan = Convert.ToDecimal(r["Giaban"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static List<SanPhamTonKhoDTO> TimKiemTonKho(string keyword)
        {
            var list = new List<SanPhamTonKhoDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_TimKiemTonKho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuKhoa", keyword);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new SanPhamTonKhoDTO
                            {
                                MaSP = Convert.ToInt32(r["Masp"]),
                                TenSP = r["Tensp"].ToString(),
                                SoLuongTon = Convert.ToInt32(r["Soluongton"]),
                                CanhBaoTon = Convert.ToInt32(r["Canhbaotonkho"]),
                                GiaBan = Convert.ToDecimal(r["Giaban"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static DataTable LayNhaCungCap()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_LayNhaCungCap", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // --- PHẦN 2: NHẬP KHO (TRANSACTION) ---
        public static bool NhapKho(int maNCC, string maNV, List<CartItemDTO> listnhapkho)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    int maNK = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_TaoPhieuNhap", conn, trans))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Manhacc", maNCC);
                        cmd.Parameters.AddWithValue("@Manv", maNV);

                        SqlParameter outParam = new SqlParameter("@Mank", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);

                        cmd.ExecuteNonQuery();
                        maNK = (int)outParam.Value;
                    }

                    // 2. Thêm chi tiết (Gọi SP cho từng món)
                    foreach (var item in listnhapkho)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_ThemChiTietNhap", conn, trans))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Mank", maNK);
                            cmd.Parameters.AddWithValue("@Masp", item.MaSP);
                            cmd.Parameters.AddWithValue("@Soluong", item.SoLuong);
                            cmd.Parameters.AddWithValue("@Gianhap", item.DonGia);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw; // Ném lỗi về BUS xử lý
                }
            }
        }

        // --- PHẦN 3: XUẤT KHO (TRANSACTION) ---
        public static bool XuatKho(string maNV, string lyDo, List<CartItemDTO> listxuatkho)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Tạo phiếu xuất
                    int maXK = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_TaoPhieuXuat", conn, trans))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Manv", maNV);
                        cmd.Parameters.AddWithValue("@LyDo", lyDo ?? (object)DBNull.Value);

                        SqlParameter outParam = new SqlParameter("@MaXK", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);

                        cmd.ExecuteNonQuery();
                        maXK = (int)outParam.Value;
                    }

                    // 2. Thêm chi tiết xuất
                    foreach (var item in listxuatkho)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_ThemChiTietXuat", conn, trans))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaXK", maXK);
                            cmd.Parameters.AddWithValue("@Masp", item.MaSP);
                            cmd.Parameters.AddWithValue("@Soluong", item.SoLuong);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // --- PHẦN 4: LỊCH SỬ ---
        public static List<PhieuNhapDTO> LayLichSuNhap(DateTime? tuNgay, DateTime? denNgay, string tuKhoa)
        {
            var list = new List<PhieuNhapDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_LayLichSuNhapKho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TuKhoa", string.IsNullOrEmpty(tuKhoa) ? (object)DBNull.Value : tuKhoa);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new PhieuNhapDTO
                            {
                                MaNK = Convert.ToInt32(r["Mank"]),
                                NgayNhap = Convert.ToDateTime(r["Ngaynhap"]),
                                TenNCC = r["Tennhacc"].ToString(),
                                TenNhanVien = r["TenNhanVien"].ToString(),
                                TongTien = Convert.ToDecimal(r["Tongtien"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static List<ChiTietKhoDTO> LayChiTietPhieuNhap(int maNK)
        {
            var list = new List<ChiTietKhoDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_LayChiTietPhieuNhap", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Mank", maNK);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new ChiTietKhoDTO
                            {
                                MaPhieu = Convert.ToInt32(r["Mank"]),
                                MaSP = Convert.ToInt32(r["Masp"]),
                                TenSP = r["Tensp"].ToString(),
                                SoLuong = Convert.ToInt32(r["Soluongnhap"]),
                                DonGia = Convert.ToDecimal(r["Gianhap"]),
                                TenNhanVien = r["TenNhanVien"].ToString()

                            });
                        }
                    }
                }
            }
            return list;
        }
        public static List<PhieuXuatDTO> LayLichSuXuat(DateTime? tuNgay, DateTime? denNgay, string tuKhoa)
        {
            var list = new List<PhieuXuatDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_LayLichSuXuatKho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TuKhoa", string.IsNullOrEmpty(tuKhoa) ? (object)DBNull.Value : tuKhoa);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new PhieuXuatDTO
                            {
                                MaXK = Convert.ToInt32(r["MaXK"]),
                                NgayXuat = Convert.ToDateTime(r["NgayXuat"]),
                                TenNhanVien = r["TenNhanVien"].ToString(),
                                LyDo = r["LyDoxuat"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static List<ChiTietKhoDTO> LayChiTietPhieuXuat(int maXK)
        {
            var list = new List<ChiTietKhoDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_LayChiTietPhieuXuat", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaXK", maXK);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new ChiTietKhoDTO
                            {
                                MaPhieu = Convert.ToInt32(r["MaXK"]),
                                MaSP = Convert.ToInt32(r["Masp"]),
                                TenSP = r["Tensp"].ToString(),
                                SoLuong = Convert.ToInt32(r["SoLuongXuat"]),
                                DonGia = 0, // Xuất kho không lưu giá trong chi tiết
                                TenNhanVien = "" // Không dùng
                            });
                        }
                    }
                }
            }
            return list;
        }




    }
}