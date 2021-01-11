using System;
using System.Collections.Generic;

namespace Memoria
{
    public static class Statisztika
    {
        public static int FelfedettKartyakSzama { get; set; } = 0;
        public static List<string> FelforditottKepek { get; set; } = new List<string>();
        public static int EltalaltParokSzama { get; set; }
    }
}
