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

            await CreateFruits(context);

            var fruitsInDatabase = context.Fruits.ToList();

            foreach (var item in fruitsInDatabase)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadLine();
        }

        static async Task CreateFruits(DatabaseContext context)
        {
            if (!context.Fruits.Any())
            {
                var fruits = new List<Fruit>
                {
                    new Fruit{Id = 1, Color = "yellow", Name = "banana"},
                    new Fruit{Id = 2, Color = "red", Name = "apple"},
                };

                context.Fruits.AddRange(fruits);

                await context.SaveChangesAsync();
            }
        }
    }
}
