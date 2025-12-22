using BUS;
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
    public partial class QuanLiKho : Form
    {

        public QuanLiKho()
        {
            InitializeComponent();
            this.Load += QuanLiKho_Load;

            this.txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            this.btnLamMoi.Click += btnLamMoi_Click;
            this.btnThoat.Click += btnThoat_Click;
            this.dgvKho.CellFormatting += dgvKho_CellFormatting;

        }

        private void QuanLiKho_Load(object sender, EventArgs e)
        {
            dgvKho.AutoGenerateColumns = false;
            LoadData();

            try
            {
                UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
                UIText.ApplyButtonTextStyle(this);
                UIDataGridView.FormatDataGridView(dgvKho);
            }
            catch { }
        }

        private void LoadData()
        {
            dgvKho.DataSource = KhoBUS.LayTatCaSanPham();
        }

        private List<int> Laymasp()
        {
            List<int> listMaSP = new List<int>();
            foreach (DataGridViewRow row in dgvKho.SelectedRows)
            {
                if (row.Cells["Masp"].Value != null)
                {
                    listMaSP.Add(Convert.ToInt32(row.Cells["Masp"].Value));
                }
            }
            return listMaSP;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvKho.DataSource = KhoBUS.TimKiemSanPham(txtTimKiem.Text);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            var listIDs = Laymasp();
            if (listIDs.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để nhập kho (Giữ phím Ctrl để chọn nhiều).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThemTonKho formNhap = new ThemTonKho(listIDs);
            if (formNhap.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            var listIDs = Laymasp();
            if (listIDs.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để xuất kho (Giữ phím Ctrl để chọn nhiều).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XuatKho formXuat = new XuatKho(listIDs);
            if (formXuat.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dgvKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKho.Rows.Count) return;

            if (dgvKho.Columns[e.ColumnIndex].Name == "SoLuong")
            {
                var item = dgvKho.Rows[e.RowIndex].DataBoundItem as SanPhamTonKhoDTO;
                if (item != null && item.IsLowStock)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.BackColor = dgvKho.DefaultCellStyle.BackColor;
                    e.CellStyle.ForeColor = dgvKho.DefaultCellStyle.ForeColor;
                }
            }
        }
    }
}