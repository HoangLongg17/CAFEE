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
using DTO;

namespace CF36
{
    public partial class ThemKhachHang : Form
    {
        public ThemKhachHang()
        {
            InitializeComponent();
        }
        public Action OnCustomerAdded { get; set; }
        private bool IsValidPhone(string phone)
        {
            // Kiểm tra không rỗng, chỉ chứa số, độ dài từ 9–11 ký tự
            return !string.IsNullOrWhiteSpace(phone) &&
                   phone.All(char.IsDigit) &&
                   phone.Length >= 9 && phone.Length <= 11;
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            // Kiểm tra dữ liệu đầu vào

            if (!KiemTraDuLieuHopLe(tenKH, sdt))
                return;

            // Tạo đối tượng KHACHHANGDTO
            KhachHangDTO khachHang = new KhachHangDTO(0, tenKH, sdt, 1); // Tichdiem mặc định là 1

            // Gọi phương thức thêm khách hàng từ BUS
            bool result = KhachHangBUS.ThemKH(khachHang);

            // Kiểm tra kết quả và thông báo
            if (result)
            {
                MessageBox.Show("Thêm khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Clear();
                txtSDT.Clear();
                txtTichDiem.Text = "1";
                OnCustomerAdded?.Invoke(); // Gọi lại hàm reload từ form cha
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại. Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemKhachHang_Load(object sender, EventArgs e)
        {
            txtTichDiem.Text = "1";
            txtTichDiem.Enabled = false;
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);

        }
    }
}
