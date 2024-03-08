using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Samhammer.Swagger.Versioning
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerVersionedApi(this IServiceCollection services)
        {
            services.AddApiVersioning() // Core API versioning services with support for Minimal APIs
                .AddMvc() // API version-aware extensions for MVC Core with controllers (not full MVC)
                .AddApiExplorer(o =>
                {
                    o.GroupNameFormat = "'v'VVV";
                    o.SubstituteApiVersionInUrl = true;
                }); // API version-aware API Explorer extensions

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGen>();
            services.AddTransient<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUi>();
        }
    }
}
