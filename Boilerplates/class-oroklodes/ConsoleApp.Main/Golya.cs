
// erre a using-ra szükség van, hogy egy másik namespace-ben található classt be tudjunk hivatkozni. Enélkül nem tudjuk használni a Madar classt.
using ConsoleApp.Main.Almappa;
using System;

namespace ConsoleApp.Main
{
    // más osztályból úgy tudunk örököltetni, hogy : használata után megadjuk a class nevét, amiből örököltetni szeretnénk a classunkat
    // egy classnak csak egy közvetlen ősosztálya lehet, viszont ezt a láncolatot a végtelenségig lehetne folytatni, pl. Madar -> Golya -> GolyaFioka, stb.
    class Golya : Madar
    {
        public int SzárnyakSzáma { get; set; }
        
        // így tudjuk meghívni az ősosztály konstruktorát is, amikor egy új Golya példányt hozunk létre.
        // a base-en belül adjuk meg paraméterként, hogy hány lábbal hozzuk létre a classt (lásd Madar class)
        public Golya() : base(4)
        {

        }

        // ez a konstruktor független az ősosztálytól. Ha a szárnyak számának megadásával hozunk létre egy új gólyát, akkor az ősosztály konstruktora nem lesz meghívva (mert hiányzik a : base() )
        // és így a LábakSzáma értéke nem lesz beállítva, amiért a Madar class lenne a felelős
        public Golya(int szarnyakSzama = 2) // default értéket is meg tudunk adni paraméterként
        {
            this.SzárnyakSzáma = szarnyakSzama;
            this.Lepes();
        }

        // privát függvényeket nem tudunk meghívni a classon kívül sehol sem, csak a classon belüli függvényekben
        private void Lepes()
        {
            Console.WriteLine("Lépegetés");
        }
    }
}
