using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        List<Auto> autok = new List<Auto>();
        List<Igeny> igenyek = new List<Igeny>();

        var beolvasottAutok = File.ReadAllLines(@"C:\temp\autok.csv", Encoding.GetEncoding("ISO-8859-1"));
        var beolvasottIgenyek = File.ReadAllLines(@"C:\temp\igenyek.csv", Encoding.GetEncoding("ISO-8859-1"));

        foreach (var sor in beolvasottAutok.Skip(1))
        {
            var auto = new Auto(sor);
            autok.Add(auto);
        }

        foreach (var sor in beolvasottIgenyek.Skip(1))
        {
            var igeny = new Igeny(sor);
            igenyek.Add(igeny);
        }

        // 2. feladat
        Console.WriteLine($"{autok.Count} hirdető adatát tartalmazta az első fájl.");

        // 3. feladat
        var budMis = autok
            .Where(x => x.IndulasiHely == "Budapest" && x.Uticel == "Miskolc")
            .Sum(x => x.FerohelyekSzama);

        Console.WriteLine($"Összesen {budMis} férőhelyet hirdettek pest és miskolc között.");

        // 4. feladat
        var legtobbFerohely = autok.OrderByDescending(x => x.FerohelyekSzama).First();

        Console.WriteLine($"{legtobbFerohely.IndulasiHely}-{legtobbFerohely.Uticel} útvonalon volt a legtöbb férőhely, {legtobbFerohely.FerohelyekSzama} darab");

        // 5. feladat
        Dictionary<string, string> parositas = new Dictionary<string, string>();

        foreach (var igeny in igenyek)
        {
            var megfeleloAutok = autok.Where(x => x.IndulasiHely == igeny.IndulasiHely && x.Uticel == igeny.Uticel).ToList();

            if (megfeleloAutok.Count > 0)
            {
                var elegFerohelyesAuto = megfeleloAutok.Where(x => x.FerohelyekSzama >= igeny.UtasokSzama).FirstOrDefault();

                if (elegFerohelyesAuto != null)
                {
                    elegFerohelyesAuto.FerohelyekSzama -= igeny.UtasokSzama;
                    parositas.Add(igeny.IgenyloAzonosito, elegFerohelyesAuto.Rendszam);
                    igeny.Teljesitheto = true;
                }
            }
        }

        foreach (var par in parositas)
        {
            Console.WriteLine($"{par.Key} => {par.Value}");
        }

        // 6. feladat
        List<string> eredmeny = new List<string>();
        foreach (var igeny in igenyek)
        {
            var szoveg = $"{igeny.IgenyloAzonosito}: ";

            if (igeny.Teljesitheto)
            {
                var rendszam = parositas.Single(x => x.Key == igeny.IgenyloAzonosito).Value;
                var auto = autok.Single(x => x.Rendszam == rendszam);
                szoveg += $"Rendszám: {auto.Rendszam}, Telfonszám: {auto.Telefonszam}";
            }
            else
            {
                szoveg += "Sajnos nem sikerült autót találni.";
            }

            eredmeny.Add(szoveg);
        }

        File.WriteAllLines(@"C:\temp\utasuzenetek.txt", eredmeny, Encoding.GetEncoding("ISO-8859-1"));

        Console.ReadLine();
    }

    class Auto
    {
        public string IndulasiHely { get; set; }
        public string Uticel { get; set; }
        public string Rendszam { get; set; }
        public string Telefonszam { get; set; }
        public int FerohelyekSzama { get; set; }

        public Auto(string sor)
        {
            var a = sor.Split(';');
            IndulasiHely = a[0];
            Uticel = a[1];
            Rendszam = a[2];
            Telefonszam = a[3];
            FerohelyekSzama = Convert.ToInt32(a[4]);
        }
    }

    class Igeny
    {
        public string IgenyloAzonosito { get; set; }
        public string IndulasiHely { get; set; }
        public string Uticel { get; set; }
        public int UtasokSzama { get; set; }
        public bool Teljesitheto { get; set; }
        public Igeny(string sor)
        {
            var a = sor.Split(';');
            IgenyloAzonosito = a[0];
            IndulasiHely = a[1];
            Uticel = a[2];
            UtasokSzama = Convert.ToInt32(a[3]);
        }
    }
}
