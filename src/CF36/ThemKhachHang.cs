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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên và số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhone(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
