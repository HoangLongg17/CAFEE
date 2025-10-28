using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfFont = iTextSharp.text.Font;

namespace CF36
{
    public partial class DANHSACHSANPHAM : Form
    {
        private DanhSachSanPhamBUS sanPhamBUS = new DanhSachSanPhamBUS();

        // Dùng Dictionary để map tên hiển thị và giá trị thực tế cho ComboBox
        private Dictionary<string, string> searchTypes = new Dictionary<string, string>();
        private string FONT_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "times.ttf");
        private BaseFont vietnameseFont;
        public DANHSACHSANPHAM()
        {
            InitializeComponent();
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            ThemSanPham themSanPham = new ThemSanPham();
            themSanPham.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaSanPham suaSanPham = new SuaSanPham();
            suaSanPham.Show();
        }

        private void DANHSACHSANPHAM_Load(object sender, EventArgs e)
        {
            LoadSearchComboBox();
            LoadDataGrid(); // Tải tất cả sản phẩm khi form mở
            SetupDataGridView();
            InitializePdfFont();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);

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
        private void LoadSearchComboBox()
        {
            searchTypes.Add("Mã sản phẩm", "MaSP");
            searchTypes.Add("Tên sản phẩm", "TenSP");
            searchTypes.Add("Loại sản phẩm", "LoaiSP");

            cbbLoaiTimKiem.DataSource = new BindingSource(searchTypes, null);
            cbbLoaiTimKiem.DisplayMember = "Key";
            cbbLoaiTimKiem.ValueMember = "Value";
        }

        // Cấu hình hiển thị cho DataGridView
        private void SetupDataGridView()
        {
            dgvDanhSachSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachSanPham.MultiSelect = false;
            dgvDanhSachSanPham.ReadOnly = true;

            // Đặt tên cột cho thân thiện
            dgvDanhSachSanPham.Columns["ID"].HeaderText = "ID";
            dgvDanhSachSanPham.Columns["MaSP"].HeaderText = "Mã SP";
            dgvDanhSachSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvDanhSachSanPham.Columns["TenLoai"].HeaderText = "Loại";
            dgvDanhSachSanPham.Columns["KichCo"].HeaderText = "Size";
            dgvDanhSachSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
            dgvDanhSachSanPham.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
            dgvDanhSachSanPham.Columns["TrangThaiText"].HeaderText = "Trạng Thái";

            // Định dạng cột tiền
            dgvDanhSachSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
        }

        // Hàm tải/tải lại dữ liệu cho DataGridView
        private void LoadDataGrid(string searchType = null, string searchTerm = null)
        {
            try
            {
                dgvDanhSachSanPham.DataSource = sanPhamBUS.SearchSanPham(searchType, searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string searchType = cbbLoaiTimKiem.SelectedValue.ToString();
            string searchTerm = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Nếu ô tìm kiếm rỗng, tải lại tất cả
                LoadDataGrid();
            }
            else
            {
                // Nếu có chữ, bắt đầu tìm
                LoadDataGrid(searchType, searchTerm);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnHien_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần Ẩn/Hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int selectedID = (int)dgvDanhSachSanPham.CurrentRow.Cells["ID"].Value;
                string tenSP = dgvDanhSachSanPham.CurrentRow.Cells["TenSP"].Value.ToString();
                string size = dgvDanhSachSanPham.CurrentRow.Cells["KichCo"].Value.ToString();
                string trangThaiHienTai = dgvDanhSachSanPham.CurrentRow.Cells["TrangThaiText"].Value.ToString();
                string trangThaiMoi = (trangThaiHienTai == "Đang bán") ? "Ngừng bán" : "Đang bán";

                DialogResult confirm = MessageBox.Show(
                    $"Bạn có chắc muốn đổi trạng thái của '{tenSP} (Size {size})' từ '{trangThaiHienTai}' thành '{trangThaiMoi}' không?",
                    "Xác nhận Ẩn/Hiện",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    bool success = sanPhamBUS.ToggleTrangThaiSanPham(selectedID);

                    if (success)
                    {
                        MessageBox.Show("Đã cập nhật trạng thái thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int selectedID = (int)dgvDanhSachSanPham.CurrentRow.Cells["ID"].Value;
                string tenSP = dgvDanhSachSanPham.CurrentRow.Cells["TenSP"].Value.ToString();
                string size = dgvDanhSachSanPham.CurrentRow.Cells["KichCo"].Value.ToString();

                DialogResult confirm = MessageBox.Show(
                    $"Bạn có chắc muốn XÓA vĩnh viễn sản phẩm '{tenSP} (Size {size})'?\n" +
                    $"Hành động này sẽ xóa sản phẩm khỏi kho và không thể hoàn tác.",
                    "Xác nhận Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    // 4. Gọi BUS
                    bool success = sanPhamBUS.DeleteSanPham(selectedID);

                    if (success)
                    {
                        MessageBox.Show("Đã xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REFERENCE constraint") || ex.Message.Contains("khóa ngoại"))
                {
                    MessageBox.Show("Không thể xóa sản phẩm này vì nó đã tồn tại trong một hóa đơn hoặc phiếu nhập kho.", "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            if (vietnameseFont == null)
            {
                MessageBox.Show("Chưa tải được font Tiếng Việt. Không thể xuất PDF.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvDanhSachSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"DanhSachSanPham_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportDataGridViewToPdf(dgvDanhSachSanPham, saveFileDialog.FileName);
                    MessageBox.Show("Xuất file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void ExportDataGridViewToPdf(DataGridView dgv, string filePath)
        {
            // 1. Tạo Font
            PdfFont headerFont = new PdfFont(vietnameseFont, 14, PdfFont.BOLD);
            PdfFont cellFont = new PdfFont(vietnameseFont, 10, PdfFont.NORMAL);
            PdfFont titleFont = new PdfFont(vietnameseFont, 20, PdfFont.BOLD);
            // (MỚI) Font cho ngày giờ (nhỏ, nghiêng)
            PdfFont timestampFont = new PdfFont(vietnameseFont, 11, PdfFont.ITALIC);

            // 2. Tạo Document
            Document document = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f); // Trang ngang
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // 3. Thêm Tiêu đề
            Paragraph title = new Paragraph("DANH SÁCH SẢN PHẨM", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 5; // Giảm khoảng cách sau tiêu đề
            document.Add(title);

            // --- (PHẦN MỚI THÊM) ---
            // 3b. Thêm Ngày giờ xuất file
            string thoiGianXuat = $"(Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss})";
            Paragraph timestamp = new Paragraph(thoiGianXuat, timestampFont);
            timestamp.Alignment = Element.ALIGN_CENTER;
            timestamp.SpacingAfter = 15; // Khoảng cách trước khi vào bảng
            document.Add(timestamp);
            // --- (HẾT PHẦN MỚI) ---

            // 4. Tạo Bảng (Table)
            PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
            pdfTable.WidthPercentage = 100;

            // 5. Thêm Header cho bảng
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = new BaseColor(230, 230, 230);
                cell.Padding = 5;
                pdfTable.AddCell(cell);
            }

            // 6. Thêm Dữ liệu (Dòng)
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellValue = cell.Value?.ToString() ?? "";
                    PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, cellFont));
                    pdfCell.Padding = 5;

                    if (cell.OwningColumn.Name == "GiaBan" || cell.OwningColumn.Name == "SoLuongTon")
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

            // 7. Thêm bảng vào document
            document.Add(pdfTable);

            // 8. Đóng file
            document.Close();
            writer.Close();
        }
    }
}
