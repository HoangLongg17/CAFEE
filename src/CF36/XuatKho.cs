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
        private string selectedMaSP = "";
        private string selectedSize = "";

        public XuatKho()
        {
            InitializeComponent();

            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            btnThoat.Click += (s, e) => Close();
            btnXuat.Click += btnXuat_Click;
            dgvxuatkho.CellClick += dgvxuatkho_CellClick;
            this.Load += XuatKho_Load;
            dgvxuatkho.CellFormatting += dgvxuatkho_CellFormatting;
        }

        private void XuatKho_Load(object sender, EventArgs e)
        {
            dgvxuatkho.AutoGenerateColumns = false;
            dgvxuatkho.DataSource = KhoBUS.LayTatCa();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvxuatkho.DataSource = KhoBUS.TimKiem(txtTimKiem.Text);
        }

        private void dgvxuatkho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvxuatkho.Rows[e.RowIndex];
            selectedMaSP = row.Cells["MaSP"].Value?.ToString() ?? "";
            selectedSize = row.Cells["Size"].Value?.ToString() ?? "";
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            var danhSach = dgvxuatkho.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => new KhoDTO
                {
                    MaSP = r.Cells["MaSP"].Value?.ToString(),
                    Size = r.Cells["Size"].Value?.ToString(),
                    SoLuongXuat = int.TryParse(txtSoLuong.Text, out int sl) ? sl : 0
                })
                .ToList();

            var result = KhoBUS.XuatKho(danhSach);
            MessageBox.Show(result.message);

            if (result.success)
            {
                dgvxuatkho.DataSource = KhoBUS.LayTatCa();
                txtSoLuong.Clear();
            }
        }


        private void dgvxuatkho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = dgvxuatkho.Columns[e.ColumnIndex];

            if (col.DataPropertyName == "SoLuong")
            {
                var item = dgvxuatkho.Rows[e.RowIndex].DataBoundItem as KhoDTO;
                if (item != null && item.IsLowStock)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = dgvxuatkho.DefaultCellStyle.BackColor;
                    e.CellStyle.ForeColor = dgvxuatkho.DefaultCellStyle.ForeColor;
                }
            }
        }
        private void dgvxuatkho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        
    }
}