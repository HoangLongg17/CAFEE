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
using DTO;

namespace CF36
{
    public partial class LichSuNhapKho : Form
    {
        public LichSuNhapKho()
        {
            InitializeComponent();
            this.Load += LichSuNhapKho_Load;
            this.txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            this.btnLamMoi.Click += btnLamMoi_Click;
            this.btnThoat.Click += btnThoat_Click;
            this.btnXuatExcel.Click += new EventHandler(this.btnXuatExcel_Click);
            this.dgvLichSuNhapKho.CellContentClick += dgvLichSuNhapKho_CellContentClick;


            this.dtpTuNgay.ValueChanged += LocTheoNgay;
            this.dtpDenNgay.ValueChanged += LocTheoNgay;
        }

        private void LichSuNhapKho_Load(object sender, EventArgs e)
        {
            dgvLichSuNhapKho.AutoGenerateColumns = false;
            dgvLichSuNhapKho.DataSource = LSNhapKhoBUS.LayTatCa();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);
            UIDataGridView.FormatDataGridView(dgvLichSuNhapKho);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvLichSuNhapKho.DataSource = LSNhapKhoBUS.TimKiem(txtTimKiem.Text);
        }

        private void LocTheoNgay(object sender, EventArgs e)
        {
            DateTime tu = dtpTuNgay.Value.Date;
            DateTime den = dtpDenNgay.Value.Date;
            dgvLichSuNhapKho.DataSource = LSNhapKhoBUS.LocTheoNgay(tu, den);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            dgvLichSuNhapKho.DataSource = LSNhapKhoBUS.LayTatCa();
            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now.AddDays(1);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvLichSuNhapKho.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRows = dgvLichSuNhapKho.SelectedRows;
            List<LSNhapKhoDTO> dataToExport = new List<LSNhapKhoDTO>();

            if (selectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    if (row.DataBoundItem is LSNhapKhoDTO item)
                        dataToExport.Add(item);
                }
            }
            else
            {
                dataToExport = dgvLichSuNhapKho.DataSource as List<LSNhapKhoDTO>;
            }

            if (dataToExport == null || dataToExport.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "LichSuNhapKho.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DateTime? tu = dtpTuNgay.Checked ? dtpTuNgay.Value.Date : (DateTime?)null;
                    DateTime? den = dtpDenNgay.Checked ? dtpDenNgay.Value.Date : (DateTime?)null;

                    bool success = LSNhapKhoBUS.XuatExcel(dataToExport, sfd.FileName, tu, den);

                    if (success)
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Lỗi khi xuất file Excel!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvLichSuNhapKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLichSuNhapKho.Columns[e.ColumnIndex].Name == "chitietnhapkho")
            {
                int mank = (int)dgvLichSuNhapKho.Rows[e.RowIndex].Cells["MaNk"].Value;
                var frmChiTiet = new LichSuChiTietNhapKho(mank);
                frmChiTiet.ShowDialog();
            }
        }

        private void LichSuNhapKho_Load_1(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {

        }
    }
}
