using Microsoft.Extensions.DependencyInjection;
using Quake.Core.Repositories.Buildings;

namespace Quake.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IBuildingRepository, BuildingRepository>();
        }
    }
}