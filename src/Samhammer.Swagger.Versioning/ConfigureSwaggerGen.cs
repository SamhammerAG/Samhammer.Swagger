using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Samhammer.Swagger.Versioning
{
    public class ConfigureSwaggerGen : IConfigureOptions<SwaggerGenOptions>
    {
        private IApiVersionDescriptionProvider Provider { get; }

        public ConfigureSwaggerGen(IApiVersionDescriptionProvider provider)
        {
            Provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            var apiVersionDescriptions = Provider.ApiVersionDescriptions;

            foreach (var description in apiVersionDescriptions)
            {
                var info = new OpenApiInfo
                {
                    Version = description.ApiVersion.ToString(),
                    Description = description.IsDeprecated ? "This API version has been deprecated." : string.Empty,
                };

                options.SwaggerDoc(description.GroupName, info);
            }
        }
    }
}
