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
    public partial class BANHANG : Form
    {
        private DanhSachSanPhamBUS sanPhamBUS = new DanhSachSanPhamBUS();
        private KhachHangBUS khachHangBUS = new KhachHangBUS();
        private BanHangBUS banHangBUS = new BanHangBUS();

        private List<DanhSachSanPhamDTO> danhSachDaChon = new List<DanhSachSanPhamDTO>();
        private string maND;

        private int? maKH; // gán khi chọn khách hàng

        // Mã giảm giá
        private int? maVoucherId; // ID mã giảm giá (dùng để lưu vào DB)
        private string maVoucherCode; // Mã giảm giá dạng chuỗi (hiển thị trong hóa đơn)
        private KetQuaGiamGiaDTO ketQuaGiamGia; // Kết quả áp dụng mã: tiền giảm, sản phẩm tặng, loại mã
        public BANHANG()
        {
            InitializeComponent();
            maND = CurrentUser.Mand;
        }

        private void btnThemKhachHangMoi_Click(object sender, EventArgs e)
        {
            ThemKhachHang themKhachHang = new ThemKhachHang();
            themKhachHang.ShowDialog();
            this.Show();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            var danhSachMua = LaySanPhamTuGiaoDien();
            if (danhSachMua == null || danhSachMua.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(maND))
            {
                MessageBox.Show("Không xác định được nhân viên. Vui lòng đăng nhập lại.");
                return;
            }

            var formTT = new ThanhToan(danhSachMua, maND, maKH, maVoucherId, maVoucherCode, ketQuaGiamGia);
            formTT.SetMaKH(maKH);
            formTT.SoDienThoai = txtTimKhachHang.Text;
            formTT.TenKhachHang = KhachHangBUS.LayTenKhachHangTheoSDT(txtTimKhachHang.Text);
            formTT.Show();

        }

        private void BANHANG_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
            UIText.ApplyButtonTextStyle(this);
            LoadSanPham();

            maND = CurrentUser.Mand;

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadSanPham();
                // Nếu rỗng thì load toàn bộ
            }
            else
            {
                LoadSanPham("TenSP", keyword); // Tìm theo tên sản phẩm
            }

        }
        private void LoadSanPham(string searchType = null, string searchTerm = null)
        {
            try
            {
                flpSanPham.Controls.Clear();

                var danhSach = banHangBUS.SearchSanPham(searchType, searchTerm);

                var nhomSanPham = danhSach
                    .GroupBy(sp => new { sp.TenSP, sp.DuongDanAnh })
                    .ToList();

                string rootPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));

                foreach (var group in nhomSanPham)
                {
                    var spDauTien = group.First();

                    Panel p = new Panel
                    {
                        Size = new Size(300, 240),
                        Margin = new Padding(10),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White
                    };

                    bool hetHang = spDauTien.SoLuongTon == 0;

                   if (hetHang)
                   p.BackColor = Color.LightGray;

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

                    Label lblTen = new Label
                    {
                        Text = spDauTien.TenSP,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        Location = new Point(10, 135),
                        Size = new Size(160, 20)
                    };

                    FlowLayoutPanel pnlSizes = new FlowLayoutPanel
                    {
                        Location = new Point(5, 160),
                        AutoSize = true,                          // ✅ tự co giãn theo nội dung
                        AutoSizeMode = AutoSizeMode.GrowAndShrink,
                        FlowDirection = FlowDirection.LeftToRight,
                        WrapContents = true,
                        Margin = new Padding(0)

                    };

                    foreach (var sp in group)
                    {
                        Button btnSize = new Button
                        {
                            Text = $"{sp.KichCo} - {sp.GiaBan:N0}đ",
                            AutoSize = true,                          // ✅ tự co theo nội dung
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            Height = 25,
                            Font = new Font("Segoe UI", 8, FontStyle.Regular),
                            Tag = sp,
                            FlatStyle = FlatStyle.Flat,
                            BackColor = Color.Beige,
                            Margin = new Padding(3)

                        };

                        btnSize.FlatAppearance.BorderSize = 1;

                        btnSize.Click += (s, e) => XuLyChonSanPham(sp);


                        pnlSizes.Controls.Add(btnSize);
                    }

                    // 🧩 Thêm tất cả vào panel
                    p.Controls.Add(pic);
                    p.Controls.Add(lblTen);
                    p.Controls.Add(pnlSizes);

                    flpSanPham.Controls.Add(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void XuLyChonSanPham(BanHangDTO sp)
        {
            sp.GiaGoc = sp.GiaBan; //lưu giá gốc ban đầu
            if (sp.SoLuongTon == 0)
            {
                MessageBox.Show("❌ Sản phẩm đã hết hàng. Không thể mua.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sp.TrangThaiText == "Ngừng bán")
            {
                MessageBox.Show("❌ Sản phẩm đang ngừng bán. Không thể mua.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Nhập số lượng cho {sp.TenSP} size {sp.KichCo}:",
                "Chọn số lượng",
                "1"
            );

            if (string.IsNullOrWhiteSpace(input))
            {
                return; 
            }

            if (!int.TryParse(input, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soLuong > sp.SoLuongTon)
            {
                MessageBox.Show("Số lượng vượt quá tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sp.SoLuong = soLuong;
            ThemSanPhamVaoFlow(sp, soLuong);
            CapNhatTongTien();
        }



        private void ThemSanPhamVaoFlow(BanHangDTO sp, int soLuong)
        {
            foreach (Control ctrl in fLPSanPhamDaChon.Controls)
            {
                if (ctrl is Panel existingPanel && existingPanel.Tag is BanHangDTO existingSp)
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
                            lblTong.Text = $"Tổng: {(existingSp.GiaBan * newSL):N0} đ";

                            existingSp.SoLuong = newSL; // ✅ Cập nhật lại số lượng trong Tag
                            existingPanel.BackColor = Color.LightGreen;
                            CapNhatTongTien();
                            return;
                        }
                    }
                }
            }

            // Tạo panel mới
            sp.SoLuong = soLuong;
            sp.IdKcsp = DanhSachSanPhamBUS.Instance.GetIdKcsp(sp.MaSP, sp.KichCo);
            sp.LaSanPhamTang = false;
            if (sp.IdKcsp == 0)
            {
                MessageBox.Show($"Không tìm thấy mã sản phẩm theo kích cỡ cho {sp.TenSP} - Size {sp.KichCo}", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Panel newPanel = new Panel
            {
                Width = 280,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                BackColor = Color.WhiteSmoke,
                Tag = sp // Gán đối tượng có số lượng vào Tag
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
                Text = $"{sp.TenSP} size {sp.KichCo}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(100, 10),
                MaximumSize = new Size(140, 0),
                AutoSize = true
            };

            Label lblGia = new Label
            {
                Text = "Đơn giá: " + sp.GiaBan.ToString("N0") + " đ",
                Location = new Point(100, 35),
                AutoSize = true
            };

            Label lblSLMoi = new Label
            {
                Text = "Số lượng: " + sp.SoLuong,
                Location = new Point(100, 55),
                AutoSize = true
            };

            Label lblTongMoi = new Label
            {
                Text = "Tổng: " + (sp.GiaBan * sp.SoLuong).ToString("N0") + " đ",
                Location = new Point(100, 75),
                AutoSize = true
            };

            Button btnXoa = new Button
            {
                Text = "X",
                Size = new Size(25, 25),
                Location = new Point(newPanel.Width - 30, 5),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Click += (s, e) =>
            {
                fLPSanPhamDaChon.Controls.Remove(newPanel);

                //Lấy mã sản phẩm gốc từ panel vừa xóa
                string maSanPhamGoc = null;

                if (newPanel.Tag is BanHangDTO spGoc)
                {
                    maSanPhamGoc = spGoc.MaSP;
                }
                else if (newPanel.Tag is DanhSachSanPhamDTO spGocDTO)
                {
                    maSanPhamGoc = spGocDTO.MaSP;
                }

                if (!string.IsNullOrEmpty(maSanPhamGoc))
                {
                    //Xóa tất cả sản phẩm tặng có MaSanPhamGoc trùng
                    var panelsToRemove = fLPSanPhamDaChon.Controls.OfType<Panel>()
                        .Where(p =>
                        {
                            if (p.Tag is DanhSachSanPhamDTO spTang)
                            {
                                return spTang.LaSanPhamTang && spTang.MaSanPhamGoc == maSanPhamGoc;
                            }
                            return false;
                        }).ToList();

                    foreach (var p in panelsToRemove)
                    {
                        fLPSanPhamDaChon.Controls.Remove(p);
                        p.Dispose();
                    }
                }
                //Kiểm tra nếu không còn sản phẩm mua nào thì reset mã giảm giá
                var danhSachSauXoa = LaySanPhamTuGiaoDien();
                bool conSanPhamMua = danhSachSauXoa.Any(sp => !sp.LaSanPhamTang);

                if (!conSanPhamMua)
                {
                    txtMaGiamGia.Text = "";
                    maVoucherId = null;
                    maVoucherCode = "";
                    ketQuaGiamGia = new KetQuaGiamGiaDTO();
                }

                CapNhatTongTien();
            };

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(newPanel, $"Tên: {sp.TenSP}\nSize: {sp.KichCo}\nGiá: {sp.GiaBan:N0} đ");

            newPanel.Controls.Add(pic);
            newPanel.Controls.Add(lblTen);
            newPanel.Controls.Add(lblGia);
            newPanel.Controls.Add(lblSLMoi);
            newPanel.Controls.Add(lblTongMoi);
            newPanel.Controls.Add(btnXoa);
            btnXoa.BringToFront();
            fLPSanPhamDaChon.Controls.Add(newPanel);
            CapNhatTongTien();
        }

        private DanhSachSanPhamDTO TaoDTOTuRow(DataGridViewRow row)
        {
            var dto = new DanhSachSanPhamDTO
            {
                MaSP = row.Cells["MaSP"].Value.ToString(),
                TenSP = row.Cells["TenSP"].Value.ToString(),
                Maloai = Convert.ToInt32(row.Cells["Maloai"].Value),
                TenLoai = row.Cells["TenLoai"].Value.ToString(),
                KichCo = row.Cells["KichCo"].Value.ToString(),
                GiaBan = Convert.ToDecimal(row.Cells["GiaBan"].Value),
                SoLuongTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value),
                TrangThaiText = row.Cells["TrangThaiText"].Value.ToString(),
                DuongDanAnh = row.Cells["DuongDanAnh"].Value?.ToString(),
                LaSanPhamTang = false
            };

            // ✅ Gán IdKcsp để đảm bảo sản phẩm hợp lệ
            dto.IdKcsp = DanhSachSanPhamBUS.Instance.GetIdKcsp(dto.MaSP, dto.KichCo);

            return dto;
        }
        private int LaySoLuongTuNguoiDung()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập số lượng cần mua:", "Chọn số lượng", "1");
            return int.TryParse(input, out int soLuong) ? soLuong : -1;
        }


        private void cbbTimKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kh = cbbTimKhachHang.SelectedItem as KhachHangDTO;
            if (kh != null)
            {
                txtTimKhachHang.Text = kh.Sdt;
                maKH = kh.Makh;           // lưu lại để truyền sang form Thanh Toán
            }

            cbbTimKhachHang.DroppedDown = false;

        }
        private List<DanhSachSanPhamDTO> LaySanPhamTuGiaoDien()
        {
            return fLPSanPhamDaChon.Controls
                .OfType<Panel>()
                .Select(p => p.Tag)
                .Where(tag => tag is BanHangDTO || tag is DanhSachSanPhamDTO)
                .Select(tag =>
                {
                    if (tag is BanHangDTO sp)
                    {
                        return new DanhSachSanPhamDTO
                        {
                            IdKcsp = sp.IdKcsp,
                            MaSP = sp.MaSP,
                            TenSP = sp.TenSP,
                            KichCo = sp.KichCo,
                            SoLuong = sp.SoLuong,
                            GiaBan = sp.GiaBan,
                            GiaGoc = sp.GiaGoc,
                            TienGiam = sp.TienGiam,
                            SoLuongTon = sp.SoLuongTon,
                            DuongDanAnh = sp.DuongDanAnh,
                            Maloai = sp.Maloai,
                            TenLoai = sp.TenLoai,
                            TrangThaiText = sp.TrangThaiText,
                            LaSanPhamTang = sp.LaSanPhamTang,
                            MaSanPhamGoc = sp.MaSanPhamGoc
                        };
                    }
                    else
                    {
                        return (DanhSachSanPhamDTO)tag;
                    }
                })
                .Where(sp => sp != null && sp.IdKcsp > 0)
                .ToList();
        }

        private bool SanPhamTangDaTonTai(BanHangDTO spTang)
        {
            return fLPSanPhamDaChon.Controls.OfType<Panel>()
                .Any(p => p.Tag is DanhSachSanPhamDTO spCheck &&
                          spCheck.MaSP == spTang.MaSP &&
                          spCheck.KichCo == spTang.KichCo &&
                          spCheck.LaSanPhamTang &&
                          spCheck.MaSanPhamGoc == spTang.MaSanPhamGoc);
        }

        private void HienThiSanPhamTang(List<BanHangDTO> danhSachTang)
        {
            foreach (var spTang in danhSachTang)
            {
                if (SanPhamTangDaTonTai(spTang)) continue;

                var spConverted = new DanhSachSanPhamDTO
                {
                    MaSP = spTang.MaSP,
                    TenSP = spTang.TenSP,
                    DuongDanAnh = spTang.DuongDanAnh,
                    KichCo = spTang.KichCo,
                    TenLoai = spTang.TenLoai,
                    GiaBan = 0,
                    SoLuongTon = spTang.SoLuongTon,
                    TrangThaiText = spTang.TrangThaiText,
                    LaSanPhamTang = true,
                    MaSanPhamGoc = spTang.MaSanPhamGoc,
                    SoLuong = 1
                };
                spConverted.IdKcsp = DanhSachSanPhamBUS.Instance.GetIdKcsp(spConverted.MaSP, spConverted.KichCo);
                ThemSanPhamTangVaoFlow(spConverted);
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
                Location = new Point(100, 35),
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
            sp.IdKcsp = DanhSachSanPhamBUS.Instance.GetIdKcsp(sp.MaSP, sp.KichCo);
            if (sp.IdKcsp == 0)
            {
                MessageBox.Show($"Không tìm thấy mã sản phẩm theo kích cỡ cho {sp.TenSP} - Size {sp.KichCo}", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sp.LaSanPhamTang = true;
            panel.Tag = sp;

            fLPSanPhamDaChon.Controls.Add(panel);
            CapNhatTongTien();

        }
        private void CapNhatTongTien()
        {
            var danhSachDaChon = LaySanPhamTuGiaoDien()
                .Where(sp => sp.IdKcsp > 0) // ✅ chỉ lấy sản phẩm hợp lệ
                .ToList();

            var bus = new BanHangBUS();
            decimal tong = bus.TinhTongTien(danhSachDaChon);
            txtTongTien.Text = tong.ToString("N0") + " đ";

        }
        private void btnThemMaGiamGia_Click(object sender, EventArgs e)
        {
            // Xóa sản phẩm tặng cũ khỏi danh sách
            danhSachDaChon.RemoveAll(sp => sp.LaSanPhamTang);

            // Xóa khỏi giao diện
            XoaSanPhamTang();
            QuanLiMAGIAMGIA formMaGiam = new QuanLiMAGIAMGIA(true, maND);
            if (formMaGiam.ShowDialog() == DialogResult.OK)
            {
                string code = formMaGiam.MaGiamGiaDuocChon;
                this.maVoucherCode = code;
                this.maVoucherId = VoucherBUS.GetIdFromCode(code);

                var danhSachMua = LaySanPhamTuGiaoDien();
                ketQuaGiamGia = banHangBUS.ApDungMaGiamGia(code, danhSachMua);

                if (!string.IsNullOrEmpty(ketQuaGiamGia.Loi))
                {
                    MessageBox.Show(ketQuaGiamGia.Loi, "Lỗi áp dụng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Kiểm tra sản phẩm tặng có hợp lệ không

                foreach (var spTang in ketQuaGiamGia.SanPhamTang)
                {
                    if (spTang.SoLuongTon == 0 || spTang.TrangThaiText == "Ngừng bán")
                    {
                        MessageBox.Show($"❌ Sản phẩm tặng '{spTang.TenSP} - Size {spTang.KichCo}' đã hết hàng hoặc ngừng bán.\nKhông thể áp dụng mã giảm giá này.", "Lỗi sản phẩm tặng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                foreach (var spTang in ketQuaGiamGia.SanPhamTang)
                {
                    var dto = new DanhSachSanPhamDTO
                    {
                        MaSP = spTang.MaSP,
                        TenSP = spTang.TenSP,
                        KichCo = spTang.KichCo,
                        GiaBan = 0,
                        SoLuong = 1,
                        IdKcsp = spTang.IdKcsp,
                        Maloai = spTang.Maloai,
                        MaSanPhamGoc = danhSachMua.FirstOrDefault()?.MaSP,
                        TenLoai = spTang.TenLoai,
                        DuongDanAnh = spTang.DuongDanAnh,
                        TrangThaiText = spTang.TrangThaiText,
                        SoLuongTon = spTang.SoLuongTon,
                        LaSanPhamTang = true
                    };
                    danhSachDaChon.Add(dto);
                    ThemSanPhamTangVaoFlow(dto);
                }
                txtMaGiamGia.Text = code;
                txtTongTien.Text = (ketQuaGiamGia.TongTien - ketQuaGiamGia.TienGiam).ToString("N0") + " đ";
            }
        }
        private void XoaSanPhamTang()
        {
            var controlsToRemove = new List<Control>();

            foreach (Control ctrl in fLPSanPhamDaChon.Controls)
            {
                if (ctrl.Tag is DanhSachSanPhamDTO dto && dto.LaSanPhamTang)
                {
                    controlsToRemove.Add(ctrl);
                }
            }

            foreach (var ctrl in controlsToRemove)
            {
                fLPSanPhamDaChon.Controls.Remove(ctrl);
                ctrl.Dispose(); // Giải phóng bộ nhớ
            }
        }
        public void CapNhatGiaoDienSauThanhToan()
        {

            // ✅ Gán lại danh sách sản phẩm
            LoadSanPham();

            // ✅ Reset giao diện khác
            fLPSanPhamDaChon.Controls.Clear();
            fLPSanPhamDaChon.Refresh();
            txtTongTien.Text = "0 đ";
            ketQuaGiamGia = new KetQuaGiamGiaDTO();
            maVoucherCode = "";
            maVoucherId = null;
        }
        private void txtTimKhachHang_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKhachHang.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                cbbTimKhachHang.Items.Clear();
                cbbTimKhachHang.DroppedDown = false;
                return;
            }

            var danhSach = khachHangBUS.TimKiemTheoSDT(keyword);

            cbbTimKhachHang.DataSource = null;
            cbbTimKhachHang.Items.Clear();

            foreach (var kh in danhSach)
            {
                cbbTimKhachHang.Items.Add(kh);
            }

            cbbTimKhachHang.DisplayMember = "Sdt";
            cbbTimKhachHang.ValueMember = "Makh";

            if (danhSach.Count > 0)
            {
                if (!cbbTimKhachHang.DroppedDown)
                    cbbTimKhachHang.DroppedDown = true;
            }
            else
            {
                cbbTimKhachHang.DroppedDown = false;
            }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
