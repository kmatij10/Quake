using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Quake.Data.Entities;

namespace Quake.Data.Seed
{
    public static class BuildingSeeder
    {
        public static void SeedBuildings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building
                {
                    Id = 1,
                    Lat = 45.803226,
                    Lng = 15.989195,
                    Address = "Strojarska 20",
                    Description = "Vrlo oštećena zgrada",
                    CityId = 1,
                    CardId = 1
                },
                new Building
                {
                    Id = 2,
                    Lat = 45.800563,
                    Lng = 15.994924,
                    Address = "Ulica grada Vukovara 238",
                    Description = "Vrlo oštećena zgrada",
                    CityId = 1,
                    CardId = 2
                },
                new Building
                {
                    Id = 3,
                    Lat = 45.799618,
                    Lng = 15.982285,
                    Address = "Sumetlicka 39",
                    Description = "Manje oštećena zgrada",
                    CityId = 1,
                    CardId = 3
                },
                new Building
                {
                    Id = 4,
                    Lat = 45.806241,
                    Lng = 15.989721,
                    Address = "Ulica Kraljice Jelene 4",
                    Description = "Manje oštećena zgrada",
                    CityId = 1,
                    CardId = 3
                },
                new Building
                {
                    Id = 5,
                    Lat = 45.807784,
                    Lng = 15.982133,
                    Address = "Pavla Hatza 20",
                    Description = "Manje oštećena zgrada",
                    CityId = 1,
                    CardId = 3
                },
                new Building
                {
                    Id = 6,
                    Lat = 45.807714,
                    Lng = 15.976683,
                    Address = "Ulica Baruna Trenka 2",
                    Description = "Manje oštećena zgrada",
                    CityId = 1,
                    CardId = 3
                },
                new Building
                {
                    Id = 7,
                    Lat = 45.810807,
                    Lng = 15.971931,
                    Address = "Gunduliceva 12",
                    Description = "Manje oštećena zgrada",
                    CityId = 1,
                    CardId = 3
                },
                new Building
                {
                    Id = 8,
                    Lat = 45.814089,
                    Lng = 15.981847,
                    Address = "Branjugova 6",
                    Description = "Manje oštećena zgrada",
                    CityId = 1,
                    CardId = 3
                },
                new Building
                {
                    Id = 9,
                    Lat = 45.812211,
                    Lng = 15.991466,
                    Address = "Marticeva 63",
                    Description = "Manje oštećena zgrada",
                    CityId = 1,
                    CardId = 3
                },
                new Building
                {
                    Id = 10,
                    Lat = 45.809515,
                    Lng = 15.997946,
                    Address = "Tuskanova ulica 45",
                    Description = "Manje oštećena zgrada",
                    CityId = 1,
                    CardId = 3
                },
                new Building
                {
                    Id = 11,
                    Lat = 45.807856,
                    Lng = 15.967188,
                    Address = "Ulica Izidora Krsnjavog 2",
                    Description = "Manje oštećena zgrada",
                    CityId = 1,
                    CardId = 3
                }
            );
        }
    }
}