using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string firstName = textBox3.Text.Trim();
            string lastName = textBox4.Text.Trim();
            string email = textBox5.Text.Trim();
            string phoneNumber = textBox6.Text.Trim();
            string gender = textBox7.Text.Trim();

            // Tạo một đối tượng DatabaseConnection và gọi phương thức RegisterUser
            DatabaseConnection db = new DatabaseConnection();
            bool isRegistered = db.RegisterUser(username, password, firstName, lastName, email, phoneNumber, gender);

            // Hiển thị thông báo dựa trên kết quả đăng ký
            if (isRegistered)
            {

                MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                login loginForm = new login();
                loginForm.Show();  // Mở form đăng nhập
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
