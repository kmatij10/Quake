using Microsoft.EntityFrameworkCore;
using Quake.Data.Entities;

namespace Quake.Data.Seed
{
    public static class CardSeeder
    {
        public static void SeedCards(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(
                new Card
                {
                    Id = 1,
                    CardType = "Red"
                },
                new Card
                {
                    Id = 2,
                    CardType = "Yellow"
                },
                new Card
                {
                    Id = 3,
                    CardType = "Green"
                }
            );
        }
    }
}