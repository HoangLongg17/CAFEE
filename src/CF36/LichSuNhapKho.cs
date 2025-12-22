using System;
using System.Collections.Generic;
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

            this.btnLamMoi.Click += btnLamMoi_Click;
            this.btnThoat.Click += (s, e) => Close();

            this.txtTimKiem.TextChanged += (s, e) => LoadData(null, null);
            this.dtpTuNgay.ValueChanged += LoadData;
            this.dtpDenNgay.ValueChanged += LoadData;

            this.dgvLichSuNhapKho.CellContentClick += dgvLichSuNhapKho_CellContentClick;
        }

        private void LichSuNhapKho_Load(object sender, EventArgs e)
        {
            dgvLichSuNhapKho.AutoGenerateColumns = false;

            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;

            LoadData(null, null);

            try
            {
                UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
                UIText.ApplyButtonTextStyle(this);
                UIDataGridView.FormatDataGridView(dgvLichSuNhapKho);
            }
            catch { }
        }

        private void LoadData(object sender, EventArgs e)
        {
            DateTime tu = dtpTuNgay.Value.Date;
            DateTime den = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // Hết ngày

            string tuKhoa = txtTimKiem.Text.Trim();

            List<PhieuNhapDTO> list = KhoBUS.LayLichSuNhap(tu, den, tuKhoa);
            dgvLichSuNhapKho.DataSource = list;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadData(null, null);
        }

        private void dgvLichSuNhapKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLichSuNhapKho.Columns[e.ColumnIndex].Name == "chitietnhapkho")
            {
                var item = dgvLichSuNhapKho.Rows[e.RowIndex].DataBoundItem as PhieuNhapDTO;
                if (item != null)
                {
                    var frmChiTiet = new LichSuChiTietNhapKho(item.MaNK);
                    frmChiTiet.ShowDialog();
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            var data = dgvLichSuNhapKho.DataSource as List<PhieuNhapDTO>;

            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel files (*.xlsx)|*.xlsx", FileName = "LichSuNhapKho.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DateTime? tu = dtpTuNgay.Value.Date;
                    DateTime? den = dtpDenNgay.Value.Date;

                    bool success = KhoBUS.XuatExcel(data, sfd.FileName, tu, den);

                    if (success)
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo");
                    else
                        MessageBox.Show("Xuất Excel không thành công!", "Thông báo");

                }
            }
        }

        private void LichSuNhapKho_Load_1(object sender, EventArgs e) { }
        private void btnThoat_Click_1(object sender, EventArgs e) { }
    }
}