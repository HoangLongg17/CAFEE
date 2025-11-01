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

            // Gọi hàm kiểm tra dữ liệu
            if (!KiemTraDuLieuHopLe(tenKH, sdt))
                return;

            // Kiểm tra tích điểm
            if (!int.TryParse(txtTichDiem.Text.Trim(), out tichdiem))
            {
                MessageBox.Show("Tích điểm phải là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private bool KiemTraDuLieuHopLe(string tenKH, string sdt)
        {
            if (string.IsNullOrWhiteSpace(tenKH))
            {
                MessageBox.Show("Tên khách hàng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tenKH.Length > 50)
            {
                MessageBox.Show("Tên khách hàng không được vượt quá 50 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (sdt.Length < 10 || sdt.Length > 11)
            {
                MessageBox.Show("Số điện thoại phải từ 10 đến 11 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void SuaKhachHang_Load(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = khachHang.Tenkh;
            txtSoDienThoai.Text = khachHang.Sdt;
            txtTichDiem.Text = khachHang.Tichdiem.ToString();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
