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

namespace ABC
{
    public partial class LICHSUHOADON : Form
    {
        private LichSuHoaDonBUS lichSuBUS = new LichSuHoaDonBUS();
        private string FONT_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "times.ttf");
        private BaseFont vietnameseFont;
        private bool isShowingDetails = false;
        public LICHSUHOADON()
        {
            InitializeComponent();
        }

        private void LICHSUHOADON_Load(object sender, EventArgs e)
        {
            SetupInitialState();
            LoadAllHoaDon();
            ClearChiTietGrid();
            InitializePdfFont();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);
            UIDataGridView.FormatDataGridView(dgvHoaDon);
            UIDataGridView.FormatDataGridView(dgvNhanVien);
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
        private void SetupInitialState()
        {
            txtMaNhanVien.Enabled = false;
            dTPTuNgay.Enabled = false;
            dTPDenNgay.Enabled = false;

            dTPTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dTPDenNgay.Value = DateTime.Now;

            // Cấu hình dgvHoaDon
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.ReadOnly = true;

            // Cấu hình dgvNhanVien
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.ReadOnly = true;
        }

        private void LoadAllHoaDon()
        {
            try
            {
                dgvHoaDon.DataSource = lichSuBUS.SearchHoaDon(null, null, null, null);
                UIDataGridView.FormatDataGridView(dgvHoaDon);
                SetupHoaDonGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhanVienGrid()
        {
            isShowingDetails = false; // Set cờ: Grid trên đang hiển thị Nhân viên
            try
            {
                dgvNhanVien.DataSource = lichSuBUS.GetNhanVienList();
                UIDataGridView.FormatDataGridView(dgvNhanVien);
                SetupNhanVienGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cBNhanVienBan_CheckedChanged(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = cBNhanVienBan.Checked;
            if (!cBNhanVienBan.Checked)
            {
                txtMaNhanVien.Text = "";
            }
        }

        private void cBTuNgay_CheckedChanged(object sender, EventArgs e)
        {
            dTPTuNgay.Enabled = cBTuNgay.Checked;
        }

        private void cBDenNgay_CheckedChanged(object sender, EventArgs e)
        {
            dTPDenNgay.Enabled = cBDenNgay.Checked;
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                string timKiem = txtTimKiem.Text.Trim();
                string maNV = cBNhanVienBan.Checked ? txtMaNhanVien.Text.Trim() : null;
                DateTime? tuNgay = cBTuNgay.Checked ? dTPTuNgay.Value.Date : (DateTime?)null;
                DateTime? denNgay = cBDenNgay.Checked ? dTPDenNgay.Value.Date : (DateTime?)null;

                dgvHoaDon.DataSource = lichSuBUS.SearchHoaDon(timKiem, maNV, tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null && dgvNhanVien.CurrentRow.DataBoundItem != null)
            {
                // (SỬA LẠI) Chỉ chạy code này nếu đối tượng ĐÚNG LÀ NhanVienDTO
                if (dgvNhanVien.CurrentRow.DataBoundItem is NhanVienDTO nv)
                {
                    // Nếu vào đây, 'nv' chắc chắn là NhanVienDTO và không null
                    string maNV = nv.Mand;
                    txtMaNhanVien.Text = maNV;
                    cBNhanVienBan.Checked = true;
                }

                // Nếu nó là ChiTietLichSuDTO, code sẽ tự động bỏ qua
            }
        }
        private void ClearChiTietGrid()
        {
            isShowingDetails = false; // Tắt cờ "đang xem chi tiết"
            dgvNhanVien.DataSource = null;

            // (Tùy chọn) Xóa luôn các cột cũ
            dgvNhanVien.Columns.Clear();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            txtMaNhanVien.Text = "";
            cBNhanVienBan.Checked = false;
            cBTuNgay.Checked = false;
            cBDenNgay.Checked = false;
            SetupInitialState(); // Reset lại ngày tháng
            LoadAllHoaDon();
            ClearChiTietGrid();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
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
            saveFileDialog.FileName = $"LichSuHoaDon_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportLichSuToPdf(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file PDF lịch sử thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file (đã sửa lỗi)
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
        private void ExportLichSuToPdf(string filePath)
        {
            // 1. Định nghĩa Font
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(vietnameseFont, 20f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(vietnameseFont, 12f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font normalFont = new iTextSharp.text.Font(vietnameseFont, 11f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font timestampFont = new iTextSharp.text.Font(vietnameseFont, 10f, iTextSharp.text.Font.ITALIC);

            // 2. Tạo Document
            Document document = new Document(PageSize.A4, 25f, 25f, 30f, 30f); // Trang đứng A4
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // 3. Thêm Tiêu đề
            Paragraph title = new Paragraph("LỊCH SỬ HÓA ĐƠN", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 5;
            document.Add(title);

            // 4. Thêm Ngày giờ xuất
            string thoiGianXuat = $"(Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss})";
            Paragraph timestamp = new Paragraph(thoiGianXuat, timestampFont);
            timestamp.Alignment = Element.ALIGN_CENTER;
            timestamp.SpacingAfter = 15;
            document.Add(timestamp);

            // 5. Thêm Tiêu chí lọc
            document.Add(new Paragraph("THÔNG TIN LỌC:", subHeaderFont));

            string timKiem = string.IsNullOrEmpty(txtTimKiem.Text) ? "(Không nhập)" : txtTimKiem.Text;
            string maNV = cBNhanVienBan.Checked ? txtMaNhanVien.Text : "(Không chọn)";
            string tuNgay = cBTuNgay.Checked ? dTPTuNgay.Value.ToString("dd/MM/yyyy") : "(Không chọn)";
            string denNgay = cBDenNgay.Checked ? dTPDenNgay.Value.ToString("dd/MM/yyyy") : "(Không chọn)";

            document.Add(new Paragraph($"  - Tìm kiếm (Mã HĐ, Mã KH, Tên/SĐT KH): {timKiem}", normalFont));
            document.Add(new Paragraph($"  - Mã nhân viên: {maNV}", normalFont));
            document.Add(new Paragraph($"  - Từ ngày: {tuNgay}", normalFont));
            document.Add(new Paragraph($"  - Đến ngày: {denNgay}", normalFont));

            // 6. Thêm Bảng Hóa Đơn
            document.Add(new Paragraph("DANH SÁCH HÓA ĐƠN ĐÃ LỌC:", subHeaderFont) { SpacingBefore = 10, SpacingAfter = 10 });
            if (dgvHoaDon.Rows.Count > 0)
            {
                PdfPTable tableHD = CreatePdfTableFromDgv(dgvHoaDon, subHeaderFont, normalFont);
                document.Add(tableHD);
            }
            else
            {
                document.Add(new Paragraph("(Không có dữ liệu hóa đơn)", normalFont));
            }

            // 7. Thêm Bảng Nhân Viên
            document.Add(new Paragraph("DANH SÁCH NHÂN VIÊN (THAM KHẢO):", subHeaderFont) { SpacingBefore = 10, SpacingAfter = 10 });
            if (dgvNhanVien.Rows.Count > 0)
            {
                PdfPTable tableNV = CreatePdfTableFromDgv(dgvNhanVien, subHeaderFont, normalFont);
                document.Add(tableNV);
            }
            else
            {
                document.Add(new Paragraph("(Không có dữ liệu nhân viên)", normalFont));
            }

            // 8. Đóng file
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

                    // Căn lề
                    if (cell.ValueType == typeof(decimal) || cell.ValueType == typeof(int))
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
        private void SetupNhanVienGridColumns()
        {
            var columnMap = new Dictionary<string, string>
            {
                { "Mand", "Mã nhân viên" },
                { "Vitri", "Vị trí" },
                { "Hoten", "Họ tên" },
                { "Sdt", "Số điện thoại" },
                { "Email", "Email" },
                { "NgaySinh", "Ngày sinh" },
                { "Diachi", "Địa chỉ" },
                { "Luong", "Lương" },
                { "Bank", "Bank" },
                { "Stk", "Số tài khoản" }
            };

            foreach (DataGridViewColumn col in dgvNhanVien.Columns)
            {
                if (columnMap.ContainsKey(col.Name))
                {
                    col.HeaderText = columnMap[col.Name];
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false; // Ẩn các cột không nằm trong danh sách
                }
            }
        }
        private void SetupHoaDonGridColumns()
        {
            var columnMap = new Dictionary<string, string>
    {
        { "MaHD", "Mã hóa đơn" },
        { "NgayLap", "Ngày lập" },
        { "TenNhanVien", "Tên nhân viên" },
        { "TenKhachHang", "Tên khách hàng" },
        { "TongTien", "Tổng tiền" }
    };

            dgvHoaDon.Columns.Clear(); // Xóa cột cũ
            dgvHoaDon.AutoGenerateColumns = false; // TẮT TỰ ĐỘNG TẠO CỘT

            // Thêm các cột dữ liệu
            foreach (var pair in columnMap)
            {
                dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = pair.Key,
                    DataPropertyName = pair.Key, // Liên kết với DTO
                    HeaderText = pair.Value
                });
            }

            // THÊM CỘT NÚT BẤM "XEM"
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "ChiTiet";
            btnColumn.HeaderText = "Chi tiết";
            btnColumn.Text = "XEM";
            btnColumn.UseColumnTextForButtonValue = true; // Nút nào cũng ghi chữ "XEM"
            btnColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnColumn.FlatStyle = FlatStyle.Flat;
            btnColumn.DefaultCellStyle.BackColor = Color.ForestGreen;
            btnColumn.DefaultCellStyle.ForeColor = Color.White;
            dgvHoaDon.Columns.Add(btnColumn);

            // Định dạng cột
            dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null && dgvHoaDon.CurrentRow.DataBoundItem != null)
            {
                isShowingDetails = true; // Set cờ: Grid trên sắp hiển thị Chi tiết
                try
                {
                    // Lấy MaHD từ grid dưới
                    int maHD = (dgvHoaDon.CurrentRow.DataBoundItem as LichSuHoaDonDTO).MaHD;

                    // Gọi BUS lấy chi tiết
                    List<ChiTietLichSuDTO> details = lichSuBUS.GetChiTietHoaDon(maHD);

                    // Đổ chi tiết lên grid TRÊN
                    dgvNhanVien.DataSource = details;

                    // Đổi tên cột grid trên
                    SetupChiTietGridColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SetupChiTietGridColumns()
        {
            // Đặt tên lại các cột
            dgvNhanVien.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvNhanVien.Columns["KichCo"].HeaderText = "Size";
            dgvNhanVien.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvNhanVien.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvNhanVien.Columns["ThanhTien"].HeaderText = "Thành tiền";

            // Định dạng tiền
            dgvNhanVien.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvNhanVien.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            // Ẩn các cột khác (nếu có)
            foreach (DataGridViewColumn col in dgvNhanVien.Columns)
            {
                if (col.Name != "TenSP" && col.Name != "KichCo" && col.Name != "SoLuong" && col.Name != "DonGia" && col.Name != "ThanhTien")
                {
                    col.Visible = false;
                }
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvHoaDon.Columns["ChiTiet"].Index)
            {
                try
                {
                    // Lấy MaHD từ hàng được click
                    LichSuHoaDonDTO selectedHoaDon = dgvHoaDon.Rows[e.RowIndex].DataBoundItem as LichSuHoaDonDTO;
                    if (selectedHoaDon != null)
                    {
                        int maHD = selectedHoaDon.MaHD;

                        // Mở form chi tiết và truyền MaHD vào
                        ChiTietHoaDon formChiTiet = new ChiTietHoaDon(maHD);
                        formChiTiet.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi mở chi tiết: " + ex.Message);
                }
            }
        }

        private void tlpall_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
