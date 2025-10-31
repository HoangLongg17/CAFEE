using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace BUS
{
    public class BanHangBUS
    {
        private BanHangDAO dao = new BanHangDAO();

        // Kiểm tra sản phẩm có phù hợp với loại voucher
        public bool KiemTraSanPhamPhuHopTheoLoai(List<DanhSachSanPhamDTO> danhSach, int maloai)
        {
            return danhSach.Any(sp => !sp.LaSanPhamTang && sp.Maloai == maloai);
        }

        // Tính tổng tiền đơn hàng (không tính sản phẩm tặng)
        public decimal TinhTongTien(List<DanhSachSanPhamDTO> danhSach)
        {
            return danhSach.Where(sp => !sp.LaSanPhamTang)
                           .Sum(sp => sp.GiaBan * sp.SoLuong);
        }

        // Tính tiền sau khi giảm
        public decimal TinhTienSauGiam(decimal tongTien, decimal giamGia)
        {
            return tongTien - giamGia;
        }

        public List<DanhSachSanPhamDTO> LaySanPhamTang(int mavc, int maloaiGoc, string maSanPhamGoc, int soLuongMua, int loaiVC)
        {
            var ds = new List<DanhSachSanPhamDTO>();
            DataTable dt;

            // Truy vấn sản phẩm tặng theo loại voucher
            if (loaiVC == 2)
            {
                // Mua 1 tặng 1 cùng dòng → lấy toàn bộ sản phẩm tặng theo mã
                dt = dao.GetSanPhamTangByVoucher(mavc);
            }
            else
            {
                // Các loại khác → truyền thêm maloai nếu cần
                dt = dao.GetSanPhamTangByVoucher(mavc, maloaiGoc, loaiVC);
            }
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0]; // ✅ chỉ lấy 1 sản phẩm tặng đầu tiên
                string masp = row["MaSP"].ToString().Trim();
                string kichco = row["KichCo"].ToString().Trim();

                var sp = DanhSachSanPhamBUS.Instance.GetSanPhamTheoMaVaKichCo(masp, kichco);
                if (sp != null)
                {
                    sp.IdKcsp = DanhSachSanPhamBUS.Instance.GetIdKcsp(sp.MaSP, sp.KichCo);
                    ds.Add(new DanhSachSanPhamDTO
                    {
                        MaSP = sp.MaSP,
                        TenSP = sp.TenSP,
                        DuongDanAnh = sp.DuongDanAnh,
                        KichCo = sp.KichCo,
                        GiaBan = 0,
                        SoLuong = 1,
                        LaSanPhamTang = true,
                        MaSanPhamGoc = maSanPhamGoc,
                        Maloai = sp.Maloai,
                        TenLoai = sp.TenLoai,
                        TrangThaiText = sp.TrangThaiText,
                        SoLuongTon = sp.SoLuongTon,
                        IdKcsp = sp.IdKcsp
                    });
                }
            }

            return ds;
        }


        // Chuyển đổi từ DanhSachSanPhamDTO sang BanHangDTO
        public List<BanHangDTO> ChuyenDoiDanhSachBanHang(List<DanhSachSanPhamDTO> danhSach)
        {
            return danhSach.Select(sp => new BanHangDTO
            {
                IdKcsp = sp.IdKcsp,
                MaSP = sp.MaSP,
                TenSP = sp.TenSP,
                KichCo = sp.KichCo,
                SoLuong = sp.LaSanPhamTang ? 1 : sp.SoLuong,
                GiaBan = sp.GiaBan,
                LaSanPhamTang = sp.LaSanPhamTang,
                Maloai = sp.Maloai,
                MaSanPhamGoc = sp.MaSanPhamGoc,
                SoLuongTon = sp.SoLuongTon,
                DuongDanAnh = sp.DuongDanAnh,
                TenLoai = sp.TenLoai,
                TrangThaiText = sp.TrangThaiText
            }).ToList();
        }

        public KetQuaGiamGiaDTO ApDungMaGiamGia(string code, List<DanhSachSanPhamDTO> danhSachDaChon)
        {
            var result = new KetQuaGiamGiaDTO { SanPhamTang = new List<BanHangDTO>() };

            // 1. Lấy thông tin mã giảm giá
            var voucher = VoucherBUS.Instance.GetAllVouchersWithJoin()
                .AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("code") == code);

            if (voucher == null)
            {
                result.Loi = "Không tìm thấy mã giảm giá.";
                return result;
            }

            int loaiVC = voucher.Field<int>("maloaivc");
            decimal? dieuKien = voucher["DieuKien"] != DBNull.Value ? Convert.ToDecimal(voucher["DieuKien"]) : (decimal?)null;
            decimal giatri = voucher.Field<decimal>("giatri");
            int mavc = voucher.Field<int>("mavc");
            int? maloai = voucher.Field<int?>("maloai");

            // 2. Kiểm tra sản phẩm mua có phù hợp
            var danhSachMua = danhSachDaChon.Where(sp => !sp.LaSanPhamTang).ToList();
            if (maloai.HasValue)
            {
                if (!KiemTraSanPhamPhuHopTheoLoai(danhSachMua, maloai.Value))
                {
                    result.Loi = "Mã giảm giá này không áp dụng cho dòng sản phẩm bạn đã chọn.";
                    return result;
                }
            }

            // 3. Tính tổng tiền
            decimal tongTien = TinhTongTien(danhSachMua);
            result.TongTien = tongTien;

            if (tongTien < dieuKien)
            {
                result.Loi = "Đơn hàng chưa đạt điều kiện tối thiểu để áp dụng mã giảm giá.";
                return result;
            }

            // 4. Áp dụng theo loại mã
            switch (loaiVC)
            {
                case 1: // Giảm theo %
                    result.TienGiam = tongTien * giatri / 100;
                    break;

                case 3: // Giảm theo số tiền
                    result.TienGiam = giatri;
                    break;

                case 2: // Mua 1 tặng 1 cùng dòng
                case 4: // Mua 1 tặng 1 bất kỳ
                    var dsTang = LaySanPhamTang(mavc, maloai ?? 0, "", 1, loaiVC);
                    foreach (var spTang in dsTang)
                    {
                        result.SanPhamTang.Add(new BanHangDTO
                        {
                            MaSP = spTang.MaSP,
                            TenSP = spTang.TenSP,
                            KichCo = spTang.KichCo,
                            GiaBan = 0,
                            SoLuong = 1, // ✅ luôn tặng 1 sản phẩm
                            LaSanPhamTang = true,
                            IdKcsp = spTang.IdKcsp,
                            Maloai = spTang.Maloai,
                            MaSanPhamGoc = spTang.MaSanPhamGoc,
                            TenLoai = spTang.TenLoai,
                            DuongDanAnh = spTang.DuongDanAnh,
                            TrangThaiText = spTang.TrangThaiText,
                            SoLuongTon = spTang.SoLuongTon
                        });
                    }
                    break;
            }

            // 5. Gán thông tin mã
            result.LoaiVC = loaiVC;
            result.GiaTri = giatri;

            return result;
        }

        // Ghi hóa đơn, chi tiết, trừ tồn kho, áp mã giảm giá
        // 1. Thêm 'decimal tongTienSauGiam' vào tham số
        public int XuatHoaDon(int? makh, string mand, List<BanHangDTO> danhSachSanPham, int? maVoucher, decimal tongTienSauGiam)
        {
            // 2. (BỎ) Không tự tính tổng tiền ở đây nữa
            // decimal tongTien = danhSachSanPham...

            // 3. (SỬA) Dùng tongTienSauGiam để tạo hóa đơn
            // (Giả sử dao.TaoHoaDon nhận 3 tham số và trả về MaHD)
            int mahd = dao.TaoHoaDon(makh, mand, tongTienSauGiam);

            // 4. Gộp các sản phẩm lại (nếu mua trùng)
            var danhSachGop = danhSachSanPham
                .GroupBy(sp => sp.IdKcsp)
                .Select(g => new BanHangDTO
                {
                    IdKcsp = g.Key,
                    MaSP = g.First().MaSP,
                    TenSP = g.First().TenSP,
                    KichCo = g.First().KichCo,
                    SoLuong = g.Sum(x => x.SoLuong),
                    GiaBan = g.First().GiaBan,
                    LaSanPhamTang = g.First().LaSanPhamTang,
                    // ... (copy các thuộc tính khác nếu cần)
                })
                .ToList();

            // 5. Thêm chi tiết và áp voucher
            foreach (var sp in danhSachGop)
            {
                // Chỉ thêm chi tiết cho món không phải hàng tặng
                if (!sp.LaSanPhamTang)
                {
                    dao.ThemChiTietHoaDon(mahd, sp);
                }
            }

            if (maVoucher.HasValue)
            {
                dao.ApDungVoucher(maVoucher.Value, mahd);
            }

            return mahd;
        }
        // Xuất hóa đơn ra file PDF
        public void XuatHoaDonPDF(HoaDonDTO hoaDon, List<DanhSachSanPhamDTO> danhSachSP, string filePath)
        {
            Document doc = new Document(PageSize.A4, 40, 40, 60, 50);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // ✅ Nhúng font Unicode tiếng Việt
            string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Fonts\times.ttf");
            fontPath = Path.GetFullPath(fontPath);
            if (!File.Exists(fontPath))
            {
                MessageBox.Show("Không tìm thấy file font tại: " + fontPath);
                return;
            }

            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            var fontTitle = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
            var fontHeader = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
            var fontNormal = new iTextSharp.text.Font(baseFont, 11, iTextSharp.text.Font.NORMAL);

            // Tiêu đề
            Paragraph title = new Paragraph("HÓA ĐƠN BÁN HÀNG", fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20
            };
            doc.Add(title);

            // Thông tin cửa hàng và hóa đơn
            doc.Add(new Paragraph("CỬA HÀNG CÀ PHÊ CF36", fontHeader));
            doc.Add(new Paragraph("Địa chỉ: TỊNH THẤT BỒNG LAI", fontNormal));
            doc.Add(new Paragraph("Điện thoại: 0999 999 999", fontNormal));
            doc.Add(new Paragraph("Ngày lập: " + hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm:ss"), fontNormal));
            doc.Add(new Paragraph("Mã hóa đơn: " + hoaDon.MaHD, fontNormal));
            doc.Add(new Paragraph("Nhân viên lập: " + hoaDon.TenNhanVien, fontNormal));
            doc.Add(new Paragraph("Khách hàng: " + hoaDon.TenKH, fontNormal));
            doc.Add(new Paragraph("Số điện thoại: " + hoaDon.SDTKH, fontNormal));
            doc.Add(new Paragraph(" "));

            // Bảng sản phẩm chính
            PdfPTable table = new PdfPTable(5)
            {
                WidthPercentage = 100
            };
            table.SetWidths(new float[] { 3, 1.2f, 1.5f, 1.2f, 1.5f });

            string[] headers = { "Tên sản phẩm", "Size", "Đơn giá", "Số lượng", "Thành tiền" };
            foreach (var h in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(h, fontHeader))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 5
                };
                table.AddCell(cell);
            }

            foreach (var sp in danhSachSP.Where(sp => !sp.LaSanPhamTang))
            {
                table.AddCell(new Phrase(sp.TenSP, fontNormal));
                table.AddCell(new Phrase(sp.KichCo, fontNormal));
                table.AddCell(new Phrase(sp.GiaBan.ToString("N0") + " đ", fontNormal));
                table.AddCell(new Phrase(sp.SoLuong.ToString(), fontNormal));
                table.AddCell(new Phrase((sp.GiaBan * sp.SoLuong).ToString("N0") + " đ", fontNormal));
            }

            doc.Add(table);
            doc.Add(new Paragraph(" "));

            // ✅ Thông tin giảm giá
            doc.Add(new Paragraph("Tổng tiền gốc: " + hoaDon.TongTienGoc.ToString("N0") + " đ", fontNormal));

            if (!string.IsNullOrEmpty(hoaDon.MaVoucher))
            {
                doc.Add(new Paragraph("Mã giảm giá: " + hoaDon.MaVoucher, fontNormal));
                if (hoaDon.PhanTramGiam.HasValue)
                {
                    doc.Add(new Paragraph("Hình thức: Giảm " + hoaDon.PhanTramGiam.Value + "%", fontNormal));
                }
                doc.Add(new Paragraph("Tiền giảm: " + hoaDon.TienGiam.ToString("N0") + " đ", fontNormal));
            }

            // ✅ Thành tiền sau giảm
            Paragraph thanhTien = new Paragraph($"Thành tiền: {hoaDon.TongTien.ToString("N0")} đ", fontHeader)
            {
                Alignment = Element.ALIGN_RIGHT,
                SpacingBefore = 10,
                SpacingAfter = 20
            };
            doc.Add(thanhTien);

            // ✅ Sản phẩm tặng nếu có
            if (hoaDon.SanPhamTang != null && hoaDon.SanPhamTang.Count > 0)
            {
                doc.Add(new Paragraph("🎁 Sản phẩm tặng theo mã voucher:", fontHeader));

                PdfPTable tableTang = new PdfPTable(3)
                {
                    WidthPercentage = 100
                };
                tableTang.SetWidths(new float[] { 3, 1.2f, 1.2f });

                tableTang.AddCell(new Phrase("Tên sản phẩm", fontHeader));
                tableTang.AddCell(new Phrase("Size", fontHeader));
                tableTang.AddCell(new Phrase("Số lượng", fontHeader));

                foreach (var sp in hoaDon.SanPhamTang)
                {
                    tableTang.AddCell(new Phrase(sp.TenSP, fontNormal));
                    tableTang.AddCell(new Phrase(sp.KichCo, fontNormal));
                    tableTang.AddCell(new Phrase(sp.SoLuong.ToString(), fontNormal));
                }

                doc.Add(tableTang);
                doc.Add(new Paragraph(" "));
            }

            // Ghi chú và ký tên
            doc.Add(new Paragraph("Ghi chú: Quý khách vui lòng kiểm tra kỹ sản phẩm trước khi rời khỏi cửa hàng.", fontNormal));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Người lập hóa đơn", fontNormal));
            doc.Add(new Paragraph(" ", fontNormal));
            doc.Add(new Paragraph("(Ký và ghi rõ họ tên)", fontNormal));

            doc.Close();
        }
        public static void CapNhatTonKhoSauThanhToan(List<DanhSachSanPhamDTO> danhSachDaBan)
        {
            foreach (var sp in danhSachDaBan)
            {
                int tonKhoHienTai = DanhSachSanPhamDAO.GetSoLuongTon(sp.IdKcsp);

                if (tonKhoHienTai >= sp.SoLuong)
                {
                    DanhSachSanPhamDAO.CapNhatSoLuongTon(sp.IdKcsp, -sp.SoLuong);

                    int tonMoi = tonKhoHienTai - sp.SoLuong;
                    if (tonMoi <= 0)
                    {
                        DanhSachSanPhamDAO.KhoaSanPham(sp.IdKcsp);
                    }
                }
                else
                {
                    MessageBox.Show(
                        $"❌ Không đủ tồn kho cho sản phẩm: {sp.TenSP} - Size {sp.KichCo}\n" +
                        $"Tồn kho hiện tại: {tonKhoHienTai}, cần: {sp.SoLuong}",
                        "Thiếu hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                }
            }
        }
    }
}
