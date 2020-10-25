using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quake.Data.Database;
using Quake.Data.Entities;

namespace Quake.Core.Repositories.Buildings
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly QuakeContext context;

        public BuildingRepository(QuakeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Building> GetAll(string search)
        {
            return this.context.Buildings.ToList();
        }
        public Building GetOne(long id)
        {
            return this.context.Buildings.Where(c => c.Id == id).Single();
        }

        public Building Create(Building c)
        {
            this.context.Buildings.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.Buildings.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Building Update(long id, Building newBuilding)
        {
            newBuilding.Id = id;
            this.context.Entry(newBuilding).State = EntityState.Modified;
            this.context.SaveChanges();

            return newBuilding;
        }
    }
}