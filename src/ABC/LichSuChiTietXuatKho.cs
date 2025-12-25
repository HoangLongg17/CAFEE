using System;
using System.Windows.Forms;
using BUS;

namespace ABC
{
    public partial class LichSuChiTietXuatKho : Form
    {
        private int _maXK;

        public LichSuChiTietXuatKho(int maXK)
        {
            InitializeComponent();
            _maXK = maXK;
            this.Load += LichSuChiTietXuatKho_Load;
            this.btnDong.Click += (s, e) => Close();
        }

        private void LichSuChiTietXuatKho_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"CHI TIẾT PHIẾU XUẤT #{_maXK}";
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.DataSource = KhoBUS.LayChiTietPhieuXuat(_maXK);

            try
            {
                UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
                UIText.ApplyButtonTextStyle(this);
                UIDataGridView.FormatDataGridView(dgvChiTiet);
            }
            catch { }
        }
    }
}