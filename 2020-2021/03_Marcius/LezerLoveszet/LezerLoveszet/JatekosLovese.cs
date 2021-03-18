using System;
using System.Collections.Generic;
using System.Text;

namespace LezerLoveszet
{
    class JatekosLovese
    {
        public string Nev { get; set; }
        public double LovesX { get; set; }
        public double LovesY { get; set; }
        public int Sorszam { get; set; }

        public JatekosLovese(string sor, int sorszam)
        {
            var a = sor.Split(';');
            Nev = a[0];
            LovesX = Convert.ToDouble(a[1]);
            LovesY = Convert.ToDouble(a[2]);
            Sorszam = sorszam;
        }

        public double Tavolsag(double tablaX, double tablaY)
        {
            var x = tablaX - LovesX;
            var y = tablaY - LovesY;

            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public double Pontszam(double tablaX, double tablaY)
        {
            var eredmeny = Math.Round(10 - Tavolsag(tablaX, tablaY), 2);
            return eredmeny > 0 ? eredmeny : 0;
        }
    }
}
