using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAlapok22
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> lista = new List<Person>();

            for (int i = 0; i < 100; i++)
            {
                var person = new Person
                {
                    Id = i,
                    Name = Faker.Name.FullName(),
                    Felnott = i % 3 == 0
                };
                lista.Add(person);
            }

            var abc = lista
                .OrderBy(x => x.Name)
                .ToList();

            var csoportok = lista
                .GroupBy(x => x.Felnott)
                .ToList();

            var felnottekCsokkenoNevsorban = lista
                .Where(x => x.Felnott)
                .OrderByDescending(x => x.Name)
                .ToList();

            Console.ReadLine();
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Felnott { get; set; }
    }
}
