using System;
using System.Collections.Generic;
using System.Transactions; // <-- Quan trọng!
using System.Linq; // <-- Thêm thư viện này
using DAO;
using DTO;

namespace BUS
{
    public class SuaSanPhamBUS
    {
        private SuaSanPhamDAO suaSanPhamDAO = new SuaSanPhamDAO();

        // --- Logic Tải (Load) ---
        public List<LoaiSPDTO> GetLoaiSP()

        {

            return suaSanPhamDAO.GetLoaiSP();

        }



        public Dictionary<char, int> GetKichCoMap()

        {

            return suaSanPhamDAO.GetKichCoMap();

        }

        // (SỬA LẠI) Hàm GetSanPhamInfo
        public SuaSanPhamLoadDTO GetSanPhamInfo(string maSP)
        {
            if (string.IsNullOrEmpty(maSP))
            {
                throw new Exception("Mã sản phẩm không hợp lệ.");
            }
            // Sửa tên hàm gọi xuống DAO
            return suaSanPhamDAO.GetSanPhamBaseInfo(maSP);
        }

        // --- Logic Lưu (Save) ---

        // (VIẾT LẠI HOÀN TOÀN)
        public void LuuThongTinSanPham(string maSP, string tenSP, int maLoai, int canhBao,
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

            // (Code parse giá S, M, L giữ nguyên)
            decimal giaBanS = 0, giaBanM = 0, giaBanL = 0;
            if (cbS && (!decimal.TryParse(giaS, out giaBanS) || giaBanS <= 0))
                throw new Exception("Giá size S không hợp lệ.");
            if (cbM && (!decimal.TryParse(giaM, out giaBanM) || giaBanM <= 0))
                throw new Exception("Giá size M không hợp lệ.");
            if (cbL && (!decimal.TryParse(giaL, out giaBanL) || giaBanL <= 0))
                throw new Exception("Giá size L không hợp lệ.");

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

                    // A. Cập nhật bảng SANPHAM
                    suaSanPhamDAO.UpdateSanPham(sp); // <-- Giờ 'sp' đã tồn tại

                    // B. Logic Merge (Giữ nguyên)
                    List<KichCoSPDTO> oldSizes = suaSanPhamDAO.GetKichCoSPList(maSP);
                    ProcessSizeMerge(maSP, kichCoMap['S'], cbS, giaBanS, oldSizes, canhBao);
                    ProcessSizeMerge(maSP, kichCoMap['M'], cbM, giaBanM, oldSizes, canhBao);
                    ProcessSizeMerge(maSP, kichCoMap['L'], cbL, giaBanL, oldSizes, canhBao);

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật CSDL: " + ex.Message);
                }
            }
        }


        // (MỚI) Hàm trợ giúp cho logic Merge
        private void ProcessSizeMerge(string maSP, int maKichCo, bool isChecked, decimal newPrice, List<KichCoSPDTO> oldSizes, int canhBao)
        {
            KichCoSPDTO oldSize = oldSizes.FirstOrDefault(s => s.MaKichCo == maKichCo);

            if (isChecked)
            {
                if (oldSize != null)
                {
                    // ĐÃ CÓ -> UPDATE
                    // (SỬA) Truyền 'canhBao'
                    suaSanPhamDAO.UpdateKichCoSP(maSP, maKichCo, newPrice, canhBao);
                }
                else
                {
                    // CHƯA CÓ -> INSERT
                    // (SỬA) Truyền 'canhBao'
                    KichCoSPDTO newDto = CreateKichCoSP(maSP, maKichCo, newPrice, canhBao);
                    suaSanPhamDAO.InsertKichCoSP(newDto);
                }
            }
            else
            {
                if (oldSize != null)
                {
                    // ĐÃ CÓ -> DELETE (Giữ nguyên)
                    suaSanPhamDAO.DeleteSpecificKichCoSP(maSP, maKichCo);
                }
            }
        }


        // (Giữ nguyên) Hàm trợ giúp tạo DTO
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