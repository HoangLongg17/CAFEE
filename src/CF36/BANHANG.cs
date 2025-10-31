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
            List<DanhSachSanPhamDTO> danhSachMua = LaySanPhamTuGiaoDien();
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
            ThanhToan formTT = new ThanhToan(danhSachMua, maND, maKH, maVoucherId, maVoucherCode, ketQuaGiamGia);
            formTT.SetMaKH(maKH);
            formTT.SoDienThoai = txtTimKhachHang.Text;
            formTT.TenKhachHang = KhachHangBUS.LayTenKhachHangTheoSDT(txtTimKhachHang.Text);
            formTT.Show();
        }

        private void BANHANG_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(this,
                Properties.Resources.exit,
                Properties.Resources.delete,
                Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);
            UIDataGridView.FormatDataGridView(dgvSanPham);
            LoadDataGrid();
            maND = CurrentUser.Mand;

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadDataGrid(); // Nếu rỗng thì load toàn bộ
            }
            else
            {
                LoadDataGrid("TenSP", keyword); // Tìm theo tên sản phẩm
            }

        }
        private void LoadDataGrid(string searchType = null, string searchTerm = null)
        {
            try
            {
                // 1. Lấy danh sách sản phẩm từ BUS
                var danhSach = sanPhamBUS.SearchSanPham(searchType, searchTerm);
                dgvSanPham.Columns.Clear(); // Xóa toàn bộ cột cũ để tránh lỗi tên cột
                // 2. Gán vào DataGridView
                dgvSanPham.DataSource = danhSach;
                if (dgvSanPham.Columns.Contains("duongdananh"))
                    dgvSanPham.Columns["duongdananh"].Visible = false;
                if (dgvSanPham.Columns.Contains("LaSanPhamTang"))
                    dgvSanPham.Columns["LaSanPhamTang"].Visible = false;
                if (dgvSanPham.Columns.Contains("SoLuong"))
                    dgvSanPham.Columns["SoLuong"].Visible = false;
                if (dgvSanPham.Columns.Contains("MaSanPhamGoc"))
                    dgvSanPham.Columns["MaSanPhamGoc"].Visible = false;
                if (dgvSanPham.Columns.Contains("maloai"))
                    dgvSanPham.Columns["maloai"].HeaderText = "Mã loại sản phẩm";
                if (dgvSanPham.Columns.Contains("Idkcsp"))
                    dgvSanPham.Columns["Idkcsp"].Visible = false;
                // Bật chế độ chọn toàn dòng
                dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSanPham.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue; //màu nền khi chọn
                dgvSanPham.DefaultCellStyle.SelectionForeColor = Color.Black;
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    int tonKho = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                    string trangThai = row.Cells["TrangThaiText"].Value?.ToString();

                    if (tonKho == 0 || trangThai == "Ngừng bán")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral; // ✅ tô đỏ
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
                // 3. Thêm cột ảnh nếu chưa có
                if (!dgvSanPham.Columns.Contains("Anh"))
                {
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                    imgCol.Name = "Anh";
                    imgCol.HeaderText = "Ảnh";
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgvSanPham.Columns.Insert(0, imgCol); // chèn vào đầu
                }

                // 4. Gán ảnh cho từng dòng
                string rootPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));

                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (row.Cells["DuongDanAnh"] != null && row.Cells["DuongDanAnh"].Value != null)
                    {
                        string relativePath = row.Cells["DuongDanAnh"].Value.ToString();
                        string fullPath = Path.Combine(rootPath, relativePath);

                        if (File.Exists(fullPath))
                        {
                            row.Cells["Anh"].Value = System.Drawing.Image.FromFile(fullPath);
                        }
                        else
                        {
                            row.Cells["Anh"].Value = Properties.Resources.no_image;
                        }
                    }
                    else
                    {
                        row.Cells["Anh"].Value = Properties.Resources.no_image;
                    }
                }

                // 5. Đặt tên cột sau khi gán DataSource
                dgvSanPham.Columns["ID"].HeaderText = "ID";
                dgvSanPham.Columns["MaSP"].HeaderText = "Mã SP";
                dgvSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dgvSanPham.Columns["TenLoai"].HeaderText = "Loại";
                dgvSanPham.Columns["KichCo"].HeaderText = "Size";
                dgvSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvSanPham.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
                dgvSanPham.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
                dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                dgvSanPham.Columns["ID"].Visible = false;
                // 6. Đánh dấu sản phẩm bị khóa (trạng thái = false)
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (row.Cells["TrangThaiText"] != null && row.Cells["TrangThaiText"].Value != null)
                    {
                        string trangThai = row.Cells["TrangThaiText"].Value.ToString().Trim().ToLower();
                        if (trangThai == "khóa" || trangThai == "0" || trangThai == "false")
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            row.Cells["TenSP"].Value = "🔒 " + row.Cells["TenSP"].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // ✅ Xóa toàn bộ sản phẩm tặng (vì chỉ có 1 sản phẩm tặng duy nhất)
                var panelsToRemove = fLPSanPhamDaChon.Controls.OfType<Panel>()
                    .Where(p => p.Tag is DanhSachSanPhamDTO spTang && spTang.LaSanPhamTang)
                    .ToList();

                foreach (var p in panelsToRemove)
                {
                    fLPSanPhamDaChon.Controls.Remove(p);
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
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvSanPham.SelectedRows[0];
            var sp = TaoDTOTuRow(row);
            sp.LaSanPhamTang = false;
            // Kiểm tra trạng thái và tồn kho
            string trangThai = row.Cells["TrangThaiText"].Value?.ToString();
            int tonKho = Convert.ToInt32(row.Cells["SoLuongTon"].Value);

            if (tonKho == 0)
            {
                MessageBox.Show("❌ Sản phẩm đã hết hàng. Không thể mua.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (trangThai == "Ngừng bán")
            {
                MessageBox.Show("❌ Sản phẩm đang ngừng bán. Không thể mua.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong = LaySoLuongTuNguoiDung();
            if (soLuong <= 0)
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
        ComboBox cbbKetQuaKH = null;
        private void txtTimKhachHang_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKhachHang.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                cbbTimKhachHang.DataSource = null;
                cbbTimKhachHang.DroppedDown = false;
                return;
            }

            var danhSach = khachHangBUS.TimKiemTheoSDT(keyword); // Trả về List<KhachHangDTO>

            if (danhSach.Count > 0)
            {
                cbbTimKhachHang.DataSource = danhSach;
                cbbTimKhachHang.DisplayMember = "TenVaSDT";
                cbbTimKhachHang.ValueMember = "MaKH";

                cbbTimKhachHang.DroppedDown = true;
                cbbTimKhachHang.Focus();
            }
            else
            {
                cbbTimKhachHang.DataSource = null;
                cbbTimKhachHang.DroppedDown = false;
            }

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
                .OfType<DanhSachSanPhamDTO>()
                .Where(sp => sp.IdKcsp > 0)
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
                        MaSanPhamGoc = spTang.MaSanPhamGoc,
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
            LoadDataGrid();

            // ✅ Reset giao diện khác
            fLPSanPhamDaChon.Controls.Clear();
            fLPSanPhamDaChon.Refresh();
            txtTongTien.Text = "0 đ";
            ketQuaGiamGia = new KetQuaGiamGiaDTO();
            maVoucherCode = "";
            maVoucherId = null;
        }
        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSanPham_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = dgvSanPham.Rows[e.RowIndex];

            // Kiểm tra cột tồn tại trước khi truy cập
            if (!dgvSanPham.Columns.Contains("TenSP") ||
                !dgvSanPham.Columns.Contains("TenLoai") ||
                !dgvSanPham.Columns.Contains("KichCo") ||
                !dgvSanPham.Columns.Contains("GiaBan"))
            {
                return;
            }

            string tenSP = row.Cells["TenSP"].Value?.ToString();
            string loaiSP = row.Cells["TenLoai"].Value?.ToString();
            string kichco = row.Cells["KichCo"].Value?.ToString();
            string gia = row.Cells["GiaBan"].Value?.ToString();

            dgvSanPham.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText =
                $"Tên: {tenSP}\nLoại: {loaiSP}\nSize: {kichco}\nGiá: {gia} đ";

        }

    }
}
