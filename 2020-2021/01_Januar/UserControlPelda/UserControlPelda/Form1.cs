using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UserControlPelda
{
    public partial class Form1 : Form
    {
        List<UserControl> lista;

        public Form1()
        {
            InitializeComponent();

            lista = new List<UserControl> { uc1, uc2, uc3 };

            comboBox1.Items.AddRange(new string[] { "Alma", "Körte", "Banán" });
            listBox1.Items.AddRange(new string[] { "Alma", "Körte", "Banán" });
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            HideAllUserControls();

            if (radioButton1.Checked)
            {
                uc1.Visible = true;
            }
            else if (radioButton2.Checked)
            {
                uc2.Visible = true;
            }
            else if (radioButton3.Checked)
            {
                uc3.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllUserControls();

            var selected = comboBox1.SelectedIndex;
            lista[selected].Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllUserControls();

            var selected = listBox1.SelectedIndex;
            lista[selected].Visible = true;
        }

        private void HideAllUserControls()
        {
            lista.ForEach(x => x.Visible = false);
        }
    }
}
