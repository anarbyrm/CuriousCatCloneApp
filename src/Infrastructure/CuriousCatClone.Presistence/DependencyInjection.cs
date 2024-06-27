using CuriousCatClone.Application.Contexts;
using CuriousCatClone.Application.Services;
using CuriousCatClone.Domain.Entities;
using CuriousCatClone.Presistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CuriousCatClone.Presistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayerServices(this IServiceCollection services, string connectionString)
        {
            AddDbContext(services, connectionString);
            AddInternalServices(services);
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
                .AddIdentityCore<AppUser>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }

        private static IServiceCollection AddInternalServices(IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
    }
}
