using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Samhammer.Swagger.Authentication
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerAuthentication(this IServiceCollection services, Action<SwaggerAuthOptions> configure)
        {
            services.Configure(configure);
            services.AddSwaggerAuthentication();
        }

        public static void AddSwaggerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SwaggerAuthOptions>(configuration.GetSection(nameof(SwaggerAuthOptions)));
            services.AddSwaggerAuthentication();
        }

        private static void AddSwaggerAuthentication(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGen>();
            services.AddTransient<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUi>();
        }
    }
}
