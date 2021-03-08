using System;

namespace Gyorsbufe
{
    class Egysegar
    {
        public string Termek { get; set; }
        public int Ar { get; set; }

        public Egysegar(string sor)
        {
            var a = sor.Split(';');
            Termek = a[0];
            Ar = Convert.ToInt32(a[1]);
        }
    }
}
