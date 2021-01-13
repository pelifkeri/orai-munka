using System;
using System.Drawing;
using System.Windows.Forms;

namespace Amoba
{
    public partial class Form1 : Form
    {
        Button[,] gombok = new Button[3, 3];
        string jelenlegiIkon = "X";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Top = i * 85;
                    button.Left = j * 85;
                    button.Height = 80;
                    button.Width = 80;
                    button.Click += Button_Click;
                    button.Font = new Font("Arial", 24, FontStyle.Bold);
                    gombok[i, j] = button;

                    this.Controls.Add(button);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ((Button)sender).Text = jelenlegiIkon;
            jelenlegiIkon = jelenlegiIkon == "X" ? "O" : "X";
            CheckIfGameIsOver();
        }

        private void CheckIfGameIsOver()
        {
            for (int i = 0; i < 3; i++)
            {
                // sorok ellenőrzése
                if (gombok[i, 0].Text == gombok[i, 1].Text && gombok[i, 1].Text == gombok[i, 2].Text && gombok[i, 0].Text != "")
                {
                    GameOver(gombok[i, 0].Text);
                }
                // oszlopok ellenőrzése
                if (gombok[0, i].Text == gombok[1, i].Text && gombok[1, i].Text == gombok[2, i].Text && gombok[0, i].Text != "")
                {
                    GameOver(gombok[0, i].Text);
                }
            }

            // egyik átló
            if (gombok[0, 0].Text == gombok[1, 1].Text && gombok[1, 1].Text == gombok[2, 2].Text && gombok[0, 0].Text != "")
            {
                GameOver(gombok[0, 0].Text);
            }
            // másik átló
            if (gombok[0, 2].Text == gombok[1, 1].Text && gombok[1, 1].Text == gombok[2, 0].Text && gombok[0, 2].Text != "")
            {
                GameOver(gombok[0, 2].Text);
            }
        }

        private void GameOver(string ikon)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gombok[i, j].Enabled = false;
                }
            }

            MessageBox.Show($"{ikon} győzött!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gombok[i, j].Enabled = true;
                    gombok[i, j].Text = "";
                }
            }
        }
    }
}
