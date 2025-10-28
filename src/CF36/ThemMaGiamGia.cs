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
    public partial class ThemMaGiamGia : Form
    {
        public ThemMaGiamGia()
        {
            InitializeComponent();
        }

        private void btnThemMaGiamGia1tang1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThemMaGiamGia1tang1 themMaGiamGia1Tang1 = new ThemMaGiamGia1tang1();
            themMaGiamGia1Tang1.ShowDialog();
            this.Show();
        }

        private void ThemMaGiamGia_Load(object sender, EventArgs e)
        {
            LoadLoaiMaGG();
            LoadLoaiSanPham();
            LoadSanPham();

            // Mặc định chọn loại giảm theo giá trị thực
            cbbLoaiMaGG.SelectedValue = 3; // Giả sử 3 là "Giảm theo giá trị thực"
            UpdateInputVisibility();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);


        }
        private void LoadLoaiMaGG()
        {
            DataTable dt = VoucherBUS.Instance.GetVoucherTypes();

            // Lọc chỉ lấy loại mã 1 và 3
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Maloaivc = 1 OR Maloaivc = 3";

            cbbLoaiMaGG.DataSource = dv;
            cbbLoaiMaGG.DisplayMember = "Tenloai";
            cbbLoaiMaGG.ValueMember = "Maloaivc";
            cbbLoaiMaGG.SelectedIndex = -1;

        }
        private void UpdateInputVisibility()
        {
            if (cbbLoaiMaGG.SelectedItem is DataRowView row)
            {
                int maloaivc = Convert.ToInt32(row["Maloaivc"]);
                // 1 = Giảm %, 3 = Giảm theo giá trị thực
                txtGiaTriGiam.Enabled = (maloaivc == 3);
                numGiamPhanTram.Enabled = (maloaivc == 1);
            }
        }



        private void LoadLoaiSanPham()
        {
            cbbLoaiSanPham.DataSource = DanhSachSanPhamBUS.Instance.GetLoaiSanPham();
            cbbLoaiSanPham.DisplayMember = "tenloai";
            cbbLoaiSanPham.ValueMember = "maloai";
            cbbLoaiSanPham.SelectedIndex = -1;
        }

        private void LoadSanPham()
        {
            dgvSanPham.DataSource = DanhSachSanPhamBUS.Instance.GetAllSanPham();

            // Chỉ hiển thị các cột cần thiết
            dgvSanPham.Columns["ID"].HeaderText = "ID";
            dgvSanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns["KichCo"].HeaderText = "Size";
            dgvSanPham.Columns["GiaBan"].HeaderText = "Giá bán";

            foreach (DataGridViewColumn col in dgvSanPham.Columns)
            {
                if (col.Name != "ID" && col.Name != "TenSP" && col.Name != "KichCo" && col.Name != "GiaBan")
                {
                    col.Visible = false;
                }
            }
        }



        private void cbbLoaiMaGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInputVisibility();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string code = txtMaGiamGia.Text.Trim();
            string ten = txtTenMa.Text.Trim();
            decimal giatri = 0;

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã và tên mã giảm giá.");
                return;
            }

            int maloaivc = Convert.ToInt32(cbbLoaiMaGG.SelectedValue);

            if (maloaivc == 1)
                giatri = numGiamPhanTram.Value;
            else if (maloaivc == 3 && !decimal.TryParse(txtGiaTriGiam.Text, out giatri))
            {
                MessageBox.Show("Giá trị giảm không hợp lệ.");
                return;
            }
            if (VoucherBUS.Instance.CheckCodeExists(code))
            {
                MessageBox.Show("Mã giảm giá đã tồn tại. Vui lòng chọn mã khác.");
                return;
            }
            decimal? dieuKien = null;
            if (decimal.TryParse(txtGiaTriDonToiThieu.Text, out decimal dk))
                dieuKien = dk;

            DateTime ngaybd = dTPBatDau.Value.Date;
            DateTime ngaykt = dTPHetHan.Value.Date;

            if (ngaykt < ngaybd)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.");
                return;
            }

            int? maloai = cbbLoaiSanPham.SelectedIndex != -1 ? Convert.ToInt32(cbbLoaiSanPham.SelectedValue) : null;

            VoucherDTO voucher = new VoucherDTO(0, code, giatri, ngaybd, ngaykt, dieuKien, maloaivc, maloai);

            try
            {
                int mavc = VoucherBUS.Instance.AddVoucherAndGetID(voucher);

                if (mavc > 0)
                {
                    // Nếu có chọn sản phẩm cụ thể
                    if (dgvSanPham.SelectedRows.Count > 0)
                    {
                        int idkcsp = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["ID"].Value);
                        bool added = VoucherBUS.Instance.AddVoucherChiTiet(mavc, idkcsp);

                        if (!added)
                        {
                            MessageBox.Show("Không thể liên kết mã với sản phẩm đã chọn.");
                        }
                    }

                    MessageBox.Show("Thêm mã giảm giá thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Có thể mã đã tồn tại hoặc dữ liệu không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }

        }
    }
}
