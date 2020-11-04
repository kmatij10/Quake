using System.Collections.Generic;

namespace Quake.Data.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public ICollection<Building> Buildings { get; set; }   
    }
}