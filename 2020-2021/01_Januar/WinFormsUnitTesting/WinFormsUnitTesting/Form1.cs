using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsUnitTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = Matematika.Osszeadas(textBox1.Text, textBox2.Text);

                label1.Text = result.ToString();
            }
            catch (UresTextboxException ex)
            {
                label1.Text = "Hiba történt a számítás során!";
            }
        }
    }
}
