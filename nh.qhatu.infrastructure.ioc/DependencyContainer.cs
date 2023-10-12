using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace nh.qhatu.infrastructure.ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration) 
        {
            //MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());           

            return services;
        }
    }
}
