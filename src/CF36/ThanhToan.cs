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
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);
            HienThiSanPham();
            tongTienGoc = new BanHangBUS().TinhTongTien(danhSachMua);
            tongTienSauGiam = new BanHangBUS().TinhTienSauGiam(tongTienGoc, ketQua?.TienGiam ?? 0);
            lbTongTien.Text = tongTienSauGiam.ToString("N0") + " đ";
            lblTenKhachHang.Text = TenKhachHang;
            lblSDT.Text = SoDienThoai;
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            string raw = txtTienKhachDua.Text.Replace(",", "").Trim();

            if (decimal.TryParse(raw, out decimal tienKhach))
            {
                decimal tongTien = new BanHangBUS().TinhTongTien(danhSachMua);
                decimal tienTraLai = tienKhach - tongTienSauGiam;

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
            sb.AppendLine($"Khách hàng: {TenKhachHang}");
            sb.AppendLine($"SĐT: {SoDienThoai}");
            sb.AppendLine("Sản phẩm:");
            foreach (var sp in danhSach.Where(sp => !sp.LaSanPhamTang))
            {
                sb.AppendLine($"- {sp.TenSP} | Size: {sp.KichCo} | SL: {sp.SoLuong} | Đơn giá: {sp.GiaBan:N0} đ");
            }

            if (maVoucher.HasValue)
            {
                sb.AppendLine("");
                sb.AppendLine($"Áp dụng mã giảm giá: {maVoucher.Value}");
            }

            decimal tongTien = danhSach.Where(sp => !sp.LaSanPhamTang).Sum(sp => sp.SoLuong * sp.GiaBan);
            sb.AppendLine("");
            sb.AppendLine($"Tổng tiền: {tongTienSauGiam:N0} đ");
            decimal tienTraLai = tienKhach - tongTienSauGiam;
            sb.AppendLine($"Tiền khách đưa: {tienKhach:N0} đ");
            sb.AppendLine($"Tiền trả lại: {tienTraLai:N0} đ");
            MessageBox.Show(sb.ToString(), "HÓA ĐƠN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool XacNhanThanhToan(List<BanHangDTO> danhSachBanHang, BanHangBUS bus)
        {
            StringBuilder xacNhan = new StringBuilder();
            xacNhan.AppendLine("Bạn có chắc muốn thanh toán đơn hàng sau?");
            xacNhan.AppendLine("──────────────────────────────");

            foreach (var sp in danhSachBanHang.Where(sp => !sp.LaSanPhamTang))
            {
                xacNhan.AppendLine($"- {sp.TenSP} | Size: {sp.KichCo} | SL: {sp.SoLuong} | Đơn giá: {sp.GiaBan:N0} đ");
            }

            decimal tongTien = bus.TinhTongTien(
                danhSachBanHang.Select(sp => new DanhSachSanPhamDTO
                {
                    GiaBan = sp.GiaBan,
                    SoLuong = sp.SoLuong,
                    LaSanPhamTang = sp.LaSanPhamTang
                }).ToList()
            );

            xacNhan.AppendLine("──────────────────────────────");
            xacNhan.AppendLine($"Tổng tiền: {tongTien:N0} đ");

            var result = MessageBox.Show(xacNhan.ToString(), "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (danhSachMua == null || danhSachMua.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để thanh toán.");
                return;
            }
            if (!KiemTraTienKhachDua(out decimal tienKhach))
            {
                return; // nếu không đủ tiền thì dừng luôn
            }
            var bus = new BanHangBUS();

            // Cập nhật giá sau giảm
            foreach (var sp in danhSachMua)
            {
                var spGiam = ketQua?.SanPhamDuocGiam?.FirstOrDefault(x => x.IdKcsp == sp.IdKcsp);
                if (spGiam != null)
                {
                    if (sp.GiaGoc == 0) sp.GiaGoc = sp.GiaBan;
                    sp.TienGiam = spGiam.TienGiam;
                    sp.GiaBan = Math.Max(0, sp.GiaGoc - sp.TienGiam);
                }
                else
                {
                    if (sp.GiaGoc == 0) sp.GiaGoc = sp.GiaBan;
                    sp.TienGiam = 0;
                    sp.GiaBan = sp.GiaGoc;
                }
            }

            var danhSachBanHang = bus.ChuyenDoiDanhSachBanHang(danhSachMua, ketQua);

            // Gộp sản phẩm tặng
            if (ketQua?.SanPhamTang?.Count > 0)
            {
                var sanPhamTangGop = ketQua.SanPhamTang
                    .GroupBy(sp => sp.IdKcsp)
                    .Select(g => new BanHangDTO
                    {
                        IdKcsp = g.Key,
                        TenSP = g.First().TenSP,
                        KichCo = g.First().KichCo,
                        LaSanPhamTang = true,
                        SoLuong = 1,
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

            // Kiểm tra tồn kho
            foreach (var sp in danhSachBanHang)
            {
                int tonKho = DanhSachSanPhamDAO.GetSoLuongTon(sp.IdKcsp);
                int soLuongThucTe = sp.LaSanPhamTang ? 1 : sp.SoLuong;
                if (tonKho < soLuongThucTe)
                {
                    MessageBox.Show($"❌ {sp.TenSP} - Size {sp.KichCo} không đủ tồn kho.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Xác nhận thanh toán
            if (!XacNhanThanhToan(danhSachBanHang, bus)) return;

            int mahd = bus.XuatHoaDon(maKH, maND, danhSachBanHang, maVoucherId);
            MessageBox.Show($"✅ Thanh toán thành công. Mã hóa đơn: {mahd}");


            // ✅ In hóa đơn PDF nếu người dùng đồng ý
            if (MessageBox.Show("Bạn có muốn in hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Tính tổng tiền
                var danhSachSP_TinhTien = danhSachBanHang.Select(sp => new DanhSachSanPhamDTO
                {
                    GiaBan = sp.GiaBan,
                    SoLuong = sp.SoLuong,
                    LaSanPhamTang = sp.LaSanPhamTang
                }).ToList();

                // Tính tổng tiền gốc và sau giảm dựa trên từng sản phẩm
                decimal tongTienGoc = danhSachBanHang
                    .Where(sp => !sp.LaSanPhamTang)
                    .Sum(sp => sp.GiaGoc * sp.SoLuong);

                decimal tongTienSauGiam = danhSachBanHang
                    .Where(sp => !sp.LaSanPhamTang)
                    .Sum(sp => (sp.GiaGoc - sp.TienGiam) * sp.SoLuong);

                decimal tongTienGiam = tongTienGoc - tongTienSauGiam;
                if (ketQua == null)
                {
                    ketQua = new KetQuaGiamGiaDTO
                    {
                        SanPhamTang = new List<BanHangDTO>(),
                        SanPhamDuocGiam = new List<DanhSachSanPhamDTO>(),
                        TienGiam = 0,
                        LoaiVC = 0,   // 0 = không áp mã
                        GiaTri = 0
                    };
                }
                // Chuẩn bị dữ liệu hóa đơn
                var hoaDonDTO = new HoaDonDTO
                {
                    MaHD = mahd,
                    NgayLap = DateTime.Now,
                    TenKH = maKH.HasValue ? KhachHangBUS.GetTenKhachHang(maKH.Value) : "Khách lẻ",
                    SDTKH = maKH.HasValue ? KhachHangBUS.GetSDTKhachHang(maKH.Value) : "",
                    TenNhanVien = NhanVienBUS.GetTenNguoiDung(maND),
                    TongTienGoc = tongTienGoc,
                    TienGiam = (ketQua?.LoaiVC == 1 || ketQua?.LoaiVC == 3) ? ketQua.TienGiam : 0,
                    TongTien = tongTienSauGiam,
                    MaVoucher = maVoucherCode,
                    PhanTramGiam = ketQua.LoaiVC == 1 ? (int?)ketQua.GiaTri : null,
                    LoaiVoucher = ketQua.LoaiVC,
                    SanPhamTang = ketQua.SanPhamTang?.Select(sp => new DanhSachSanPhamDTO
                    {
                        TenSP = sp.TenSP,
                        KichCo = sp.KichCo,
                        SoLuong = 1
                    }).ToList() ?? new List<DanhSachSanPhamDTO>(),
                    SanPhamDuocGiam = (ketQua?.LoaiVC == 1 || ketQua?.LoaiVC == 3)
                    ? (ketQua?.SanPhamDuocGiam ?? Enumerable.Empty<DanhSachSanPhamDTO>())
                        .Select(sp => new DanhSachSanPhamDTO
                        {
                            TenSP = sp.TenSP,
                            KichCo = sp.KichCo,
                            SoLuong = sp.SoLuong,
                            IdKcsp = sp.IdKcsp
                        }).ToList()
                    : new List<DanhSachSanPhamDTO>()
                };
                // Dữ liệu chi tiết để in PDF
                var danhSachSP_InPDF = danhSachBanHang.Select(sp =>
                {
                    var spGiam = ketQua.SanPhamDuocGiam?.FirstOrDefault(g => g.IdKcsp == sp.IdKcsp);

                    decimal giaGoc = sp.GiaGoc > 0 ? sp.GiaGoc : sp.GiaBan;
                    decimal tienGiam = spGiam?.TienGiam ?? 0;
                    decimal giaSauGiam = Math.Max(0, giaGoc - tienGiam);

                    return new DanhSachSanPhamDTO
                    {
                        IdKcsp = sp.IdKcsp,
                        MaSP = sp.MaSP,
                        TenSP = sp.TenSP,
                        KichCo = sp.KichCo,
                        SoLuong = sp.LaSanPhamTang ? 1 : sp.SoLuong,
                        GiaGoc = giaGoc,
                        GiaBan = giaSauGiam,
                        TienGiam = tienGiam,
                        LaSanPhamTang = sp.LaSanPhamTang,
                        Maloai = sp.Maloai,
                        MaSanPhamGoc = sp.MaSanPhamGoc,
                        SoLuongTon = sp.SoLuongTon,
                        DuongDanAnh = sp.DuongDanAnh,
                        TenLoai = sp.TenLoai,
                        TrangThaiText = sp.TrangThaiText
                    };
                }).ToList();

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = $"HoaDon_{mahd}.pdf"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bus.XuatHoaDonPDF(hoaDonDTO, danhSachSP_InPDF, sfd.FileName);
                    MessageBox.Show("✅ Hóa đơn PDF đã được xuất thành công!");
                }
            }
            // ✅ Cập nhật tồn kho sau thanh toán
            var danhSachCapNhat = danhSachBanHang
                .GroupBy(sp => new { sp.IdKcsp, sp.LaSanPhamTang })
                .Select(g => new DanhSachSanPhamDTO
                {
                    IdKcsp = g.Key.IdKcsp,
                    TenSP = g.First().TenSP,
                    KichCo = g.First().KichCo,
                    LaSanPhamTang = g.Key.LaSanPhamTang,
                    SoLuong = g.Key.LaSanPhamTang ? 1 : g.Sum(x => x.SoLuong)
                }).ToList();

            BanHangBUS.CapNhatTonKhoSauThanhToan(danhSachCapNhat);

            // ✅ Làm mới giao diện bán hàng
            var formBanHang = Application.OpenForms["BANHANG"] as BANHANG;
            formBanHang?.CapNhatGiaoDienSauThanhToan();

            this.Close();
        
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
