using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Program
{
    public static List<T> Beolvasas<T>(string path) where T : Olvashato, new()
    {
        List<T> lista = new List<T>();
        var beolvasott = File.ReadAllLines(path, Encoding.GetEncoding("ISO-8859-1"));

        foreach (var sor in beolvasott.Skip(1))
        {
            T tipus = new T();
            tipus.ErtekAdas(sor);
            lista.Add(tipus);
        }

        return lista;
    }

    static void Main(string[] args)
    {
        // 2. feladat
        var kutyaNevek = Beolvasas<KutyaNev>(@"c:\temp\kutyanevek.csv");

        // 3. feladat
        Console.WriteLine($"A beolvasott nevek között {kutyaNevek.Count} kutya név található.");

        // 4. feladat
        var kutyaFajtak = Beolvasas<KutyaFajta>(@"C:\temp\kutyafajtak.csv");

        // 5. feladat
        var vizsgalatok = Beolvasas<Vizsgalat>(@"C:\temp\kutyak.csv");

        // 6. feladat
        var atlagEletkor = vizsgalatok.Average(x => x.Eletkor);
        Console.WriteLine($"A vizsgált kutyák átlag életkora {atlagEletkor:0.00}");

        // 7. feladat
        var legidosebb = vizsgalatok.OrderByDescending(x => x.Eletkor).FirstOrDefault();

        Console.WriteLine($"A legidősebb kutya neve {legidosebb.KutyaNeve(kutyaNevek)}, fajtája {legidosebb.KutyaFaj(kutyaFajtak)}");

        // 8. feladat
        var fajtankent = vizsgalatok
            .Where(x => x.VizsgalatIdeje == new DateTime(2018, 1, 10))
            .GroupBy(x => x.FajtaId)
            .ToList();

        foreach (var item in fajtankent)
        {
            var fajta = kutyaFajtak.SingleOrDefault(x => x.Id == item.Key).MagyarNev;
            Console.WriteLine($"{fajta}: {item.Count()} kutya");
        }

        // 9. feladat
        var naponkent = vizsgalatok
            .GroupBy(x => x.VizsgalatIdeje)
            .OrderByDescending(x => x.Count())
            .ToList()
            .First();

        Console.WriteLine($"Legjobban leterhelt nap: {naponkent.Key.ToShortDateString()}: {naponkent.Count()} darab kutya ");

        // 10. feladat
        var nevekAlapjan = vizsgalatok
            .GroupBy(x => x.KutyaNeve(kutyaNevek))
            .OrderByDescending(x => x.Count())
            .ToList();

        List<string> kiirandoNevek = new List<string>();

        foreach (var item in nevekAlapjan)
        {
            var csv = $"{item.Key};{item.Count()}";
            kiirandoNevek.Add(csv);
        }

        File.WriteAllLines(@"c:\temp\nevstatisztika.txt", kiirandoNevek, Encoding.GetEncoding("ISO-8859-1"));

        Console.ReadLine();
    }

    class KutyaNev : Olvashato
    {
        public int Id { get; set; }
        public string Nev { get; set; }

        public void ErtekAdas(string sor)
        {
            var a = sor.Split(';');

            Id = Convert.ToInt32(a[0]);
            Nev = a[1];
        }
    }

    class KutyaFajta : Olvashato
    {
        public int Id { get; set; }
        public string MagyarNev { get; set; }
        public string EredetiNev { get; set; }

        public void ErtekAdas(string sor)
        {
            var a = sor.Split(';');

            Id = Convert.ToInt32(a[0]);
            MagyarNev = a[1];
            EredetiNev = a[2];
        }
    }

    class Vizsgalat : Olvashato
    {
        public int Id { get; set; }
        public int FajtaId { get; set; }
        public int NevId { get; set; }
        public int Eletkor { get; set; }
        public DateTime VizsgalatIdeje { get; set; }

        public string KutyaNeve(List<KutyaNev> nevek)
        {
            return nevek.SingleOrDefault(x => x.Id == NevId).Nev;
        }

        public string KutyaFaj(List<KutyaFajta> fajtak)
        {
            return fajtak.SingleOrDefault(x => x.Id == FajtaId).MagyarNev;
        }

        public void ErtekAdas(string sor)
        {
            var a = sor.Split(';');

            Id = Convert.ToInt32(a[0]);
            FajtaId = Convert.ToInt32(a[1]);
            NevId = Convert.ToInt32(a[2]);
            Eletkor = Convert.ToInt32(a[3]);
            VizsgalatIdeje = Convert.ToDateTime(a[4]);
        }
    }

    public interface Olvashato
    {
        public void ErtekAdas(string sor);
    }
}
