using Microsoft.EntityFrameworkCore;
using Quake.Data.Entities;
using System;

namespace Quake.Data.Database
{
    public class QuakeContext : DbContext
    {
        public QuakeContext(DbContextOptions<QuakeContext> options)
            : base(options)
        { }

        public DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building
                {
                    Id = 1,
                    Lat = 20.3,
                    Lng = 13.3,
                    Description = "Vrlo oštećena zgrada"
                },
                new Building
                {
                    Id = 2,
                    Lat = 40.3,
                    Lng = 30.3,
                    Description = "Vrlo oštećena zgrada"
                },
                new Building
                {
                    Id = 3,
                    Lat = -13.3,
                    Lng = 40.3,
                    Description = "Manje oštećena zgrada"
                }
            );
        }
    }
}