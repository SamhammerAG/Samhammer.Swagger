using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Samhammer.Swagger.Default
{
    public class ConfigureSwaggerUi : IConfigureOptions<SwaggerUIOptions>
    {
        public void Configure(SwaggerUIOptions swaggerUi)
        {
            swaggerUi.SwaggerEndpoint("api-docs/swagger.json", "API Docs");
        }
    }
}
