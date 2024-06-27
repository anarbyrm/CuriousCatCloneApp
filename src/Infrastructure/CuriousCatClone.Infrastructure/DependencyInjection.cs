using CuriousCatClone.Infrastructure.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuriousCatClone.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayerServices(this IServiceCollection services)
        {
            services.AddScoped<JwtTokenHandler, JwtTokenHandler>();
            return services;
        }
    }
}
