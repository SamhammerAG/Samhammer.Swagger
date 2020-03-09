using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Samhammer.Swagger.Default
{
    public class ConfigureSwaggerGen : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("api-docs", new OpenApiInfo { Title = "API Docs" });
        }
    }
}
