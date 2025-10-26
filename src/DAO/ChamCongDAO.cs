using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ChamCongDAO
    {
        private static ChamCongDAO instance;
        public static ChamCongDAO Instance => instance ??= new ChamCongDAO();

        private DataProvider provider = DataProvider.Instance;

        // Bắt đầu làm việc: chỉ lưu giờ bắt đầu
        public bool InsertBatDauLam(string mand, DateTime gioBatDau)
        {
            string query = @"
                INSERT INTO CHAMCONG (Mand, Ngay, GioBatDau)
                VALUES (@Mand, @Ngay, @GioBatDau)";
            SqlParameter[] parameters = {
                new SqlParameter("@Mand", mand),
                new SqlParameter("@Ngay", gioBatDau.Date),
                new SqlParameter("@GioBatDau", gioBatDau)
            };
            return provider.ExecuteNonQuery(query, parameters) > 0;
        }

        // Chấm công: cập nhật giờ kết thúc và tổng thời gian
        public bool UpdateChamCong(string mand, DateTime ngay, DateTime gioKetThuc, int tongPhut)
        {
            string query = @"
                UPDATE CHAMCONG
                SET GioKetThuc = @GioKetThuc, TongThoiGian = @Tong
                WHERE Mand = @Mand AND Ngay = @Ngay AND GioKetThuc IS NULL";
            SqlParameter[] parameters = {
                new SqlParameter("@Mand", mand),
                new SqlParameter("@Ngay", ngay),
                new SqlParameter("@GioKetThuc", gioKetThuc),
                new SqlParameter("@Tong", tongPhut)
            };
            return provider.ExecuteNonQuery(query, parameters) > 0;
        }

        // Lưu đầy đủ một lượt chấm công (nếu không dùng bắt đầu riêng)
        public bool InsertChamCongFull(string mand, DateTime gioBatDau, DateTime gioKetThuc, int tongPhut)
        {
            string query = @"
                INSERT INTO CHAMCONG (Mand, Ngay, GioBatDau, GioKetThuc, TongThoiGian)
                VALUES (@Mand, @Ngay, @GioBatDau, @GioKetThuc, @TongThoiGian)";
            SqlParameter[] parameters = {
                new SqlParameter("@Mand", mand),
                new SqlParameter("@Ngay", gioBatDau.Date),
                new SqlParameter("@GioBatDau", gioBatDau),
                new SqlParameter("@GioKetThuc", gioKetThuc),
                new SqlParameter("@TongThoiGian", tongPhut)
            };
            return provider.ExecuteNonQuery(query, parameters) > 0;
        }

        // Lấy tổng thời gian làm trong ngày
        public int GetTongPhutTrongNgay(string mand, DateTime ngay)
        {
            string query = @"
                SELECT ISNULL(SUM(TongThoiGian), 0)
                FROM CHAMCONG
                WHERE Mand = @Mand AND Ngay = @Ngay";
            SqlParameter[] parameters = {
                new SqlParameter("@Mand", mand),
                new SqlParameter("@Ngay", ngay)
            };
            object result = provider.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        // Lấy giờ bắt đầu chưa chấm công
        public DateTime? GetGioBatDauChuaChamCong(string mand, DateTime ngay)
        {
            string query = @"
                SELECT TOP 1 GioBatDau
                FROM CHAMCONG
                WHERE Mand = @Mand AND Ngay = @Ngay AND GioKetThuc IS NULL";
            SqlParameter[] parameters = {
                new SqlParameter("@Mand", mand),
                new SqlParameter("@Ngay", ngay)
            };
            object result = provider.ExecuteScalar(query, parameters);
            return result != DBNull.Value ? (DateTime?)result : null;
        }

    }
}
