using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Samhammer.Swagger.Versioning
{
    public class ConfigureSwaggerGen : IConfigureOptions<SwaggerGenOptions>
    {
        private IApiVersionDescriptionProvider Provider { get; }

        private IWebHostEnvironment HostingEnv { get; }

        public ConfigureSwaggerGen(IApiVersionDescriptionProvider provider, IWebHostEnvironment hostingEnv)
        {
            Provider = provider;
            HostingEnv = hostingEnv;
        }

        public void Configure(SwaggerGenOptions options)
        {
            var apiVersionDescriptions = Provider.ApiVersionDescriptions;

            foreach (var description in apiVersionDescriptions)
            {
                var info = new OpenApiInfo
                {
                    Version = description.ApiVersion.ToString(),
                    Title = HostingEnv.ApplicationName,
                    Description = description.IsDeprecated ? "This API version has been deprecated." : string.Empty,
                };

                options.SwaggerDoc(description.GroupName, info);
            }
        }
    }
}
