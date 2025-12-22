using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using DTO;

namespace CF36
{
    public partial class LichSuChiTietNhapKho : Form
    {
        private int _maNK;

        public LichSuChiTietNhapKho(int maNK)
        {
            InitializeComponent();
            _maNK = maNK;
            this.Load += LichSuChiTietNhapKho_Load;
        }

        private void LichSuChiTietNhapKho_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"CHI TIẾT PHIẾU NHẬP #{_maNK}";
            dgvChiTiet.DataSource = KhoBUS.LayChiTietPhieu(_maNK);

            try
            {
                UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh, Properties.Resources.done);
                UIText.ApplyButtonTextStyle(this);
                UIDataGridView.FormatDataGridView(dgvChiTiet);
            }
            catch { }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
    }
}