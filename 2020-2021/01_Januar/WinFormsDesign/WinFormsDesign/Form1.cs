using System;
using System.Windows.Forms;

namespace WinFormsDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

            this.Hide();

            form2.FormClosed += Form2_FormClosed;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var controlok = ((Form2)sender).Controls;
            //MessageBox.Show(((Label)controlok[1]).Text);

            var str = ((Form2)sender).ValamiAdat;

            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
