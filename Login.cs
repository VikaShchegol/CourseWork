using System;
using System.Data.Common;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace course
{
    public partial class Login : Form
    {
        private MySqlConnection conn;
        public Login()
        {
            InitializeComponent();
            conn = DBUtils.GetDBConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string role = comboBoxRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            string sql = "";
            string idColumn = "";

            switch (role)
            {
                case "Клієнт":
                    sql = "SELECT ID_client FROM Clients WHERE Електронна_пошта = @Email AND Пароль = @Password";
                    idColumn = "ID_client";
                    break;
                case "Співробітник":
                    sql = "SELECT ID_employee FROM Employees WHERE Електронна_пошта = @Email AND Пароль = @Password";
                    idColumn = "ID_employee";
                    break;
                case "Тренер":
                    sql = "SELECT ID_coach FROM Coaches WHERE Електронна_пошта = @Email AND Пароль = @Password";
                    idColumn = "ID_coach";
                    break;
                case "Лікар":
                    sql = "SELECT ID_doctor FROM Doctors WHERE Електронна_пошта = @Email AND Пароль = @Password";
                    idColumn = "ID_doctor";
                    break;
                default:
                    MessageBox.Show("Выберите корректную роль.");
                    return;
            }

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(idColumn);
                            MessageBox.Show($"Вход выполнен успешно. Ваш ID: {userId}");

                            // Переход на соответствующую форму в зависимости от роли
                            switch (role)
                            {
                                case "Клієнт":
                                    ClientForm clientForm = new ClientForm(userId);
                                    clientForm.Show();
                                    break;
                                case "Співробітник":
                                    EmployeeForm employeeForm = new EmployeeForm(userId);
                                    employeeForm.Show();
                                    break;
                                case "Тренер":
                                    CoachForm coachForm = new CoachForm(userId);
                                    coachForm.Show();
                                    break;
                                case "Лікар":
                                    DoctorForm doctorForm = new DoctorForm(userId);
                                    doctorForm.Show();
                                    break;
                            }

                            this.Hide(); // Скрыть форму входа
                        }
                        else
                        {
                            MessageBox.Show("Неверный email или пароль.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при входе: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}
