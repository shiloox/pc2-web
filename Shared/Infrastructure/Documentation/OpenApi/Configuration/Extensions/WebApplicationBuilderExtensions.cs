using Microsoft.OpenApi.Models;

namespace pc2u202114643.API.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddOpenApiConfigurationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "pc2u202114643.API",
                    Version = "v1",
                    Description = "Delta Faucet Company SCM API",
                    TermsOfService = new Uri("https://www.deltafaucetcompany.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Delta Faucet Company",
                        Email = "support@deltafaucetcompany.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Internal Use Only",
                        Url = new Uri("https://www.deltafaucetcompany.com/")
                    }
                });
            options.EnableAnnotations();
        });
    }
}
