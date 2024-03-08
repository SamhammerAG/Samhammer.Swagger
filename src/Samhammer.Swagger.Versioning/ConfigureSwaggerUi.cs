using System.Linq;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Samhammer.Swagger.Versioning
{
    public class ConfigureSwaggerUi : IConfigureOptions<SwaggerUIOptions>
    {
        private IApiVersionDescriptionProvider ApiVersionDescriptionProvider { get; }

        public ConfigureSwaggerUi(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            ApiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        public void Configure(SwaggerUIOptions swaggerUi)
        {
            var apiVersionDescriptions = ApiVersionDescriptionProvider.ApiVersionDescriptions.Reverse();

            foreach (var description in apiVersionDescriptions)
            {
                swaggerUi.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        }
    }
}
