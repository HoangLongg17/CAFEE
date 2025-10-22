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

namespace CF36
{
    public partial class LICHSUHOADON : Form
    {
        private LichSuHoaDonBUS lichSuBUS = new LichSuHoaDonBUS();
        public LICHSUHOADON()
        {
            InitializeComponent();
        }

        private void LICHSUHOADON_Load(object sender, EventArgs e)
        {
            SetupInitialState();
            LoadAllHoaDon();
            LoadNhanVienGrid();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhanVienGrid()
        {
            try
            {
                dgvNhanVien.DataSource = lichSuBUS.GetNhanVienList();
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
                // Lấy MaNV từ DTO
                string maNV = (dgvNhanVien.CurrentRow.DataBoundItem as NhanVienDTO).Mand;

                // Tự động điền vào bộ lọc
                txtMaNhanVien.Text = maNV;
                cBNhanVienBan.Checked = true;
            }
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
            dgvNhanVien.ClearSelection();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
