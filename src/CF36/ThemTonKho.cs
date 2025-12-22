using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CF36
{
    public partial class ThemTonKho : Form
    {
        private List<int> _listIDs;
        private Dictionary<int, (TextBox txtSL, TextBox txtGia)> _inputs = new Dictionary<int, (TextBox, TextBox)>();

        public ThemTonKho(List<int> listIDs)
        {
            InitializeComponent();
            _listIDs = listIDs;

            this.Load += ThemTonKho_Load;
            btnThoat.Click += (s, e) => this.Close();
            btnThem.Click += btnThem_Click;
        }

        private void ThemTonKho_Load(object sender, EventArgs e)
        {
            cbbNhaCungCap.DataSource = KhoBUS.LayNhaCungCap();
            cbbNhaCungCap.DisplayMember = "Tennhacc";
            cbbNhaCungCap.ValueMember = "Manhacc";

            HienThiDanhSachSanPham();
            flpDanhSachSP.SizeChanged += (s, ev) => DieuChinhKichThuocPanel();

            try
            {
                UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
                UIText.ApplyButtonTextStyle(this);
            }
            catch { }
        }

        private void DieuChinhKichThuocPanel()
        {
            int newWidth = flpDanhSachSP.Width - 30;
            foreach (Control ctrl in flpDanhSachSP.Controls)
            {
                if (ctrl is Panel pnl)
                {
                    pnl.Width = newWidth;
                }
            }
        }

        private void HienThiDanhSachSanPham()
        {
            flpDanhSachSP.Controls.Clear();
            _inputs.Clear();

            var all = KhoBUS.LayTatCaSanPham();
            var selected = all.Where(p => _listIDs.Contains(p.MaSP)).ToList();
            int panelWidth = flpDanhSachSP.Width - 30;

            foreach (var item in selected)
            {
                Panel pnl = new Panel();
                pnl.Size = new Size(panelWidth, 40);
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.Margin = new Padding(5);
                pnl.BackColor = Color.WhiteSmoke;

                Label lblTen = new Label();
                lblTen.Text = item.TenSP;
                lblTen.Location = new Point(5, 10);
                lblTen.Size = new Size(200, 20);
                lblTen.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lblTen.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                Label lblTon = new Label();
                lblTon.Text = $"Tồn: {item.SoLuongTon}";
                lblTon.Location = new Point(220, 10);
                lblTon.Size = new Size(80, 20);
                lblTon.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                Label lblSL = new Label { Text = "SL:", Location = new Point(panelWidth - 350, 10), AutoSize = true };
                lblSL.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                TextBox txtSL = new TextBox();
                txtSL.Location = new Point(panelWidth - 320, 7);
                txtSL.Size = new Size(80, 25);
                txtSL.TextAlign = HorizontalAlignment.Center;
                txtSL.KeyPress += OnlyNumber;
                txtSL.TextChanged += (s, e) => TinhTongTien();
                txtSL.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                Label lblGia = new Label { Text = "Giá:", Location = new Point(panelWidth - 220, 10), AutoSize = true };
                lblGia.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                TextBox txtGia = new TextBox();
                txtGia.Location = new Point(panelWidth - 180, 7);
                txtGia.Size = new Size(120, 25);
                txtGia.TextAlign = HorizontalAlignment.Right;
                txtGia.KeyPress += OnlyNumber;
                txtGia.TextChanged += (s, e) => TinhTongTien();
                txtGia.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                pnl.Controls.AddRange(new Control[] { lblTen, lblTon, lblSL, txtSL, lblGia, txtGia });
                flpDanhSachSP.Controls.Add(pnl);

                _inputs.Add(item.MaSP, (txtSL, txtGia));
            }
        }

        private void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TinhTongTien()
        {
            decimal total = 0;
            foreach (var item in _inputs.Values)
            {
                int sl = int.TryParse(item.txtSL.Text, out int s) ? s : 0;
                decimal gia = decimal.TryParse(item.txtGia.Text, out decimal g) ? g : 0;
                total += sl * gia;
            }
            texttongtien.Text = total.ToString("N0");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn nhà cung cấp!");
                return;
            }

            string maNV = CurrentUser.Manv;
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Không xác định được người dùng hiện tại (Vui lòng đăng nhập lại).");
                return;
            }

            List<CartItemDTO> listnhapkho = new List<CartItemDTO>();
            foreach (var kvp in _inputs)
            {
                int sl = int.TryParse(kvp.Value.txtSL.Text, out int s) ? s : 0;
                decimal gia = decimal.TryParse(kvp.Value.txtGia.Text, out decimal g) ? g : 0;

                if (sl > 0 && gia > 0)
                {
                    listnhapkho.Add(new CartItemDTO { MaSP = kvp.Key, SoLuong = sl, DonGia = gia });
                }
            }

            if (listnhapkho.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng và giá cho ít nhất 1 sản phẩm.");
                return;
            }

            var result = KhoBUS.XuLyNhapKho((int)cbbNhaCungCap.SelectedValue, maNV, listnhapkho);

            MessageBox.Show(result.message);
            if (result.success)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}