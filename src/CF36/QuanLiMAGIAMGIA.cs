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

namespace CF36
{
    public partial class QuanLiMAGIAMGIA : Form
    {
        public QuanLiMAGIAMGIA()
        {
            InitializeComponent();
        }
        void SetColumnHeader(string columnName, string headerText, string newName)
        {
            if (dgvMaGiamGia.Columns.Contains(columnName))
            {
                dgvMaGiamGia.Columns[columnName].HeaderText = headerText;
                dgvMaGiamGia.Columns[columnName].Name = newName;
            }
        }
        private void LoadVouchers()
        {
            DataTable dt = VoucherBUS.Instance.GetAllVouchersWithJoin();
            dgvMaGiamGia.DataSource = dt;
            SetColumnHeader("Code", "Mã giảm giá", "colMa");
            SetColumnHeader("Giatri", "Giá trị giảm", "colGiaTri");
            SetColumnHeader("Ngaybd", "Ngày bắt đầu", "colNgayBD");
            SetColumnHeader("Ngaykt", "Ngày kết thúc", "colNgayKT");
            SetColumnHeader("DieuKien", "Đơn tối thiểu", "colDieuKien");
            SetColumnHeader("TenLoaiVoucher", "Loại mã", "colLoaiMa");
            SetColumnHeader("Maloaivc", "Kiểu mã", "colKieuMa");
            SetColumnHeader("maloai", "Loại sản phẩm áp dụng", "colLoaiSPApDung");
            SetColumnHeader("SizeSanPham", "Size", "colSize");
            SetColumnHeader("GiaSanPham", "Giá sản phẩm", "colGiaSP");
        }
        private void LoadVoucherTypes()
        {
            DataTable dt = VoucherBUS.Instance.GetVoucherTypes();
            cbbLoaiVoucher.DataSource = dt;
            cbbLoaiVoucher.DisplayMember = "Tenloai";
            cbbLoaiVoucher.ValueMember = "Maloaivc";
            cbbLoaiVoucher.SelectedIndex = -1;
        }

        private void btnThemMaGiamGia_Click(object sender, EventArgs e)
        {
            ThemMaGiamGia themMaGiamGia = new ThemMaGiamGia();
            var result = themMaGiamGia.ShowDialog();

            // Sau khi form thêm đóng, reload lại danh sách
            LoadVouchers();

        }

        private void QuanLiMAGIAMGIA_Load(object sender, EventArgs e)
        {
            LoadVouchers();
            LoadVoucherTypes();
        }

        private void btnSuaMaGiamGia_Click(object sender, EventArgs e)
        {
            if (dgvMaGiamGia.SelectedRows.Count > 0)
            {
                int mavc = Convert.ToInt32(dgvMaGiamGia.SelectedRows[0].Cells["Mavc"].Value);
                SuaMaGiamGia suaForm = new SuaMaGiamGia(mavc);
                suaForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã giảm giá cần sửa.");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dgvMaGiamGia.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("Code LIKE '%{0}%'", txtTimKiem.Text.Trim());
            }

        }

        private void dgvMaGiamGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbLoaiVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoaiVoucher.SelectedIndex != -1)
            {
                int maloaivc = Convert.ToInt32(((DataRowView)cbbLoaiVoucher.SelectedItem)["Maloaivc"]);
                DataTable dt = VoucherBUS.Instance.GetVouchersByType(maloaivc);
                dgvMaGiamGia.DataSource = dt;
            }

        }

        private void tlpall_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMaGiamGia.SelectedRows.Count > 0)
            {
                int mavc = Convert.ToInt32(dgvMaGiamGia.SelectedRows[0].Cells["Mavc"].Value);
                string code = dgvMaGiamGia.SelectedRows[0].Cells["colMa"].Value.ToString();

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa mã giảm giá '{code}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool success = VoucherBUS.Instance.DeleteVoucher(mavc);
                    MessageBox.Show(success ? "Xóa thành công!" : "Xóa thất bại!");
                    if (success) LoadVouchers();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã giảm giá cần xóa.");
            }

        }

        private void btnSuaMaGiamGia1tang1_Click(object sender, EventArgs e)
        {
            if (dgvMaGiamGia.SelectedRows.Count > 0)
            {
                int mavc = Convert.ToInt32(dgvMaGiamGia.SelectedRows[0].Cells["Mavc"].Value);
                int maloaivc = Convert.ToInt32(dgvMaGiamGia.SelectedRows[0].Cells["colKieuMa"].Value);

                if (maloaivc == 2 || maloaivc == 4)
                {
                    SuaMaGiamGiaMua1Tang1 form = new SuaMaGiamGiaMua1Tang1(mavc);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mã này không phải loại mua 1 tặng 1.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã cần sửa.");
            }

        }
    }
}
