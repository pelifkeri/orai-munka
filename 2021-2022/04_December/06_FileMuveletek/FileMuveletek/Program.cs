using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileMuveletek
{
    class Program
    {
        static void Main(string[] args)
        {
            var beolvasott = File.ReadAllLines(@"C:\temp\adat.txt");
            List<Person> lista = new List<Person>();

            foreach (string sor in beolvasott)
            {
                var person = new Person(sor);
                lista.Add(person);
            }

            List<string> kiirando = new List<string>();
            kiirando.Add("Ez a .txt fájl első sora.");
            foreach (var person in lista)
            {
                kiirando.Add($"{person.Name} jelenleg {person.Age} éves.");
            }

            File.WriteAllLines(@"C:\temp\kiirtadat.txt", kiirando);
        }
    }

    class Person
    {
        public Person(string sor)
        {
            var adat = sor.Split(";");
            Id = Convert.ToInt32(adat[0]);
            Name = adat[1];
            Age = Convert.ToInt32(adat[2]);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
