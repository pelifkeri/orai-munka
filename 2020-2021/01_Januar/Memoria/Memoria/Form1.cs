using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Memoria
{
    public partial class Form1 : Form
    {
        private string KepUrl = @"C:\Users\Dunowen\Desktop\ikon.jpg";
        private List<MemoriaButton> Gombok = new List<MemoriaButton>();
        private Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();

            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;

            //ha van pár
            if (Statisztika.FelforditottKepek[0] == Statisztika.FelforditottKepek[1])
            {
                foreach (var item in this.Controls)
                {
                    if (item is MemoriaButton)
                    {
                        if (((MemoriaButton)item).KepUrl == Statisztika.FelforditottKepek[0])
                        {
                            ((MemoriaButton)item).Hide();
                        }
                    }
                }
                Statisztika.EltalaltParokSzama += 1;
                label1.Text = $"Eltalált párok száma: {Statisztika.EltalaltParokSzama}";
            }

            if (Statisztika.EltalaltParokSzama == 15)
            {
                MessageBox.Show("Gratula");
            }

            Statisztika.FelfedettKartyakSzama = 0;
            Statisztika.FelforditottKepek.Clear();
            Gombok.ForEach(x => x.BackgroundImage = null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    MemoriaButton button = new MemoriaButton(KepUrl);
                    button.Top = 100 + i * 45;
                    button.Left = 230 + j * 45;
                    button.Height = 40;
                    button.Width = 40;
                    button.Click += Button_Click;
                    Gombok.Add(button);

                    this.Controls.Add(button);
                }
            }

            Gombok[0].KepUrl = $@"C:\Users\Dunowen\Desktop\temp_kepek\1.jpg";
            Gombok[1].KepUrl = $@"C:\Users\Dunowen\Desktop\temp_kepek\1.jpg";

            Gombok[2].KepUrl = $@"C:\Users\Dunowen\Desktop\temp_kepek\2.jpg";
            Gombok[3].KepUrl = $@"C:\Users\Dunowen\Desktop\temp_kepek\2.jpg";

            Gombok[4].KepUrl = $@"C:\Users\Dunowen\Desktop\temp_kepek\3.jpg";
            Gombok[5].KepUrl = $@"C:\Users\Dunowen\Desktop\temp_kepek\3.jpg";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (Statisztika.FelfedettKartyakSzama == 2)
            {
                //indítsuk el egy timert pl. 2 mp-ig
                timer.Enabled = true;
            }
        }
    }
}
