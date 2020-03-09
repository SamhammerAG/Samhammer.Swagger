## Samhammer.Swagger.Default

This providdes configuration for swagger with default endpoints for swagger spec and ui.
It can be used in every web API project that is built with ASP.NET Core.

#### How to add this to your project:
- reference this package to your project: https://www.nuget.org/packages/Samhammer.Swagger.Default/

#### How to use:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSwaggerGen();
    services.AddSwaggerDefaultApi();
}

public void Configure(IApplicationBuilder app)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```


## Samhammer.Swagger.Authentication

This providdes configuration for swagger with authentication by oauth2 codeflow or bearer token.
It can be used in every web API project that is built with ASP.NET Core.

#### How to add this to your project:
- reference this package to your project: https://www.nuget.org/packages/Samhammer.Swagger.Authentication/

#### How to use:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSwaggerGen();
    services.AddSwaggerAuthentication(Configuration);
}

public void Configure(IApplicationBuilder app)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

For usage of auth2 codeflow setup settings in appsettings.json:
```js
  "SwaggerAuthOptions": {
    "ClientId": "<<ClientId>>",
    "AccessTokenUrl": "<<TokenUrl>>",
    "AuthUrl": "<<AuthUrl>>"
  },
```


## Samhammer.Swagger.Versioning

This providdes configuration for swagger with api versioning support.
It can be used in every web API project that is built with ASP.NET Core.

#### How to add this to your project:
- reference this package to your project: https://www.nuget.org/packages/Samhammer.Swagger.Authentication/

#### How to use:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddApiVersioning(...);
    services.AddSwaggerVersionedApi();
}

public void Configure(IApplicationBuilder app)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

## Contribute

#### How to publish package
- set package version in Samhammer.Swagger.Default.csproj
- set package version in Samhammer.Swagger.Authentication.csproj
- set package version in Samhammer.Swagger.Versioning.csproj
- create git tag
- dotnet pack -c Release
- nuget push .\bin\Release\Samhammer.Swagger.Default.*.nupkg NUGET_API_KEY -src https://api.nuget.org/v3/index.json
- nuget push .\bin\Release\Samhammer.Swagger.Authentication.*.nupkg NUGET_API_KEY -src https://api.nuget.org/v3/index.json
- nuget push .\bin\Release\Samhammer.Swagger.Versioning.*.nupkg NUGET_API_KEY -src https://api.nuget.org/v3/index.json
- (optional) nuget setapikey NUGET_API_KEY -source https://api.nuget.org/v3/index.json
