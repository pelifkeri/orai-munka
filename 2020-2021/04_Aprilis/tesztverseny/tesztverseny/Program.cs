using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace tesztverseny
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat
            List<Eredmeny> lista = new List<Eredmeny>();
            var beolvasott = File.ReadAllLines(@"C:\temp\tesztverseny\valaszok.txt");
            var helyesValaszok = beolvasott[0];

            foreach (var sor in beolvasott.Skip(1))
            {
                var eredmeny = new Eredmeny(sor);
                lista.Add(eredmeny);
            }

            // 2.feladat
            Console.WriteLine($"A versenyen {lista.Count} db versenyző vett részt.");

            // 3. feladat
            var azonosito = Console.ReadLine();
            var egyeniEredmeny = lista.Where(x => x.Versenyzo == azonosito).FirstOrDefault();
            Console.WriteLine($"{egyeniEredmeny.Versenyzo} - {egyeniEredmeny.Valaszok}");

            // 4. feladat
            Console.WriteLine(helyesValaszok);

            string str = "";
            for (int i = 0; i < helyesValaszok.Length; i++)
            {
                str += helyesValaszok[i] == egyeniEredmeny.Valaszok[i] ? "+" : " ";
            }
            Console.WriteLine(str);

            // 5. feladat
            var sorszam = Convert.ToInt32(Console.ReadLine());
            var helyesValasz = helyesValaszok[sorszam - 1];
            var valaszok = lista.Select(x => x.Valaszok[sorszam - 1]).ToList();
            var helyesValaszadok = valaszok.Where(x => x == helyesValasz).ToList();

            double megoszlas = Math.Round(Convert.ToDouble(helyesValaszadok.Count) / Convert.ToDouble(valaszok.Count), 4) * 100;
            Console.WriteLine($"A(z) {sorszam}. kérdésre {helyesValaszadok.Count} versenyző {megoszlas}%-a adott jó választ");

            // 6. feladat
            List<string> eredmenyek = new List<string>();
            foreach (var eredmeny in lista)
            {
                string sor = $"{eredmeny.Versenyzo} {eredmeny.Pontszam(helyesValaszok)}";
                eredmenyek.Add(sor);
            }
            File.WriteAllLines(@"C:\temp\tesztverseny\pontok.txt", eredmenyek);

            // 7. feladat
            var vegeredmeny = lista
                .GroupBy(x => x.Pontszam(helyesValaszok))
                .OrderByDescending(x => x.First().Pontszam(helyesValaszok))
                .Take(3)
                .ToList();

            int helyezes = 1;
            foreach (var versenyzok in vegeredmeny)
            {
                foreach (var item in versenyzok)
                {
                    Console.WriteLine($"({helyezes}. díj) ({item.Pontszam(helyesValaszok)} pont): {item.Versenyzo}");
                }
                helyezes += 1;
            }

            Console.ReadLine();
        }
    }
}
