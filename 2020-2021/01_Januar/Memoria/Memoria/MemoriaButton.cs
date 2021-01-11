using System;
using System.Drawing;
using System.Windows.Forms;

namespace Memoria
{
    public class MemoriaButton : Button
    {
        public string KepUrl { get; set; }

        public MemoriaButton(string kepUrl)
        {
            KepUrl = kepUrl;

            this.Click += MemoriaButton_Click;
        }

        private void MemoriaButton_Click(object sender, EventArgs e)
        {
            Statisztika.FelfedettKartyakSzama += 1;
            Statisztika.FelforditottKepek.Add(KepUrl);

            this.BackgroundImage = Image.FromFile(KepUrl);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
