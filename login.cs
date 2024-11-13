using System;
using System.Windows.Forms;

namespace project
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox trên form
            string password = textBox2.Text.Trim();

            // Tạo một đối tượng DatabaseConnection
            DatabaseConnection db = new DatabaseConnection();

            // Kiểm tra tài khoản đăng nhập
            if (db.AuthenticateUser(username, password))
            {
                // Đăng nhập thành công, mở form manager
                manager m = new manager();
                this.Hide();
                m.ShowDialog();
                this.Show();
            }
            else
            {
                // Hiển thị thông báo lỗi nếu đăng nhập không thành công
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 registerForm = new Form1(); // Tạo đối tượng của Form1 (form đăng ký)
            registerForm.Show();  // Mở form đăng ký
            this.Hide();
        }
    }
}
