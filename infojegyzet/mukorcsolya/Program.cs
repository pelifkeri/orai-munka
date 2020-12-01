using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

public class Program
{
    static List<Eredmeny> rovidprogram = new List<Eredmeny>();
    static List<Eredmeny> donto = new List<Eredmeny>();

    static void Main(string[] args)
    {
        // 1. feladat
        var beolvasottRovid = File.ReadAllLines(@"C:\temp\rovidprogram.csv", Encoding.GetEncoding("ISO-8859-1"));
        var beolvasottDonto = File.ReadAllLines(@"C:\temp\donto.csv", Encoding.GetEncoding("ISO-8859-1"));

        foreach (var item in beolvasottRovid.Skip(1))
        {
            var rovid = new Eredmeny(item);
            rovidprogram.Add(rovid);
        }

        foreach (var item in beolvasottDonto.Skip(1))
        {
            var dontoEredmeny = new Eredmeny(item);
            donto.Add(dontoEredmeny);
        }

        // 2. feladat
        Console.WriteLine($"A rövidprogramban {rovidprogram.Count} db versenyző indult.");

        // 3. feladat
        var vaneMagyar = donto.SingleOrDefault(x => x.Orszagkod == "HUN");
        string uzenet = (vaneMagyar == null) ? "A magyar versenyző nem jutott be a döntőbe" : "A magyar versenyző bejutott a döntőbe";
        Console.WriteLine(uzenet);

        // 5. feladat
        var indulo = Console.ReadLine();
        var versenyzo = rovidprogram.SingleOrDefault(x => x.Nev == indulo);

        if (versenyzo == null)
        {
            Console.WriteLine("Nem található ilyen nevű versenyző!");
        }
        // 6. feladat
        else
        {
            Console.WriteLine($"A versenyző összpontszáma: {Osszpontszam(indulo)}");
        }

        // 7. feladat
        var csoportositas = donto
            .GroupBy(x => x.Orszagkod)
            .Where(x => x.Count() > 1)
            .ToList();

        foreach (var item in csoportositas)
        {
            Console.WriteLine($"{item.Key}: {item.Count()} versenyző");
        }

        // 8. feladat
        foreach (var item in donto)
        {
            item.Osszpontszam = Osszpontszam(item.Nev);
        }

        var vegeredmeny = donto.OrderByDescending(x => x.Osszpontszam).ToList();

        List<string> vegeredm = new List<string>();
        for (int i = 0; i < vegeredmeny.Count; i++)
        {
            var csv = $"{i + 1};{vegeredmeny[i].Nev};{vegeredmeny[i].Orszagkod};{vegeredmeny[i].Osszpontszam:0.00}";
            vegeredm.Add(csv);
        }

        File.WriteAllLines(@"c:\temp\vegeredmeny.csv", vegeredm, Encoding.GetEncoding("ISO-8859-1"));

        Console.ReadLine();
    }

    // 4. feladat
    static double Osszpontszam(string nev)
    {
        var rovider = rovidprogram.SingleOrDefault(x => x.Nev == nev);
        var dontoer = donto.SingleOrDefault(x => x.Nev == nev);

        double osszpontszam = 0;

        if (rovider != null)
        {
            osszpontszam += (rovider.KomponensPontszam + rovider.TechnikaiPontszam);
        }
        if (dontoer != null)
        {
            osszpontszam += (dontoer.KomponensPontszam + dontoer.TechnikaiPontszam);
        }

        return osszpontszam;
    }

    class Eredmeny
    {
        public string Nev { get; set; }
        public string Orszagkod { get; set; }
        public double TechnikaiPontszam { get; set; }
        public double KomponensPontszam { get; set; }
        public double Osszpontszam { get; set; }
        public int Hibapont { get; set; }

        public Eredmeny(string sor)
        {
            var a = sor.Split(';');

            Nev = a[0];
            Orszagkod = a[1];
            TechnikaiPontszam = Convert.ToDouble(a[2], CultureInfo.InvariantCulture);
            KomponensPontszam = Convert.ToDouble(a[3], CultureInfo.InvariantCulture);
            Hibapont = Convert.ToInt32(a[4]);
        }
    }
}
