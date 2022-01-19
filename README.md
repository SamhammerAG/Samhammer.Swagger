[![Build Status](https://travis-ci.com/SamhammerAG/Samhammer.Swagger.svg?branch=master)](https://travis-ci.com/SamhammerAG/Samhammer.Swagger)

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

This providdes configuration for swagger with authentication by oauth2 codeflow or bearer token or guest auth.
It can be used in every web API project that is built with ASP.NET Core.

#### How to add this to your project:
- reference this package to your project: https://www.nuget.org/packages/Samhammer.Swagger.Authentication/

#### How to use:

### JWT Authentication

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

For setup of auth2 codeflow add this to appsettings.json:
```js
  "SwaggerAuthOptions": {
    "ClientId": "<<ClientId>>",
    "AccessTokenUrl": "<<TokenUrl>>",
    "AuthUrl": "<<AuthUrl>>"
  },
```

### Guest Authentication
For Authenticaton by https://github.com/SamhammerAG/Samhammer.Authentication#guest-authentication

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSwaggerGuest(Configuration);
}
```

For override of default settings (enabled true) add this to appsettings.json:
```js
  "SwaggerGuestOptions": {
    "Enabled": false
  }
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
    services.AddSwaggerGen();
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
- Create a tag and let the github action do the publishing for you
