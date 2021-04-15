using System;

namespace eutazas
{
    class Utazas
    {
        public int Megallo { get; set; }
        public string Datum { get; set; }
        public int KartyaAzonosito { get; set; }
        public JegyTipusEnum JegyTipus { get; set; }
        public string Lejarat { get; set; }
        public bool IngyenesUtazas => JegyTipus == JegyTipusEnum.NYP || JegyTipus == JegyTipusEnum.RVS || JegyTipus == JegyTipusEnum.GYK;
        public bool KedvezmenyesUtazas => JegyTipus == JegyTipusEnum.TAB || JegyTipus == JegyTipusEnum.NYB;
        public bool BerletesUtazo => Lejarat.Length > 2;

        public Utazas(string sor)
        {
            var a = sor.Split();
            Megallo = Convert.ToInt32(a[0]);
            Datum = a[1];
            KartyaAzonosito = Convert.ToInt32(a[2]);
            JegyTipus = Enum.Parse<JegyTipusEnum>(a[3]);
            Lejarat = a[4];
        }

        public int NapokSzama(int e1, int h1, int n1, int e2, int h2, int n2)
        {
            h1 = (h1 + 9) % 12;
            e1 = e1 - h1 / 10;
            var d1 = 365 * e1 + e1 / 4 - e1 / 100 + e1 / 400 + (h1 * 306 + 5) / 10 + n1 - 1;
            h2 = (h2 + 9) % 12;
            e2 = e2 - h2 / 10;
            var d2 = 365 * e2 + e2 / 4 - e2 / 100 + e2 / 400 + (h2 * 306 + 5) / 10 + n2 - 1;

            return d2 - d1;
        }

        public bool ErvenyesUtazas()
        {
            if (Lejarat == "0")
            {
                return false;
            }
            else if (Lejarat.Length <= 2)
            {
                return true;
            }
            else
            {
                var utazasDatuma = Convert.ToInt32(Datum.Substring(0, 8));
                var ervenyesseg = Convert.ToInt32(Lejarat);

                return ervenyesseg >= utazasDatuma;
            }
        }
    }
}
