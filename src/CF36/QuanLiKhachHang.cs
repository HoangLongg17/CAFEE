using BUS;
using DAO;
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
    public partial class QuanLiKhachHang : Form
    {
        private int selectedRowIndex;
        public QuanLiKhachHang()
        {
            InitializeComponent();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            ThemKhachHang formThem = new ThemKhachHang();
            formThem.OnCustomerAdded = () => LoadDSKH();
            formThem.ShowDialog();
        }
        private void LoadDSKH()
        {
            dgvKhachHang.DataSource = KhachHangBUS.LayDSKH();
            UIDataGridView.FormatDataGridView(dgvKhachHang);

            if (dgvKhachHang.Columns.Count > 0)
            {
                dgvKhachHang.Columns["Makh"].HeaderText = "Mã khách hàng";
                dgvKhachHang.Columns["Tenkh"].HeaderText = "Tên khách hàng";
                dgvKhachHang.Columns["Sdt"].HeaderText = "Số điện thoại";
                dgvKhachHang.Columns["Tichdiem"].HeaderText = "Tích điểm";
            }

        }
        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKhachHang.SelectedRows[0];
                int makh = Convert.ToInt32(row.Cells["Makh"].Value);
                string tenkh = row.Cells["Tenkh"].Value.ToString();
                string sdt = row.Cells["Sdt"].Value.ToString();
                int tichdiem = Convert.ToInt32(row.Cells["Tichdiem"].Value);

                KhachHangDTO kh = new KhachHangDTO(makh, tenkh, sdt, tichdiem);

                // Mở form sửa và truyền dữ liệu
                SuaKhachHang formSua = new SuaKhachHang(kh);
                formSua.ShowDialog();

                // Sau khi sửa xong, reload danh sách
                LoadDSKH();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.");
            }

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            List<KhachHangDTO> dsKH = KhachHangBUS.TimKH(keyword);
            dgvKhachHang.DataSource = dsKH;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLiKhachHang_Load(object sender, EventArgs e)
        {
            LoadDSKH();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);

        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKhachHang_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKhachHang.SelectedRows[0];
                int makh = Convert.ToInt32(row.Cells["Makh"].Value);

                DialogResult confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa khách hàng mã {makh}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    if (KhachHangBUS.XoaKH(makh))
                    {
                        LoadDSKH();
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDSKH();
            selectedRowIndex = -1;
            dgvKhachHang.ClearSelection();

        }
    }
}
