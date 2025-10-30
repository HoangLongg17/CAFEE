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
    public partial class ThanhToan : Form
    {
        private List<DanhSachSanPhamDTO> danhSachMua;
        public ThanhToan(List<DanhSachSanPhamDTO> danhSach)
        {
            InitializeComponent();
            danhSachMua = danhSach;
            HienThiSanPham(); // hàm để hiển thị danh sách mua

        }
        private void HienThiSanPham()
        {
            flpSanPham.Controls.Clear();
            flpSanPham.AutoScroll = true;

            foreach (var sp in danhSachMua)
            {
                Panel panel = new Panel
                {
                    Width = 250,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5),
                    BackColor = sp.LaSanPhamTang ? Color.LightYellow : Color.WhiteSmoke
                };

                // Ảnh sản phẩm
                PictureBox pic = new PictureBox
                {
                    Width = 80,
                    Height = 80,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(10, 10)
                };

                string rootPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                string fullPath = Path.Combine(rootPath, sp.DuongDanAnh ?? "");
                if (File.Exists(fullPath))
                {
                    byte[] imageBytes = File.ReadAllBytes(fullPath);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pic.Image = Image.FromStream(ms);
                    }
                }
                panel.Controls.Add(pic);

                // Tên sản phẩm
                Label lblTen = new Label
                {
                    Text = sp.LaSanPhamTang ? $"🎁 {sp.TenSP} size {sp.KichCo}" : $"{sp.TenSP} size {sp.KichCo}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    MaximumSize = new Size(140, 0),
                    AutoSize = true
                };
                lblTen.Location = new Point(100, 10);
                panel.Controls.Add(lblTen);

                // Sau khi thêm lblTen, layout mới được tính
                panel.PerformLayout();
                int yOffset = lblTen.Bottom + 5;

                // Đơn giá
                Label lblGia = new Label
                {
                    Text = sp.LaSanPhamTang ? "Đơn giá: Tặng" : "Đơn giá: " + sp.GiaBan.ToString("N0") + " đ",
                    Font = new Font("Segoe UI", 9),
                    AutoSize = true,
                    Location = new Point(100, yOffset)
                };
                panel.Controls.Add(lblGia);
                yOffset = lblGia.Bottom + 5;

                // Số lượng
                Label lblSL = new Label
                {
                    Text = "Số lượng: 1",
                    Font = new Font("Segoe UI", 9),
                    AutoSize = true,
                    Location = new Point(100, yOffset)
                };
                panel.Controls.Add(lblSL);
                yOffset = lblSL.Bottom + 5;

                // Tổng tiền
                Label lblTong = new Label
                {
                    Text = sp.LaSanPhamTang ? "Tổng: 0 đ (Tặng)" : "Tổng: " + sp.GiaBan.ToString("N0") + " đ",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(100, yOffset)
                };
                panel.Controls.Add(lblTong);

                // Tăng chiều cao panel theo nội dung
                panel.Height = Math.Max(pic.Bottom + 10, lblTong.Bottom + 10);

                // Tooltip
                ToolTip tooltip = new ToolTip();
                tooltip.SetToolTip(panel, sp.LaSanPhamTang
                    ? $"🎁 Sản phẩm tặng\nTên: {sp.TenSP}\nSize: {sp.KichCo}"
                    : $"Tên: {sp.TenSP}\nSize: {sp.KichCo}\nGiá: {sp.GiaBan:N0} đ");

                // Thêm vào FlowLayoutPanel
                flpSanPham.Controls.Add(panel);
            }
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);

        }
        private decimal TinhTongTien()
        {
            decimal tong = 0;
            foreach (var sp in danhSachMua)
            {
                tong += sp.GiaBan; // nếu có số lượng thì nhân thêm
            }
            return tong;
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            string raw = txtTienKhachDua.Text.Replace(",", "").Trim();

            if (decimal.TryParse(raw, out decimal tienKhach))
            {
                decimal tongTien = TinhTongTien();
                decimal tienTraLai = tienKhach - tongTien;

                txtTienTraLai.Text = tienTraLai >= 0 ? tienTraLai.ToString("N0") : "0";

                // ✅ Hiện cảnh báo nếu không đủ tiền
                if (tienTraLai < 0)
                {
                    lblCanhBao.Text = "⚠️ Tiền khách đưa không đủ!";
                    lblCanhBao.ForeColor = Color.Red;
                }
                else
                {
                    lblCanhBao.Text = "";
                }
            }
            else
            {
                txtTienTraLai.Text = "0";
                lblCanhBao.Text = "";
            }

        }

        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép số và phím điều khiển (Backspace, Delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn ký tự không hợp lệ
            }

        }

        private void txtTienKhachDua_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTienKhachDua.Text.Replace(",", "").Trim(), out decimal value))
            {
                txtTienKhachDua.Text = value.ToString("N0"); // định dạng kiểu 1,000,000
            }

        }
    }
}
