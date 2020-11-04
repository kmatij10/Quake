using Microsoft.Extensions.DependencyInjection;
using Quake.Core.Repositories.Buildings;
using Quake.Api.Services;

namespace Quake.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IBuildingRepository, BuildingRepository>();

            services.AddScoped<IBuildingService, BuildingService>();
        }
    }
}