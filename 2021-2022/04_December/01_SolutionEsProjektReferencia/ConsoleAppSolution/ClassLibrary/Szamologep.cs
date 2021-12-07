using System;

namespace ClassLibrary
{
    public class Szamologep
    {
        public Szamologep()
        {
            var osszeg = Osszeadas(2, 2);
        }

        protected static int Osszeadas(int a, int b) => a + b;
        protected static int Kivonas(int a, int b) => a - b;
        protected static int Szorzas(int a, int b) => a * b;
        protected static double Osztas(double a, double b) => a / b;
    }
}
