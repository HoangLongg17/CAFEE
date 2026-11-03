using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text.pdf;

namespace ABC
{
    /// <summary>
    /// Các hàm dùng chung cho chức năng xuất PDF.
    /// </summary>
    internal static class PdfHelper
    {
        // Mở file PDF sau khi xuất. Nếu máy không mở được thì chỉ báo nhẹ,
        // KHÔNG coi là lỗi xuất file (file đã được tạo thành công).
        public static void MoTapTin(string filePath)
        {
            try
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Đã xuất file thành công nhưng không thể tự động mở file.\nFile được lưu tại:\n" + filePath,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Thông báo lỗi xuất PDF, có hướng dẫn riêng cho lỗi file đang được mở.
        public static void ThongBaoLoi(Exception ex)
        {
            string msg = ex is IOException || ex is UnauthorizedAccessException
                ? "Không thể ghi file PDF.\nFile có thể đang được mở bằng chương trình khác (trình đọc PDF) hoặc bạn không có quyền ghi vào thư mục này.\nHãy đóng file rồi thử lại.\n\nChi tiết: " + ex.Message
                : "Đã xảy ra lỗi khi xuất PDF: " + ex.Message;
            MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Giá trị hiển thị trong PDF: tiền -> 63.000, ngày giờ -> dd/MM/yyyy HH:mm
        public static string DinhDang(DataGridViewCell cell)
        {
            object? v = cell.Value;
            if (v == null || v == DBNull.Value) return "";
            if (v is DateTime dt)
                return dt.TimeOfDay == TimeSpan.Zero ? dt.ToString("dd/MM/yyyy") : dt.ToString("dd/MM/yyyy HH:mm");
            if (v is decimal d) return d.ToString("N0");
            return cell.FormattedValue?.ToString() ?? "";
        }

        // Tạo ô PDF chứa ảnh (thu nhỏ để file nhẹ). Lỗi ảnh thì để ô trống.
        public static PdfPCell TaoOAnh(Image anh, iTextSharp.text.Font font)
        {
            try
            {
                int h = 80;
                int w = Math.Max(1, anh.Width * h / Math.Max(1, anh.Height));
                using var thumb = new Bitmap(anh, new Size(w, h));
                using var ms = new MemoryStream();
                thumb.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                var img = iTextSharp.text.Image.GetInstance(ms.ToArray());
                var cell = new PdfPCell(img, true)
                {
                    HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE,
                    FixedHeight = 40f
                };
                return cell;
            }
            catch (Exception)
            {
                return new PdfPCell(new iTextSharp.text.Phrase("", font));
            }
        }
    }
}
