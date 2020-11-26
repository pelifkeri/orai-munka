using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        List<NobelDij> lista = new List<NobelDij>();
        var beolvasott = File.ReadAllLines(@"C:\temp\nobel.csv", Encoding.GetEncoding("ISO-8859-1"));

        foreach (var sor in beolvasott.Skip(1))
        {
            var nobelDij = new NobelDij(sor);
            lista.Add(nobelDij);
        }

        // 3. feladat
        var arthur = lista.SingleOrDefault(x => x.Keresztnev == "Arthur B." && x.Vezeteknev == "McDonald");
        Console.WriteLine($"{arthur.Keresztnev} {arthur.Vezeteknev} {arthur.Tipus} típusú díjat kapott");

        // 4. feladat
        var irodalmi = lista.SingleOrDefault(x => x.Ev == 2017 && x.Tipus == "irodalmi");
        Console.WriteLine($"2017-ben {irodalmi.Keresztnev} {irodalmi.Vezeteknev} kapott irodalmi Nobel-díjat.");

        // 5. feladat
        var szervezetek = lista.Where(x => x.Tipus == "béke" && x.Ev >= 1990 && x.Szervezet).ToList();
        foreach (var szervezet in szervezetek)
        {
            Console.WriteLine($"{szervezet.Keresztnev}");
        }

        // 6. feladat
        var curiek = lista.Where(x => x.Vezeteknev.Contains("Curie")).ToList();
        foreach (var elem in curiek)
        {
            Console.WriteLine($"{elem.Ev}: {elem.Keresztnev} {elem.Vezeteknev} - {elem.Tipus}");
        }

        // 7. feladat
        var group = lista.GroupBy(x => x.Tipus).ToList();
        foreach (var item in group)
        {
            Console.WriteLine($"{item.Key} - {item.Count()} db");
        }

        // 8. feladat
        var rendezettLista = lista.Where(x => x.Tipus == "orvosi").OrderBy(x => x.Ev).ToList();
        var eredmeny = new List<string>();

        foreach (var orvosi in rendezettLista)
        {
            var csv = $"{orvosi.Ev};{orvosi.Keresztnev} {orvosi.Vezeteknev}";
            eredmeny.Add(csv);
        }

        File.WriteAllLines(@"C:\temp\orvosi.txt", eredmeny, Encoding.GetEncoding("ISO-8859-1"));

        Console.ReadLine();
    }

    class NobelDij
    {
        public int Ev { get; set; }
        public string Tipus { get; set; }
        public string Keresztnev { get; set; }
        public string Vezeteknev { get; set; }
        public bool Szervezet { get; set; }

        public NobelDij(string sor)
        {
            var a = sor.Split(';');
            Ev = Convert.ToInt32(a[0]);
            Tipus = a[1];
            Keresztnev = a[2];
            Vezeteknev = a[3];
            Szervezet = Vezeteknev == "";
        }
    }
}
