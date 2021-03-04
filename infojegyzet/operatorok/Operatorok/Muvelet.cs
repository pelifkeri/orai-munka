using System;

namespace Operatorok
{
    class Muvelet
    {
        public int Elso { get; set; }
        public string Operator { get; set; }
        public int Masodik { get; set; }

        public Muvelet(string sor)
        {
            var a = sor.Split();
            Elso = Convert.ToInt32(a[0]);
            Operator = a[1];
            Masodik = Convert.ToInt32(a[2]);
        }
    }
}
