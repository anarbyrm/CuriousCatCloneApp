using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CuriousCatClone.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
        {
            AddMediator(services);
            return services;
        }

        private static IServiceCollection AddMediator(IServiceCollection services)
        {
            services.AddMediatR(
                options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
