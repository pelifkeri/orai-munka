using EntityFrameworkMySQL.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace EntityFrameworkMySQL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Noveny> Novenyek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;database=teszt",
                new MySqlServerVersion(new Version(10, 4, 16)),
                mySqlOptions => mySqlOptions
                    .CharSetBehavior(CharSetBehavior.NeverAppend));
        }
    }
}
