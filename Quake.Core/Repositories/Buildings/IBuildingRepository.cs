using System.Collections.Generic;
using Quake.Data.Entities;

namespace Quake.Core.Repositories.Buildings
{
    public interface IBuildingRepository : IRepository<Building>
    {
         List<Building> GetPaginatedBuildings(int page = 1, string? search = null, string? sort = null);
         int PerPage { get; set; }
         int Count(string search);
    }
}