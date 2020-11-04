using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quake.Data.Entities
{
    public class Building : BaseEntity
    {
        [Required]
        public double Lat { get; set; }
        [Required]
        public double Lng { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
        public long CardId { get; set; }
        public Card Card { get; set; }
    }
}