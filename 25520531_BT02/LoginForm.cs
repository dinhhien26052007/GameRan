namespace _25520531_BT02
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public bool KiemTraDangNhap(string ten, string mk)
        {
            if (ten.Equals("Admin") == true && mk.Equals("123456") == true)
                return true;
            return false;

        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string ten = tbTenDangNhap.Text;
            string mk = tbMatKhau.Text;
            if (KiemTraDangNhap(ten, mk))
            {
                
                QuanLySanPhamForm frmQuanLySanPham = new QuanLySanPhamForm();
                frmQuanLySanPham.Show();   
                this.Hide();


            }
            else
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu chưa chính xác !!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
//Hiển đẹp trai cute pho mai que.
