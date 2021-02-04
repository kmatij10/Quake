using Microsoft.Extensions.DependencyInjection;
using Quake.Core.Repositories.Buildings;
using Quake.Core.Repositories.Cities;
using Quake.Core.Repositories.Cards;
using Quake.Api.Services;

namespace Quake.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<IBuildingService, BuildingService>();
        }
    }
}