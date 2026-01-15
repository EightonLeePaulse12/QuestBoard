using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace Shared.Library.DependencyInjection
{
    public static class AddSwagger
    {
        public static IServiceCollection AddswaggerUI(this IServiceCollection services, IConfiguration config, string Title, string Description)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = Title,
                        Version = "v1",
                        Description = Description,
                    }
                );
            });

            return services;
        }
    }
}