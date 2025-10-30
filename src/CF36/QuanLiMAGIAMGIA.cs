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
        public string MaGiamGiaDuocChon { get; private set; }
        private bool isChonMa = false;
        public QuanLiMAGIAMGIA(bool chonMa = false)
        {
            InitializeComponent();
            isChonMa = chonMa;
        }
        void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvMaGiamGia.Columns.Contains(columnName))
            {
                dgvMaGiamGia.Columns[columnName].HeaderText = headerText;
            }
        }
        public void LoadVouchers()
        {
            DataTable dt = VoucherBUS.Instance.GetAllVouchersWithJoin();
            dgvMaGiamGia.DataSource = dt;
            SetAllColumnHeaders();
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
            ThemMaGiamGia form = new ThemMaGiamGia();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadVouchers(); // cập nhật lại sau khi thêm
            }

        }

        private void QuanLiMAGIAMGIA_Load(object sender, EventArgs e)
        {
            LoadVoucherTypes();
            LoadVouchers();
            UIDataGridView.FormatDataGridView(dgvMaGiamGia);
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);
            btnApDung.Visible = isChonMa;

        }

        private void btnSuaMaGiamGia_Click(object sender, EventArgs e)
        {
            if (dgvMaGiamGia.SelectedRows.Count > 0)
            {
                int mavc = Convert.ToInt32(dgvMaGiamGia.SelectedRows[0].Cells["Mavc"].Value);
                int maloaivc = Convert.ToInt32(dgvMaGiamGia.SelectedRows[0].Cells["Maloaivc"].Value);

                if (maloaivc == 1 || maloaivc == 3)
                {
                    SuaMaGiamGia form = new SuaMaGiamGia(mavc);
                    form.FormClosed += (s, e) => LoadVouchers(); // gọi lại hàm load
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mã này không phải loại 'Giảm theo %' hoặc 'Giảm theo giá trị thực'.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã cần sửa.");
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
        private void SetAllColumnHeaders()
        {
            SetColumnHeader("Mavc", "Id");
            SetColumnHeader("Code", "Mã giảm giá");
            SetColumnHeader("TenMaGiamGia", "Tên mã giảm giá");
            SetColumnHeader("Giatri", "Giá trị giảm");
            SetColumnHeader("Ngaybd", "Ngày bắt đầu");
            SetColumnHeader("Ngaykt", "Ngày kết thúc");
            SetColumnHeader("DieuKien", "Đơn tối thiểu");
            SetColumnHeader("Maloaivc", "Loại mã");
            SetColumnHeader("maloai", "Mã loại sản phẩm mua");
            SetColumnHeader("TenLoaiVouCher", "Tên loại mã giảm giá");
            SetColumnHeader("TenLoaiSanPhamApDung", "Loại SP áp dụng");
            SetColumnHeader("TenLoaiSanPhamTang", "Loại SP tặng");
        }
        private void cbbLoaiVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoaiVoucher.SelectedIndex != -1)
            {
                int maloaivc = Convert.ToInt32(((DataRowView)cbbLoaiVoucher.SelectedItem)["Maloaivc"]);
                DataTable dt = VoucherBUS.Instance.GetVouchersByTypeWithJoin(maloaivc);
                dgvMaGiamGia.DataSource = dt;

                SetAllColumnHeaders(); // cập nhật lại tiêu đề cột
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
                string code = dgvMaGiamGia.SelectedRows[0].Cells["Code"].Value.ToString();

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
                int maloaivc = Convert.ToInt32(dgvMaGiamGia.SelectedRows[0].Cells["Maloaivc"].Value);

                if (maloaivc == 2 || maloaivc == 4)
                {
                    SuaMaGiamGiaMua1Tang1 form = new SuaMaGiamGiaMua1Tang1(mavc);
                    form.FormClosed += (s, e) => LoadVouchers(); // gọi lại hàm load
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

        private void btnApDung_Click(object sender, EventArgs e)
        {
            if (dgvMaGiamGia.CurrentRow != null)
            {
                MaGiamGiaDuocChon = dgvMaGiamGia.CurrentRow.Cells["code"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mã giảm giá để áp dụng.");
            }

        }
    }
}
