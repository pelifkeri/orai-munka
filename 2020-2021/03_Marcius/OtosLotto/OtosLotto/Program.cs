using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OtosLotto
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2. feladat
            List<Sorsolas> sorsolasok = new List<Sorsolas>();
            var beolvasott = File.ReadAllLines(@"C:\temp\lotto\otos.csv");
            foreach (var sor in beolvasott)
            {
                var sorsolas = new Sorsolas(sor);
                sorsolasok.Add(sorsolas);
            }

            // 3. feladat
            Console.WriteLine($"Összesen {sorsolasok.Count} héten történt húzás.");

            // 4. feladat
            var legelsoHuzas = sorsolasok
                .OrderBy(x => x.Datum)
                .Where(x => x.Datum != new DateTime())
                .First()
                .Datum.ToShortDateString();

            Console.WriteLine($"A legelső húzás {legelsoHuzas} napon történt.");

            // 5. feladat
            var legnagyobbOsszeg = sorsolasok
                .OrderByDescending(x => x.OtosOsszeg)
                .First();

            Console.WriteLine($"A legnagyobb nyeremény {legnagyobbOsszeg.OtosOsszeg:0,###} Ft volt {legnagyobbOsszeg.Datum.ToShortDateString()} napon.");
            Console.WriteLine(String.Join(", ", legnagyobbOsszeg.Szamok));

            // 6. feladat
            var azonosHuzasok = sorsolasok
                .GroupBy(x => x.Szamok)
                .Where(x => x.Count() > 1)
                .ToList();

            foreach (var huzas in azonosHuzasok)
            {
                Console.WriteLine($"Ismétlődő számok: {huzas.Key} összesen {huzas.Count()} alkalommal");
            }

            // 7. feladat
            var kilencvennyóc = sorsolasok
                .Where(x => x.Ev > 1997 && x.Otos > 0)
                .ToList();

            Console.WriteLine($"Összesen {kilencvennyóc.Sum(x => x.Otos)} db telitalálat volt {kilencvennyóc.Sum(x => x.OtosOsszeg)} értékben.");

            // 8. feladat
            var max2 = sorsolasok.Max(x => x.KettesOsszeg);
            var max3 = sorsolasok.Max(x => x.HarmasOsszeg);
            var max4 = sorsolasok.Max(x => x.NegyesOsszeg);

            Console.WriteLine($"2-es: {max2}, 3-as: {max3}, 4-es: {max4}");

            // 9. feladat
            var legtobbNegyes = sorsolasok
                .OrderByDescending(x => x.Negyes)
                .First();
            Console.WriteLine($"A legtöbb 4-est {legtobbNegyes.Datum.ToShortDateString()} napon nyerték. {legtobbNegyes.Negyes} db játékos nyert, fejenként {legtobbNegyes.NegyesOsszeg} Ft-ot");

            // 10. feladat
            bool folytatas = true;
            List<int> beadottSzamok = new List<int>();
            do
            {
                string szamsor = "";
                beadottSzamok.Clear();
                Console.WriteLine("Adj meg 5 db számot szóközökkel elválasztva!");
                try
                {
                    var szamok = Console.ReadLine();
                    var split = szamok.Split().ToList();
                    if (split.Distinct().Count() != 5)
                    {
                        continue;
                    }

                    split.ForEach(x => beadottSzamok.Add(Convert.ToInt32(x)));
                    beadottSzamok.OrderBy(x => x);
                    szamsor = $"{beadottSzamok[0]}, {beadottSzamok[1]}, {beadottSzamok[2]}, {beadottSzamok[3]}, {beadottSzamok[4]}";
                }
                catch (Exception)
                {
                    continue;
                }

                var talalat = sorsolasok
                    .Where(x => x.Szamok == szamsor)
                    .ToList();

                if (talalat.Count > 0)
                {
                    Console.WriteLine($"Volt ilyen számokkal való sorsolás {talalat[0].Datum} napon!");
                }
                else
                {
                    Console.WriteLine("Nem volt még sorsolás ezekkel a számokkal!");
                }

                Console.WriteLine("Szeretnél-e még próbálkozni? (igen/nem)");
                var valasz = Console.ReadLine();
                if (valasz == "nem")
                {
                    folytatas = false;
                }
            } while (folytatas);

            Console.ReadLine();
        }
    }
}
