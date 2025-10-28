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
using BUS;
using DAO;
namespace CF36
{
    public partial class SuaKhachHang : Form
    {
        private KhachHangDTO khachHang;
        public SuaKhachHang(KhachHangDTO kh)
        {
            InitializeComponent();
            khachHang = kh;
        }
        private bool IsValidPhone(string phone)
        {
            // Kiểm tra không rỗng, chỉ chứa số, độ dài từ 9–11 ký tự
            return !string.IsNullOrWhiteSpace(phone) &&
                   phone.All(char.IsDigit) &&
                   phone.Length >= 9 && phone.Length <= 11;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenKH = txtTenKhachHang.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            int tichdiem;

            if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(sdt) || !int.TryParse(txtTichDiem.Text, out tichdiem))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhone(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHangDTO khMoi = new KhachHangDTO(khachHang.Makh, tenKH, sdt, tichdiem);

            if (KhachHangBUS.SuaKH(khMoi))
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SuaKhachHang_Load(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = khachHang.Tenkh;
            txtSoDienThoai.Text = khachHang.Sdt;
            txtTichDiem.Text = khachHang.Tichdiem.ToString();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
