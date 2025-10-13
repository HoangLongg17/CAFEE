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
    }
}
