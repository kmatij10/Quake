using Quake.Data.Entities;
using System.Collections.Generic;

namespace Quake.Api.Responses.Buildings
{
    public class PaginatedBuildingResponse : BaseResponse
    {
        public PaginatedBuildingResponse()
        {

        }

        public PaginatedBuildingResponse(List<Building> buildings, int page, int count, int perPage)
        {
            Buildings = buildings;
            Count = count;
            PerPage = perPage;
            Page = page;
            Success = true;
        }

        public List<Building> Buildings { get; set; }
        public int Count { get; set; }
        public int PerPage { get; set; }
        public int Page { get; set; }
    }
}