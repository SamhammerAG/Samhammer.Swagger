using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Samhammer.Swagger.Default
{
    public static class SwaggerExtensions
    {
        [Obsolete("swashbuckle 6.2.3 setups default path for swagger.json for swagger-gen and swagger-ui already")]
        public static void AddSwaggerDefaultApi(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGen>();
            services.AddTransient<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUi>();
        }
    }
}
