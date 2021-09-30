using System;

namespace ConsoleApp.Main.Almappa
{
    // bár nincs semmilyen módosító kulcsszó a class előtt, alapértelmezetten internal típussal jön létre
    // ezekről az access modofierekről (public, private, internal, stb.) itt találhatsz több infót:
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
    class Madar
    {
        public int LábakSzáma { get; set; }

        public Madar(int labakSzama = 2)  // default értéket is meg tudunk adni paraméterként, így paraméter nélkül is példányosítani tudjuk az osztályt
        {
            this.LábakSzáma = labakSzama;
        }

        public void HangKiadasa()
        {
            Console.WriteLine("krr krr");
        }
    }
}
