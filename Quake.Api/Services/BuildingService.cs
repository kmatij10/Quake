using AutoMapper;
using Quake.Api.Requests.Buildings;
using Quake.Api.Responses.Buildings;
using Quake.Core.Repositories.Buildings;

namespace Quake.Api.Services
{
    public interface IBuildingService
    {
        PaginatedBuildingResponse GetPaginatedResponse(PaginatedBuildingRequest request);
    }
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository buildingRepository;
        private readonly IMapper mapper;

        public BuildingService(
            IBuildingRepository buildingRepository,
            IMapper mapper
        )
        {
            this.buildingRepository = buildingRepository;
            this.mapper = mapper;
        }

        public PaginatedBuildingResponse GetPaginatedResponse(PaginatedBuildingRequest request)
        {
            var buildings = this.buildingRepository.GetPaginatedBuildings(
                request.Page,
                request.Search,
                request.Sort
            );

            int count = this.buildingRepository.Count(request.Search);
            var response = new PaginatedBuildingResponse(buildings, request.Page, count, this.buildingRepository.PerPage);
            return response;
        }
    }
}