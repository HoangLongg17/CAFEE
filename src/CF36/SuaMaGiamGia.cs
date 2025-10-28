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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CF36
{
    public partial class SuaMaGiamGia : Form
    {
        public SuaMaGiamGia()
        {
            InitializeComponent();
        }
        private int mavc;

        public SuaMaGiamGia(int mavc)
        {
            InitializeComponent();
            this.mavc = mavc;
        }

        private void btnSuaMaGiamGiaMua1Tang1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SuaMaGiamGiaMua1Tang1 suaMaGiamGiaMua1Tang1 = new SuaMaGiamGiaMua1Tang1();
            suaMaGiamGiaMua1Tang1.ShowDialog();
            this.Show();
        }

        private void SuaMaGiamGia_Load(object sender, EventArgs e)
        {
            // Giới hạn phần trăm giảm
            numGiaTriGiamTheoPT.Minimum = 0;
            numGiaTriGiamTheoPT.Maximum = 100;

            // Load dữ liệu các control
            LoadLoaiMaGG();
            LoadLoaiSanPham();
            LoadSanPham();

            // Lấy thông tin mã giảm giá cần sửa
            var voucher = VoucherBUS.Instance.GetVoucherByID(mavc);
            if (voucher == null)
            {
                MessageBox.Show("Không tìm thấy mã giảm giá cần sửa.");
                this.Close();
                return;
            }

            // Gán dữ liệu lên form
            txtMaGiamGia.Text = voucher.Code;
            dtpNgayBatDau.Value = voucher.Ngaybd;
            dtpNgayHetHan.Value = voucher.Ngaykt;
            txtGiaTriDonHangToiThieu.Text = voucher.DieuKien?.ToString() ?? "";
            cbbLoaiMaGiamGia.SelectedValue = voucher.Maloaivc;
            cbbLoaiSanPham.SelectedValue = voucher.Maloai ?? -1;

            // Hiển thị đúng control giá trị giảm
            if (voucher.Maloaivc == 1) // Giảm theo %
            {
                if (voucher.Giatri > numGiaTriGiamTheoPT.Maximum)
                {
                    MessageBox.Show($"Giá trị phần trăm giảm vượt quá giới hạn ({numGiaTriGiamTheoPT.Maximum}%).");
                    this.Close();
                    return;
                }

                numGiaTriGiamTheoPT.Value = voucher.Giatri;
                numGiaTriGiamTheoPT.Visible = true;
                txtGiaTriGiam.Visible = false;
            }
            else if (voucher.Maloaivc == 3) // Giảm theo giá trị thực
            {
                txtGiaTriGiam.Text = voucher.Giatri.ToString();
                txtGiaTriGiam.Visible = true;
                numGiaTriGiamTheoPT.Visible = false;
            }
            else
            {
                MessageBox.Show("Chỉ hỗ trợ sửa mã giảm giá loại phần trăm hoặc giá trị thực.");
                this.Close();
                return;
            }

            // Gán sản phẩm áp dụng
            var chiTiet = DanhSachSanPhamBUS.Instance.GetChiTietVoucher(mavc);
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                int id = Convert.ToInt32(row.Cells["ID"].Value);
                if (chiTiet.Contains(id))
                    row.Selected = true;
            }
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);

        }
        private void LoadLoaiMaGG()
        {
            DataTable dt = VoucherBUS.Instance.GetVoucherTypes();

            //lọc loại mã 1 và 3
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Maloaivc = 1 OR Maloaivc = 3";

            cbbLoaiMaGiamGia.DataSource = dv;
            cbbLoaiMaGiamGia.DisplayMember = "Tenloai";
            cbbLoaiMaGiamGia.ValueMember = "Maloaivc";
            cbbLoaiMaGiamGia.SelectedIndex = -1;

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string code = txtMaGiamGia.Text.Trim();

            // Kiểm tra trùng mã
            if (VoucherBUS.Instance.CheckCodeExists(code, mavc))
            {
                MessageBox.Show("Mã giảm giá đã tồn tại. Vui lòng chọn mã khác.");
                return;
            }

            // Kiểm tra ngày
            if (dtpNgayBatDau.Value >= dtpNgayHetHan.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
                return;
            }

            // Xác định loại mã
            int maloaivc = Convert.ToInt32(cbbLoaiMaGiamGia.SelectedValue);
            decimal giatri = 0;

            if (maloaivc == 1) // phần trăm
            {
                giatri = numGiaTriGiamTheoPT.Value;
                if (giatri > numGiaTriGiamTheoPT.Maximum)
                {
                    MessageBox.Show($"Giá trị phần trăm giảm không được vượt quá {numGiaTriGiamTheoPT.Maximum}%.");
                    return;
                }
            }
            else if (maloaivc == 3) // giá trị thực
            {
                if (!decimal.TryParse(txtGiaTriGiam.Text.Trim(), out giatri))
                {
                    MessageBox.Show("Giá trị giảm không hợp lệ.");
                    return;
                }
            }

            // Tạo DTO
            VoucherDTO dto = new VoucherDTO
            {
                Mavc = mavc,
                Code = code,
                Giatri = giatri,
                Ngaybd = dtpNgayBatDau.Value,
                Ngaykt = dtpNgayHetHan.Value,
                DieuKien = string.IsNullOrWhiteSpace(txtGiaTriDonHangToiThieu.Text) ? null : (decimal?)decimal.Parse(txtGiaTriDonHangToiThieu.Text),
                Maloaivc = maloaivc,
                Maloai = cbbLoaiSanPham.SelectedIndex != -1 ? (int?)Convert.ToInt32(cbbLoaiSanPham.SelectedValue) : null
            };

            // Cập nhật voucher
            bool ok = VoucherBUS.Instance.UpdateVoucher(dto);

            // Cập nhật chi tiết sản phẩm áp dụng
            List<int> idkcspList = new List<int>();
            foreach (DataGridViewRow row in dgvSanPham.SelectedRows)
            {
                if (row.Cells["ID"].Value != null)
                {
                    idkcspList.Add(Convert.ToInt32(row.Cells["ID"].Value));
                }
            }

            bool chiTietOk = VoucherBUS.Instance.UpdateVoucherChiTiet(mavc, idkcspList);

            MessageBox.Show(ok && chiTietOk ? "Cập nhật thành công!" : "Cập nhật thất bại!");
            if (ok && chiTietOk) this.Close();

        }

        private void cbbLoaiMaGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoaiMaGiamGia.SelectedItem is DataRowView row)
            {
                int maloaivc = Convert.ToInt32(row["Maloaivc"]);

                if (maloaivc == 1)
                {
                    numGiaTriGiamTheoPT.Visible = true;
                    txtGiaTriGiam.Visible = false;
                }
                else if (maloaivc == 3)
                {
                    txtGiaTriGiam.Visible = true;
                    numGiaTriGiamTheoPT.Visible = false;
                }
            }

        }
    }
}
