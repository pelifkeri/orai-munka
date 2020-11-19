using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    static void Main(string[] args)
    {
        //1. feladat
        List<Nyelvvizsga> lista = new List<Nyelvvizsga>();

        var sikeresBeolvasas = File.ReadAllLines(@"C:\temp\sikeres.csv", Encoding.GetEncoding("ISO-8859-1"));
        var sikertelenBeolvasas = File.ReadAllLines(@"C:\temp\sikertelen.csv", Encoding.GetEncoding("ISO-8859-1"));

        for (int i = 1; i < sikeresBeolvasas.Length; i++)
        {
            var vizsga = new Nyelvvizsga(sikeresBeolvasas[i], sikertelenBeolvasas[i]);
            lista.Add(vizsga);
        }

        // 2. feladat
        var nepszeru = lista.OrderByDescending(x => x.VizsgakSzamaOsszesen()).Take(3).ToList();

        foreach (var item in nepszeru)
        {
            Console.WriteLine(item.Nyelv);
        }

        // 3. feladat
        var ev = Console.ReadLine();
        while (!(Convert.ToInt32(ev) >= 2009 && Convert.ToInt32(ev) <= 2017))
        {
            ev = Console.ReadLine();
        }
        int evSzam = Convert.ToInt32(ev);

        // 4. feladat
        var bukasiArany = lista.OrderByDescending(x => x.SikertelenVizsgakAranya(evSzam)).First();
        Console.WriteLine($"{ev}-ben {bukasiArany.Nyelv} nyelvből {bukasiArany.SikertelenVizsgakAranya(evSzam)}% volt a bukási arány.");

        // 5. feladat
        var nemvolt = lista.Where(x => x.NemVoltVizsgaAzAdottEvben(evSzam)).ToList();

        foreach (var item in nemvolt)
        {
            Console.WriteLine(item.Nyelv);
        }

        // 6. feladat
        var eredmeny = lista.Select(x => x.Vegeredmeny()).ToArray();

        File.WriteAllLines(@"C:\temp\vegeredmeny.csv", eredmeny, Encoding.GetEncoding("ISO-8859-1"));

        Console.ReadLine();
    }

    class Nyelvvizsga
    {
        public string Nyelv { get; set; }
        public Dictionary<int, int> SikeresVizsgak { get; set; }
        public Dictionary<int, int> SikertelenVizsgak { get; set; }

        public Nyelvvizsga(string sikeresSor, string sikertelenSor)
        {
            var a1 = sikeresSor.Split(';');
            var a2 = sikertelenSor.Split(';');

            Nyelv = a1[0];
            SikeresVizsgak = EredmenyekOsszeallitasa(a1);
            SikertelenVizsgak = EredmenyekOsszeallitasa(a2);
        }

        private Dictionary<int, int> EredmenyekOsszeallitasa(string[] eredmenyek)
        {
            var eredmeny = new Dictionary<int, int>();
            int kezdoEv = 2009;
            for (int i = 1; i < eredmenyek.Length; i++)
            {
                eredmeny.Add(kezdoEv, Convert.ToInt32(eredmenyek[i]));
                kezdoEv++;
            }

            return eredmeny;
        }

        public int VizsgakSzamaOsszesen()
        {
            return SikeresVizsgak.Values.Sum() + SikertelenVizsgak.Values.Sum();
        }

        public double SikertelenVizsgakAranya(int ev)
        {
            var sikertelen = SikertelenVizsgak.Single(x => x.Key == ev).Value;
            var sikeres = SikeresVizsgak.Single(x => x.Key == ev).Value;
            var osszes = sikertelen + sikeres;

            if (osszes == 0)
            {
                return 0;
            }

            var eredmeny = Convert.ToDouble(sikertelen) / Convert.ToDouble(osszes) * 100;
            return Math.Round(eredmeny, 2);
        }

        public bool NemVoltVizsgaAzAdottEvben(int ev)
        {
            return SikeresVizsgak.Single(x => x.Key == ev).Value == 0 && SikertelenVizsgak.Single(x => x.Key == ev).Value == 0;
        }

        public string Vegeredmeny()
        {
            var osszesSikeres = (double)SikeresVizsgak.Values.Sum();
            var sikeresVizsgakAranya = Math.Round(osszesSikeres / (double)VizsgakSzamaOsszesen() * 100, 2);

            return $"{Nyelv};{VizsgakSzamaOsszesen()};{sikeresVizsgakAranya}%";
        }
    }
}
