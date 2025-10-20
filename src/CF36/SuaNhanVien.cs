using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BUS;
using DTO;

namespace CF36
{
    public partial class SuaNhanVien : Form
    {
        private readonly string _maNhanVienCanSua;
        public SuaNhanVien(string maNhanVien)
        {
            InitializeComponent();
            _maNhanVienCanSua = maNhanVien;
            this.Load += SuaNhanVien_Load;
        }
        private void SuaNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;

            KhoiTaoComboBox();
            LoadThongTinNhanVien(_maNhanVienCanSua);
        }
        private void KhoiTaoComboBox()
        {

            cbbViTri.Items.Clear();
            cbbViTri.Items.AddRange(new object[] { "Admin", "NhanVien" });

            cbbNganHang.Items.Clear();
            cbbNganHang.Items.AddRange(new object[] { "VCB", "MB", "AGR", "OCB", "SCB" });
        }
        private void cbbViTri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbNganHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tlpall_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadThongTinNhanVien(string maNhanVien)
        {
            try
            {
                NhanVienDTO nv = NhanVienBUS.LayNhanVienTheoID(maNhanVien);

                if (nv != null)
                {
                    txtMaNhanVien.Text = nv.Mand;
                    txtTenNhanVien.Text = nv.Hoten;
                    txtSoDienThoai.Text = nv.Sdt;
                    txtEmail.Text = nv.Email;

                    if (nv.NgaySinh > DateTime.MinValue)
                        dTPNgaySinh.Value = nv.NgaySinh;

                    txtTenTaiKhoan.Text = nv.Tk;
                    txtMatKhau.Text = nv.Mk;

                    cbbViTri.SelectedItem = nv.Vitri;
                    cbbNganHang.SelectedItem = nv.Bank;

                    txtLuongTheoGio.Text = nv.Luong.ToString();
                    txtSTK.Text = nv.Stk;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên có mã: " + maNhanVien, "Lỗi Tải Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message + "\nVui lòng kiểm tra kết nối database.", "Lỗi Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]+$");
        }
        private bool IsValidMaNhanVien(string maNhanVien)
        {
            return Regex.IsMatch(maNhanVien, @"^(NV|AD)\d{2}$", RegexOptions.IgnoreCase);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!IsValidMaNhanVien(txtMaNhanVien.Text))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ. Mã phải có định dạng 'NVxx' hoặc 'ADxx' (x là chữ số).", "Lỗi Nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return;
            }

            if (!IsValidUsername(txtTenTaiKhoan.Text))
            {
                MessageBox.Show("Tên tài khoản không hợp lệ. Vui lòng chỉ sử dụng chữ cái (không dấu) và số.", "Lỗi Nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTaiKhoan.Focus();
                return;
            }

            if (!decimal.TryParse(txtLuongTheoGio.Text, out decimal luongTheoGio))
            {
                MessageBox.Show("Lương theo giờ không hợp lệ.", "Lỗi Nhập liệu");
                return;
            }

            if (cbbViTri.SelectedItem == null || cbbNganHang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Vị trí và Ngân hàng.", "Lỗi Nhập liệu");
                return;
            }

            NhanVienDTO nvMoi = new NhanVienDTO
            {
                Mand = txtMaNhanVien.Text,
                Hoten = txtTenNhanVien.Text,
                Sdt = txtSoDienThoai.Text,
                Email = txtEmail.Text,
                NgaySinh = dTPNgaySinh.Value,
                Tk = txtTenTaiKhoan.Text,
                Mk = txtMatKhau.Text,
                Vitri = cbbViTri.SelectedItem.ToString(),
                Luong = luongTheoGio,
                Bank = cbbNganHang.SelectedItem.ToString(),
                Stk = txtSTK.Text
            };

            if (NhanVienBUS.SuaNV(nvMoi))
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadThongTinNhanVien(_maNhanVienCanSua);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
