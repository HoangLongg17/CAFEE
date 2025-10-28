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
        public void LuuThongTinSanPham(string maSP, string tenSP, int maLoai,
                                      bool cbS, string giaS,
                                      bool cbM, string giaM,
                                      bool cbL, string giaL,
                                      Dictionary<char, int> kichCoMap)
        {
            // --- 1. Validation ---
            if (string.IsNullOrWhiteSpace(tenSP))
            {
                throw new Exception("Tên sản phẩm không được để trống.");
            }

            if (!cbS && !cbM && !cbL)
            {
                throw new Exception("Phải chọn ít nhất một kích cỡ (size).");
            }

            // Parse giá tiền trước khi vào transaction
            decimal giaBanS = 0, giaBanM = 0, giaBanL = 0;
            if (cbS && (!decimal.TryParse(giaS, out giaBanS) || giaBanS <= 0))
                throw new Exception("Giá size S không hợp lệ.");
            if (cbM && (!decimal.TryParse(giaM, out giaBanM) || giaBanM <= 0))
                throw new Exception("Giá size M không hợp lệ.");
            if (cbL && (!decimal.TryParse(giaL, out giaBanL) || giaBanL <= 0))
                throw new Exception("Giá size L không hợp lệ.");


            // --- 2. Xử lý Transaction (Giao dịch) ---
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    // A. Cập nhật bảng SANPHAM
                    suaSanPhamDAO.UpdateSanPham(new SanPhamDTO { MaSP = maSP, TenSP = tenSP, MaLoai = maLoai });

                    // B. Lấy danh sách size hiện tại từ DB
                    List<KichCoSPDTO> oldSizes = suaSanPhamDAO.GetKichCoSPList(maSP);

                    // C. Xử lý logic Merge cho từng size
                    ProcessSizeMerge(maSP, kichCoMap['S'], cbS, giaBanS, oldSizes);
                    ProcessSizeMerge(maSP, kichCoMap['M'], cbM, giaBanM, oldSizes);
                    ProcessSizeMerge(maSP, kichCoMap['L'], cbL, giaBanL, oldSizes);

                    // Nếu tất cả thành công, commit
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    // Nếu lỗi, transaction tự động rollback
                    throw new Exception("Lỗi khi cập nhật CSDL: " + ex.Message);
                }
            }
        }

        // (MỚI) Hàm trợ giúp cho logic Merge
        private void ProcessSizeMerge(string maSP, int maKichCo, bool isChecked, decimal newPrice, List<KichCoSPDTO> oldSizes)
        {
            // Tìm xem size này có trong DB từ trước không
            KichCoSPDTO oldSize = oldSizes.FirstOrDefault(s => s.MaKichCo == maKichCo);

            if (isChecked)
            {
                // Người dùng MUỐN có size này
                if (oldSize != null)
                {
                    // ĐÃ CÓ -> UPDATE
                    // (Chỉ update nếu giá khác, cho tối ưu)
                    if (oldSize.GiaBan != newPrice)
                    {
                        suaSanPhamDAO.UpdateKichCoSP(maSP, maKichCo, newPrice);
                    }
                }
                else
                {
                    // CHƯA CÓ -> INSERT
                    // Dùng lại helper cũ, nó sẽ set Tồn kho = 0
                    KichCoSPDTO newDto = CreateKichCoSP(maSP, maKichCo, newPrice);
                    suaSanPhamDAO.InsertKichCoSP(newDto);
                }
            }
            else
            {
                // Người dùng KHÔNG MUỐN có size này
                if (oldSize != null)
                {
                    // ĐÃ CÓ -> DELETE
                    suaSanPhamDAO.DeleteSpecificKichCoSP(maSP, maKichCo);
                }
                // else: CHƯA CÓ -> Không làm gì cả (đúng)
            }
        }


        // (Giữ nguyên) Hàm trợ giúp tạo DTO
        private KichCoSPDTO CreateKichCoSP(string maSP, int maKichCo, decimal giaBan)
        {
            return new KichCoSPDTO
            {
                MaSP = maSP,
                MaKichCo = maKichCo,
                GiaBan = giaBan,
                SoLuongTon = 0,      // Mặc định về 0 khi thêm MỚI
                CanhBaoTonKho = 10,
                TrangThaiSP = true
            };
        }
    }
}