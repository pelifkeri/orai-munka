using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        List<Fuvar> lista = new List<Fuvar>();
        var sorok = File.ReadAllLines(@"C:\temp\fuvar.csv");

        for (int i = 1; i < sorok.Length; i++)
        {
            var fuvar = new Fuvar(sorok[i]);
            lista.Add(fuvar);
        }

        // 3. feladat
        Console.WriteLine($"Az állományban {lista.Count} darab utazás történt.");

        // 4. feladat
        var egyediTaxis = lista.Where(x => x.TaxiId == 6185).ToList();
        var osszesBevetel = egyediTaxis.Sum(x => x.Viteldij);

        Console.WriteLine($"A 6185-ös taxis összesen {egyediTaxis.Count} fuvart teljesített {osszesBevetel} értékben.");

        // 5. feladat
        var csoportositas = lista.GroupBy(x => x.FizetesModja);

        foreach (var item in csoportositas)
        {
            Console.WriteLine($"{item.Key}: {item.Count()} fuvar");
        }

        // 6. feladat
        var osszTav = Math.Round(lista.Sum(x => x.Tavolsag) * 1.6, 2);
        Console.WriteLine($"Összesen {osszTav} km-t tettek meg a taxisok.");

        // 7. feladat
        var leghosszab = lista.OrderByDescending(x => x.Idotartam).First();
        Console.WriteLine($"Leghosszabb fuvar:");
        Console.WriteLine($"Fuvar hossza: {leghosszab.Tavolsag}");
        Console.WriteLine($"Taxi azonosító: {leghosszab.TaxiId}");
        Console.WriteLine($"Megtett távolság: {leghosszab.Tavolsag}");
        Console.WriteLine($"Viteldíj: {leghosszab.Viteldij}");

        // 8. feladat
        var szurtLista = lista
            .Where(x => x.Idotartam > 0 && x.Viteldij > 0 && x.Tavolsag == 0)
            .OrderBy(x => x.Indulas)
            .ToList();
        var szurtSorok = szurtLista.Select(x => x.ToCsv()).ToList();

        File.WriteAllLines(@"C:\temp\hibak.txt", szurtSorok, Encoding.UTF8);

        Console.ReadLine();
    }

    class Fuvar
    {
        private string Sor { get; set; }
        public int TaxiId { get; set; }
        public DateTime Indulas { get; set; }
        public int Idotartam { get; set; }
        public double Tavolsag { get; set; }
        public double Viteldij { get; set; }
        public double Borravalo { get; set; }
        public string FizetesModja { get; set; }

        public Fuvar(string sor)
        {
            Sor = sor;
            var a = sor.Split(';');
            TaxiId = Convert.ToInt32(a[0]);
            Indulas = Convert.ToDateTime(a[1]);
            Idotartam = Convert.ToInt32(a[2]);
            Tavolsag = Convert.ToDouble(a[3]);
            Viteldij = Convert.ToDouble(a[4]);
            Borravalo = Convert.ToDouble(a[5]);
            FizetesModja = a[6];
        }

        public string ToCsv()
        {
            return Sor;
        }
    }
}