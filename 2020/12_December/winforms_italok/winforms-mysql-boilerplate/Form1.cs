using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace winforms_mysql_boilerplate
{
    public partial class Form1 : Form
    {
        private readonly string connectionString;

        public Form1()
        {
            InitializeComponent();
            connectionString = "server=localhost;database=teszt;uid=root";

            listBox1.ValueMember = nameof(Ital.Id);
            listBox1.DisplayMember = nameof(Ital.Nev);
        }

        private void OnButtonClick(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "SELECT * FROM italok";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var ital = new Ital(Convert.ToInt32(reader[0]), reader[1].ToString());
                    listBox1.Items.Add(ital);

                    Console.WriteLine(ital);

                }
                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection!");
            }
        }

        private void OnListboxSelectedIndexChanged(object sender, EventArgs e)
        {
            var kijeloltElem = (Ital)listBox1.SelectedItems[0];
            textBox1.Text = kijeloltElem.Nev;
        }

        private void OnAtnevezesClick(object sender, EventArgs e)
        {
            var kijeloltElem = (Ital)listBox1.SelectedItems[0];
            var ujErtek = textBox1.Text;

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = $"UPDATE italok SET Name = '{ujErtek}' WHERE Id = {kijeloltElem.Id}";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                reader.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection!");
            }
        }
    }
}
