using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Infrastructure.Messaging
{
    public static class AddMassTransitWithRabbitMq
    {
        public static IServiceCollection AddMassTransitConf(this IServiceCollection services, IConfiguration config, Action<IBusRegistrationConfigurator>? configureConsumers = null)
        {
            services.AddMassTransit(x =>
            {
                configureConsumers?.Invoke(x);
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost", cred =>
                    {
                        cred.Username("guest");
                        cred.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
