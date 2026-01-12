using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Samhammer.Swagger.Authentication.Guest
{
    public class ConfigureSwaggerGenGuest(IOptions<SwaggerGuestOptions> options) : IConfigureOptions<SwaggerGenOptions>
    {
        private SwaggerGuestOptions Options { get; } = options.Value;

        private const string HeaderKey = "GuestID";

        public void Configure(SwaggerGenOptions swaggerGen)
        {
            if (!Options.Enabled)
            {
                return;
            }

            const string schemeId = "Guest";

            var apiKeyScheme = new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Name = HeaderKey,
            };

            swaggerGen.AddSecurityDefinition(schemeId, apiKeyScheme);

            swaggerGen.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference(schemeId, document)] = new List<string>(),
            });

            swaggerGen.OperationFilter<SecurityRequirementsOperationFilter>(true, schemeId);

            if (!swaggerGen.OperationFilterDescriptors.Exists(f => f.Type == typeof(AppendAuthorizeToSummaryOperationFilter)))
            {
                swaggerGen.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            }
        }
    }
}
