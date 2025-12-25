using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ABC
{
    public partial class TraHang : Form
    {
        private string connectionString;

        public TraHang()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["QUANLICHTL"].ConnectionString;

            LoadHoaDon(); // Load danh sách hóa đơn khi mở form
        }

        // Load danh sách hóa đơn
        private void LoadHoaDon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Mahd, Ngaylap, Makh, Manv, TongTien FROM HOADON ORDER BY Ngaylap DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHoaDon.DataSource = dt;
            }

            // dgvChiTietTraHang.DataSource = null; // Reset chi tiết trả hàng
        }

        // Khi chọn 1 hóa đơn
        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                int mahd = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["Mahd"].Value);
                LoadChiTietHoaDon(mahd);     // Hiển thị chi tiết hóa đơn
                LoadChiTietTraHang(mahd);    // Hiển thị chi tiết trả hàng
            }
        }

        // Load chi tiết hóa đơn
        private void LoadChiTietHoaDon(int mahd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT ct.Masp, sp.Tensp, ct.Soluong, ct.Dongia, ct.Thanhtien
                    FROM CHITIETHD ct
                    JOIN SANPHAM sp ON ct.Masp = sp.Masp
                    WHERE ct.Mahd = @Mahd";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Mahd", mahd);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Nếu muốn tách hóa đơn và trả hàng ra hai dgv khác
                // dgvChiTietHoaDon.DataSource = dt;
            }
        }

        // Load chi tiết trả hàng
        private void LoadChiTietTraHang(int mahd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT th.Matra, th.Ngaytra, th.Lydotra, ct.Masp, sp.Tensp, ct.Soluong, ct.Dongia, ct.Soluong * ct.Dongia AS Thanhtien
                    FROM TRAHANG th
                    JOIN CTTRAHANG ct ON th.Matra = ct.Matra
                    JOIN SANPHAM sp ON ct.Masp = sp.Masp
                    WHERE th.Mahd = @Mahd";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Mahd", mahd);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // dgvChiTietTraHang.DataSource = dt;
            }
        }

        // Tìm kiếm hóa đơn
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadHoaDon();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Mahd, Ngaylap, Makh, Manv, TongTien FROM HOADON WHERE CAST(Mahd AS NVARCHAR) LIKE '%' + @TuKhoa + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHoaDon.DataSource = dt;

                // dgvChiTietTraHang.DataSource = null;
            }
        }

        // Thực hiện trả hàng
        private void btnTraHang_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để trả hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int mahd = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["Mahd"].Value);
            string lyDo = txtLyDo.Text.Trim();
            string manv = "NV01"; // Có thể lấy từ login hiện tại

            if (string.IsNullOrEmpty(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do trả hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1. Tạo phiếu trả hàng
                    string insertTraHang = "INSERT INTO TRAHANG (Mahd, Manv, Lydotra, Ngaytra) OUTPUT INSERTED.Matra VALUES (@Mahd, @Manv, @LyDo, GETDATE())";
                    SqlCommand cmd = new SqlCommand(insertTraHang, conn, tran);
                    cmd.Parameters.AddWithValue("@Mahd", mahd);
                    cmd.Parameters.AddWithValue("@Manv", manv);
                    cmd.Parameters.AddWithValue("@LyDo", lyDo);
                    int matra = (int)cmd.ExecuteScalar();

                    // 2. Lấy chi tiết hóa đơn
                    string queryCTHD = "SELECT Masp, Soluong, Dongia FROM CHITIETHD WHERE Mahd = @Mahd";
                    SqlCommand cmdCTHD = new SqlCommand(queryCTHD, conn, tran);
                    cmdCTHD.Parameters.AddWithValue("@Mahd", mahd);
                    SqlDataAdapter da = new SqlDataAdapter(cmdCTHD);
                    DataTable dtCTHD = new DataTable();
                    da.Fill(dtCTHD);

                    // 3. Thêm chi tiết trả hàng & cập nhật tồn kho
                    foreach (DataRow row in dtCTHD.Rows)
                    {
                        int masp = Convert.ToInt32(row["Masp"]);
                        int soluong = Convert.ToInt32(row["Soluong"]);
                        decimal dongia = Convert.ToDecimal(row["Dongia"]);

                        string insertCTTH = "INSERT INTO CTTRAHANG (Matra, Masp, Soluong, Dongia) VALUES (@Matra, @Masp, @Soluong, @Dongia)";
                        SqlCommand cmdCTTH = new SqlCommand(insertCTTH, conn, tran);
                        cmdCTTH.Parameters.AddWithValue("@Matra", matra);
                        cmdCTTH.Parameters.AddWithValue("@Masp", masp);
                        cmdCTTH.Parameters.AddWithValue("@Soluong", soluong);
                        cmdCTTH.Parameters.AddWithValue("@Dongia", dongia);
                        cmdCTTH.ExecuteNonQuery();

                        // Cập nhật tồn kho
                        string updateSP = "UPDATE SANPHAM SET Soluongton = Soluongton + @Soluong WHERE Masp = @Masp";
                        SqlCommand cmdUpdate = new SqlCommand(updateSP, conn, tran);
                        cmdUpdate.Parameters.AddWithValue("@Soluong", soluong);
                        cmdUpdate.Parameters.AddWithValue("@Masp", masp);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Trả hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadHoaDon();
                    // Sau khi load lại danh sách, load chi tiết trả hàng mới
                    if (dgvHoaDon.SelectedRows.Count > 0)
                    {
                        int selectedMahd = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["Mahd"].Value);
                        LoadChiTietTraHang(selectedMahd);
                    }

                    txtLyDo.Clear();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e) { }
        private void dgvChiTietTraHang_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblLyDo_Click(object sender, EventArgs e) { }
        private void txtLyDo_TextChanged(object sender, EventArgs e) { }

        private void tlpContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
