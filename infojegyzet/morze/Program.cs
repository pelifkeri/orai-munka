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
        Dictionary<string, string> abc = new Dictionary<string, string>();
        var beolvasottAbc = File.ReadAllLines(@"C:\temp\morzeabc.txt", Encoding.GetEncoding("ISO-8859-1"));

        for (int i = 1; i < beolvasottAbc.Length; i++)
        {
            var adat = beolvasottAbc[i].Split('\t');
            abc.Add(adat[0], adat[1]);
        }

        // 3. feladat
        Console.WriteLine($"{abc.Count} sort olvastunk be.");

        // 4. feladat
        var bekert = Console.ReadKey();
        var talalat = abc.SingleOrDefault(x => x.Key == bekert.KeyChar.ToString());

        if (talalat.Value == null)
        {
            Console.WriteLine("Nem található a kódtárban ilyen karakter!");
        }
        else
        {
            Console.WriteLine($"A bekért karkter ({bekert.KeyChar.ToString()}) morze kódja {talalat.Value}");
        }

        // 5. feladat
        List<Idezet> idezetek = new List<Idezet>();
        var beolvasottIdezet = File.ReadAllLines(@"C:\temp\morze.txt", Encoding.GetEncoding("ISO-8859-1"));

        foreach (var sor in beolvasottIdezet)
        {
            var idezet = new Idezet(abc, sor);
            idezetek.Add(idezet);
        }

        // 7. feladat
        Console.WriteLine(idezetek[0].Szerzo);

        // 8. feladat
        var leghosszabb = idezetek.OrderByDescending(x => x.Szoveg.Length).First();
        Console.WriteLine($"A leghosszabb: {leghosszabb.Szerzo}: {leghosszabb.Szoveg}");

        // 9 . feladat
        var arisztotelesz = idezetek.Where(x => x.Szerzo == "ARISZTOTELÉSZ ").ToList();
        Console.WriteLine("Arisztotelész idézetei:");
        foreach (var item in arisztotelesz)
        {
            Console.WriteLine($"- {item.Szoveg}");
        }

        // 10. feladat
        string[] sorIdezetek = idezetek.Select(x => $"{x.Szerzo}:{x.Szoveg}").ToArray();
        File.WriteAllLines(@"C:\temp\idezetek.txt", sorIdezetek, Encoding.GetEncoding("ISO-8859-1"));

        Console.ReadLine();
    }

    class Idezet
    {
        public string Szerzo { get; set; }
        public string Szoveg { get; set; }

        public Idezet(Dictionary<string, string> abc, string sor)
        {
            var a = sor.Split(';');
            Szerzo = Morze2Szöveg(abc, a[0]);
            Szoveg = Morze2Szöveg(abc, a[1]);
        }
        
        public string Morze2Szöveg(Dictionary<string, string> abc, string morze)
        {
            var roviditettMorze = morze.Replace("   ", " ");
            var splitted = roviditettMorze.Split(' ');
            var dekodolt = "";

            foreach (var morzeErtek in splitted)
            {
                if (morzeErtek == "" || morzeErtek == " ")
                {
                    dekodolt += " ";
                }
                else
                {
                    var dekodoltMorze = abc.SingleOrDefault(x => x.Value == morzeErtek).Key;
                    dekodolt += dekodoltMorze;
                }
            }

            return dekodolt;
        }
    }
}
