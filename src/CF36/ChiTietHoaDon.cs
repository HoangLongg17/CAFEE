using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CF36
{
    public partial class ChiTietHoaDon : Form
    {
        private int maHD;
        private LichSuHoaDonBUS lichSuBUS = new LichSuHoaDonBUS();
        private string FONT_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "times.ttf");
        private BaseFont vietnameseFont;
        public ChiTietHoaDon()
        {
            InitializeComponent();
            InitializePdfFont();
        }
        public ChiTietHoaDon(int maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
            this.Text = $"Chi tiết Hóa đơn: {maHD}";

            InitializePdfFont();
        }
        private void InitializePdfFont()
        {
            try
            {
                if (!File.Exists(FONT_PATH))
                {
                    MessageBox.Show($"Không tìm thấy file font tại: {FONT_PATH}\nKhông thể xuất PDF Tiếng Việt.", "Lỗi Font", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                vietnameseFont = BaseFont.CreateFont(FONT_PATH, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải font Tiếng Việt cho PDF: " + ex.Message, "Lỗi Font", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadChiTiet()
        {
            try
            {
                // 1. Lấy DTO đầy đủ (chứa mọi thông tin)
                HoaDonDayDuDTO dto = lichSuBUS.GetHoaDonDayDu(this.maHD);

                if (dto == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu hóa đơn.");
                    this.Close();
                    return;
                }

                // 2. (MỚI) Tạo danh sách cho Grid thông tin chung
                List<ThongTinChungDTO> thongTinList = new List<ThongTinChungDTO>();

                thongTinList.Add(new ThongTinChungDTO { ThuocTinh = "Mã Hóa Đơn", GiaTri = dto.MaHD.ToString() });
                thongTinList.Add(new ThongTinChungDTO { ThuocTinh = "Ngày Lập", GiaTri = dto.NgayLap.ToString("dd/MM/yyyy HH:mm") });
                thongTinList.Add(new ThongTinChungDTO { ThuocTinh = "Nhân Viên", GiaTri = dto.TenNhanVien });
                thongTinList.Add(new ThongTinChungDTO { ThuocTinh = "Khách Hàng", GiaTri = dto.TenKhachHang });
                thongTinList.Add(new ThongTinChungDTO { ThuocTinh = "SĐT Khách", GiaTri = dto.SdtKhachHang ?? "(Không có)" });

                // Tính toán
                decimal tamTinh = dto.Items.Sum(item => item.ThanhTien);
                decimal giamGia = tamTinh - dto.TongTienCuoiCung;

                thongTinList.Add(new ThongTinChungDTO { ThuocTinh = "Tạm Tính (Tổng món)", GiaTri = tamTinh.ToString("N0") + " VNĐ" });

                if (dto.VouchersSuDung.Count > 0)
                {
                    thongTinList.Add(new ThongTinChungDTO { ThuocTinh = "Voucher đã dùng", GiaTri = string.Join(", ", dto.VouchersSuDung) });
                }

                thongTinList.Add(new ThongTinChungDTO { ThuocTinh = "Giảm giá", GiaTri = giamGia.ToString("N0") + " VNĐ" });
                thongTinList.Add(new ThongTinChungDTO { ThuocTinh = "TỔNG THANH TOÁN", GiaTri = dto.TongTienCuoiCung.ToString("N0") + " VNĐ" });

                // 3. Gán DataSource cho 2 grid
                dgvThongTinChung.DataSource = thongTinList;
                dgvChiTiet.DataSource = dto.Items;

                // 4. Cấu hình cột
                SetupInfoGridColumns();
                SetupItemGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message);
            }
        }

        // (MỚI) Hàm cấu hình cho grid trên (Thông tin chung)
        private void SetupInfoGridColumns()
        {
            dgvThongTinChung.Columns["ThuocTinh"].HeaderText = "Thông Tin";
            dgvThongTinChung.Columns["GiaTri"].HeaderText = "Giá Trị";

            dgvThongTinChung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongTinChung.ReadOnly = true;
            dgvThongTinChung.AllowUserToAddRows = false; // Cấm thêm hàng
            dgvThongTinChung.RowHeadersVisible = false; // Ẩn ô vuông đầu hàng
        }

        // (SỬA) Đổi tên hàm này
        private void SetupItemGridColumns()
        {
            // Đặt tên cột
            dgvChiTiet.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvChiTiet.Columns["KichCo"].HeaderText = "Size";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";

            // Định dạng tiền
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadChiTiet();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            if (vietnameseFont == null)
            {
                MessageBox.Show("Chưa tải được font Tiếng Việt. Không thể xuất PDF.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"ChiTietHoaDon_{this.maHD}_{DateTime.Now:ddMMyyyy}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportChiTietToPdf(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file PDF chi tiết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveFileDialog.FileName)
                    {
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportChiTietToPdf(string filePath)
        {
            // 1. Định nghĩa Font
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(vietnameseFont, 20f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(vietnameseFont, 12f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font normalFont = new iTextSharp.text.Font(vietnameseFont, 11f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font normalBoldFont = new iTextSharp.text.Font(vietnameseFont, 11f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font timestampFont = new iTextSharp.text.Font(vietnameseFont, 10f, iTextSharp.text.Font.ITALIC);

            // 2. Tạo Document
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25f, 25f, 30f, 30f);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // 3. Tiêu đề
            iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph($"CHI TIẾT HÓA ĐƠN: {this.maHD}", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 5;
            document.Add(title);

            // 4. Ngày giờ xuất
            string thoiGianXuat = $"(Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss})";
            iTextSharp.text.Paragraph timestamp = new iTextSharp.text.Paragraph(thoiGianXuat, timestampFont);
            timestamp.Alignment = Element.ALIGN_CENTER;
            timestamp.SpacingAfter = 15;
            document.Add(timestamp);

            // 5. Thêm Bảng Thông Tin Chung (từ dgvThongTinChung)
            document.Add(new iTextSharp.text.Paragraph("THÔNG TIN HÓA ĐƠN:", subHeaderFont) { SpacingAfter = 10 });

            PdfPTable infoTable = new PdfPTable(2); // Bảng có 2 cột
            infoTable.WidthPercentage = 100;
            infoTable.SetWidths(new float[] { 1f, 2f }); // Cột 1 nhỏ, Cột 2 lớn

            foreach (DataGridViewRow row in dgvThongTinChung.Rows)
            {
                string thuocTinh = row.Cells["ThuocTinh"].Value?.ToString() ?? "";
                string giaTri = row.Cells["GiaTri"].Value?.ToString() ?? "";

                // Cột Thuộc tính (in đậm)
                PdfPCell cell1 = new PdfPCell(new Phrase(thuocTinh, normalBoldFont));
                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell1.Padding = 5;
                cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                infoTable.AddCell(cell1);

                // Cột Giá trị
                PdfPCell cell2 = new PdfPCell(new Phrase(giaTri, normalFont));
                cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell2.Padding = 5;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                infoTable.AddCell(cell2);
            }
            document.Add(infoTable);

            // 6. Thêm Bảng Chi Tiết Món (từ dgvChiTiet)
            document.Add(new iTextSharp.text.Paragraph("CHI TIẾT MÓN:", subHeaderFont) { SpacingBefore = 15, SpacingAfter = 10 });

            if (dgvChiTiet.Rows.Count > 0)
            {
                // Dùng hàm CreatePdfTableFromDgv (copy từ form Lịch sử)
                PdfPTable itemTable = CreatePdfTableFromDgv(dgvChiTiet, subHeaderFont, normalFont);
                document.Add(itemTable);
            }
            else
            {
                document.Add(new iTextSharp.text.Paragraph("(Không có chi tiết món)", normalFont));
            }

            // 7. Đóng file
            document.Close();
            writer.Close();
        }

        private PdfPTable CreatePdfTableFromDgv(DataGridView dgv, iTextSharp.text.Font headerFont, iTextSharp.text.Font cellFont)
        {
            PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
            pdfTable.WidthPercentage = 100;

            // Thêm Header
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = new BaseColor(230, 230, 230);
                cell.Padding = 5;
                pdfTable.AddCell(cell);
            }

            // Thêm Dữ liệu
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellValue = cell.Value?.ToString() ?? "";
                    PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, cellFont));
                    pdfCell.Padding = 5;

                    if (cell.OwningColumn.Name == "DonGia" || cell.OwningColumn.Name == "ThanhTien" || cell.OwningColumn.Name == "SoLuong")
                    {
                        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    }
                    else
                    {
                        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    }
                    pdfTable.AddCell(pdfCell);
                }
            }
            return pdfTable;
        }
    }
}
