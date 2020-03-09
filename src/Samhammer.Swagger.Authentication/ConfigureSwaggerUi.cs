using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Samhammer.Swagger.Authentication
{
    public class ConfigureSwaggerUi : IConfigureOptions<SwaggerUIOptions>
    {
        private SwaggerAuthOptions Options { get; }

        public ConfigureSwaggerUi(IOptions<SwaggerAuthOptions> options)
        {
            Options = options.Value;
        }

        public void Configure(SwaggerUIOptions swaggerUi)
        {
            swaggerUi.OAuthClientId(Options.ClientId);
        }
    }
}
