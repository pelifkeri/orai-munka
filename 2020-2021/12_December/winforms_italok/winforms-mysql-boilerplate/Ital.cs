namespace winforms_mysql_boilerplate
{
    public class Ital
    {
        public int Id { get; set; }
        public string Nev { get; set; }

        public string Kombinalt => $"{Id} - {Nev}";

        public Ital(int id, string nev)
        {
            Id = id;
            Nev = nev;
        }
    }
}
