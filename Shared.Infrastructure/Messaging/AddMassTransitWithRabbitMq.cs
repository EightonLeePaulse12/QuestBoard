using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Infrastructure.Messaging
{
    public static class AddMassTransitWithRabbitMq
    {
        public static IServiceCollection AddMassTransitConf(this IServiceCollection services, IConfiguration config, string v, Action<IBusRegistrationConfigurator>? configureConsumers = null)
        {
            services.AddMassTransit(x =>
            {
                configureConsumers?.Invoke(x);

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}