using System.Collections.Generic;

namespace Quake.Data.Entities
{
    public class Card : BaseEntity
    {
        public string CardType { get; set; }
        public ICollection<Building> Buildings { get; set; }
    }
}