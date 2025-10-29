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
            this.Hide();
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.ShowDialog();
            this.Show();
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

                // 2. Gán vào DataGridView
                dgvSanPham.DataSource = danhSach;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ThemSanPhamVaoFlow(DanhSachSanPhamDTO sp, int soLuong)
        {
            Panel panel = new Panel();
            panel.Width = 250;
            panel.Height = 100;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(5);

            // Ảnh sản phẩm
            PictureBox pic = new PictureBox();
            pic.Width = 80;
            pic.Height = 80;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Location = new Point(10, 10);

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

            // Tên sản phẩm
            Label lblTen = new Label();
            lblTen.Text = sp.TenSP;
            lblTen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTen.Location = new Point(100, 10);
            lblTen.AutoSize = true;

            // Đơn giá
            Label lblGia = new Label();
            lblGia.Text = "Đơn giá: " + sp.GiaBan.ToString("N0") + " đ";
            lblGia.Location = new Point(100, 35);
            lblGia.AutoSize = true;

            // Số lượng
            Label lblSL = new Label();
            lblSL.Text = "Số lượng: " + soLuong;
            lblSL.Location = new Point(100, 55);
            lblSL.AutoSize = true;

            // Tổng tiền
            Label lblTong = new Label();
            lblTong.Text = "Tổng: " + (sp.GiaBan * soLuong).ToString("N0") + " đ";
            lblTong.Location = new Point(100, 75);
            lblTong.AutoSize = true;

            // Thêm vào panel
            panel.Controls.Add(pic);
            panel.Controls.Add(lblTen);
            panel.Controls.Add(lblGia);
            panel.Controls.Add(lblSL);
            panel.Controls.Add(lblTong);

            // Thêm panel vào FlowLayoutPanel
            fLPSanPhamDaChon.Controls.Add(panel);
            CapNhatTongTien();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvSanPham.SelectedRows[0];

            DanhSachSanPhamDTO sp = new DanhSachSanPhamDTO
            {
                MaSP = row.Cells["MaSP"].Value.ToString(),
                TenSP = row.Cells["TenSP"].Value.ToString(),
                TenLoai = row.Cells["TenLoai"].Value.ToString(),
                KichCo = row.Cells["KichCo"].Value.ToString(),
                GiaBan = Convert.ToDecimal(row.Cells["GiaBan"].Value),
                SoLuongTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value),
                TrangThaiText = row.Cells["TrangThaiText"].Value.ToString(),
                DuongDanAnh = row.Cells["DuongDanAnh"].Value?.ToString()
            };

            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập số lượng cần mua:", "Chọn số lượng", "1");
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

            ThemSanPhamVaoFlow(sp, soLuong);

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
            if (!KiemTraSanPhamPhuHop(voucher.Field<int>("maloai")))
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
                        TrangThaiText = ""
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
                Text = sp.TenSP + " (Tặng)",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(100, 10),
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
        private bool KiemTraSanPhamPhuHop(int maLoaiVC)
        {
            foreach (Control ctrl in fLPSanPhamDaChon.Controls)
            {
                if (ctrl is Panel panel)
                {
                    Label lblTen = panel.Controls.OfType<Label>()
                        .FirstOrDefault(l => l.Location == new Point(100, 10)); // hoặc dùng StartsWith nếu bạn đặt tên rõ

                    if (lblTen != null)
                    {
                        string tenSP = lblTen.Text.Replace("(Tặng)", "").Trim();

                        int loaiSP = DanhSachSanPhamBUS.Instance.GetLoaiSanPhamTheoTen(tenSP);
                        if (loaiSP == maLoaiVC)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
