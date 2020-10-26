using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Samhammer.Swagger.Authentication.Guest
{
    public class ConfigureSwaggerGenGuest : IConfigureOptions<SwaggerGenOptions>
    {
        private SwaggerGuestOptions Options { get; }

        public ConfigureSwaggerGenGuest(IOptions<SwaggerGuestOptions> options)
        {
            Options = options.Value;
        }

        public void Configure(SwaggerGenOptions swaggerGen)
        {
            if (!Options.Enabled)
            {
                return;
            }

            var apiKeyRef = new OpenApiReference
            {
                Id = "Guest",
                Type = ReferenceType.SecurityScheme,
            };

            var apiKeyScheme = new OpenApiSecurityScheme
            {
                Reference = apiKeyRef,
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Name = "X-GuestSession",
            };

            swaggerGen.AddSecurityDefinition(apiKeyRef.Id, apiKeyScheme);
            swaggerGen.AddSecurityRequirement(new OpenApiSecurityRequirement { { apiKeyScheme, new string[] { } } });

            swaggerGen.OperationFilter<SecurityRequirementsOperationFilter>(true, apiKeyScheme.Reference.Id);

            if (!swaggerGen.OperationFilterDescriptors.Exists(f => f.Type == typeof(AppendAuthorizeToSummaryOperationFilter)))
            {
                swaggerGen.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            }
        }
    }
}
