using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WinFormsLogin
{
    public partial class Form4 : Form
    {
        private readonly string connectionString;

        public Form4()
        {
            InitializeComponent();
            connectionString = "server=localhost;database=teszt;uid=root";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Nem egyezik a két jelszó!");
                return;
            }

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = $"SELECT COUNT(*) FROM users WHERE username = '{textBox1.Text}' AND email = '{textBox2.Text}'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                bool existingUser = false;

                while (reader.Read())
                {
                    existingUser = Convert.ToInt32(reader[0]) > 0;
                }
                reader.Close();

                if (existingUser)
                {
                    string update = $"UPDATE users SET password = '{textBox3.Text}' WHERE username = '{textBox1.Text}' AND email = '{textBox2.Text}'";
                    MySqlCommand insertCommand = new MySqlCommand(update, connection);
                    insertCommand.ExecuteReader();

                    MessageBox.Show("Sikeresen megváltoztattuk a jelszót!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nem egyezik a felhasználónév és az e-mail cím!");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection!");
            }
        }
    }
}
