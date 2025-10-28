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
        }

        private void ThemMaGiamGia1tang1_Load(object sender, EventArgs e)
        {
            // Load loại mã
            cbbLoaiMa.Items.Add("Mua 1 tặng 1 cùng dòng");
            cbbLoaiMa.Items.Add("Mua 1 tặng 1 bất kỳ");

            // Load loại sản phẩm mua
            var dtLoaiSP = DataProvider.Instance.ExecuteQuery("SELECT maloai, tenloai FROM LOAISP");
            cbbSanPhamMua.DataSource = dtLoaiSP;
            cbbSanPhamMua.DisplayMember = "tenloai";
            cbbSanPhamMua.ValueMember = "maloai";

            // Load sản phẩm tặng
            LoadSanPhamTang();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);
            UIDataGridView.FormatDataGridView(dgvSanPham);

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvSanPham.DataSource = Voucher1tang1BUS.Instance.TimSanPhamTang(keyword);


        }

        private void cbbLoaiMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isTangCungDong = cbbLoaiMa.SelectedIndex == 0;
            dgvSanPham.Enabled = !isTangCungDong;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;
            string ma = txtMaGG.Text.Trim();
            string ten = txtTenMaGiamGia.Text.Trim();
            int maloai = Convert.ToInt32(cbbSanPhamMua.SelectedValue);
            int loaiVC = cbbLoaiMa.SelectedIndex == 0 ? 2 : 4;

            decimal dieuKien = 0;
            if (!decimal.TryParse(txtGiaTriToiThieu.Text.Trim(), out dieuKien))
            {
                MessageBox.Show("Giá trị tối thiểu không hợp lệ.");
                return;
            }

            List<(string masp, string kichco)> dsTang = new List<(string, string)>();
            if (loaiVC == 4)
            {
                foreach (DataGridViewRow row in dgvSanPham.SelectedRows)
                {
                    string masp = row.Cells["masp"].Value.ToString();
                    string kichco = row.Cells["kichco"].Value.ToString();
                    dsTang.Add((masp, kichco));
                }

                if (dsTang.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm tặng.");
                    return;
                }
            }

            try
            {
                bool ok = Voucher1tang1BUS.Instance.ThemVoucher(ma, ten, loaiVC, maloai, dieuKien, dsTang);
                MessageBox.Show(ok ? "Thêm mã giảm giá thành công!" : "Thêm thất bại!");
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
    }
}
