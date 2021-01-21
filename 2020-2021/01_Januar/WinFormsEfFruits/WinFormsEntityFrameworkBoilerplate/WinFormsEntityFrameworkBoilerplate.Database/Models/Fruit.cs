namespace WinFormsEntityFrameworkBoilerplate.Database.Models
{
    public class Fruit
    {
        public Fruit()
        {

        }

        public Fruit(string name, string color)
        {
            Megnevezes = name;
            Color = color;
        }

        public int Id { get; set; }
        public string Megnevezes { get; set; }
        public string Color { get; set; }
    }
}
