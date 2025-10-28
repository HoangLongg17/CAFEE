using DocumentFormat.OpenXml.Spreadsheet;

namespace CF36
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            UIButton.ReplaceStandardButtonsWithIcons(this, Properties.Resources.exit, Properties.Resources.delete, Properties.Resources.refresh);
        }

        private void btnDangNhapQuanLi_Click(object sender, EventArgs e)
        {
            DangNhapQL dangNhapQL = new DangNhapQL();
            this.Hide();
            dangNhapQL.ShowDialog();
            this.Show();
        }

        private void btnDangNhapNhanVien_Click(object sender, EventArgs e)
        {


            DangNhapNV dangNhapNV = new DangNhapNV();
            this.Hide();
            dangNhapNV.ShowDialog();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
