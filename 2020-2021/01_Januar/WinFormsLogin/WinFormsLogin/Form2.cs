using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WinFormsLogin
{
    public partial class Form2 : Form
    {
        private readonly string connectionString;

        public Form2()
        {
            InitializeComponent();
            connectionString = "server=localhost;database=teszt;uid=root";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = $"SELECT COUNT(*) FROM users WHERE username = '{textBox1.Text}' OR email = '{textBox3.Text}'";
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
                    MessageBox.Show("Már van felhasználó ezzel a felh.névval vagy email címmel!");
                }
                else
                {
                    string insert = $"INSERT INTO users values('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}')";
                    MySqlCommand insertCommand = new MySqlCommand(insert, connection);
                    MySqlDataReader insertReader = insertCommand.ExecuteReader();

                    MessageBox.Show("Sikeresen létrehoztuk a usert!");
                    this.Close();
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
