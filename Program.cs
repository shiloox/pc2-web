using pc2u202114643.API.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;
using pc2u202114643.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using pc2u202114643.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using pc2u202114643.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using pc2u202114643.API.SCM.Infrastructure.Interfaces.ASP.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));


// Database Configuration
builder.AddDatabaseConfigurationServices();

// OpenAPI/Swagger Configuration
builder.AddOpenApiConfigurationServices();

// Dependency Injection
builder.AddSharedContextServices();
builder.AddScmContextServices();

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
app.EnsureDatabaseCreated();

// Configure OpenAPI/Swagger middleware
app.UseOpenApiConfiguration();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
