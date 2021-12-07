using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomPersonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // tároljuk el a personokat
            List<Person> lista = new List<Person>();
            // iteráljunk végig 100x
            for (int i = 0; i < 100; i++)
            {
                // generáljunk random dátumot és nevet
                Random r = new Random();
                var nev = $"Pistike - {i + 1}";
                var datum = new DateTime(r.Next(1990, 2021), r.Next(1, 13), r.Next(1, 29));
                // példányosítsuk a classt a random értékekkel
                var person = new Person(nev, datum);
                // adjuk hozzá a listához
                lista.Add(person);
            }

            // iteráljunk végig a listán és írassuk ki a szülidőt
            lista.ForEach(p =>
            {
                Console.WriteLine(p.DateOfBirth);
            });

            foreach (var p in lista)
            {
                Console.WriteLine(p.DateOfBirth);
            }

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i].DateOfBirth);
            }
        }
    }
}
