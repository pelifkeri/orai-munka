namespace tesztverseny
{
    class Eredmeny
    {
        public string Versenyzo { get; set; }
        public string Valaszok { get; set; }

        public Eredmeny(string sor)
        {
            var a = sor.Split();
            Versenyzo = a[0];
            Valaszok = a[1];
        }

        public int Pontszam(string megoldokulcs)
        {
            int pontszamok = 0;

            for (int i = 0; i < Valaszok.Length; i++)
            {
                if (Valaszok[i] == megoldokulcs[i])
                {
                    if (i == 13)
                    {
                        pontszamok += 6;
                    }
                    else if (i >= 10 && i <= 12)
                    {
                        pontszamok += 5;
                    }
                    else if (i >= 5 && i <= 9)
                    {
                        pontszamok += 4;
                    }
                    else
                    {
                        pontszamok += 3;
                    }
                }
            }

            return pontszamok;
        }
    }
}
