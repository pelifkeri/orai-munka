using System;
using System.Linq;

namespace NASA
{
    class Keres
    {
        public string Cim { get; set; }
        public string DatumIdo { get; set; }
        public string Get { get; set; }
        public string HttpKod { get; set; }
        public string Meret { get; set; }
        public int ByteMeret => Meret == "-" ? 0 : Convert.ToInt32(Meret);
        public bool DomainNev => char.IsLetter(Cim.Last());

        public Keres(string sor)
        {
            var a = sor.Split('*');

            Cim = a[0];
            DatumIdo = a[1];
            Get = a[2];

            var valasz = a[3].Split();
            HttpKod = valasz[0];
            Meret = valasz[1];
        }
    }
}
