using System;

namespace Versenyzok
{
    class Pilota
    {
        public string Nev { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public string Nemzetiseg { get; set; }
        public int Rajtszam { get; set; }

        public Pilota(string sor)
        {
            var a = sor.Split(';');
            Nev = a[0];
            SzuletesiDatum = Convert.ToDateTime(a[1]);
            Nemzetiseg = a[2];
            Rajtszam = a[3] == "" ? 0 : Convert.ToInt32(a[3]);
        }
    }
}
