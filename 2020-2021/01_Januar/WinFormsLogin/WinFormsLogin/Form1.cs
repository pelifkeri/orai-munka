using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsLogin
{
    public partial class Form1 : Form
    {
        private readonly string connectionString;

        public Form1()
        {
            InitializeComponent();
            connectionString = "server=localhost;database=teszt;uid=root";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = $"SELECT COUNT(*) FROM users WHERE username = '{textBox1.Text}' AND password = '{textBox2.Text}'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                bool userFound = false;

                while (reader.Read())
                {
                    userFound = Convert.ToInt32(reader[0]) > 0;
                }

                connection.Close();

                if (userFound)
                {
                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Rossz adatokat adtál meg!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection!");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}
