using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace kosar2004
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<Eredmeny>();
            var beolvasott = File.ReadAllLines(@"C:\eredmenyek.csv", Encoding.GetEncoding("ISO-8859-1"));

            for (int i = 1; i < beolvasott.Length; i++)
            {
                var eredmeny = new Eredmeny(beolvasott[i]);
                lista.Add(eredmeny);
            }

            // 3.
            var hazaiCount = lista.Where(x => x.Hazai == "Real Madrid").ToList().Count;
            var idegenCount = lista.Where(x => x.Idegen == "Real Madrid").ToList().Count;
            Console.WriteLine($"A Real Madrid {hazaiCount} meccset játszott otthon és {idegenCount} meccset idegenben.");

            // 4.
            bool volteDontetlen = lista.Any(x => x.HazaiPont == x.IdegenPont);

            // 5.
            string team = lista.Where(x => x.Hazai.Contains("Barcelona"))
                .ToList()
                .First()
                .Hazai;
            Console.WriteLine(team);

            // 6.
            var date = new DateTime(2004, 11, 21);
            var aznapi = lista.Where(x => x.Idopont == date).ToList();

            for (int i = 0; i < aznapi.Count; i++)
            {
                var m = aznapi[i];
                Console.WriteLine($"{m.Hazai} {m.HazaiPont} - {m.IdegenPont} {m.Idegen}");
            }

            // 7. feladat
            var groupedList = lista
                .GroupBy(x => x.Helyszin)
                .Where(y => y.Count() > 20)
                .ToList();

            for (int i = 0; i < groupedList.Count; i++)
            {
                Console.WriteLine($"{groupedList[i].Key} - {groupedList[i].Count()}");
            }

            Console.ReadLine();
        }
    }

    class Eredmeny
    {
        public string Hazai { get; set; }
        public string Idegen { get; set; }
        public int HazaiPont { get; set; }
        public int IdegenPont { get; set; }
        public string Helyszin { get; set; }
        public DateTime Idopont { get; set; }

        public Eredmeny(string sor)
        {
            var data = sor.Split(';');
            Hazai = data[0];
            Idegen = data[1];
            HazaiPont = Convert.ToInt32(data[2]);
            IdegenPont = Convert.ToInt32(data[3]);
            Helyszin = data[4];
            Idopont = Convert.ToDateTime(data[5]);
        }
    }
}
