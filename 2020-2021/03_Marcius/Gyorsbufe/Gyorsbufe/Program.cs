using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gyorsbufe
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat
            List<Egysegar> arlista = new List<Egysegar>();
            var arakBeolvasott = File.ReadAllLines(@"C:\temp\nahelyzet\egysegar.csv");
            foreach (var sor in arakBeolvasott)
            {
                var ar = new Egysegar(sor);
                arlista.Add(ar);
            }

            List<Vasarlo> vasarlok = new List<Vasarlo>();
            var vasarlasokBeolvasott = File.ReadAllLines(@"C:\temp\nahelyzet\fogyasztas.csv");
            foreach (var sor in vasarlasokBeolvasott)
            {
                var a = sor.Split(';');
                if (a[0] != "")
                {
                    var vasarlo = new Vasarlo(sor);
                    vasarlok.Add(vasarlo);
                }
                else
                {
                    vasarlok.Last().UjVasarlas(sor);
                }
            }

            // 2. feladat
            Console.WriteLine($"{vasarlok.Count} db vásárló volt a napon.");

            // 3. feladat
            var napszakok = vasarlok.GroupBy(x => x.Napszak).ToList();
            foreach (var item in napszakok)
            {
                Console.WriteLine($"{item.Key} {item.Count()} darab vásárló volt a boltban.");
            }

            // 4. feladat
            var kavesVasarlok = vasarlok.Where(x => x.Vasarlas.ContainsKey("Kávé")).ToList();
            var osszesKave = kavesVasarlok.Sum(x => x.Vasarlas["Kávé"]);

            Console.WriteLine($"{kavesVasarlok.Count} db vásárló összesen {osszesKave} db kávét vásárolt.");

            // 5. feladat
            var kavesNapszak = kavesVasarlok.GroupBy(x => x.Napszak).ToList();
            foreach (var napszak in kavesNapszak)
            {
                var osszKave = napszak.Sum(x => x.Vasarlas["Kávé"]);
                Console.WriteLine($"{napszak.Key} összesen {osszKave} db kávét vásároltak.");
            }

            var legtobbKave = kavesNapszak.OrderByDescending(x => x.Sum(x => x.Vasarlas["Kávé"])).First();
            Console.WriteLine($"{legtobbKave.Key} fogyott a legtöbb kávé");

            // 6. feladat
            Dictionary<string, int> vegosszegVasarlonkent = new Dictionary<string, int>();

            foreach (var vasarlo in vasarlok)
            {
                vasarlo.VasarlasVegosszege(arlista);
                vegosszegVasarlonkent.Add(vasarlo.Nev, vasarlo.Vegosszeg);
            }
            var osszbevetel = vegosszegVasarlonkent.Sum(x => x.Value);
            Console.WriteLine($"{osszbevetel} Ft volt a napi összes bevétel.");

            var csv = vegosszegVasarlonkent.Select(x => $"{x.Key};{x.Value}").ToList();
            csv.Add($"osszbevetel;{osszbevetel}");
            File.WriteAllLines(@"C:\temp\nahelyzet\napibevetel.csv", csv);

            // 7. feladat
            var koltesNapszakonkent = vasarlok
                .GroupBy(x => x.Napszak)
                .OrderByDescending(y => y.Sum(z => z.Vegosszeg))
                .First();
            Console.WriteLine($"{koltesNapszakonkent.Key} költöttek a legtöbbet.");

            // 8. feladat
            var legtobbetkoltovasarlo = vasarlok.OrderByDescending(x => x.Vegosszeg).First();
            Console.WriteLine($"{legtobbetkoltovasarlo.Nev} vásárló összesen {legtobbetkoltovasarlo.Vegosszeg} Ft-ot költött, ez volt a legtöbb.");

            // 9. feladat
            var legtobbKulonbozotVasarlo = vasarlok.OrderByDescending(x => x.Vasarlas.Count()).First();
            Console.WriteLine($"{legtobbKulonbozotVasarlo.Nev} összesen {legtobbKulonbozotVasarlo.Vasarlas.Count()} db termékre összesen {legtobbKulonbozotVasarlo.Vegosszeg} Ft-ot költött");

            // 10. feladat
            var egyesvasarlok = vasarlok.Where(x => x.Vasarlas.Count() == 1).ToList();
            var legtobbEgyesVasarlo = egyesvasarlok.OrderByDescending(x => x.Vegosszeg).First();
            Console.WriteLine($"Összesen {egyesvasarlok.Count} db vásárló vett csupán egyetlen terméket. A legtöbbet {legtobbEgyesVasarlo.Nev} költötte, {legtobbEgyesVasarlo.Vegosszeg} Ft értékben.");
            Console.ReadLine();
        }
    }
}
