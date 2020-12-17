using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DispalyData
{
    public partial class Form1 : Form
    {
        MySqlDataAdapter adapter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetData();
        }

        private void GetData()
        {
            try
            {
                var connectionString = "datasource=localhost;port=3306;username=root;database=teszt";
                adapter = new MySqlDataAdapter("SELECT * FROM users", connectionString);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

                DataTable table = new DataTable();
                adapter.Fill(table);
                bindingSource1.DataSource = table;

                bindingSource1.Sort = "Age DESC";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveChanges(object sender, EventArgs e)
        {
            adapter.Update((DataTable)bindingSource1.DataSource);
        }

        private void RefreshData(object sender, EventArgs e) => GetData();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            bindingSource1.Filter = $"fname LIKE '*{text}*' OR iname LIKE '*{text}*'";
            bindingSource1.Sort = "fname ASC";
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (bindingSource1.DataSource != null)
            {
                adapter.Update((DataTable)bindingSource1.DataSource);
            }
        }

        private void DeleteRows(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }
    }
}
