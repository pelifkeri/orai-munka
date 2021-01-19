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
            using var context = new DatabaseContext();

            await CreateFruits(context);

            var fruitsInDatabase = context.Fruits.ToList();

            listBox1.Items.AddRange(fruitsInDatabase.Select(x => x.Name).ToArray());
        }

        private async Task CreateFruits(DatabaseContext context)
        {
            if (!context.Fruits.Any())
            {
                var fruits = new List<Fruit>
                {
                    new Fruit{Id = 1, Color = "yellow", Name = "banana"},
                    new Fruit{Id = 2, Color = "red", Name = "apple"},
                };

                context.Fruits.AddRange(fruits);

                await context.SaveChangesAsync();
            }
        }
    }
}
