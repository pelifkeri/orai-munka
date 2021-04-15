using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace eutazas
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat
            List<Utazas> utazasok = new List<Utazas>();
            var beolvasott = File.ReadAllLines(@"C:\temp\eutazas\4_eUtazas\utasadat.txt");
            foreach (var sor in beolvasott)
            {
                var utazas = new Utazas(sor);
                utazasok.Add(utazas);
            }

            // 2. feladat
            Console.WriteLine($"Összesen {utazasok.Count} utas szállt fel a buszra.");

            // 3. feladat
            var ervenytelenUtazas = utazasok.Where(x => !x.ErvenyesUtazas()).ToList().Count;
            Console.WriteLine($"Összesen {ervenytelenUtazas} db érvénytelen felszállás történt.");

            // 4. feladat
            var megallok = utazasok
                .GroupBy(x => x.Megallo)
                .OrderByDescending(x => x.Count())
                .First();
            Console.WriteLine($"A {megallok.Key}. számú megállóban próbált felszállni a legtöbb utas ({megallok.Count()} utas).");

            // 5. feladat
            var kedvezmenyes = utazasok
                .Where(x => x.KedvezmenyesUtazas && x.ErvenyesUtazas())
                .ToList();

            var ingyenes = utazasok
                .Where(x => x.IngyenesUtazas && x.ErvenyesUtazas())
                .ToList();

            Console.WriteLine($"Összesen {kedvezmenyes.Count} darab kedvezményes utazás történt.");
            Console.WriteLine($"Összesen {ingyenes.Count} darab ingyenes utazás történt.");

            // 6. feladat
            List<string> figyelmeztetesek = new List<string>();

            var berletesUtazok = utazasok.Where(x => x.BerletesUtazo).ToList();
            foreach (var utas in berletesUtazok)
            {
                int e1, h1, n1, e2, h2, n2;

                e1 = Convert.ToInt32(utas.Datum.Substring(0, 4));
                h1 = Convert.ToInt32(utas.Datum.Substring(4, 2));
                n1 = Convert.ToInt32(utas.Datum.Substring(6, 2));
                e2 = Convert.ToInt32(utas.Lejarat.Substring(0, 4));
                h2 = Convert.ToInt32(utas.Lejarat.Substring(4, 2));
                n2 = Convert.ToInt32(utas.Lejarat.Substring(6, 2));

                var hatralevoNap = utas.NapokSzama(e1, h1, n1, e2, h2, n2);

                if (hatralevoNap < 3)
                {
                    figyelmeztetesek.Add($"{utas.KartyaAzonosito} {e2}-{h2}-{n2}");
                }
            }

            File.WriteAllLines(@"C:\temp\eutazas\figyelmeztetesek.txt", figyelmeztetesek);

            Console.ReadLine();
        }
    }
}
