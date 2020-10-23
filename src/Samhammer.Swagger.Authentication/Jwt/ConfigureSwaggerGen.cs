using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Samhammer.Swagger.Authentication.Jwt
{
    public class ConfigureSwaggerGen : IConfigureOptions<SwaggerGenOptions>
    {
        private SwaggerAuthOptions Options { get; }

        public ConfigureSwaggerGen(IOptions<SwaggerAuthOptions> options)
        {
            Options = options.Value;
        }

        public void Configure(SwaggerGenOptions swaggerGen)
        {
            swaggerGen.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            swaggerGen.OperationFilter<SecurityRequirementsOperationFilter>();

            if (string.IsNullOrWhiteSpace(Options.AuthUrl) || string.IsNullOrWhiteSpace(Options.AccessTokenUrl))
            {
                swaggerGen.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                });
            }
            else
            {
                swaggerGen.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "OAuth2 Authentication using KeyCloak account.",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(Options.AuthUrl),
                            TokenUrl = new Uri(Options.AccessTokenUrl),
                        },
                    },
                });
            }
        }
    }
}
