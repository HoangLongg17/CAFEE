using BUS;
using DTO;
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

namespace CF36
{
    public partial class THONGKE : Form
    {
        private ThongKeBUS thongKeBUS = new ThongKeBUS();
        public THONGKE()
        {
            InitializeComponent();
        }

        private void THONGKE_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            SetupInitialState();
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
            try
            {
                //Lấy tham số lọc (Code này đã đúng)
                DateTime? tuNgay = cBTuNgay.Checked ? dtTuNgay.Value.Date : (DateTime?)null;
                DateTime? denNgay = cBDenNgay.Checked ? dtDenNgay.Value.Date : (DateTime?)null;
                int? maLoai = cBLoaiSanPham.Checked ? (int?)cbbLoaiSanPham.SelectedValue : (int?)null;

                //Validate ngày (Code này đã đúng)
                if (tuNgay.HasValue && denNgay.HasValue && denNgay.Value < tuNgay.Value)
                {
                    MessageBox.Show("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgvHoaDon.DataSource = thongKeBUS.GetHoaDon(tuNgay, denNgay, maLoai);

                List<DoanhThuChartDTO> chartData = thongKeBUS.GetDoanhThu(tuNgay, denNgay, maLoai);

                decimal tongDoanhThu = thongKeBUS.CalculateTotalRevenue(chartData);
                txtTongTien.Text = tongDoanhThu.ToString("N0") + " VNĐ";

                PopulateChart(chartData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateChart(List<DoanhThuChartDTO> data)
        {
            chrThongKe.Series.Clear();
            chrThongKe.DataSource = null;

            if (data.Count == 0)
            {
                // Có thể hiển thị thông báo không có dữ liệu
                return;
            }

            var series = chrThongKe.Series.Add("Doanh thu");
            series.ChartType = SeriesChartType.Column; // Kiểu cột

            // Gán nguồn dữ liệu
            series.XValueMember = "Ngay";
            series.YValueMembers = "TongDoanhThu";
            chrThongKe.DataSource = data;

            // Tùy chỉnh trục X (Ngày tháng)
            chrThongKe.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
            chrThongKe.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chrThongKe.ChartAreas[0].AxisX.Interval = 1; // Hiển thị mỗi 1 ngày
            chrThongKe.ChartAreas[0].AxisX.Title = "Ngày";

            // Tùy chỉnh trục Y (Doanh thu)
            chrThongKe.ChartAreas[0].AxisY.LabelStyle.Format = "N0"; // Số có dấu phẩy
            chrThongKe.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";

            // Thêm Tooltip
            series.ToolTip = "Ngày: #VALX{dd/MM/yyyy}\nDoanh thu: #VALY{N0} VNĐ";

            chrThongKe.DataBind();
        }
    }
}
