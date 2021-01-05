using System;
using System.Windows.Forms;

namespace WinFormsDesign
{
    public partial class Form2 : Form
    {
        public string ValamiAdat { get; set; }

        public Form2()
        {
            InitializeComponent();
            ValamiAdat = "Magic string";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
