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
            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGen>();
            services.AddTransient<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUi>();
        }
    }
}
