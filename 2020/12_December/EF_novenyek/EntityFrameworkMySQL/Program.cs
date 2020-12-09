using EntityFrameworkMySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMySQL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new DatabaseContext();

            var novenyek = new List<Noveny>
                {
                    new Noveny{Szin = "sarga", Nev = "citromfa"},
                    new Noveny{Szin = "barna", Nev = "fűzfa"},
                    new Noveny{Szin = "piros", Nev = "akácfa"}
                };

            context.Novenyek.AddRange(novenyek);
            await context.SaveChangesAsync();

            Console.WriteLine("Adj meg egy növény ID-t:");
            var id = Convert.ToInt32(Console.ReadLine());

            var entity = context.Novenyek.Find(id);

            if (entity == null)
            {
                Console.WriteLine("Nem találtam ilyen növényt!");
            }
            else
            {
                Console.WriteLine("Add meg a  új nevét: ");
                var ujnev = Console.ReadLine();
                entity.Nev = ujnev;
                await context.SaveChangesAsync();
            }

            var legnagyobbId = context.Novenyek.OrderByDescending(x => x.Id).First();
            context.Novenyek.Remove(legnagyobbId);
            await context.SaveChangesAsync();

            Console.WriteLine($"Még {context.Novenyek.ToList().Count} darab növény van az adatbázisban.");

            Console.ReadLine();
        }
    }
}
