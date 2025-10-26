using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
namespace BUS
{
    public class ChamCongBUS
    {
        private static ChamCongBUS instance;
        public static ChamCongBUS Instance => instance ??= new ChamCongBUS();

        // Bắt đầu làm việc
        public bool BatDauLam(string mand)
        {
            DateTime gioBatDau = DateTime.Now;
            return ChamCongDAO.Instance.InsertBatDauLam(mand, gioBatDau);
        }

        // Chấm công (kết thúc ca làm)
        public bool ChamCong(string mand)
        {
            DateTime ngay = DateTime.Today;
            DateTime? gioBatDau = ChamCongDAO.Instance.GetGioBatDauChuaChamCong(mand, ngay);
            if (gioBatDau == null) return false;

            DateTime gioKetThuc = DateTime.Now;
            int tongPhut = (int)(gioKetThuc - gioBatDau.Value).TotalMinutes;

            return ChamCongDAO.Instance.UpdateChamCong(mand, ngay, gioKetThuc, tongPhut);
        }

        // Lưu chấm công đầy đủ (nếu không dùng bắt đầu riêng)
        public bool LuuChamCong(string mand, DateTime gioBatDau, DateTime gioKetThuc, int tongPhut)
        {
            return ChamCongDAO.Instance.InsertChamCongFull(mand, gioBatDau, gioKetThuc, tongPhut);
        }

        // Xem tổng giờ làm trong ngày
        public int TinhTongGioLamTrongNgay(string mand, DateTime ngay)
        {
            return ChamCongDAO.Instance.GetTongPhutTrongNgay(mand, ngay);
        }


    }
}
