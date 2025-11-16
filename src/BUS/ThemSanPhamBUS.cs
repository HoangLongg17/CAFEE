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
        public void ThemSanPham(string maSP, string tenSP, int maLoai, int canhBao,
                        bool cbS, string giaS,
                        bool cbM, string giaM,
                        bool cbL, string giaL,
                        Dictionary<char, int> kichCoMap)
        {
            // --- 1. Validation ---

            // (SỬA LẠI) Dùng 'tenSP' (biến string) thay vì 'sp.TenSP'
            if (string.IsNullOrWhiteSpace(tenSP))
            {
                throw new Exception("Tên sản phẩm không được để trống.");
            }

            if (!cbS && !cbM && !cbL)
            {
                throw new Exception("Phải chọn ít nhất một kích cỡ (size).");
            }

            List<KichCoSPDTO> kichCoList = new List<KichCoSPDTO>();
            decimal giaBan;

            // --- 2. Xử lý giá tiền ---
            if (cbS)
            {
                if (!decimal.TryParse(giaS, out giaBan) || giaBan <= 0)
                    throw new Exception("Giá size S không hợp lệ.");
                kichCoList.Add(CreateKichCoSP(maSP, kichCoMap['S'], giaBan, canhBao));
            }
            if (cbM)
            {
                if (!decimal.TryParse(giaM, out giaBan) || giaBan <= 0)
                    throw new Exception("Giá size M không hợp lệ.");
                kichCoList.Add(CreateKichCoSP(maSP, kichCoMap['M'], giaBan, canhBao));
            }
            if (cbL)
            {
                if (!decimal.TryParse(giaL, out giaBan) || giaBan <= 0)
                    throw new Exception("Giá size L không hợp lệ.");
                kichCoList.Add(CreateKichCoSP(maSP, kichCoMap['L'], giaBan, canhBao));
            }

            // --- 3. Xử lý Transaction ---
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // (SỬA LẠI) Tạo đối tượng 'sp' (SanPhamDTO) ở đây
                    SanPhamDTO sp = new SanPhamDTO
                    {
                        MaSP = maSP,
                        TenSP = tenSP,
                        MaLoai = maLoai
                    };

                    // A. Insert vào bảng SANPHAM
                    themSanPhamDAO.InsertSanPham(sp); // <-- Giờ 'sp' đã tồn tại

                    // B. Insert vào bảng KICHCOSP
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
        private KichCoSPDTO CreateKichCoSP(string maSP, int maKichCo, decimal giaBan, int canhBao)
        {
            return new KichCoSPDTO
            {
                MaSP = maSP,
                MaKichCo = maKichCo,
                GiaBan = giaBan,
                SoLuongTon = 0,
                CanhBaoTonKho = canhBao, // <-- (SỬA) Dùng giá trị mới
                TrangThaiSP = true
            };
        }
    }
}