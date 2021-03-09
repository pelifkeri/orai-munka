using System;

namespace OtosLotto
{
    class Sorsolas
    {
        public int Ev { get; set; }
        public int Het { get; set; }
        public DateTime Datum { get; set; }
        public int Otos { get; set; }
        public long OtosOsszeg { get; set; }
        public int Negyes { get; set; }
        public int NegyesOsszeg { get; set; }
        public int Harmas { get; set; }
        public int HarmasOsszeg { get; set; }
        public int Kettes { get; set; }
        public int KettesOsszeg { get; set; }
        public string Szamok { get; set; }

        public Sorsolas(string sor)
        {
            var a = sor.Split(';');

            Ev = Convert.ToInt32(a[0]);
            Het = Convert.ToInt32(a[1]);
            Datum = a[2] == "" ? new DateTime() : Convert.ToDateTime(a[2]);
            Otos = Convert.ToInt32(a[3]);
            OtosOsszeg = Convert.ToInt64(a[4]);
            Negyes = Convert.ToInt32(a[5]);
            NegyesOsszeg = Convert.ToInt32(a[6]);
            Harmas = Convert.ToInt32(a[7]);
            HarmasOsszeg = Convert.ToInt32(a[8]);
            Kettes = Convert.ToInt32(a[9]);
            KettesOsszeg = Convert.ToInt32(a[10]);
            Szamok = $"{a[11]}, {a[12]}, {a[13]}, {a[14]}, {a[15]}";
        }
    }
}
