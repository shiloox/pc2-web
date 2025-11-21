using pc2u202114643.API.SCM.Application.Internal.CommandServices;
using pc2u202114643.API.SCM.Domain.Repositories;
using pc2u202114643.API.SCM.Domain.Services;
using pc2u202114643.API.SCM.Infrastructure.Persistence.EFC.Repositories;

namespace pc2u202114643.API.SCM.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
///     Registers SCM bounded context services.
///     <author>u202114643</author>
/// </summary>
public static class WebApplicationBuilderExtensions
{
    public static void AddScmContextServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDispatchOrderRepository, DispatchOrderRepository>();
        builder.Services.AddScoped<IDispatchOrderCommandService, DispatchOrderCommandService>();
    }
}
