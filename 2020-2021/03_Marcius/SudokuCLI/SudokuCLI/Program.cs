using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SudokuCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3. feladat
            List<Feladvany> feladvanyok = new List<Feladvany>();
            var beolvasott = File.ReadAllLines(@"C:\temp\Sudoku\feladvanyok.txt");
            foreach (var sor in beolvasott)
            {
                var feladvany = new Feladvany(sor);
                feladvanyok.Add(feladvany);
            }

            Console.WriteLine($"Beolvasva {feladvanyok.Count} feladvány.");

            // 4. feladat
            int szam;
            do
            {
                szam = Convert.ToInt32(Console.ReadLine());
            } while (szam < 4 || szam > 9);

            var talalatok = feladvanyok.Where(x => x.Meret == szam).ToList();
            Console.WriteLine($"{szam}x{szam} méretből {talalatok.Count} feladvány van tárolva.");

            // 5. feladat
            Random r = new Random();
            var randomFeladat = talalatok[r.Next(0, talalatok.Count)];
            Console.WriteLine($"{randomFeladat.Kezdo}");

            // 6. feladat
            double kitoltottSzamok = randomFeladat.Kezdo.Where(x => x != '0').Count();
            var eredmeny = kitoltottSzamok / Convert.ToDouble(randomFeladat.Kezdo.Length) * 100;

            Console.WriteLine($"A feladat kitöltöttsége {eredmeny}%");

            // 7. feladat
            Console.WriteLine();
            randomFeladat.Kirajzol();

            // 8. feladat
            var lista = talalatok.Select(x => x.Kezdo);
            File.WriteAllLines($@"C:\temp\sudoku\sudoku{szam}.txt", lista);

            Console.ReadLine();
        }
    }
}
