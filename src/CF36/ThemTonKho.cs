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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CF36
{
    public partial class ThemTonKho : Form
    {
        private string selectedMaSP = "";
        private string selectedSize = "";
        public ThemTonKho()
        {
            InitializeComponent();

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            btnThoat.Click += (s, e) => Close();

            btnThem.Click += btnThem_Click;

            dgvThemkho.CellClick += dgvThemkho_CellClick;

            txtSoLuong.TextChanged += InputChanged_UpdateTotal;
            txtGiaNhap.TextChanged += InputChanged_UpdateTotal;

            this.Load += ThemTonKho_Load;
            this.dgvThemkho.CellFormatting += dgvThemkho_CellFormatting;

        }

        private void ThemTonKho_Load(object sender, EventArgs e)
        {
            dgvThemkho.AutoGenerateColumns = false;
            dgvThemkho.DataSource = KhoBUS.LayTatCa();
            cbbNhaCungCap.DataSource = KhoBUS.LayNhaCungCap();
            cbbNhaCungCap.DisplayMember = "Tennhacc";   // hiện tên NCC
            cbbNhaCungCap.ValueMember = "Manhacc";      // giữ mã NCC để lưu DB
            cbbNhaCungCap.SelectedIndex = -1;
        }
        private void tlpall_Paint(object sender, PaintEventArgs e)
        {

        }


        private void InputChanged_UpdateTotal(object sender, EventArgs e)
        {
            int sl = int.TryParse(txtSoLuong.Text, out int x) ? x : 0;
            decimal gia = decimal.TryParse(txtGiaNhap.Text, out decimal y) ? y : 0;
            texttongtien.Text = KhoBUS.TinhTongTien(sl, gia).ToString("N0");
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvThemkho.DataSource = KhoBUS.TimKiem(txtTimKiem.Text);

        }
        private void dgvThemkho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvThemkho.Rows[e.RowIndex];
            selectedMaSP = row.Cells["MaSP"].Value?.ToString() ?? "";
            selectedSize = row.Cells["Size"].Value?.ToString() ?? "";
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           

            var danhSach = dgvThemkho.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => new KhoDTO
                {
                    MaSP = r.Cells["MaSP"].Value?.ToString(),
                    Size = r.Cells["Size"].Value?.ToString(),
                    SoLuongNhap = int.TryParse(txtSoLuong.Text, out int sl) ? sl : 0,
                    GiaNhap = decimal.TryParse(txtGiaNhap.Text, out decimal g) ? g : -1,
                    MaNCC = cbbNhaCungCap.SelectedValue != null
                                ? Convert.ToInt32(cbbNhaCungCap.SelectedValue)
                                : (int?)null
                })
                .ToList();

            var result = KhoBUS.ThemTonKho(danhSach);
            MessageBox.Show(result.message);

            if (result.success)
            {
                dgvThemkho.DataSource = KhoBUS.LayTatCa();
                texttongtien.Text = result.tongTien.ToString("N0");
                txtSoLuong.Clear();
                txtGiaNhap.Clear();
            }
        }

        private void dgvThemkho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvThemkho.Columns[e.ColumnIndex];

            if (col.DataPropertyName == "SoLuong")
            {
                var item = dgvThemkho.Rows[e.RowIndex].DataBoundItem as KhoDTO;
                if (item != null && item.IsLowStock)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = dgvThemkho.DefaultCellStyle.BackColor;
                    e.CellStyle.ForeColor = dgvThemkho.DefaultCellStyle.ForeColor;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tlpThongtin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
