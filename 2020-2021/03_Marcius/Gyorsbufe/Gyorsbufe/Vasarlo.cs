using System;
using System.Collections.Generic;

namespace Gyorsbufe
{
    class Vasarlo
    {
        public string Nev { get; set; }
        public string Napszak { get; set; }
        public Dictionary<string, int> Vasarlas { get; set; }
        public int Vegosszeg { get; set; }

        public Vasarlo(string sor)
        {
            var a = sor.Split(';');
            Nev = a[0];
            Napszak = a[1];
            Vasarlas = new Dictionary<string, int>();
        }

        public void UjVasarlas(string sor)
        {
            var a = sor.Split(';');
            Vasarlas.Add(a[1], Convert.ToInt32(a[2]));
        }

        public void VasarlasVegosszege(List<Egysegar> arlista)
        {
            int vegosszeg = 0;

            foreach (var item in Vasarlas)
            {
                var ar = arlista.Find(x => x.Termek == item.Key).Ar;
                var osszes = item.Value * ar;
                vegosszeg += osszes;
            }

            Vegosszeg = vegosszeg;
        }
    }
}
