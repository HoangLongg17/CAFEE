using BUS;
using DAO;
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
    public partial class ThemMaGiamGia1tang1 : Form
    {
        public ThemMaGiamGia1tang1()
        {
            InitializeComponent();
        }
        private void LoadSanPhamTang()
        {
            dgvSanPham.DataSource = Voucher1tang1BUS.Instance.TimSanPhamTang("");
            dgvSanPham.Columns["masp"].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns["tensp"].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns["kichco"].HeaderText = "Size";
        }

        private void ThemMaGiamGia1tang1_Load(object sender, EventArgs e)
        {
            // Load loại mã
            cbbLoaiMa.Items.Add("Mua 1 tặng 1 cùng dòng");
            cbbLoaiMa.Items.Add("Mua 1 tặng 1 bất kỳ");
            cbbLoaiMa.SelectedIndex = 0;

            // Load loại sản phẩm mua
            var dtLoaiSP = DataProvider.Instance.ExecuteQuery("SELECT maloai, tenloai FROM LOAISP");
            cbbSanPhamMua.DisplayMember = "tenloai";
            cbbSanPhamMua.ValueMember = "maloai";
            cbbSanPhamMua.DataSource = dtLoaiSP;
            cbbLoaiMa_SelectedIndexChanged(null, null);

            // Format giao diện
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);
            UIDataGridView.FormatDataGridView(dgvSanPham);
            if (dgvSanPham.Columns.Contains("masp"))
                dgvSanPham.Columns["masp"].HeaderText = "Mã sản phẩm";

            if (dgvSanPham.Columns.Contains("tensp"))
                dgvSanPham.Columns["tensp"].HeaderText = "Tên sản phẩm";

            if (dgvSanPham.Columns.Contains("kichco"))
                dgvSanPham.Columns["kichco"].HeaderText = "Size";

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvSanPham.DataSource = Voucher1tang1BUS.Instance.TimSanPhamTang(keyword);


        }

        private void cbbLoaiMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int loaiVC = cbbLoaiMa.SelectedIndex == 0 ? 2 : 4;

            if (loaiVC == 2) // Mua 1 tặng 1 cùng dòng
            {
                if (cbbSanPhamMua.SelectedValue != null && int.TryParse(cbbSanPhamMua.SelectedValue.ToString(), out int maloai))
                {
                    dgvSanPham.DataSource = Voucher1tang1BUS.Instance.TimSanPhamTangTheoLoai(maloai);
                    if (dgvSanPham.Columns.Contains("maloai"))
                    {
                        dgvSanPham.Columns["maloai"].Visible = false;
                    }

                }
                else
                {
                    dgvSanPham.DataSource = null;
                    return;
                }
            }
            else // Mua 1 tặng 1 bất kỳ
            {
                LoadSanPhamTang();
            }

            dgvSanPham.Enabled = true;


        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            string ma = txtMaGG.Text.Trim();
            string ten = txtTenMaGiamGia.Text.Trim();
            int maloai = Convert.ToInt32(cbbSanPhamMua.SelectedValue);
            int loaiVC = cbbLoaiMa.SelectedIndex == 0 ? 2 : 4;

            // ✅ Cho phép bỏ trống giá trị tối thiểu
            decimal dieuKien = 0;
            string input = txtGiaTriToiThieu.Text.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                if (!decimal.TryParse(input, out dieuKien))
                {
                    MessageBox.Show("Giá trị tối thiểu không hợp lệ.");
                    return;
                }
            }

            List<(string masp, string kichco)> dsTang = new List<(string, string)>();

            foreach (DataGridViewRow row in dgvSanPham.SelectedRows)
            {
                string masp = row.Cells["masp"].Value.ToString();
                string kichco = row.Cells["kichco"].Value.ToString();

                // Chỉ kiểm tra dòng sản phẩm nếu là loại 2
                if (loaiVC == 2)
                {
                    if (!dgvSanPham.Columns.Contains("maloai") || row.Cells["maloai"].Value == null)
                    {
                        MessageBox.Show($"Thiếu thông tin loại sản phẩm cho '{masp}'. Vui lòng kiểm tra lại danh sách sản phẩm tặng.");
                        return;
                    }

                    int maloaiSP = Convert.ToInt32(row.Cells["maloai"].Value);
                    if (maloaiSP != maloai)
                    {
                        MessageBox.Show($"Sản phẩm tặng '{masp}' không cùng dòng với sản phẩm mua đã chọn.");
                        return;
                    }
                }

                dsTang.Add((masp, kichco));
            }

            if (dsTang.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm tặng.");
                return;
            }

            try
            {
                bool ok = Voucher1tang1BUS.Instance.ThemVoucher(ma, ten, loaiVC, maloai, dieuKien, dsTang);

                if (ok)
                {
                    MessageBox.Show("Thêm mã giảm giá thành công!");

                    // ✅ Gọi lại form quản lý để cập nhật danh sách
                    if (Owner is QuanLiMAGIAMGIA qlForm)
                    {
                        qlForm.LoadVouchers();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        private bool ValidateInputs()
        {
            // Kiểm tra mã và tên
            if (string.IsNullOrWhiteSpace(txtMaGG.Text) || string.IsNullOrWhiteSpace(txtTenMaGiamGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã và tên mã giảm giá.");
                return false;
            }

            // Kiểm tra ngày
            if (dTPHetHan.Value.Date < dTPBatDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.");
                return false;
            }

            return true;
        }
        private void txtGiaTriToiThieu_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbbSanPhamMua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoaiMa.SelectedIndex == 0) // Nếu đang chọn loại 2
            {
                if (cbbSanPhamMua.SelectedValue != null && int.TryParse(cbbSanPhamMua.SelectedValue.ToString(), out int maloai))
                {
                    dgvSanPham.DataSource = Voucher1tang1BUS.Instance.TimSanPhamTangTheoLoai(maloai);
                }
            }

        }
    }
}
