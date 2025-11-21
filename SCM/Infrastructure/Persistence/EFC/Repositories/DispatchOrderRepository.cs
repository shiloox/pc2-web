using pc2u202114643.API.SCM.Domain.Model.Aggregates;
using pc2u202114643.API.SCM.Domain.Repositories;
using pc2u202114643.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using pc2u202114643.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace pc2u202114643.API.SCM.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Entity Framework Core repository implementation for dispatch orders.
/// </summary>
/// <param name="context">Application DbContext.</param>
public class DispatchOrderRepository(AppDbContext context)
    : BaseRepository<DispatchOrder>(context), IDispatchOrderRepository;
