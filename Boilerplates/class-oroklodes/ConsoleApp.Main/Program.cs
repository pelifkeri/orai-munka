// ez a namespace a másik projekt classából származik. Másik projekt behivatkozásánál nem elég a namespace megadása, a projektet is be kell referálni, hogy látható legyen
using ConsoleApp.ClassLibrary;

namespace ConsoleApp.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // ennek a gólyának van 4 lába, de nincs szárnya
            var golya = new Golya();
            // golya.Lepes();  --> mivel ez egy private függvény, nem tudjuk meghívni az osztályon kívül

            // ennek a gólyának van 5 szárnya és 2 lába
            var golya2 = new Golya(5);

            // mindkettő gólya tud hangot kiadni, mert ez a függvény az ősosztályában lett definiálva, és itt meg tudjuk hívni
            golya.HangKiadasa();
            golya2.HangKiadasa();

            // static függvény használatánál nem kell példányosítanunk sem a classt, amit használunk, rögtön meg tudjuk hívni a static függvényt
            var valtozo1 = StaticClass.Fuggveny();
        }
    }
}
