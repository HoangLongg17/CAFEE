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
namespace CF36
{
    public partial class BANHANG : Form
    {
        private DanhSachSanPhamBUS sanPhamBUS = new DanhSachSanPhamBUS();
        private KhachHangBUS khachHangBUS = new KhachHangBUS();

        public BANHANG()
        {
            InitializeComponent();
        }

        private void btnThemKhachHangMoi_Click(object sender, EventArgs e)
        {
            ThemKhachHang themKhachHang = new ThemKhachHang();
            themKhachHang.ShowDialog();
            this.Show();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            List<DanhSachSanPhamDTO> danhSachMua = new List<DanhSachSanPhamDTO>();

            foreach (Control ctrl in fLPSanPhamDaChon.Controls)
            {
                if (ctrl is Panel panel && panel.Tag is DanhSachSanPhamDTO sp)
                {
                    danhSachMua.Add(sp); // ✅ lấy cả sản phẩm chính và sản phẩm tặng
                }
            }

            ThanhToan formTT = new ThanhToan(danhSachMua);
            formTT.Show();
        }

        private void BANHANG_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(this,
                Properties.Resources.exit,
                Properties.Resources.delete,
                Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);
            LoadSanPham();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadSanPham(); // Nếu rỗng thì load toàn bộ
            }
            else
            {
                LoadSanPham("TenSP", keyword); // Tìm theo tên sản phẩm
            }

        }
        private void LoadSanPham(string searchType = null, string searchTerm = null)
        {
            flpSanPham.Controls.Clear();

            // 🔹 Lấy danh sách sản phẩm từ BUS
            var danhSach = sanPhamBUS.SearchSanPham(searchType, searchTerm);

            // 🔹 Gom nhóm sản phẩm cùng tên (TenSP)
            var nhomSanPham = danhSach
                .GroupBy(sp => new { sp.TenSP, sp.DuongDanAnh })
                .ToList();

            string rootPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));

            foreach (var group in nhomSanPham)
            {
                var spDauTien = group.First();

                // 🧱 Panel sản phẩm
                Panel p = new Panel
                {
                    Size = new Size(180, 230),
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White
                };

                // 🖼 Ảnh sản phẩm
                PictureBox pic = new PictureBox
                {
                    Size = new Size(160, 120),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(10, 10),
                    Cursor = Cursors.Hand
                };

                string fullPath = Path.Combine(rootPath, spDauTien.DuongDanAnh ?? "");
                if (File.Exists(fullPath))
                    pic.Image = Image.FromFile(fullPath);
                else
                    pic.Image = Properties.Resources.no_image;

                // 🏷 Tên sản phẩm
                Label lblTen = new Label
                {
                    Text = spDauTien.TenSP,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Location = new Point(10, 135),
                    Size = new Size(160, 20)
                };

                // 📏 Panel chứa các nút size
                FlowLayoutPanel pnlSizes = new FlowLayoutPanel
                {
                    Location = new Point(5, 160),
                    Size = new Size(170, 60),
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true
                };

                // 🔁 Thêm các size
                foreach (var sp in group)
                {
                    Button btnSize = new Button
                    {
                        Text = $"{sp.KichCo} - {sp.GiaBan:N0}đ",
                        AutoSize = true,
                        Height = 25,
                        Font = new Font("Segoe UI", 8, FontStyle.Regular),
                        Tag = sp,
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Beige,
                        Margin = new Padding(3)
                    };
                    btnSize.FlatAppearance.BorderSize = 1;

                    // 🎯 Khi click chọn size
                    btnSize.Click += (s, e) =>
                    {
                        string input = Microsoft.VisualBasic.Interaction.InputBox(
                            $"Nhập số lượng cho {sp.TenSP} size {sp.KichCo}:",
                            "Chọn số lượng",
                            "1"
                        );

                        if (int.TryParse(input, out int sl) && sl > 0)
                        {
                            ThemSanPhamVaoFlow(sp, sl);
                        }
                    };

                    pnlSizes.Controls.Add(btnSize);
                }

                // 🧩 Thêm control vào panel
                p.Controls.Add(pic);
                p.Controls.Add(lblTen);
                p.Controls.Add(pnlSizes);

                flpSanPham.Controls.Add(p);
            }
        }


        private void ThemSanPhamVaoFlow(DanhSachSanPhamDTO sp, int soLuong)
        {
            // 🔍 Kiểm tra sản phẩm đã tồn tại chưa
            foreach (Control ctrl in fLPSanPhamDaChon.Controls)
            {
                if (ctrl is Panel existingPanel && existingPanel.Tag is DanhSachSanPhamDTO existingSp)
                {
                    if (existingSp.MaSP == sp.MaSP && existingSp.KichCo == sp.KichCo)
                    {
                        Label lblSL = existingPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Số lượng:"));
                        Label lblTong = existingPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Tổng:"));

                        if (lblSL != null && lblTong != null)
                        {
                            int oldSL = int.Parse(lblSL.Text.Replace("Số lượng:", "").Trim());
                            int newSL = oldSL + soLuong;
                            lblSL.Text = $"Số lượng: {newSL}";
                            lblTong.Text = $"Tổng: {(sp.GiaBan * newSL):N0} đ";

                            existingPanel.BackColor = Color.LightGreen;
                            CapNhatTongTien();
                            return;
                        }
                    }
                }
            }

            // 🧱 Tạo panel mới
            Panel newPanel = new Panel
            {
                Width = 250,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                BackColor = Color.WhiteSmoke,
                Tag = sp
            };

            // 🖼 Ảnh sản phẩm
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

            // 🏷 Tên sản phẩm
            Label lblTen = new Label
            {
                Text = $"{sp.TenSP} size {sp.KichCo}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(100, 15),
                MaximumSize = new Size(150, 0),
                AutoSize = true
            };

            // 💰 Đơn giá
            Label lblGia = new Label
            {
                Text = "Đơn giá: " + sp.GiaBan.ToString("N0") + " đ",
                Location = new Point(100, 35),
                AutoSize = true
            };

            // 🔢 Số lượng
            Label lblSLMoi = new Label
            {
                Text = "Số lượng: " + soLuong,
                Location = new Point(100, 55),
                AutoSize = true
            };

            // 📦 Tổng tiền
            Label lblTongMoi = new Label
            {
                Text = "Tổng: " + (sp.GiaBan * soLuong).ToString("N0") + " đ",
                Location = new Point(100, 75),
                AutoSize = true
            };

            // ❌ Nút xóa sản phẩm
            Button btnXoa = new Button
            {
                Text = "X",
                Size = new Size(20, 20),
                Location = new Point(newPanel.Width - 30, 5),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Click += (s, e) =>
            {
                fLPSanPhamDaChon.Controls.Remove(newPanel);
                CapNhatTongTien();
            };

            // 🧩 Tooltip mô tả sản phẩm
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(newPanel, $"Tên: {sp.TenSP}\nSize: {sp.KichCo}\nGiá: {sp.GiaBan:N0} đ");

            // 🧱 Thêm vào panel
            newPanel.Controls.Add(pic);
            newPanel.Controls.Add(lblTen);
            newPanel.Controls.Add(lblGia);
            newPanel.Controls.Add(lblSLMoi);
            newPanel.Controls.Add(lblTongMoi);
            newPanel.Controls.Add(btnXoa);
            btnXoa.BringToFront();
            // ➕ Thêm vào FlowLayoutPanel
            fLPSanPhamDaChon.Controls.Add(newPanel);
            CapNhatTongTien();
        }


        
        ComboBox cbbKetQuaKH = null;
        private void txtTimKhachHang_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKhachHang.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                cbbTimKhachHang.Items.Clear();
                cbbTimKhachHang.DroppedDown = false;
                return;
            }

            var danhSach = khachHangBUS.TimKiemTheoSDT(keyword); // Trả về List<KhachHangDTO>

            cbbTimKhachHang.Items.Clear();

            foreach (var kh in danhSach)
            {
                cbbTimKhachHang.Items.Add($"{kh.Tenkh} - {kh.Sdt}");
            }

            if (cbbTimKhachHang.Items.Count > 0)
            {
                cbbTimKhachHang.DroppedDown = true;
                cbbTimKhachHang.Focus();
                cbbTimKhachHang.SelectionStart = cbbTimKhachHang.Text.Length;
            }

        }

        private void cbbTimKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTimKhachHang.SelectedIndex < 0)
                return;

            try
            {
                string selected = cbbTimKhachHang.SelectedItem.ToString();

                // Giả sử định dạng là "Tên - SĐT"
                string[] parts = selected.Split('-');
                if (parts.Length == 2)
                {
                    string ten = parts[0].Trim();
                    string sdt = parts[1].Trim();

                    txtTimKhachHang.Text = sdt;
                }

                // Ẩn ComboBox sau khi chọn
                cbbTimKhachHang.DroppedDown = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn khách hàng: " + ex.Message);
            }

        }

        private void ApDungMaGiamGia(string code)
        {
            if (fLPSanPhamDaChon.Controls.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào.");
                return;
            }

            var voucher = VoucherBUS.Instance.GetAllVouchersWithJoin()
                .AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("code") == code);

            if (voucher == null)
            {
                MessageBox.Show("Không tìm thấy mã giảm giá.");
                return;
            }

            int loaiVC = voucher.Field<int>("maloaivc");
            decimal dieuKien = voucher.Field<decimal>("dieuKien");
            decimal giatri = voucher.Field<decimal>("giatri");
            int mavc = voucher.Field<int>("mavc");
            if (!KiemTraSanPhamPhuHop(voucher.Field<int>("maloai"), voucher.Field<int>("maloaivc"), voucher.Field<int>("mavc")))
            {
                MessageBox.Show("Mã giảm giá này không áp dụng cho sản phẩm bạn đã chọn.");
                txtMaGiamGia.Clear();
                return;
            }

            decimal tongTien = TinhTongTien();
            //Kiểm tra điều kiện tối thiểu
            if (tongTien < dieuKien)
            {
                MessageBox.Show("Đơn hàng chưa đạt điều kiện tối thiểu để áp dụng mã giảm giá.");
                txtMaGiamGia.Clear();
                return;
            }

            switch (loaiVC)
            {
                case 1: // Giảm theo %
                    decimal tienGiam1 = tongTien * giatri / 100;
                    CapNhatTienSauGiam(tongTien - tienGiam1, tienGiam1);
                    break;

                case 2: // Mua 1 tặng 1 cùng dòng
                    ApDungSanPhamTang(mavc);
                    break;
                case 4: // Mua 1 tặng 1 bất kỳ
                    ApDungSanPhamTang(mavc);
                    break;

                case 3: // Giảm theo số tiền
                    decimal tienGiam3 = giatri;
                    CapNhatTienSauGiam(tongTien - tienGiam3, tienGiam3);
                    break;
            }
        }

        private decimal TinhTongTien()
        {
            decimal tong = 0;

            foreach (Control ctrl in fLPSanPhamDaChon.Controls)
            {
                if (ctrl is Panel panel)
                {
                    Label lblTong = panel.Controls.OfType<Label>()
                        .FirstOrDefault(l => l.Text.StartsWith("Tổng:"));

                    if (lblTong != null)
                    {
                        string text = lblTong.Text.Replace("Tổng:", "").Replace("đ", "").Trim();

                        // Xử lý định dạng tiền Việt: bỏ dấu chấm, dấu phẩy
                        text = text.Replace(".", "").Replace(",", "");

                        if (decimal.TryParse(text, out decimal tien))
                        {
                            tong += tien;
                        }
                    }
                }
            }

            return tong;
        }

        private void CapNhatTienSauGiam(decimal tongSauGiam, decimal tienGiam)
        {
            txtTongTien.Text = tongSauGiam.ToString("N0") + " đ";
        }

        private void ApDungSanPhamTang(int mavc)
        {
            var dsTang = Voucher1tang1BUS.Instance.GetSanPhamTangByVoucher(mavc);
            MessageBox.Show("Số sản phẩm tặng: " + dsTang.Rows.Count);

            foreach (DataRow row in dsTang.Rows)
            {
                string masp = row["masp"].ToString().Trim();
                string kichco = row["kichco"].ToString().Trim();

                SanPhamDTO sp = DanhSachSanPhamBUS.Instance.GetSanPhamTheoMaVaKichCo(masp, kichco);
                if (sp == null)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm: {masp} - {kichco}");
                }
                else
                {
                    // ✅ Chuyển đổi sang DanhSachSanPhamDTO
                    var spConverted = new DanhSachSanPhamDTO
                    {
                        MaSP = sp.MaSP,
                        TenSP = sp.TenSP,
                        DuongDanAnh = sp.DuongDanAnh,
                        KichCo = sp.KichCo,
                        // Các thuộc tính còn lại có thể để mặc định nếu không cần
                        TenLoai = "", // hoặc lấy từ BUS nếu cần
                        GiaBan = 0,
                        SoLuongTon = 0,
                        TrangThaiText = "",
                        LaSanPhamTang = true
                    };

                    ThemSanPhamTangVaoFlow(spConverted);
                }
            }
        }

        private void ThemSanPhamTangVaoFlow(DanhSachSanPhamDTO sp)
        {
            Panel panel = new Panel
            {
                Width = 250,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                BackColor = Color.LightYellow
            };
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

            Label lblTen = new Label
            {
                Text = $"{sp.TenSP} size {sp.KichCo} (Tặng)",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(100, 10),
                MaximumSize = new Size(140, 0), //chiều rộng cố định, chiều cao tự động
                AutoSize = true
            };

            Label lblGia = new Label
            {
                Text = "Đơn giá: 0 đ",
                Location = new Point(100, 50),
                AutoSize = true
            };

            Label lblSL = new Label
            {
                Text = "Số lượng: 1",
                Location = new Point(100, 55),
                AutoSize = true
            };

            Label lblTong = new Label
            {
                Text = "Tổng: 0 đ",
                Location = new Point(100, 75),
                AutoSize = true
            };

            panel.Controls.Add(pic);
            panel.Controls.Add(lblTen);
            panel.Controls.Add(lblGia);
            panel.Controls.Add(lblSL);
            panel.Controls.Add(lblTong);
            // Gán đối tượng sản phẩm tặng vào Tag
            panel.Tag = sp;

            fLPSanPhamDaChon.Controls.Add(panel);
            CapNhatTongTien();

        }
        private void CapNhatTongTien()
        {
            decimal tong = TinhTongTien();
            txtTongTien.Text = tong.ToString("N0") + " đ";
        }
        private void btnThemMaGiamGia_Click(object sender, EventArgs e)
        {
            QuanLiMAGIAMGIA formMaGiam = new QuanLiMAGIAMGIA(true); // chế độ chọn mã
            if (formMaGiam.ShowDialog() == DialogResult.OK)
            {
                string maGiam = formMaGiam.MaGiamGiaDuocChon;
                txtMaGiamGia.Text = maGiam;
                ApDungMaGiamGia(maGiam);
            }

        }
        private bool KiemTraSanPhamPhuHop(int maloaiVC, int loaiVC, int mavc)
        {
            foreach (Control ctrl in fLPSanPhamDaChon.Controls)
            {
                if (ctrl is Panel panel && panel.Tag is DanhSachSanPhamDTO sp)
                {
                    if (loaiVC == 2)
                    {
                        Console.WriteLine($"SP Maloai: {sp.Maloai}, VC Maloai: {maloaiVC}"); // ✅ thêm dòng này

                        if (sp.Maloai == maloaiVC)
                            return true;
                    }
                    else if (loaiVC == 4)
                    {
                        var dsTang = Voucher1tang1BUS.Instance.GetSanPhamTangByVoucher(mavc);
                        foreach (DataRow row in dsTang.Rows)
                        {
                            string masp = row["masp"].ToString();
                            string kichco = row["kichco"].ToString();

                            // So sánh theo mã sản phẩm hoặc loại sản phẩm
                            if (sp.MaSP == masp || sp.KichCo.Equals(kichco, StringComparison.OrdinalIgnoreCase))
                                return true;
                        }
                    }
                }
            }

            return false;
        }

       
    }
}
