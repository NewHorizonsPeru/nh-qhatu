using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using nh.micro.qhatu.domain.bus;
using nh.qhatu.domain.bus;
using nh.qhatu.infra.bus;
using nh.qhatu.infra.bus.settings;
using System.Reflection;

namespace nh.qhatu.infra.ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration) 
        {
            //MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Event Bus
            services.AddSingleton<IEventBus, RabbitMqBus>(config =>
            {
                var mediatorFactory = config.GetService<IMediator>();
                var scopeFactory = config.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = config.GetService<IOptions<RabbitMqSettings>>();
                return new RabbitMqBus(mediatorFactory, scopeFactory, optionsFactory);
            });

            return services;
        }
    }
}
