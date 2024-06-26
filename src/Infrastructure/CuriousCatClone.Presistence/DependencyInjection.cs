using CuriousCatClone.Application.Contexts;
using CuriousCatClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CuriousCatClone.Presistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayerServices(this IServiceCollection services, string connectionString)
        {
            AddDbContext(services, connectionString);
            AddIdentity(services);
            return services;
        }

        private static IServiceCollection AddDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(connectionString));
            return services;
        }

        private static IServiceCollection AddIdentity(IServiceCollection services)
        {
            services
                .AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<AppDbContext>();
            return services;
        }
    }
}
