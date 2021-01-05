using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            button1.BackColor = c;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Szinezes();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Szinezes();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Szinezes();
        }

        private void Szinezes()
        {
            var red = TextboxKiolvasasa(textBox1);
            var green = TextboxKiolvasasa(textBox2);
            var blue = TextboxKiolvasasa(textBox3);

            Color c = Color.FromArgb(red, green, blue);
            button1.BackColor = c;
        }

        private int TextboxKiolvasasa(TextBox tb)
        {
            if (!String.IsNullOrEmpty(tb.Text))
            {
                return Convert.ToInt32(tb.Text);
            }
            else
            {
                return 0;
            }
        }
    }
}
