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
            await CreateMenus(context);
            await CreateEtelek(context);

            // vegán ételek
            var veganEtelek = context.Etelek.Where(x => x.Vegan).ToList();
            foreach (var item in veganEtelek)
            {
                Console.WriteLine(item.Name);
            }

            // kenyér szót tartalmazó ételek
            var kenyerek = context.Etelek.Where(x => x.Name.Contains("kenyér")).ToList();
            foreach (var item in kenyerek)
            {
                Console.WriteLine(item.Name);
            }

            // reggelente kapható kenyér termékek
            var reggeliKenyerek = context.Etelek
                .Where(x => x.Name.Contains("kenyér") && x.Menu.EtkezesiTipus == "Reggeli")
                .ToList();

            var reggelikenyerekcsunyan = (from e in context.Etelek
                                                join m in context.Menuk on e.MenuId equals m.Id
                                                where
                                                   e.Name.Equals("kenyér") &&
                                                   m.EtkezesiTipus == "Reggeli"
                                                select
                                                   e
                                            ).ToList();

            Console.ReadLine();
        }

        static async Task CreateMenus(DatabaseContext context)
        {
            if (!context.Menuk.Any())
            {
                List<Menu> menuk = new List<Menu>
                {
                    new Menu{Id = 1, EtkezesiTipus = "Reggeli"},
                    new Menu{Id = 2, EtkezesiTipus = "Főétel"},
                    new Menu{Id = 3, EtkezesiTipus = "Desszert"},
                    new Menu{Id = 4, EtkezesiTipus = "Uzsonna"}
                };

                context.Menuk.AddRange(menuk);
                await context.SaveChangesAsync();
            }
        }

        static async Task CreateEtelek(DatabaseContext context)
        {
            if (!context.Etelek.Any())
            {
                List<Etel> etelek = new List<Etel>
                {
                    new Etel{ MenuId = 1, Name = "Rántotta", Vegan = false},
                    new Etel{ MenuId = 1, Name = "Száraz kenyér", Vegan = true},
                    new Etel{ MenuId = 1, Name = "Zsíros kenyér", Vegan = true},
                    new Etel{ MenuId = 2, Name = "Brassói", Vegan = false},
                    new Etel{ MenuId = 3, Name = "Torta", Vegan = false},
                    new Etel{ MenuId = 4, Name = "Májkrémes kenyér", Vegan = false}
                };

                context.Etelek.AddRange(etelek);
                await context.SaveChangesAsync();
            }
        }
    }
}
