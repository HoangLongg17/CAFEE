using ClosedXML.Excel;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BUS
{   
    public static class LSNhapKhoBUS
    {
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



        public static bool XuatExcel(List<LSNhapKhoDTO> data, string filePath, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            if (data == null || data.Count == 0)
                return false;

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Lịch sử nhập kho");

                    string title = "BÁO CÁO LỊCH SỬ NHẬP KHO";
                    if (tuNgay.HasValue && denNgay.HasValue)
                        title += $" ({tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy})";

                    ws.Cell(1, 1).Value = title;
                    ws.Range("A1:G1").Merge();
                    ws.Range("A1:G1").Style.Font.Bold = true;
                    ws.Range("A1:G1").Style.Font.FontSize = 20; 
                    ws.Range("A1:G1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("A1:G1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


                    ws.Cell(2, 1).Value = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}";
                    ws.Range("A2:D2").Merge();
                    ws.Range("A2:D2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range("A2:D2").Style.Font.Italic = true;

                    ws.Cell(4, 1).Value = "Mã phiếu";
                    ws.Cell(4, 2).Value = "Ngày nhập";
                    ws.Cell(4, 3).Value = "Nhà cung cấp";
                    ws.Cell(4, 4).Value = "Tổng tiền";

                    var headerRange = ws.Range("A4:D4");
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

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


                    var wsDetail = workbook.Worksheets.Add("Chi tiết nhập kho");

                    wsDetail.Cell(1, 1).Value = "Mã phiếu";
                    wsDetail.Cell(1, 2).Value = "Mã SP";
                    wsDetail.Cell(1, 3).Value = "Tên SP";
                    wsDetail.Cell(1, 4).Value = "Size";
                    wsDetail.Cell(1, 5).Value = "Số lượng";
                    wsDetail.Cell(1, 6).Value = "Giá nhập";
                    wsDetail.Cell(1, 7).Value = "Thành tiền";

                    var headerDetail = wsDetail.Range("A1:G1");
                    headerDetail.Style.Font.Bold = true;
                    headerDetail.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerDetail.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    List<ChiTietNhapKhoDTO> chiTietList;

                    var maNKList = data.Select(x => x.Mank).ToList();

                    if (maNKList.Count > 0)
                    {
                        chiTietList = LSNhapKhoDAO.GetChiTietNhapKhoTheoDanhSach(maNKList);
                    }
                    else if (tuNgay.HasValue && denNgay.HasValue)
                    {
                        chiTietList = LSNhapKhoDAO.GetChiTietNhapKhoTheoNgay(tuNgay.Value, denNgay.Value);
                    }
                    else
                    {
                        chiTietList = LSNhapKhoDAO.GetChiTietNhapKho();
                    }


                    int r = 2;
                    foreach (var ct in chiTietList)
                    {
                        wsDetail.Cell(r, 1).Value = ct.Mank;
                        wsDetail.Cell(r, 2).Value = ct.MaSP;
                        wsDetail.Cell(r, 3).Value = ct.TenSP;
                        wsDetail.Cell(r, 4).Value = ct.Size;
                        wsDetail.Cell(r, 5).Value = ct.SoLuongNhap;
                        wsDetail.Cell(r, 6).Value = ct.GiaNhap;
                        wsDetail.Cell(r, 7).Value = ct.Thanhtien;
                        r++;
                    }

                    wsDetail.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }




    }
}