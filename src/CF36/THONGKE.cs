using BUS;
using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq; // (MỚI) Thêm thư viện này
using System.Drawing; // (MỚI) Thêm thư viện này

namespace CF36
{
    public partial class THONGKE : Form
    {
        private ThongKeBUS thongKeBUS = new ThongKeBUS();
        // (MỚI) Biến trạng thái để biết đang xem chart nào
        private bool isViewingTopProducts = false;

        // (MỚI) Các biến cho PDF
        private string FONT_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "times.ttf");
        private BaseFont vietnameseFont;
        public THONGKE()
        {
            InitializeComponent();
        }

        private void THONGKE_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            SetupInitialState();
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
        private void LoadLoaiSanPham()
        {
            try
            {
                cbbLoaiSanPham.DataSource = thongKeBUS.GetLoaiSP();
                cbbLoaiSanPham.DisplayMember = "TenLoai";
                cbbLoaiSanPham.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải loại sản phẩm: " + ex.Message);
            }
        }
        private void SetupInitialState()
        {
            dtTuNgay.Enabled = false;
            dtDenNgay.Enabled = false;
            cbbLoaiSanPham.Enabled = false;
            dtTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtDenNgay.Value = DateTime.Now;
            txtTongTien.Text = "";
        }

        private void cBTuNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtTuNgay.Enabled = cBTuNgay.Checked;
        }

        private void cBDenNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtDenNgay.Enabled = cBDenNgay.Checked;
        }

        private void cBLoaiSanPham_CheckedChanged(object sender, EventArgs e)
        {
            cbbLoaiSanPham.Enabled = cBLoaiSanPham.Checked;
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            isViewingTopProducts = false; // (MỚI) Set cờ về trạng thái doanh thu

            try
            {
                // 1. Lấy tham số lọc
                DateTime? tuNgay = cBTuNgay.Checked ? dtTuNgay.Value.Date : (DateTime?)null;
                DateTime? denNgay = cBDenNgay.Checked ? dtDenNgay.Value.Date : (DateTime?)null;
                int? maLoai = cBLoaiSanPham.Checked ? (int?)cbbLoaiSanPham.SelectedValue : (int?)null;

                // 2. Validate
                if (tuNgay.HasValue && denNgay.HasValue && denNgay.Value < tuNgay.Value)
                {
                    MessageBox.Show("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Lấy dữ liệu HÓA ĐƠN
                dgvHoaDon.DataSource = thongKeBUS.GetHoaDon(tuNgay, denNgay, maLoai);
                SetupDgvHoaDonColumns(); // (MỚI) Tùy chỉnh cột

                // 4. Lấy dữ liệu DOANH THU
                List<DoanhThuChartDTO> chartData = thongKeBUS.GetDoanhThu(tuNgay, denNgay, maLoai);

                decimal tongDoanhThu = thongKeBUS.CalculateTotalRevenue(chartData);
                txtTongTien.Text = tongDoanhThu.ToString("N0") + " VNĐ";

                // 5. Vẽ biểu đồ DOANH THU
                PopulateRevenueChart(chartData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateRevenueChart(List<DoanhThuChartDTO> data)
        {
            chrThongKe.Series.Clear();
            chrThongKe.DataSource = null;

            var series = chrThongKe.Series.Add("Doanh thu");
            series.ChartType = SeriesChartType.Column;

            if (data.Count == 0) return;

            series.XValueMember = "Ngay";
            series.YValueMembers = "TongDoanhThu";
            chrThongKe.DataSource = data;

            // Tùy chỉnh trục X (Ngày tháng)
            chrThongKe.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
            chrThongKe.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chrThongKe.ChartAreas[0].AxisX.Interval = 1;
            chrThongKe.ChartAreas[0].AxisX.Title = "Ngày";

            // Tùy chỉnh trục Y (Doanh thu)
            chrThongKe.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chrThongKe.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";

            series.ToolTip = "Ngày: #VALX{dd/MM/yyyy}\nDoanh thu: #VALY{N0} VNĐ";

            // (MỚI) Reset màu về mặc định
            foreach (DataPoint point in series.Points)
            {
                point.Color = Color.CornflowerBlue; // Màu mặc định
            }

            chrThongKe.DataBind();
        }
        private void PopulateTopProductsChart(List<SanPhamBanChayDTO> data)
        {
            chrThongKe.Series.Clear();
            chrThongKe.DataSource = null;

            var series = chrThongKe.Series.Add("Sản phẩm bán ra");
            series.ChartType = SeriesChartType.Column;

            if (data.Count == 0) return;

            series.XValueMember = "TenSP";
            series.YValueMembers = "SoLuongBan";
            chrThongKe.DataSource = data; // Dữ liệu đã được sắp xếp giảm dần từ BUS

            // Tùy chỉnh trục X (Sản phẩm)
            chrThongKe.ChartAreas[0].AxisX.LabelStyle.Format = ""; // Xóa định dạng ngày
            chrThongKe.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
            chrThongKe.ChartAreas[0].AxisX.Interval = 1;
            chrThongKe.ChartAreas[0].AxisX.Title = "Sản phẩm";

            // Tùy chỉnh trục Y (Số lượng)
            chrThongKe.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chrThongKe.ChartAreas[0].AxisY.Title = "Số lượng đã bán";

            series.ToolTip = "Sản phẩm: #VALX\nĐã bán: #VALY{N0} cái";

            chrThongKe.DataBind(); // Phải DataBind trước khi tô màu

            // (MỚI) Logic tô màu cột cao nhất
            if (series.Points.Count > 0)
            {
                // Lấy giá trị cao nhất (vì đã sắp xếp)
                double maxValue = series.Points[0].YValues[0];

                foreach (DataPoint point in series.Points)
                {
                    point.Color = Color.CornflowerBlue;
                }
            }
        }

        // (MỚI) Hàm tùy chỉnh cột DGV cho Hóa Đơn
        private void SetupDgvHoaDonColumns()
        {
            dgvHoaDon.Columns["MaHD"].HeaderText = "Mã HĐ";
            dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dgvHoaDon.Columns["TenNhanVien"].HeaderText = "Nhân Viên";
            dgvHoaDon.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
            dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
        }

        // (MỚI) Hàm tùy chỉnh cột DGV cho Top Sản Phẩm
        private void SetupDgvTopProductsColumns()
        {
            // Căn chỉnh lại cột
            dgvHoaDon.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvHoaDon.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvHoaDon.Columns["SoLuongBan"].HeaderText = "Số Lượng Bán";
            dgvHoaDon.Columns["SoLuongBan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // (BỔ SUNG KHỐI NÀY)
            dgvHoaDon.Columns["TongDoanhThu"].HeaderText = "Tổng Doanh Thu";
            dgvHoaDon.Columns["TongDoanhThu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
        }
        private void ExportThongKeToPdf(string filePath)
        {
            // 1. Định nghĩa Font (ĐÃ SỬA)
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(vietnameseFont, 20f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(vietnameseFont, 14f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(vietnameseFont, 12f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font normalFont = new iTextSharp.text.Font(vietnameseFont, 11f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font timestampFont = new iTextSharp.text.Font(vietnameseFont, 10f, iTextSharp.text.Font.ITALIC);

            // 2. Tạo Document
            Document document = new Document(PageSize.A4, 25f, 25f, 30f, 30f); // Trang đứng A4
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // 3. Thêm Tiêu đề
            Paragraph title = new Paragraph("BÁO CÁO THỐNG KÊ DOANH THU", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 5;
            document.Add(title);

            // 4. Thêm Ngày giờ xuất
            string thoiGianXuat = $"(Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss})";
            Paragraph timestamp = new Paragraph(thoiGianXuat, timestampFont);
            timestamp.Alignment = Element.ALIGN_CENTER;
            timestamp.SpacingAfter = 15;
            document.Add(timestamp);

            // 5. Thêm Tiêu chí lọc (ĐÃ SỬA)
            document.Add(new Paragraph("THÔNG TIN LỌC:", subHeaderFont));

            string tuNgay = cBTuNgay.Checked ? dtTuNgay.Value.ToString("dd/MM/yyyy") : "(Không chọn)";
            string denNgay = cBDenNgay.Checked ? dtDenNgay.Value.ToString("dd/MM/yyyy") : "(Không chọn)";
            string loaiSP = cBLoaiSanPham.Checked ? cbbLoaiSanPham.Text : "(Tất cả)";

            document.Add(new Paragraph($"  - Từ ngày: {tuNgay}", normalFont));
            document.Add(new Paragraph($"  - Đến ngày: {denNgay}", normalFont));
            document.Add(new Paragraph($"  - Loại sản phẩm: {loaiSP}", normalFont));

            // 6. Thêm Tổng doanh thu (ĐÃ SỬA)
            document.Add(new Paragraph("TỔNG DOANH THU:", subHeaderFont) { SpacingBefore = 10, SpacingAfter = 5 });
            Paragraph tongTienPara = new Paragraph(txtTongTien.Text, headerFont); // Dùng font to
            tongTienPara.Alignment = Element.ALIGN_CENTER;
            tongTienPara.SpacingAfter = 15;
            document.Add(tongTienPara);

            // 7. Thêm Biểu đồ (ĐÃ SỬA)
            document.Add(new Paragraph("BIỂU ĐỒ DOANH THU:", subHeaderFont) { SpacingAfter = 5 });
            try
            {
                // Chuyển biểu đồ thành ảnh
                using (MemoryStream chartStream = new MemoryStream())
                {
                    chrThongKe.SaveImage(chartStream, ChartImageFormat.Png);
                    iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(chartStream.GetBuffer());

                    // Thay đổi kích cỡ ảnh cho vừa trang
                    float chartWidth = PageSize.A4.Width - document.LeftMargin - document.RightMargin;
                    float chartHeight = chartImage.Height * (chartWidth / chartImage.Width);
                    chartImage.ScaleAbsolute(chartWidth, chartHeight);

                    document.Add(chartImage);
                }
            }
            catch (Exception ex)
            {
                document.Add(new Paragraph($" (Lỗi không thể chèn biểu đồ: {ex.Message})", timestampFont));
            }

            // 8. Thêm Bảng sản phẩm
            document.NewPage();
            document.Add(new Paragraph("CHI TIẾT SẢN PHẨM BÁN CHẠY:", subHeaderFont) { SpacingBefore = 10, SpacingAfter = 10 });

            if (dgvHoaDon.Rows.Count > 0 && isViewingTopProducts)
            {
                // (SỬA) Tự động lấy số cột mới (giờ là 3)
                PdfPTable pdfTable = new PdfPTable(dgvHoaDon.Columns.Count);
                pdfTable.WidthPercentage = 100;

                // Thêm Header (Không cần sửa)
                foreach (DataGridViewColumn column in dgvHoaDon.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, subHeaderFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.BackgroundColor = new BaseColor(230, 230, 230);
                    cell.Padding = 5;
                    pdfTable.AddCell(cell);
                }

                // Thêm Dữ liệu
                foreach (DataGridViewRow row in dgvHoaDon.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string cellValue = cell.Value?.ToString() ?? "";
                        PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, normalFont));
                        pdfCell.Padding = 5;

                        // (SỬA LẠI DÒNG IF NÀY)
                        // Căn lề phải cho cột Số lượng Bán và Tổng Doanh Thu
                        if (cell.OwningColumn.Name == "SoLuongBan" || cell.OwningColumn.Name == "TongDoanhThu")
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
                document.Add(pdfTable);
            }
            else
            {
                document.Add(new Paragraph("(Không có dữ liệu sản phẩm)", normalFont));
            }

            // 9. Đóng file
            document.Close();
            writer.Close();
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
            saveFileDialog.FileName = $"ThongKeDoanhThu_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportThongKeToPdf(saveFileDialog.FileName);

                    MessageBox.Show("Xuất file PDF thống kê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnSanPhamBanChay_Click(object sender, EventArgs e)
        {
            isViewingTopProducts = true; // (MỚI) Set cờ về trạng thái bán chạy

            try
            {
                // 1. Lấy tham số lọc
                DateTime? tuNgay = cBTuNgay.Checked ? dtTuNgay.Value.Date : (DateTime?)null;
                DateTime? denNgay = cBDenNgay.Checked ? dtDenNgay.Value.Date : (DateTime?)null;
                int? maLoai = cBLoaiSanPham.Checked ? (int?)cbbLoaiSanPham.SelectedValue : (int?)null;

                // 2. Lấy dữ liệu SẢN PHẨM BÁN CHẠY
                List<SanPhamBanChayDTO> topProducts = thongKeBUS.GetSanPhamBanChay(tuNgay, denNgay, maLoai);

                // 3. Gán dữ liệu cho DataGridView
                dgvHoaDon.DataSource = topProducts;
                SetupDgvTopProductsColumns(); // (MỚI) Tùy chỉnh cột

                // 4. Xóa tổng doanh thu (vì không liên quan)
                txtTongTien.Text = "";

                // 5. Vẽ biểu đồ BÁN CHẠY
                PopulateTopProductsChart(topProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lọc sản phẩm bán chạy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
