using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqGyakorlas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> lista = new List<Person>();
            var random = new Random();

            for (int i = 1; i < 100000; i++)
            {
                var person = new Person()
                {
                    Id = i,
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    City = Faker.Address.City(),
                    DateOfBirth = Faker.Identification.DateOfBirth(),
                    HasGlasses = random.Next(0,100) < 20
                };
                lista.Add(person);
            }

            var cbetusek = lista
                .Where(x => x.FirstName.StartsWith("C"))
                .Count();
            Console.WriteLine($"Összesen {cbetusek} ember keresztneve kezdődik C betűvel.");

            var kiskoruak = lista
                .Where(x => x.DateOfBirth > DateTime.Now.AddYears(-18))
                .Count();
            Console.WriteLine($"Összesen {kiskoruak} fiatal van az emberek között.");

            var varosokSzerint = lista
                .GroupBy(x => x.City)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault();
            Console.WriteLine($"A legtöbben ({varosokSzerint.Count()} fő) {varosokSzerint.Key} városban lakik");

            var masodikKeresztnev = lista
                .GroupBy(x => x.FirstName)
                .OrderByDescending(x => x.Count())
                .ElementAt(1);
            Console.WriteLine($"A legnépszerűbb keresztnév a {masodikKeresztnev.Key}, {masodikKeresztnev.Count()} létszámmal.");
            
            Console.ReadLine();
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HasGlasses { get; set; }
    }

    // hozzunk létre egy új propertyt HasGlasses néven 
    // és generáljunk neki random true-false értéket
    // legyen a true valószínűsége 20%

    // írassuk ki a consolera a C betűvel kezdődő emberek számát (FirstName)

    // Számoljuk meg és írassuk ki a 18 évnél fiatalabbak létszámát

    // Számoljuk össze, hogy melyik városban laknak a legtöbben és hány fő

    // Írassuk ki a második legnépszerűbb keresztnevet
}
