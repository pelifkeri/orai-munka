namespace ConsoleApp.ClassLibrary
{
    // az ebben a projektenben található classokat csak akkor tudunk felhasználni más projektekben, ha a public kulcsszó szerepel a class előtt
    public class StaticClass
    {
        public int Szam { get; set; }

        // a static kulcsszóval megjelölt függvények az osztály példányosítása nélkül meghívhatóak bárhonnan
        // ebben az esetben viszont nem használhatóak az osztályban található propertyk, tehát a fenti Szam mezőnek nem tudnánk értéket adni a static függvényen belül
        public static string Fuggveny()
        {
            return "string";
        }

        // ez a függvény alapértelmezetten "internal" módosítót kap, ezért csak ebben a projekten belül lehet meghívni, más projektekben nem lesz elérhető
        static string NemPublikusFuggveny()
        {
            return "masik string";
        }
    }
}
