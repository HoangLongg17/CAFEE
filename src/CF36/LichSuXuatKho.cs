using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using DTO;

namespace CF36
{
    public partial class LichSuXuatKho : Form
    {
        public LichSuXuatKho()
        {
            InitializeComponent();
            this.Load += LichSuXuatKho_Load;
            this.btnLamMoi.Click += (s, e) => { dtpTuNgay.Value = DateTime.Now.AddDays(-30); dtpDenNgay.Value = DateTime.Now; LoadData(); };
            this.btnThoat.Click += (s, e) => Close();
            this.btnXuatExcel.Click += btnXuatExcel_Click;
            this.txtTimKiem.TextChanged += (s, e) => LoadData();

            this.dtpTuNgay.ValueChanged += (s, e) => LoadData();
            this.dtpDenNgay.ValueChanged += (s, e) => LoadData();
            this.dgvLichSu.CellContentClick += dgvLichSu_CellContentClick;
        }

        private void LichSuXuatKho_Load(object sender, EventArgs e)
        {
            dgvLichSu.AutoGenerateColumns = false;
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();

            try
            {
                UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
                UIText.ApplyButtonTextStyle(this);
                UIDataGridView.FormatDataGridView(dgvLichSu);
            }
            catch { }
        }

        private void LoadData()
        {
            DateTime tu = dtpTuNgay.Value.Date;
            DateTime den = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
            string kw = txtTimKiem.Text.Trim();

            dgvLichSu.DataSource = KhoBUS.LayLichSuXuat(tu, den, kw);
        }

        private void dgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLichSu.Columns[e.ColumnIndex].Name == "colXemChiTiet")
            {
                var item = dgvLichSu.Rows[e.RowIndex].DataBoundItem as PhieuXuatDTO;
                if (item != null)
                {
                    var frm = new LichSuChiTietXuatKho(item.MaXK);
                    frm.ShowDialog();
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            var data = dgvLichSu.DataSource as List<PhieuXuatDTO>;
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel files (*.xlsx)|*.xlsx", FileName = "LichSuXuatKho.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bool success = KhoBUS.XuatExcelXuatKho(data, sfd.FileName, dtpTuNgay.Value, dtpDenNgay.Value);
                    MessageBox.Show(success ? "Xuất Excel thành công!" : "Lỗi khi xuất Excel.");
                }
            }
        }
    }
}