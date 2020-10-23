using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Samhammer.Swagger.Authentication.Guest;
using Samhammer.Swagger.Authentication.Jwt;
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

        public static void AddSwaggerGuest(this IServiceCollection services, Action<SwaggerGuestOptions> configure)
        {
            services.Configure(configure);
            AddSwaggerGuest(services);
        }

        public static void AddSwaggerGuest(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SwaggerGuestOptions>(configuration.GetSection(nameof(SwaggerGuestOptions)));
            AddSwaggerGuest(services);
        }

        public static void AddSwaggerGuest(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenGuest>();
        }
    }
}
