using BUS;
using System;
using System.Windows.Forms;

namespace CF36
{
    public partial class DangNhapNV : Form
    {
        private DangNhapNVBUS userBUS = new DangNhapNVBUS();

        public DangNhapNV()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusernv.Text.Trim();
            string password = txtpasswordnv.Text.Trim();

            // 🛑 Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔐 Login
            var result = userBUS.Login(username, password);

            // ❌ Đăng nhập thất bại
            if (!result.success)
            {
                MessageBox.Show(result.message,
                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Đăng nhập thành công
            MessageBox.Show(result.message,
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 👉 Lấy thông tin từ result.user
            string manv = result.user.Manv;
            string vitri = result.user.Vitri; // Lấy vị trí

            if (string.IsNullOrEmpty(manv))
            {
                MessageBox.Show("Không tìm thấy mã nhân viên.",
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🌍 Lưu user hiện tại (context)
            CurrentUser.Manv = manv;

            this.Hide();

            // 🚀 PHÂN QUYỀN MỞ FORM DỰA TRÊN VỊ TRÍ
            if (vitri == "Nvkho")
            {
                // Giả sử form NhanVienKho có constructor tương tự hoặc không tham số
                // Bạn cần đảm bảo đã tạo form NhanVienKho.cs trong project
                NhanVienKho frmKho = new NhanVienKho(result.user.Hoten,
                    username,
                    manv);
                frmKho.ShowDialog();
            }
            else if (vitri == "Nvthungan")
            {
                // Mở form thu ngân (NHANVIEN)
                NHANVIEN nhanvien = new NHANVIEN(
                    result.user.Hoten,
                    username,
                    manv
                );
                nhanvien.ShowDialog();
            }
            else
            {
                // Xử lý các vị trí khác (Ví dụ: Quanly)
                // Mặc định có thể mở form NHANVIEN hoặc thông báo
                MessageBox.Show($"Chức năng cho vị trí '{vitri}' đang được cập nhật.", "Thông báo");

                // Nếu muốn Quản lý cũng vào form NHANVIEN thì bỏ comment dòng dưới:
                /*
                NHANVIEN frmDefault = new NHANVIEN(result.user.Hoten, username, manv);
                frmDefault.ShowDialog();
                */
            }

            this.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhapNV_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(
                this,
                Properties.Resources.exit,
                Properties.Resources.delete,
                Properties.Resources.refresh,
                Properties.Resources.done
            );

            UIText.ApplyButtonTextStyle(this);
        }

        private void btnPassword_Click_1(object sender, EventArgs e)
        {
            if (txtpasswordnv.PasswordChar == '*')
            {
                txtpasswordnv.PasswordChar = '\0';
                btnPassword.Text = "🙈";
            }
            else
            {
                txtpasswordnv.PasswordChar = '*';
                btnPassword.Text = "👁️";
            }
        }
    }
}
