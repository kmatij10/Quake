using Microsoft.EntityFrameworkCore;
using Quake.Data.Entities;

namespace Quake.Data.Seed
{
    public static class CitySeeder
    {
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    CityName = "Zagreb"
                },
                new City
                {
                    Id = 2,
                    CityName = "Karlovac"
                }
            );
        }
    }
}