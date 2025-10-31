using System;
using System.Collections.Generic;
using System.Transactions; // <-- Quan trọng! Phải thêm reference System.Transactions
using DAO;
using DTO;

namespace BUS
{
    public class ThemSanPhamBUS
    {
        private ThemSanPhamDAO themSanPhamDAO = new ThemSanPhamDAO();

        public List<LoaiSPDTO> GetLoaiSP()
        {
            return themSanPhamDAO.GetLoaiSP();
        }

        public Dictionary<char, int> GetKichCoMap()
        {
            return themSanPhamDAO.GetKichCoMap();
        }

        // Hàm logic chính
        public void ThemSanPham(SanPhamDTO sp,
                                bool cbS, string giaS,
                                bool cbM, string giaM,
                                bool cbL, string giaL,
                                Dictionary<char, int> kichCoMap)
        {
            // --- 1. Validation ---
            if (string.IsNullOrWhiteSpace(sp.MaSP) || string.IsNullOrWhiteSpace(sp.TenSP))
                throw new Exception("Mã sản phẩm và Tên sản phẩm không được để trống.");

            if (themSanPhamDAO.CheckMaSPExists(sp.MaSP))
                throw new Exception($"Mã sản phẩm '{sp.MaSP}' đã tồn tại.");

            if (!cbS && !cbM && !cbL)
                throw new Exception("Bạn phải chọn ít nhất một kích cỡ.");

            List<KichCoSPDTO> kichCoList = new List<KichCoSPDTO>();
            decimal giaBan;

            if (cbS)
            {
                if (!decimal.TryParse(giaS, out giaBan) || giaBan <= 0)
                    throw new Exception("Giá size S không hợp lệ.");
                kichCoList.Add(CreateKichCoSP(sp.MaSP, kichCoMap['S'], giaBan));
            }
            if (cbM)
            {
                if (!decimal.TryParse(giaM, out giaBan) || giaBan <= 0)
                    throw new Exception("Giá size M không hợp lệ.");
                kichCoList.Add(CreateKichCoSP(sp.MaSP, kichCoMap['M'], giaBan));
            }
            if (cbL)
            {
                if (!decimal.TryParse(giaL, out giaBan) || giaBan <= 0)
                    throw new Exception("Giá size L không hợp lệ.");
                kichCoList.Add(CreateKichCoSP(sp.MaSP, kichCoMap['L'], giaBan));
            }

            // --- 2. Transaction ---
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    themSanPhamDAO.InsertSanPham(sp); // đã có DuongDanAnh
                    foreach (var kcsp in kichCoList)
                    {
                        themSanPhamDAO.InsertKichCoSP(kcsp);
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm vào CSDL: " + ex.Message);
                }
            }
        }


        // Hàm trợ giúp tạo DTO
        private KichCoSPDTO CreateKichCoSP(string maSP, int maKichCo, decimal giaBan)
        {
            return new KichCoSPDTO
            {
                MaSP = maSP,
                MaKichCo = maKichCo,
                GiaBan = giaBan,
                SoLuongTon = 0,      // Mặc định tồn kho là 0
                CanhBaoTonKho = 10,  // Mặc định cảnh báo là 10
                TrangThaiSP = true   // Mặc định là Đang bán
            };
        }
    }
}