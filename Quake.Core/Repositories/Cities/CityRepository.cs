using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quake.Data.Database;
using Quake.Data.Entities;

namespace Quake.Core.Repositories.Cities
{
    public interface ICityRepository : IRepository<City> { }
    public class CityRepository : ICityRepository
    {
        private readonly QuakeContext context;
        public CityRepository(QuakeContext context)
        {
            this.context = context;
        }

        public IEnumerable<City> GetAll(string search)
        {
            return this.context.Cities.ToList();
        }

        public City GetOne(long id)
        {
            return this.context.Cities.Where(c => c.Id == id).Single();
        }

        public City Create(City c)
        {
            this.context.Cities.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool Delete(long id)
        {
            this.context.Cities.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public City Update(long id, City newCity)
        {
            newCity.Id = id;
            this.context.Entry(newCity).State = EntityState.Modified;
            this.context.SaveChanges();

            return newCity;
        }
    }
}