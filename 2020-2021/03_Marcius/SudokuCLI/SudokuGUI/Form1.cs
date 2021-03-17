using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuGUI
{
    public partial class Form1 : Form
    {
        public int Ertek
        {
            get { return Convert.ToInt32(txtSzam.Text); }
            set
            {
                if (value > 3 && value < 10)
                {
                    txtSzam.Text = value.ToString();
                }
            }
        }

        public int KezdoJelenlegiHossza
        {
            get { return txtKezdo.Text.Length; }
        }


        public int MyProperty { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void minuszClick(object sender, EventArgs e)
        {
            Ertek--;
        }

        private void pluszClick(object sender, EventArgs e)
        {
            Ertek++;
        }

        private void Ellenorzes(object sender, EventArgs e)
        {
            var vartHossz = Math.Pow(Ertek, 2);
            var kulonbseg = Math.Abs(vartHossz - KezdoJelenlegiHossza);

            if (txtKezdo.Text.Length == vartHossz)
            {
                MessageBox.Show("A feladvány megfelelő hosszúságú!");
            }
            else if (KezdoJelenlegiHossza < vartHossz)
            {
                MessageBox.Show($"A feladvány rövid, kell még {kulonbseg} számjegy!");
            }
            else
            {
                MessageBox.Show($"A feladvány hosszú, törlendő {kulonbseg} számjegy!");
            }
        }

        private void Kezdo_Changed(object sender, EventArgs e)
        {
            var ertek = ((TextBox)sender).Text.Length;
            lblHossz.Text = $"Hossz: {ertek}";
        }
    }
}
