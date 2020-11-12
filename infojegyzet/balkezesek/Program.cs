using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kosar2004
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<Jatekos>();

            var sorok = File.ReadAllLines(@"C:\temp\balkezesek.csv");
            for (int i = 1; i < sorok.Length; i++)
            {
                var jatekos = new Jatekos(sorok[i]);
                lista.Add(jatekos);
            }

            // 3. feladat
            Console.WriteLine($"{lista.Count} adatsor található az állományban");

            // 4. feladat
            var utoljara99ben = lista.Where(x => x.UtolsoPalyaraLepes.Year == 1999 && x.UtolsoPalyaraLepes.Month == 10).ToList();

            foreach (var jatekos in utoljara99ben)
            {
                Console.WriteLine($"{jatekos.Nev} - magassága: {jatekos.MagassagCentimeterben:0.0} cm");
            }

            // 5. feladat
            Console.Write("Kérek egy 1990 és 1999 közötti évszámot!");
            var szam = Convert.ToInt32(Console.ReadLine());

            while (!(szam >= 1990 && szam <= 1999))
            {
                Console.Write("Kérek egy 1990 és 1999 közötti évszámot!");
                szam = Convert.ToInt32(Console.ReadLine());
            }

            // 6. feladat
            var jatszottak = lista.Where(x => szam <= x.UtolsoPalyaraLepes.Year && szam >= x.ElsoPalyaraLepes.Year).ToList();

            double atlagsuly = jatszottak.Average(x => x.Suly);
            Console.WriteLine($"A játékosok átlagos súlya {szam} évben {atlagsuly:0.00} volt.");

            Console.ReadLine();
        }
    }

    class Jatekos
    {
        public string Nev { get; set; }
        public DateTime ElsoPalyaraLepes { get; set; }
        public DateTime UtolsoPalyaraLepes { get; set; }
        public int Suly { get; set; }
        public int Magassag { get; set; }
        public double MagassagCentimeterben => Magassag * 2.54;

        public Jatekos(string sor)
        {
            var a = sor.Split(';');
            Nev = a[0];
            ElsoPalyaraLepes = Convert.ToDateTime(a[1]);
            UtolsoPalyaraLepes = Convert.ToDateTime(a[2]);
            Suly = Convert.ToInt32(a[3]);
            Magassag = Convert.ToInt32(a[4]);
        }
    }
}
