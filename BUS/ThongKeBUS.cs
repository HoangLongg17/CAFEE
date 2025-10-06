using CF36.DAO;
using CF36.DTO;
using DTO;
using System;
using System.Collections.Generic;

namespace CF36.BUS
{
    public class ThongKeBUS
    {
        private ThongKeDAO thongKeDAO;

        public ThongKeBUS(string connectionString)
        {
            thongKeDAO = new ThongKeDAO(connectionString);
        }

        public List<LoaiSanPhamDTO> GetLoaiSanPham()
        {
            return thongKeDAO.LayLoaiSanPham();
        }

        public List<ThongKeDTO> GetThongKe(DateTime? tuNgay, DateTime? denNgay, string tenLoai)
        {
            return thongKeDAO.LayDoanhThu(tuNgay, denNgay, tenLoai);
        }
    }
}
