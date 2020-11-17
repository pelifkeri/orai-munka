using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace console_app
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<Felfedezes>();

            var olvas = File.ReadAllLines(@"C:\temp\felfedezesek.csv", Encoding.GetEncoding("ISO-8859-1"));
            for (int i = 1; i < olvas.Length; i++)
            {
                var felfedezes = new Felfedezes(olvas[i]);
                lista.Add(felfedezes);
            }

            // 3. feladat
            Console.WriteLine($"{lista.Count} felfedezést tartalmaz az állomány.");

            // 4. feladat
            var okori = lista.Where(x => x.Ev == "Ókor").ToList();
            Console.WriteLine($"Felfedezések száma az ókorban: {okori.Count}");

            // 5. feladat
            string pattern = "^[A-Za-z]{1,2}$";

            var vegyjel = Console.ReadLine();
            while (!Regex.IsMatch(vegyjel, pattern))
            {
                vegyjel = Console.ReadLine();
            }

            // 6. feladat
            var elem = lista.Where(x => x.Vegyjel.Equals(vegyjel, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (elem == null)
            {
                Console.WriteLine("Nincs ilyen elem az adatforrásban!");
            }
            else
            {
                Console.WriteLine("Keresés");
                Console.WriteLine($"Az elem vegyjele: {elem.Vegyjel}");
                Console.WriteLine($"Az elem neve: {elem.Nev}");
                Console.WriteLine($"Az elem rendszáma: {elem.Rendszam}");
                Console.WriteLine($"Felfedezés éve: {elem.Ev}");
                Console.WriteLine($"Felfedező: {elem.Felfedezo}");
            }

            // 7. feladat
            var evszamok = lista
                .Where(x => x.Ev != "Ókor")
                .Select(x => Convert.ToInt32(x.Ev))
                .OrderBy(x => x)
                .ToList();

            var max = 0;
            for (int i = 0; i < evszamok.Count - 1; i++)
            {
                if ((evszamok[i + 1] - evszamok[i]) > max)
                {
                    max = evszamok[i + 1] - evszamok[i];
                }
            }

            Console.WriteLine($"{max} év volt a leghosszabb idő.");

            // 8. feladat
            var csoportositott = lista
                .Where(x => x.Ev != "Ókor")
                .GroupBy(x => x.Ev)
                .Where(x => x.Count() > 3)
                .ToList();

            foreach (var item in csoportositott)
            {
                Console.WriteLine($"{item.Key}: {item.Count()} db");
            }

            Console.ReadLine();
        }
    }

    public class Felfedezes
    {
        public string Ev { get; set; }
        public string Nev { get; set; }
        public string Vegyjel { get; set; }
        public int Rendszam { get; set; }
        public string Felfedezo { get; set; }

        public Felfedezes(string sor)
        {
            var a = sor.Split(';');
            Ev = a[0];
            Nev = a[1];
            Vegyjel = a[2];
            Rendszam = Convert.ToInt32(a[3]);
            Felfedezo = a[4];
        }
    }
}
