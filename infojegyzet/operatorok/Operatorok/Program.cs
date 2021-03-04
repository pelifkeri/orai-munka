using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Operatorok
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. feladat
            List<Muvelet> muveletek = new List<Muvelet>();
            var beolvasott = File.ReadAllLines(@"C:\temp\operatorok\kifejezesek.txt");
            foreach (var sor in beolvasott)
            {
                var muvelet = new Muvelet(sor);
                muveletek.Add(muvelet);
            }

            // 2. feladat
            Console.WriteLine(muveletek.Count);

            // 3. feladat
            var mod = muveletek.Where(x => x.Operator == "mod").ToList();
            Console.WriteLine(mod.Count);

            // 4. feladat
            bool talalat = false;
            foreach (var item in muveletek)
            {
                if (item.Elso % 10 == 0 && item.Masodik % 10 == 0)
                {
                    talalat = true;
                    break;
                }
            }
            string eredmeny = talalat ? "Találtunk" : "Nem találtunk";
            Console.WriteLine($"{eredmeny} ilyen értéket");

            // 5. feladat
            var muvjelek = new List<string> { "mod", "/", "div", "-", "*", "+" };
            var statisztika = muveletek
                .GroupBy(x => x.Operator)
                .Where(x => muvjelek.Contains(x.Key))
                .ToList();

            foreach (var item in statisztika)
            {
                Console.WriteLine($"{item.Key} -> {item.Count()} db");
            }

            // 7. feladat
            string bekeres = Console.ReadLine();
            while (bekeres != "vége")
            {
                var a = bekeres.Split();
                var result = Kalkulacio(Convert.ToInt32(a[0]), Convert.ToInt32(a[2]), a[1]);
                Console.WriteLine(result);
                bekeres = Console.ReadLine();
            }

            // 8. feladat
            List<string> vegeredmenyek = new List<string>();

            foreach (var muvelet in muveletek)
            {
                vegeredmenyek.Add(Kalkulacio(muvelet.Elso, muvelet.Masodik, muvelet.Operator));
            }

            File.WriteAllLines(@"C:\temp\operatorok\eredmenyek.txt", vegeredmenyek);

            Console.ReadLine();
        }

        private static string Kalkulacio(int elso, int masodik, string muvelet)
        {
            string eredmeny = "";
            try
            {
                switch (muvelet)
                {
                    case "+":
                        eredmeny = (elso + masodik).ToString();
                        break;
                    case "-":
                        eredmeny = (elso - masodik).ToString();
                        break;
                    case "div":
                    case "/":
                        eredmeny = (elso / masodik).ToString();
                        break;
                    case "mod":
                        eredmeny = (elso % masodik).ToString();
                        break;
                    case "*":
                        eredmeny = (elso * masodik).ToString();
                        break;
                    default:
                        eredmeny = "Hibás operátor!";
                        break;
                }
            }
            catch (Exception)
            {
                eredmeny = "Egyéb hiba!";
            }

            return eredmeny;
        }
    }
}
