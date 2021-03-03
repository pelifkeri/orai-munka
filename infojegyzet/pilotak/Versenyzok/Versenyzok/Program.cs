using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Versenyzok
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2. feladat
            List<Pilota> pilotak = new List<Pilota>();
            var beolvasott = File.ReadAllLines(@"C:\temp\pilotak\pilotak.csv");
            foreach (var sor in beolvasott.Skip(1))
            {
                var pilota = new Pilota(sor);
                pilotak.Add(pilota);
            }

            // 3. feladat
            Console.WriteLine(pilotak.Count);

            // 4. feladat
            var utolso = pilotak.LastOrDefault();
            Console.WriteLine(utolso.Nev);

            // 5. feladat
            var datum = new DateTime(1901, 1, 1);
            var idosek = pilotak.Where(x => x.SzuletesiDatum < datum).ToList();
            foreach (var item in idosek)
            {
                Console.WriteLine($"{item.Nev} ({item.SzuletesiDatum.ToString("yyyy. MM. dd.")})");
            }

            // 6. feladat
            var legkisebb = pilotak
                .OrderBy(x => x.Rajtszam)
                .Where(x => x.Rajtszam > 0)
                .FirstOrDefault();
            Console.WriteLine(legkisebb.Nemzetiseg);

            // 7. feladat
            var azonosSorszamok = pilotak
                .GroupBy(x => x.Rajtszam)
                .Where(x => x.Count() > 1 && x.Key != 0)
                .ToList();

            var szamok = azonosSorszamok.Select(x => x.Key).ToList();
            var eredmeny = String.Join(", ", szamok);

            Console.WriteLine(eredmeny);

            Console.ReadLine();
        }
    }
}
