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
        public int PerPage { get; set; } = 6;
        public BuildingRepository(QuakeContext context)
        {
            this.context = context;
        }

        /*public IEnumerable<Building> GetAll(string search)
        {
            var query = this.context.Buildings.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    b => b.Address.Contains(search) ||
                    b.Description.Contains(search)
                );
            }
            return query.ToList();
        }*/

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

        public List<Building> GetPaginatedBuildings(int page, string search, string sort)
        {
            var query = this.context.Buildings.AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Address.Contains(search) || b.Description.Contains(search));
            }

            if(!string.IsNullOrEmpty(sort))
            {
                string[] elements = sort.Split(":"); 
                query = query.OrderByDescending(b => b.Address);
            }

            return query.Skip((page - 1) * this.PerPage)
            .Take(this.PerPage)
            .ToList();
        }

        public int Count(string search)
        {
            var query = this.context.Buildings.AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                return query.Count(b => b.Address.Contains(search) || b.Description.Contains(search));
            }

            return query.Count();
        }
    }
}