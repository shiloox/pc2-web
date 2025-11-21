using pc2u202114643.API.Shared.Domain.Repositories;
using pc2u202114643.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace pc2u202114643.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddSharedContextServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}