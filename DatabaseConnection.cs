using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DatabaseConnection
    {
        // Chuỗi kết nối tới cơ sở dữ liệu SQL Server
        private readonly string connectionString = "Server=LAPTOP-SKMRHNVS\\SQLEXPRESS;Database=project;Integrated Security=True;";

        private SqlConnection connection;

        // Hàm khởi tạo
        public DatabaseConnection()
        {
            connection = new SqlConnection(connectionString);
        }

        // Mở kết nối tới cơ sở dữ liệu
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Đóng kết nối tới cơ sở dữ liệu
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Phương thức để xác thực tài khoản
        public bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
            string query = "SELECT COUNT(1) FROM taikhoan WHERE username = @username AND password = @password";

            try
            {
                OpenConnection();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Sử dụng tham số để tránh SQL Injection
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    // Thực thi câu lệnh SQL
                    int count = (int)command.ExecuteScalar();
                    isAuthenticated = (count == 1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực thi câu lệnh SQL: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return isAuthenticated;
        }
        public bool RegisterUser(string username, string password, string firstName, string lastName, string email, string phoneNumber, string gender)
        {
            string query = "INSERT INTO taikhoan (username, password, firstName, lastName, email, phoneNumber, gender) " +
                           "VALUES (@username, @password, @firstName, @lastName, @email, @phoneNumber, @gender)";

            try
            {
                OpenConnection();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số vào câu lệnh SQL để tránh SQL Injection
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@gender", gender);

                    // Thực thi câu lệnh SQL
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu thêm thành công
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm tài khoản vào cơ sở dữ liệu: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
