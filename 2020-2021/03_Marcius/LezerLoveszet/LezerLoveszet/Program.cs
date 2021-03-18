using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LezerLoveszet
{
    class Program
    {
        static void Main(string[] args)
        {
            // 4. feladat
            List<JatekosLovese> lista = new List<JatekosLovese>();
            var beolvasott = File.ReadAllLines(@"C:\temp\Lezer\lovesek.txt");

            var tabla = beolvasott[0].Split(';');
            double tablaX = Convert.ToDouble(tabla[0]);
            double tablaY = Convert.ToDouble(tabla[1]);

            for (int i = 1; i < beolvasott.Length; i++)
            {
                var loves = new JatekosLovese(beolvasott[i], i);
                lista.Add(loves);
            }

            // 5. feladat
            Console.WriteLine($"Összesen {lista.Count} lövést adtak le a játékosok.");

            // 7. feladat
            var legpontosabbLoves = lista.OrderBy(x => x.Tavolsag(tablaX, tablaY)).First();
            Console.WriteLine($"Sorszám: {legpontosabbLoves.Sorszam}, Név: {legpontosabbLoves.Nev}, Távolság: {legpontosabbLoves.Tavolsag(tablaX, tablaY)}");

            // 9. feladat
            var nullapontos = lista.Where(x => x.Pontszam(tablaX, tablaY) == 0).ToList();
            Console.WriteLine(nullapontos.Count);

            // 10. feladat
            var jatekosok = lista.GroupBy(x => x.Nev).ToList();
            Console.WriteLine($"A játékosok száma: {jatekosok.Count()}");

            // 11. feladat
            foreach (var nev in jatekosok)
            {
                Console.WriteLine($"{nev.Key} - {nev.Count()} db");
            }

            // 12. feladat
            var atlagpontok = jatekosok.ToDictionary(x => x.Key, y => y.Average(x => x.Pontszam(tablaX, tablaY)));
            foreach (var item in atlagpontok)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            // 13. feladat
            var legmagasabb = atlagpontok.OrderByDescending(x => x.Value).First().Key;
            Console.WriteLine($"A játék nyertese: {legmagasabb}");


            Console.ReadLine();
        }
    }
}
