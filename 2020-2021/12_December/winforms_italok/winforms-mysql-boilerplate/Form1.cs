using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace winforms_mysql_boilerplate
{
    public partial class Form1 : Form
    {
        private readonly string connectionString;
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            connectionString = "server=localhost;database=teszt;uid=root";
            connection = new MySqlConnection(connectionString);
            connection.Open();

            listBox1.ValueMember = nameof(Ital.Id);
            listBox1.DisplayMember = nameof(Ital.Nev);

            LoadData();
        }

        ~Form1()
        {
            connection.Close();
        }

        private void LoadData()
        {
            listBox1.Items.Clear();

            try
            {
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnListboxSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (Ital)listBox1.SelectedItem;
            textBox1.Text = selectedItem.Nev;
        }

        private void OnAtnevezesClick(object sender, EventArgs e)
        {
            var kijeloltElem = (Ital)listBox1.SelectedItems[0];
            var ujErtek = textBox1.Text;

            try
            {
                string sql = $"UPDATE italok SET Name = '{ujErtek}' WHERE Id = {kijeloltElem.Id}";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                reader.Close();

                LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnHozzaadas_Click(object sender, EventArgs e)
        {
            try
            {
                var nev = txtHozzaadas.Text;
                string sql = $"INSERT INTO italok (Name) values('{nev}')";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                reader.Close();

                LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var id = ((Ital)listBox1.SelectedItem).Id;
                string sql = $"DELETE FROM italok WHERE Id = {id}";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                reader.Close();

                LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
