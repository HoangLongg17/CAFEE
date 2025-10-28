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
        public void ThemSanPham(string maSP, string tenSP, int maLoai,
                                bool cbS, string giaS,
                                bool cbM, string giaM,
                                bool cbL, string giaL,
                                Dictionary<char, int> kichCoMap)
        {
            // --- 1. Validation (Kiểm tra dữ liệu) ---
            if (string.IsNullOrWhiteSpace(maSP) || string.IsNullOrWhiteSpace(tenSP))
            {
                throw new Exception("Mã sản phẩm và Tên sản phẩm không được để trống.");
            }

            if (themSanPhamDAO.CheckMaSPExists(maSP))
            {
                throw new Exception($"Mã sản phẩm '{maSP}' đã tồn tại.");
            }

            if (!cbS && !cbM && !cbL)
            {
                throw new Exception("Bạn phải chọn ít nhất một kích cỡ (size).");
            }

            List<KichCoSPDTO> kichCoList = new List<KichCoSPDTO>();
            decimal giaBan;

            // --- 2. Xử lý giá tiền và tạo danh sách size ---
            if (cbS)
            {
                if (!decimal.TryParse(giaS, out giaBan) || giaBan <= 0)
                    throw new Exception("Giá size S không hợp lệ.");
                kichCoList.Add(CreateKichCoSP(maSP, kichCoMap['S'], giaBan));
            }
            if (cbM)
            {
                if (!decimal.TryParse(giaM, out giaBan) || giaBan <= 0)
                    throw new Exception("Giá size M không hợp lệ.");
                kichCoList.Add(CreateKichCoSP(maSP, kichCoMap['M'], giaBan));
            }
            if (cbL)
            {
                if (!decimal.TryParse(giaL, out giaBan) || giaBan <= 0)
                    throw new Exception("Giá size L không hợp lệ.");
                kichCoList.Add(CreateKichCoSP(maSP, kichCoMap['L'], giaBan));
            }

            // --- 3. Xử lý Transaction (Giao dịch) ---
            // Đảm bảo cả 2 bảng được insert, hoặc không gì cả
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // A. Insert vào bảng SANPHAM
                    SanPhamDTO sp = new SanPhamDTO { MaSP = maSP, TenSP = tenSP, MaLoai = maLoai };
                    themSanPhamDAO.InsertSanPham(sp);

                    // B. Insert vào bảng KICHCOSP (từng size)
                    foreach (var kcsp in kichCoList)
                    {
                        themSanPhamDAO.InsertKichCoSP(kcsp);
                    }

                    // Nếu tất cả thành công, commit transaction
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    // Nếu 1 trong 2 cái insert lỗi, Transaction sẽ tự động Rollback
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