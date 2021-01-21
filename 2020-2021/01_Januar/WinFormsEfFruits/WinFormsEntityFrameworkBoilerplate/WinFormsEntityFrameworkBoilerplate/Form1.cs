using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsEntityFrameworkBoilerplate.Database;
using WinFormsEntityFrameworkBoilerplate.Database.Models;

namespace WinFormsEntityFrameworkBoilerplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using var context = new DatabaseContext();

                await CreateFruits(context);
                await GetFruitsIntoListbox(context);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task CreateFruits(DatabaseContext context)
        {
            if (!context.Fruits.Any())
            {
                var fruits = new List<Fruit>
                {
                    new Fruit{Id = 1, Color = "yellow", Megnevezes = "banana"},
                    new Fruit{Id = 2, Color = "red", Megnevezes = "apple"},
                };

                context.Fruits.AddRange(fruits);

                await context.SaveChangesAsync();
            }
        }

        private async void OnAddFruit(object sender, EventArgs e)
        {
            using var context = new DatabaseContext();

            var fruit = new Fruit(txtNev.Text, txtSzin.Text);
            context.Fruits.Add(fruit);

            await context.SaveChangesAsync();
            await GetFruitsIntoListbox(context);

            txtNev.Text = "";
            txtSzin.Text = "";
        }

        private async Task GetFruitsIntoListbox(DatabaseContext context)
        {
            var fruitsInDatabase = await context.Fruits.ToListAsync();
            listBox1.DisplayMember = nameof(Fruit.Megnevezes);
            listBox1.Items.Clear();
            listBox1.Items.AddRange(fruitsInDatabase.ToArray());
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var selectedFruit = (Fruit)listBox1.SelectedItem;

            using var context = new DatabaseContext();
            context.Fruits.Remove(selectedFruit);
            await context.SaveChangesAsync();

            await GetFruitsIntoListbox(context);
        }
    }
}
