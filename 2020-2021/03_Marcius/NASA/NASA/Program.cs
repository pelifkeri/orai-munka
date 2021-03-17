using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NASA
{
    class Program
    {
        static void Main(string[] args)
        {
            // 4. feladat
            List<Keres> keresek = new List<Keres>();
            var beolvasott = File.ReadAllLines("NASAlog.txt");
            foreach (var sor in beolvasott)
            {
                var keres = new Keres(sor);
                keresek.Add(keres);
            }

            // 5. feladat
            Console.WriteLine($"{keresek.Count} db sor található a fájlban.");

            // 6. feladat
            var osszesMeret = keresek.Sum(x => x.ByteMeret);
            Console.WriteLine($"Az összes kérés {osszesMeret} byte méretű volt.");

            // 8. feladat
            double domainKeresek = keresek.Where(x => x.DomainNev).Count();
            double megoszlas = domainKeresek / Convert.ToDouble(keresek.Count) * 100;
            Console.WriteLine($"A domain névről befutó kérések megoszlása: {megoszlas:0.00}%");

            // 9. feladat
            var csoportositas = keresek.GroupBy(x => x.HttpKod).ToList();
            foreach (var item in csoportositas)
            {
                Console.WriteLine($"{item.Key}: {item.Count()} db");
            }

            Console.ReadLine();
        }
    }
}
