using System;
using System.Collections.Generic;
using System.Data;
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
            HienThiChiTiet();
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
            UIText.ApplyButtonTextStyle(this);
            UIDataGridView.FormatDataGridView(dgvChiTiet);
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThiChiTiet();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThiChiTiet()
        {
            try
            {
                List<ChiTietNhapKhoDTO> chiTietList = BUS.LSNhapKhoBUS.LayChiTietNhapKhoTheoMaNK(_maNK);

                if (chiTietList == null || chiTietList.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu chi tiết cho phiếu này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvChiTiet.AutoGenerateColumns = false; // dùng nếu bạn set cột thủ công trong Designer
                dgvChiTiet.DataSource = chiTietList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết nhập kho: " + ex.Message);
            }
        }

        private void LichSuChiTietNhapKho_Load_1(object sender, EventArgs e)
        {
            
        }
    }
}
