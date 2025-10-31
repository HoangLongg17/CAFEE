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
using System.IO; // Thêm thư viện này

namespace CF36
{
    public partial class ThanhToan : Form
    {
        private List<DanhSachSanPhamDTO> danhSachMua;
        private string maND;
        private int? maKH;
        private KetQuaGiamGiaDTO ketQua;
        private decimal tongTienGoc;
        private decimal tongTienSauGiam;
        public void SetMaKH(int? maKH)
        {
            this.maKH = maKH;
        }
        private int? maVoucherId; // kiểu int? — đúng để truyền vào DB
        private string maVoucherCode; // kiểu string — dùng để hiển thị
        public string SoDienThoai { get; set; } = "";
        public string TenKhachHang { get; set; } = "Khách lẻ";
        public ThanhToan(List<DanhSachSanPhamDTO> danhSach, string maND, int? maKH, int? maVoucherId, string maVoucherCode, KetQuaGiamGiaDTO ketQua)
        {
            InitializeComponent();
            this.danhSachMua = danhSach;
            this.maND = maND;
            this.maKH = maKH;
            this.maVoucherId = maVoucherId;
            this.maVoucherCode = maVoucherCode;
            this.ketQua = ketQua;
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
                    Text = "Số lượng: " + sp.SoLuong,
                    Font = new Font("Segoe UI", 9),
                    AutoSize = true,
                    Location = new Point(100, yOffset)
                };
                panel.Controls.Add(lblSL);
                yOffset = lblSL.Bottom + 5;

                // Tổng tiền
                Label lblTong = new Label
                {
                    Text = sp.LaSanPhamTang
                        ? "Tổng: 0 đ (Tặng)"
                        : "Tổng: " + (sp.GiaBan * sp.SoLuong).ToString("N0") + " đ",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(100, yOffset)
                };
                panel.Controls.Add(lblTong);

                panel.Height = Math.Max(pic.Bottom + 10, lblTong.Bottom + 10);

                ToolTip tooltip = new ToolTip();
                tooltip.SetToolTip(panel, sp.LaSanPhamTang
                    ? $"🎁 Sản phẩm tặng\nTên: {sp.TenSP}\nSize: {sp.KichCo}"
                    : $"Tên: {sp.TenSP}\nSize: {sp.KichCo}\nGiá: {sp.GiaBan:N0} đ\nSố lượng: {sp.SoLuong}");
                panel.Tag = sp;
                flpSanPham.Controls.Add(panel);
            }
        }
        private void ThanhToan_Load(object sender, EventArgs e)
        {
            // UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            // UIText.ApplyButtonTextStyle(this);
            HienThiSanPham();
            tongTienGoc = new BanHangBUS().TinhTongTien(danhSachMua);

            // Đảm bảo ketQua không null trước khi truy cập
            if (ketQua == null)
            {
                ketQua = new KetQuaGiamGiaDTO();
            }

            tongTienSauGiam = new BanHangBUS().TinhTienSauGiam(tongTienGoc, ketQua.TienGiam);

            // Giả sử ông có Label tên lbTongTien, lblTenKhachHang, lblSDT
            lbTongTien.Text = tongTienSauGiam.ToString("N0") + " đ";
            lblTenKhachHang.Text = TenKhachHang;
            lblSDT.Text = SoDienThoai;
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            string raw = txtTienKhachDua.Text.Replace(",", "").Trim();

            if (decimal.TryParse(raw, out decimal tienKhach))
            {
                // (Sửa) Không cần gọi TinhTongTien ở đây nữa
                decimal tienTraLai = tienKhach - tongTienSauGiam;
                txtTienTraLai.Text = tienTraLai >= 0 ? tienTraLai.ToString("N0") : "0";

                // (Sửa) Kiểm tra lblCanhBao
                if (lblCanhBao != null)
                {
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
            }
            else
            {
                txtTienTraLai.Text = "0";
                if (lblCanhBao != null) lblCanhBao.Text = "";
            }

        }

        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // (Thêm) Nhấn Enter để thanh toán
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnThanhtoan_Click(sender, e);
                e.Handled = true;
            }
        }

        private void txtTienKhachDua_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTienKhachDua.Text.Replace(",", "").Trim(), out decimal value))
            {
                txtTienKhachDua.Text = value.ToString("N0");
            }
        }
        private bool KiemTraTienKhachDua(out decimal tienKhach)
        {
            tienKhach = 0;
            string raw = txtTienKhachDua.Text.Replace(",", "").Trim();

            if (!decimal.TryParse(raw, out tienKhach))
            {
                MessageBox.Show("Vui lòng nhập số tiền khách đưa hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (tienKhach < tongTienSauGiam)
            {
                MessageBox.Show($"❌ Tiền khách đưa không đủ để thanh toán.\nTổng tiền: {tongTienSauGiam:N0} đ\nKhách đưa: {tienKhach:N0} đ", "Thiếu tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void InHoaDon(int mahd, List<BanHangDTO> danhSach, string maND, int? maVoucher, decimal tienKhach)
        {
            string tenNV = NhanVienBUS.GetTenNguoiDung(maND);
            var ngayLap = DateTime.Now;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===== HÓA ĐƠN BÁN HÀNG =====");
            sb.AppendLine($"Mã hóa đơn: {mahd}");
            sb.AppendLine($"Nhân viên lập: {tenNV}");
            sb.AppendLine($"Thời gian: {ngayLap:dd/MM/yyyy HH:mm}");
            sb.AppendLine("");
            sb.AppendLine($"Khách hàng: {this.TenKhachHang}"); // Dùng thuộc tính
            sb.AppendLine($"SĐT: {this.SoDienThoai}"); // Dùng thuộc tính
            sb.AppendLine("Sản phẩm:");
            foreach (var sp in danhSach.Where(sp => !sp.LaSanPhamTang))
            {
                sb.AppendLine($"- {sp.TenSP} | Size: {sp.KichCo} | SL: {sp.SoLuong} | Đơn giá: {sp.GiaBan:N0} đ");
            }

            if (maVoucher.HasValue)
            {
                sb.AppendLine("");
                sb.AppendLine($"Áp dụng mã giảm giá: {this.maVoucherCode}"); // Dùng mã code
            }

            sb.AppendLine("");
            sb.AppendLine($"Tổng tiền: {tongTienSauGiam:N0} đ");
            decimal tienTraLai = tienKhach - tongTienSauGiam;
            sb.AppendLine($"Tiền khách đưa: {tienKhach:N0} đ");
            sb.AppendLine($"Tiền trả lại: {tienTraLai:N0} đ");
            MessageBox.Show(sb.ToString(), "HÓA ĐƠN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool XacNhanThanhToan(List<BanHangDTO> danhSachBanHang, List<DanhSachSanPhamDTO> danhSachMua, BanHangBUS bus)
        {
            StringBuilder xacNhan = new StringBuilder();
            xacNhan.AppendLine("Bạn có chắc muốn thanh toán đơn hàng sau?");
            xacNhan.AppendLine("──────────────────────────────");

            foreach (var sp in danhSachBanHang.Where(sp => !sp.LaSanPhamTang))
            {
                xacNhan.AppendLine($"- {sp.TenSP} | Size: {sp.KichCo} | SL: {sp.SoLuong} | Đơn giá: {sp.GiaBan:N0} đ");
            }

            xacNhan.AppendLine("──────────────────────────────");
            xacNhan.AppendLine($"Tổng tiền: {tongTienSauGiam:N0} đ");

            var result = MessageBox.Show(xacNhan.ToString(), "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maND))
            {
                MessageBox.Show("Không xác định được nhân viên. Vui lòng đăng nhập lại.");
                return;
            }
            var bus = new BanHangBUS();
            if (ketQua == null)
            {
                ketQua = new KetQuaGiamGiaDTO();
            }
            if (danhSachMua.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để thanh toán.");
                return;
            }
            if (!KiemTraTienKhachDua(out decimal tienKhach))
            {
                return; //Dừng nếu tiền không hợp lệ
            }

            var danhSachBanHang = bus.ChuyenDoiDanhSachBanHang(danhSachMua);

            if (ketQua?.SanPhamTang != null && ketQua.SanPhamTang.Count > 0)
            {
                var sanPhamTangGop = ketQua.SanPhamTang
                    .GroupBy(sp => sp.IdKcsp)
                    .Select(g => new BanHangDTO
                    {
                        IdKcsp = g.Key,
                        TenSP = g.First().TenSP,
                        KichCo = g.First().KichCo,
                        LaSanPhamTang = true,
                        SoLuong = g.Sum(x => x.SoLuong),
                        MaSP = g.First().MaSP,
                        GiaBan = g.First().GiaBan,
                        Maloai = g.First().Maloai,
                        MaSanPhamGoc = g.First().MaSanPhamGoc,
                        SoLuongTon = g.First().SoLuongTon,
                        DuongDanAnh = g.First().DuongDanAnh,
                        TenLoai = g.First().TenLoai,
                        TrangThaiText = g.First().TrangThaiText
                    }).ToList();

                danhSachBanHang.AddRange(sanPhamTangGop);
            }

            //Kiểm tra tồn kho trước khi thanh toán
            foreach (var sp in danhSachBanHang)
            {
                int tonKho = DanhSachSanPhamDAO.GetSoLuongTon(sp.IdKcsp);
                if (tonKho < sp.SoLuong)
                {
                    MessageBox.Show(
                        $"❌ Sản phẩm {sp.TenSP} - Size {sp.KichCo} không đủ tồn kho.\n" +
                        $"Tồn kho: {tonKho}, cần: {sp.SoLuong}",
                        "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                    return;
                }
            }
            if (!XacNhanThanhToan(danhSachBanHang, danhSachMua, bus))
            {
                return;
            }

            // (SỬA LẠI DÒNG NÀY)
            // Thêm 'this.tongTienSauGiam' làm tham số cuối cùng
            int mahd = bus.XuatHoaDon(maKH, maND, danhSachBanHang, maVoucherId, this.tongTienSauGiam);
            // ==========================================================

            MessageBox.Show($"✅ Thanh toán thành công. Mã hóa đơn: {mahd}");

            if (MessageBox.Show("Bạn có muốn in hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InHoaDon(mahd, danhSachBanHang, maND, maVoucherId, tienKhach);

                decimal tongTienGoc = bus.TinhTongTien(danhSachMua);
                decimal tongTienSauGiam = bus.TinhTienSauGiam(tongTienGoc, ketQua.TienGiam);

                var hoaDonDTO = new HoaDonDTO
                {
                    MaHD = mahd,
                    NgayLap = DateTime.Now,
                    TenKH = this.TenKhachHang, // Dùng thuộc tính
                    SDTKH = this.SoDienThoai, // Dùng thuộc tính
                    TenNhanVien = NhanVienBUS.GetTenNguoiDung(maND),
                    TongTienGoc = tongTienGoc,
                    TienGiam = ketQua.TienGiam,
                    TongTien = tongTienSauGiam,
                    MaVoucher = maVoucherCode,
                    PhanTramGiam = ketQua.LoaiVC == 1 ? (int?)ketQua.GiaTri : null,

                    // ==========================================================
                    // (SỬA LỖI ARGUMENTNULLEXCEPTION)
                    // Kiểm tra SanPhamTang có null không
                    SanPhamTang = (ketQua.SanPhamTang != null)
                        ? ketQua.SanPhamTang.Select(sp => new DanhSachSanPhamDTO
                        {
                            TenSP = sp.TenSP,
                            KichCo = sp.KichCo,
                            SoLuong = sp.SoLuong
                        }).ToList()
                        : new List<DanhSachSanPhamDTO>() // Nếu null, dùng list rỗng
                    // ==========================================================
                };

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = $"HoaDon_{mahd}.pdf"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bus.XuatHoaDonPDF(hoaDonDTO, danhSachMua, sfd.FileName);
                    MessageBox.Show("✅ Hóa đơn PDF đã được xuất thành công!");
                }
            }
            var danhSachCapNhat = danhSachBanHang
                .GroupBy(sp => new { sp.IdKcsp, sp.LaSanPhamTang })
                .Select(g => new DanhSachSanPhamDTO
                {
                    IdKcsp = g.Key.IdKcsp,
                    TenSP = g.First().TenSP,
                    KichCo = g.First().KichCo,
                    LaSanPhamTang = g.Key.LaSanPhamTang,
                    SoLuong = 1
                }).ToList();

            BanHangBUS.CapNhatTonKhoSauThanhToan(danhSachCapNhat);
            var formBanHang = Application.OpenForms["BANHANG"] as BANHANG;
            if (formBanHang != null)
            {
                formBanHang.CapNhatGiaoDienSauThanhToan();
            }
            this.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}