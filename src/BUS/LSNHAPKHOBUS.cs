using ClosedXML.Excel;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BUS
{
    public static class LSNhapKhoBUS
    {
        // ================== PHIẾU NHẬP ==================

        public static List<LSNhapKhoDTO> LayTatCa()
        {
            try
            {
                return LSNhapKhoDAO.GetAll();
            }
            catch
            {
                return new List<LSNhapKhoDTO>();
            }
        }

        public static List<LSNhapKhoDTO> TimKiem(string keyword)
        {
            try
            {
                return LSNhapKhoDAO.Search(keyword);
            }
            catch
            {
                return new List<LSNhapKhoDTO>();
            }
        }

        public static List<LSNhapKhoDTO> LocTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return LSNhapKhoDAO.FilterByDate(tuNgay, denNgay);
            }
            catch
            {
                return new List<LSNhapKhoDTO>();
            }
        }

        // ================== CHI TIẾT NHẬP ==================

        public static List<ChiTietNhapKhoDTO> LayChiTietNhapKho()
        {
            try
            {
                return LSNhapKhoDAO.GetChiTietNhapKho();
            }
            catch
            {
                return new List<ChiTietNhapKhoDTO>();
            }
        }

        public static List<ChiTietNhapKhoDTO> LayChiTietNhapKhoTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return LSNhapKhoDAO.GetChiTietNhapKhoTheoNgay(tuNgay, denNgay);
            }
            catch
            {
                return new List<ChiTietNhapKhoDTO>();
            }
        }

        public static List<ChiTietNhapKhoDTO> LayChiTietNhapKhoTheoMaNK(int maNK)
        {
            try
            {
                return LSNhapKhoDAO.GetChiTietNhapKhoTheoMaNK(maNK);
            }
            catch
            {
                return new List<ChiTietNhapKhoDTO>();
            }
        }

        // ================== XUẤT EXCEL ==================

        public static bool XuatExcel(
            List<LSNhapKhoDTO> data,
            string filePath,
            DateTime? tuNgay = null,
            DateTime? denNgay = null)
        {
            if (data == null || data.Count == 0)
                return false;

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    // ===== Sheet 1: Lịch sử nhập kho =====
                    var ws = workbook.Worksheets.Add("Lịch sử nhập kho");

                    string title = "BÁO CÁO LỊCH SỬ NHẬP KHO";
                    if (tuNgay.HasValue && denNgay.HasValue)
                        title += $" ({tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy})";

                    ws.Cell(1, 1).Value = title;
                    ws.Range("A1:D1").Merge();
                    ws.Range("A1:D1").Style.Font.Bold = true;
                    ws.Range("A1:D1").Style.Font.FontSize = 18;
                    ws.Range("A1:D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                    ws.Range("A2:D2").Merge();
                    ws.Range("A2:D2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range("A2:D2").Style.Font.Italic = true;

                    ws.Cell(4, 1).Value = "Mã phiếu";
                    ws.Cell(4, 2).Value = "Ngày nhập";
                    ws.Cell(4, 3).Value = "Nhà cung cấp";
                    ws.Cell(4, 4).Value = "Tổng tiền";

                    var header = ws.Range("A4:D4");
                    header.Style.Font.Bold = true;
                    header.Style.Fill.BackgroundColor = XLColor.LightGray;
                    header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    int row = 5;
                    foreach (var item in data)
                    {
                        ws.Cell(row, 1).Value = item.Mank;
                        ws.Cell(row, 2).Value = item.Ngaynhap.ToString("dd/MM/yyyy");
                        ws.Cell(row, 3).Value = item.Tennhacc;
                        ws.Cell(row, 4).Value = item.Tongtien;
                        ws.Cell(row, 4).Style.NumberFormat.Format = "#,##0 \"VNĐ\"";
                        row++;
                    }

                    ws.Cell(row, 3).Value = "Tổng cộng:";
                    ws.Cell(row, 3).Style.Font.Bold = true;
                    ws.Cell(row, 4).FormulaA1 = $"SUM(D5:D{row - 1})";
                    ws.Cell(row, 4).Style.Font.Bold = true;
                    ws.Cell(row, 4).Style.NumberFormat.Format = "#,##0 \"VNĐ\"";

                    ws.Columns().AdjustToContents();

                    // ===== Sheet 2: Chi tiết nhập kho =====
                    var wsDetail = workbook.Worksheets.Add("Chi tiết nhập kho");

                    wsDetail.Cell(1, 1).Value = "Mã phiếu";
                    wsDetail.Cell(1, 2).Value = "Mã SP";
                    wsDetail.Cell(1, 3).Value = "Tên SP";
                    wsDetail.Cell(1, 4).Value = "Số lượng";
                    wsDetail.Cell(1, 5).Value = "Giá nhập";
                    wsDetail.Cell(1, 6).Value = "Thành tiền";

                    var headerDetail = wsDetail.Range("A1:F1");
                    headerDetail.Style.Font.Bold = true;
                    headerDetail.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerDetail.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    List<ChiTietNhapKhoDTO> chiTietList;

                    if (tuNgay.HasValue && denNgay.HasValue)
                        chiTietList = LSNhapKhoDAO.GetChiTietNhapKhoTheoNgay(
                            tuNgay.Value, denNgay.Value);
                    else
                        chiTietList = LSNhapKhoDAO.GetChiTietNhapKho();

                    int r = 2;
                    foreach (var ct in chiTietList)
                    {
                        wsDetail.Cell(r, 1).Value = ct.Mank;
                        wsDetail.Cell(r, 2).Value = ct.MaSP;
                        wsDetail.Cell(r, 3).Value = ct.TenSP;
                        wsDetail.Cell(r, 4).Value = ct.SoLuongNhap;
                        wsDetail.Cell(r, 5).Value = ct.GiaNhap;
                        wsDetail.Cell(r, 6).Value = ct.Thanhtien;
                        r++;
                    }

                    wsDetail.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi xuất Excel: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
