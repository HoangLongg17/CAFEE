using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CF36
{
    public partial class LichSuTraHang : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QUANLICHTL"].ConnectionString;

        public LichSuTraHang()
        {
            InitializeComponent();
            LoadDanhSachTraHang();
            dgvDanhSachTraHang.SelectionChanged += DgvDanhSachTraHang_SelectionChanged;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachTraHang(txtTimKiem.Text.Trim());
        }

        private void DgvDanhSachTraHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachTraHang.SelectedRows.Count > 0)
            {
                int matra = Convert.ToInt32(dgvDanhSachTraHang.SelectedRows[0].Cells["Matra"].Value);
                LoadChiTietTraHang(matra);
            }
            else
            {
                dgvChiTietTraHang.DataSource = null;
            }
        }

        private void LoadDanhSachTraHang(string tuKhoa = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT th.Matra, th.Ngaytra, nv.Hoten AS TenNhanVien, hd.Makh,
                           kh.Tenkh, th.Lydotra, hd.TongTien
                    FROM TRAHANG th
                    JOIN NHANVIEN nv ON th.Manv = nv.Manv
                    JOIN HOADON hd ON th.Mahd = hd.Mahd
                    LEFT JOIN KHACHHANG kh ON hd.Makh = kh.Makh
                    WHERE (@TuKhoa = '' OR CAST(th.Matra AS NVARCHAR) LIKE '%' + @TuKhoa + '%'
                           OR nv.Hoten LIKE '%' + @TuKhoa + '%'
                           OR kh.Tenkh LIKE '%' + @TuKhoa + '%')
                    ORDER BY th.Ngaytra DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@TuKhoa", tuKhoa);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDanhSachTraHang.DataSource = dt;

                // Tùy chỉnh hiển thị
                dgvDanhSachTraHang.Columns["Matra"].HeaderText = "Mã Trả";
                dgvDanhSachTraHang.Columns["Ngaytra"].HeaderText = "Ngày Trả";
                dgvDanhSachTraHang.Columns["TenNhanVien"].HeaderText = "Nhân Viên";
                dgvDanhSachTraHang.Columns["Makh"].Visible = false;
                dgvDanhSachTraHang.Columns["Tenkh"].HeaderText = "Khách Hàng";
                dgvDanhSachTraHang.Columns["Lydotra"].HeaderText = "Lý Do Trả";
                dgvDanhSachTraHang.Columns["TongTien"].HeaderText = "Tổng Tiền HD";
            }
        }

        private void LoadChiTietTraHang(int matra)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT cth.Masp, sp.Tensp, cth.Soluong, cth.Dongia, 
                           (cth.Soluong * cth.Dongia) AS ThanhTien
                    FROM CTTRAHANG cth
                    JOIN SANPHAM sp ON cth.Masp = sp.Masp
                    WHERE cth.Matra = @Matra";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Matra", matra);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvChiTietTraHang.DataSource = dt;

                dgvChiTietTraHang.Columns["Masp"].HeaderText = "Mã SP";
                dgvChiTietTraHang.Columns["Tensp"].HeaderText = "Tên SP";
                dgvChiTietTraHang.Columns["Soluong"].HeaderText = "Số Lượng";
                dgvChiTietTraHang.Columns["Dongia"].HeaderText = "Đơn Giá";
                dgvChiTietTraHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            }
        }

        private void LichSuTraHang_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);
            UIDataGridView.FormatDataGridView(dgvChiTietTraHang);
            UIDataGridView.FormatDataGridView(dgvDanhSachTraHang);
        }
    }
}
