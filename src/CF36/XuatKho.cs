using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace CF36
{
    public partial class XuatKho : Form
    {
        private List<int> _listIDs;
        private Dictionary<int, (TextBox txtSL, int tonKho)> _inputs = new Dictionary<int, (TextBox, int)>();

        public XuatKho(List<int> listIDs)
        {
            InitializeComponent();
            _listIDs = listIDs;

            this.Load += XuatKho_Load;
            this.btnXuat.Click += btnXuat_Click;
            this.btnThoat.Click += (s, e) =>Close();
        }

        private void XuatKho_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
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

        private void HienThiDanhSach()
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
                lblTen.Size = new Size(250, 20);
                lblTen.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lblTen.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                Label lblTon = new Label();
                lblTon.Text = $"Tồn: {item.SoLuongTon}";
                lblTon.Location = new Point(270, 10);
                lblTon.Size = new Size(100, 20);
                lblTon.ForeColor = item.IsLowStock ? Color.Red : Color.Black;
                lblTon.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                Label lblSL = new Label { Text = "Xuất:", Location = new Point(panelWidth - 220, 10), AutoSize = true };
                lblSL.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                TextBox txtSL = new TextBox();
                txtSL.Location = new Point(panelWidth - 180, 7);
                txtSL.Size = new Size(120, 25);
                txtSL.TextAlign = HorizontalAlignment.Center;
                txtSL.KeyPress += (s, e) => {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
                };
                txtSL.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                pnl.Controls.AddRange(new Control[] { lblTen, lblTon, lblSL, txtSL });
                flpDanhSachSP.Controls.Add(pnl);

                _inputs.Add(item.MaSP, (txtSL, item.SoLuongTon));
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string lyDo = txtLyDo.Text.Trim();
            if (string.IsNullOrEmpty(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do xuất kho!");
                txtLyDo.Focus();
                return;
            }

            string maNV = CurrentUser.Manv;
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Không xác định được người dùng hiện tại.");
                return;
            }

            List<CartItemDTO> listxuatkho = new List<CartItemDTO>();
            foreach (var kvp in _inputs)
            {
                int sl = int.TryParse(kvp.Value.txtSL.Text, out int s) ? s : 0;

                if (sl > 0)
                {
                    if (sl > kvp.Value.tonKho)
                    {
                        MessageBox.Show($"Sản phẩm mã {kvp.Key} không đủ tồn (Yêu cầu: {sl}, Tồn: {kvp.Value.tonKho})");
                        return;
                    }
                    listxuatkho.Add(new CartItemDTO { MaSP = kvp.Key, SoLuong = sl });
                }
            }

            if (listxuatkho.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng cho ít nhất 1 sản phẩm.");
                return;
            }

            var result = KhoBUS.XuLyXuatKho(maNV, lyDo, listxuatkho);

            MessageBox.Show(result.message);

            if (result.success)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}