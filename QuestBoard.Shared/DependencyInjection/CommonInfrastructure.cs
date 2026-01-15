using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Library.DependencyInjection
{
    public static class CommonInfrastructure
    {
        public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();

            return services;
        }
    }
}