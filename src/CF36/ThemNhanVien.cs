using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;
namespace CF36
{
    public partial class ThemNhanVien : Form
    {
        public delegate void NhanVienAddedHandler(object sender, EventArgs e);
        public event NhanVienAddedHandler NhanVienAdded;
        public ThemNhanVien()
        {
            InitializeComponent();
            this.Load += ThemNhanVien_Load;
        }
        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            KhoiTaoComboBox();
            dTPNgaySinh.Value = DateTime.Now;
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);

        }
        private void KhoiTaoComboBox()
        {
            cbbViTri.Items.Clear();
            cbbViTri.Items.AddRange(new object[] { "Admin", "NhanVien" });
            cbbViTri.SelectedIndex = 1;
            cbbNganHang.Items.Clear();
            cbbNganHang.Items.AddRange(new object[] { "VCB", "MB", "AGR", "OCB", "SCB" });
            cbbNganHang.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // mã nhân viên
            if (!NhanVienBUS.IsValidMaNhanVien(txtMaNhanVien.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ. Mã phải có định dạng 'NVxx' hoặc 'ADxx' (x là chữ số).", "Lỗi Nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return;
            }
            //tên tài khoản
            if(!NhanVienBUS.IsValidUsername(txtTenTaiKhoan.Text.Trim()))
    {
                MessageBox.Show("Tên tài khoản không hợp lệ. Vui lòng chỉ sử dụng chữ cái (không dấu) và số.", "Lỗi Nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTaiKhoan.Focus();
                return;
            }
            // mật khẩu
            if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu và Nhập lại mật khẩu không khớp.", "Lỗi Nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLaiMatKhau.Focus();
                return;
            }
            // lương
            if (!decimal.TryParse(txtLuongTheoGio.Text, out decimal luongTheoGio))
            {
                MessageBox.Show("Lương không hợp lệ. Vui lòng nhập số.", "Lỗi Nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuongTheoGio.Focus();
                return;
            }

            NhanVienDTO nvMoi = new NhanVienDTO
            {
                Mand = txtMaNhanVien.Text.Trim(),
                Hoten = txtTenNhanVien.Text,
                Sdt = txtSoDienThoai.Text,
                Diachi = txtDiaChi.Text,
                Email = txtEmail.Text,
                NgaySinh = dTPNgaySinh.Value,
                Tk = txtTenTaiKhoan.Text.Trim(),
                Mk = txtMatKhau.Text,
                Vitri = cbbViTri.SelectedItem?.ToString(),
                Luong = luongTheoGio,
                Bank = cbbNganHang.SelectedItem?.ToString(),
                Stk = txtSoTaiKhoan.Text
            };

            if (NhanVienBUS.themNV(nvMoi))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                NhanVienAdded?.Invoke(this, EventArgs.Empty);

                btnLamMoi_Click(sender, e);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtTenTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtNhapLaiMatKhau.Clear();
            txtLuongTheoGio.Clear();
            txtSoTaiKhoan.Clear();

            cbbViTri.SelectedIndex = 1;
            cbbNganHang.SelectedIndex = -1;
            dTPNgaySinh.Value = DateTime.Now;

            txtMaNhanVien.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlpall_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
