using System;
using System.Data.Common;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace course
{
        public partial class RegistrationForm : Form
        {
            private MySqlConnection conn;

            public RegistrationForm()
            {
                InitializeComponent();
                conn = DBUtils.GetDBConnection();
            }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
                try
                {
                    string firstName = textBoxFirstName.Text;
                    string lastName = textBoxLastName.Text;
                    string email = textBoxEmail.Text;
                    string password = textBoxPassword.Text;
                    string role = comboBoxRole.SelectedItem?.ToString();

                    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
                    {
                        MessageBox.Show("Всі поля повинні бути заповненими.");
                        return;
                    }

                    string sql = "";

                    switch (role)
                    {
                        case "Клієнт":
                            sql = "INSERT INTO Clients (Ім_я, Прізвище, Електронна_пошта, Пароль) VALUES (@firstName, @lastName, @Email, @Password)";
                            break;
                        case "Співробітник":
                            sql = "INSERT INTO Employees (Ім_я, Прізвище, Електронна_пошта, Пароль) VALUES (@firstName, @lastName, @Email, @Password)";
                            break;
                        case "Тренер":
                            sql = "INSERT INTO Coaches (Ім_я, Прізвище, Електронна_пошта, Пароль) VALUES (@firstName, @lastName, @Email, @Password)";
                            break;
                        case "Лікар":
                            sql = "INSERT INTO Doctors (Ім_я, Прізвище, Електронна_пошта, Пароль) VALUES (@firstName, @lastName, @Email, @Password)";
                            break;
                        default:
                            MessageBox.Show("Выберите корректную роль.");
                            return;
                    }

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                    long insertedId = cmd.LastInsertedId;

                    MessageBox.Show($"Реєстрація пройшла успішно. Ваш ID: {insertedId}");

                    this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при реєстрації: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
 