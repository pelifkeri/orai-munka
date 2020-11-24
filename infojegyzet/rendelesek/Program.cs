using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        List<Termek> raktar = new List<Termek>();
        List<Termek> raktarMasolat = new List<Termek>();
        List<Rendeles> rendelesek = new List<Rendeles>();
        var raktarBeolvasas = File.ReadAllLines(@"C:\temp\raktar.csv", Encoding.GetEncoding("ISO-8859-1"));
        foreach (var sor in raktarBeolvasas)
        {
            var termek = new Termek(sor);
            raktar.Add(termek);
        }
        raktarMasolat = raktar;

        var rendelesekBeolvasas = File.ReadAllLines(@"C:\temp\rendeles.csv", Encoding.GetEncoding("ISO-8859-1"));
        foreach (var sor in rendelesekBeolvasas)
        {
            if (sor.StartsWith('M'))
            {
                var rendeles = new Rendeles(sor);
                rendelesek.Add(rendeles);
            }
            else
            {
                var megrendeltTermek = new MegrendeltTermek(sor);
                var meglevoMegrendeles = rendelesek.Where(x => x.Id == megrendeltTermek.RendelesId).First();
                meglevoMegrendeles.RendeltTermekek.Add(megrendeltTermek);
            }
        }

        // 2. feladat
        foreach (var rendeles in rendelesek)
        {
            var teljesitheto = false;
            foreach (var megrendeltTermek in rendeles.RendeltTermekek)
            {
                var raktarkeszlet = raktar.Where(x => x.TermekKod == megrendeltTermek.TermekKod).First();

                if (raktarkeszlet.Keszleten > megrendeltTermek.RendeltMennyiseg)
                {
                    teljesitheto = true;
                }
                else
                {
                    teljesitheto = false;
                    break;
                }
            }

            rendeles.Teljesitheto = teljesitheto;

            if (teljesitheto)
            {
                foreach (var megrendeltTermek in rendeles.RendeltTermekek)
                {
                    var raktarkeszlet = raktar.Where(x => x.TermekKod == megrendeltTermek.TermekKod).First();
                    raktarkeszlet.Keszleten -= megrendeltTermek.RendeltMennyiseg;
                    rendeles.Vegosszeg += (megrendeltTermek.RendeltMennyiseg * raktarkeszlet.Ar);
                }
            }
        }

        // 3. feladat
        var sorok = new List<string>();
        foreach (var rendeles in rendelesek)
        {
            string uzenet = rendeles.Teljesitheto ?
                $"A rendelését két napon belül szállítjuk. A rendelés értéke {rendeles.Vegosszeg} Ft." :
                "A rendelés függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról.";

            var csv = $"{rendeles.Email};{uzenet}";
            sorok.Add(csv);
        }
        File.WriteAllLines(@"C:\temp\levelek.csv", sorok, Encoding.GetEncoding("ISO-8859-1"));

        // 4. feladat
        var osszRendeles = new List<MegrendeltTermek>();
        foreach (var item in rendelesek)
        {
            osszRendeles.AddRange(item.RendeltTermekek);
        }

        var csoportositas = osszRendeles.GroupBy(x => x.TermekKod).ToList();

        var beszerzesSorok = new List<string>();
        foreach (var item in csoportositas)
        {
            var osszesRendeltMennyiseg = item.Sum(x => x.RendeltMennyiseg);
            var mennyiVanKeszleten = raktarMasolat.Where(x => x.TermekKod == item.Key).First().Keszleten;

            if(mennyiVanKeszleten < osszesRendeltMennyiseg)
            {
                var sor = $"{item.Key};{osszesRendeltMennyiseg - mennyiVanKeszleten}";
                beszerzesSorok.Add(sor);
            }
        }
        File.WriteAllLines(@"C:\temp\beszerzes.csv", beszerzesSorok, Encoding.GetEncoding("ISO-8859-1"));

        Console.ReadLine();
    }

    class Termek
    {
        public string TermekKod { get; set; }
        public string Nev { get; set; }
        public int Ar { get; set; }
        public int Keszleten { get; set; }

        public Termek(string sor)
        {
            var a = sor.Split(';');
            TermekKod = a[0];
            Nev = a[1];
            Ar = Convert.ToInt32(a[2]);
            Keszleten = Convert.ToInt32(a[3]);
        }
    }

    class Rendeles
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Email { get; set; }
        public List<MegrendeltTermek> RendeltTermekek { get; set; }
        public bool Teljesitheto { get; set; }
        public int Vegosszeg { get; set; }

        public Rendeles(string sor)
        {
            RendeltTermekek = new List<MegrendeltTermek>();

            var a = sor.Split(';');
            Datum = Convert.ToDateTime(a[1]);
            Id = Convert.ToInt32(a[2]);
            Email = a[3];
        }
    }

    class MegrendeltTermek
    {
        public int RendelesId { get; set; }
        public string TermekKod { get; set; }
        public int RendeltMennyiseg { get; set; }

        public MegrendeltTermek(string sor)
        {
            var a = sor.Split(';');
            RendelesId = Convert.ToInt32(a[1]);
            TermekKod = a[2];
            RendeltMennyiseg = Convert.ToInt32(a[3]);
        }
    }
}
