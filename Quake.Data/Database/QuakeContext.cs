using Microsoft.EntityFrameworkCore;
using Quake.Data.Entities;
using Quake.Data.Seed;
using System;

namespace Quake.Data.Database
{
    public class QuakeContext : DbContext
    {
        public QuakeContext(DbContextOptions<QuakeContext> options)
            : base(options)
        { }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedBuildings();
            modelBuilder.SeedCities();
            modelBuilder.SeedCards();
        }
    }
}