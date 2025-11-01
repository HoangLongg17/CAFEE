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
using Microsoft.Data.SqlClient;
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
            if (loaiVC != 2 && loaiVC != 4)
                return ds;

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
        public List<BanHangDTO> ChuyenDoiDanhSachBanHang(List<DanhSachSanPhamDTO> danhSach, KetQuaGiamGiaDTO ketQua)
        {
            var danhSachChuyenDoi = new List<BanHangDTO>();

            foreach (var sp in danhSach)
            {
                var dto = new BanHangDTO
                {
                    IdKcsp = sp.IdKcsp,
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    KichCo = sp.KichCo,
                    SoLuong = sp.LaSanPhamTang ? 1 : sp.SoLuong,
                    GiaGoc = sp.GiaGoc,               // ✅ Giữ nguyên giá gốc đã cập nhật
                    GiaBan = sp.GiaBan,               // ✅ Giữ nguyên giá sau giảm
                    TienGiam = sp.TienGiam,           // ✅ Giữ nguyên tiền giảm
                    LaSanPhamTang = sp.LaSanPhamTang,
                    Maloai = sp.Maloai,
                    MaSanPhamGoc = sp.MaSanPhamGoc,
                    SoLuongTon = sp.SoLuongTon,
                    DuongDanAnh = sp.DuongDanAnh,
                    TenLoai = sp.TenLoai,
                    TrangThaiText = sp.TrangThaiText
                };

                danhSachChuyenDoi.Add(dto);
            }

            return danhSachChuyenDoi;
        }
        public KetQuaGiamGiaDTO ApDungMaGiamGia(string code, List<DanhSachSanPhamDTO> danhSachDaChon)
        {
            var result = new KetQuaGiamGiaDTO
            {
                SanPhamTang = new List<BanHangDTO>(),
                SanPhamDuocGiam = new List<DanhSachSanPhamDTO>()
            };

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

            // 2. Lọc sản phẩm mua
            var danhSachMua = danhSachDaChon.Where(sp => !sp.LaSanPhamTang).ToList();

            // 3. Kiểm tra sản phẩm phù hợp
            bool coSanPhamPhuHop = false;
            var sanPhamDuocGiam = new List<DanhSachSanPhamDTO>();

            if (maloai.HasValue)
            {
                coSanPhamPhuHop = KiemTraSanPhamPhuHopTheoLoai(danhSachMua, maloai.Value);
                if (coSanPhamPhuHop)
                {
                    sanPhamDuocGiam = danhSachMua.Where(sp => sp.Maloai == maloai.Value).ToList();
                }
            }
            else
            {
                foreach (var sp in danhSachMua)
                {
                    if (VoucherBUS.Instance.CheckChiTietVoucher(mavc, sp.IdKcsp))
                    {
                        coSanPhamPhuHop = true;
                        sanPhamDuocGiam.Add(sp);
                    }
                }
            }

            if (!coSanPhamPhuHop)
            {
                result.Loi = "Mã giảm giá này không áp dụng cho sản phẩm bạn đã chọn.";
                return result;
            }

            // 4. Kiểm tra điều kiện đơn hàng
            decimal tongTien = TinhTongTien(danhSachMua);
            result.TongTien = tongTien;

            if (tongTien < dieuKien)
            {
                result.Loi = "Đơn hàng chưa đạt điều kiện tối thiểu để áp dụng mã giảm giá.";
                return result;
            }

            // 5. Áp dụng mã theo loại
            switch (loaiVC)
            {
                case 1: // Giảm theo %
                    result.TienGiam = tongTien * giatri / 100;
                    result.SanPhamDuocGiam = sanPhamDuocGiam;
                    break;

                case 3: // Giảm theo số tiền
                    result.TienGiam = giatri;

                    if (sanPhamDuocGiam.Count > 0)
                    {
                        var sp = sanPhamDuocGiam.First();
                        sp.TienGiam = giatri;   // ✅ gán giảm trực tiếp vào sản phẩm
                        result.SanPhamDuocGiam = new List<DanhSachSanPhamDTO> { sp };
                    }
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
                            SoLuong = 1,
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

            // 6. Gán thông tin mã
            result.LoaiVC = loaiVC;
            result.GiaTri = giatri;

            return result;
        }

        // Ghi hóa đơn, chi tiết, trừ tồn kho, áp mã giảm giá
        public int XuatHoaDon(int? makh, string mand, List<BanHangDTO> danhSachSanPham, int? maVoucher = null)
        {
            decimal tongTienGoc = danhSachSanPham.Where(sp => !sp.LaSanPhamTang)
                .Sum(sp => sp.GiaGoc * sp.SoLuong);

            decimal tongTienSauGiam = danhSachSanPham.Where(sp => !sp.LaSanPhamTang)
                .Sum(sp => (sp.GiaGoc - sp.TienGiam) * sp.SoLuong);

            decimal tienGiam = tongTienGoc - tongTienSauGiam;

            int mahd = dao.TaoHoaDon(makh, mand, tongTienGoc, tienGiam, tongTienSauGiam);

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
                    Maloai = g.First().Maloai,
                    MaSanPhamGoc = g.First().MaSanPhamGoc,
                    SoLuongTon = g.First().SoLuongTon,
                    DuongDanAnh = g.First().DuongDanAnh,
                    TenLoai = g.First().TenLoai,
                    TrangThaiText = g.First().TrangThaiText
                })
                .ToList();

            foreach (var sp in danhSachGop)
            {
                dao.ThemChiTietHoaDon(mahd, sp);
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

            // Font tiếng Việt
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
            doc.Add(new Paragraph("HÓA ĐƠN BÁN HÀNG", fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20
            });

            // Thông tin hóa đơn
            doc.Add(new Paragraph("CỬA HÀNG CÀ PHÊ CF36", fontHeader));
            doc.Add(new Paragraph("Địa chỉ: TỊNH THẤT BỒNG LAI", fontNormal));
            doc.Add(new Paragraph("Điện thoại: 0999 999 999", fontNormal));
            doc.Add(new Paragraph("Ngày lập: " + hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm:ss"), fontNormal));
            doc.Add(new Paragraph("Mã hóa đơn: " + hoaDon.MaHD, fontNormal));
            doc.Add(new Paragraph("Nhân viên lập: " + hoaDon.TenNhanVien, fontNormal));
            doc.Add(new Paragraph("Khách hàng: " + hoaDon.TenKH, fontNormal));
            doc.Add(new Paragraph("Số điện thoại: " + hoaDon.SDTKH, fontNormal));
            doc.Add(new Paragraph(" "));

            // Bảng sản phẩm mua
            PdfPTable table = new PdfPTable(7) { WidthPercentage = 100 };
            table.SetWidths(new float[] { 3, 1.2f, 1.5f, 1.2f, 1.5f, 1.5f, 2 });

            string[] headers = { "Tên sản phẩm", "Size", "Giá gốc", "Số lượng", "Giá sau giảm", "Thành tiền", "Ghi chú" };
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
                table.AddCell(new Phrase(sp.TenSP, fontNormal));                        // 1. Tên sản phẩm
                table.AddCell(new Phrase(sp.KichCo, fontNormal));                       // 2. Size
                                                                                        // Đơn giá gốc
                table.AddCell(new Phrase(sp.GiaGoc.ToString("N0") + " đ", fontNormal));

                // Số lượng
                table.AddCell(new Phrase(sp.SoLuong.ToString(), fontNormal));

                // Giá sau giảm (nếu có)
                decimal giaSauGiam = sp.GiaGoc - sp.TienGiam;
                table.AddCell(new Phrase(giaSauGiam.ToString("N0") + " đ", fontNormal));

                // Thành tiền
                decimal thanhTien = giaSauGiam * sp.SoLuong;
                table.AddCell(new Phrase(thanhTien.ToString("N0") + " đ", fontNormal));

                // Ghi chú
                string ghiChu = sp.TienGiam > 0
                    ? $"Áp dụng mã {hoaDon.MaVoucher} (-{sp.TienGiam:N0} đ)"
                    : "";
                table.AddCell(new Phrase(ghiChu, fontNormal));

            }
            doc.Add(table);
            doc.Add(new Paragraph(" "));

            // Thông tin giảm giá
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

            // Thành tiền sau giảm
            doc.Add(new Paragraph($"Thành tiền: {hoaDon.TongTien.ToString("N0")} đ", fontHeader)
            {
                Alignment = Element.ALIGN_RIGHT,
                SpacingBefore = 10,
                SpacingAfter = 20
            });

            // Sản phẩm tặng
            if (hoaDon.SanPhamTang != null && hoaDon.SanPhamTang.Count > 0)
            {
                doc.Add(new Paragraph("🎁 Sản phẩm tặng theo mã voucher:", fontHeader));

                PdfPTable tableTang = new PdfPTable(3) { WidthPercentage = 100 };
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
                int soLuongThucTe = sp.LaSanPhamTang ? 1 : sp.SoLuong;

                int tonKhoHienTai = DanhSachSanPhamDAO.GetSoLuongTon(sp.IdKcsp);

                if (tonKhoHienTai >= soLuongThucTe)
                {
                    DanhSachSanPhamDAO.CapNhatSoLuongTon(sp.IdKcsp, -soLuongThucTe);

                    int tonMoi = tonKhoHienTai - soLuongThucTe;
                    if (tonMoi <= 0)
                    {
                        DanhSachSanPhamDAO.KhoaSanPham(sp.IdKcsp);
                    }
                }
                else
                {
                    MessageBox.Show(
                        $"❌ Không đủ tồn kho cho sản phẩm: {sp.TenSP} - Size {sp.KichCo}\n" +
                        $"Tồn kho hiện tại: {tonKhoHienTai}, cần: {soLuongThucTe}",
                        "Thiếu hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                }
            }
        }
        public List<BanHangDTO> LayTatCa()
        {
            return BanHangDAO.Instance.LayTatCaSanPham();
        }

        public List<BanHangDTO> SearchSanPham(string searchType, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return BanHangDAO.Instance.LayTatCaSanPham();
            }
            return BanHangDAO.Instance.TimKiemSanPham(searchType, searchTerm);
        }

    }
}
