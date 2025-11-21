using pc2u202114643.API.SCM.Domain.Model.Aggregates;
using pc2u202114643.API.Shared.Domain.Repositories;

namespace pc2u202114643.API.SCM.Domain.Repositories;

/// <summary>
///     Repository contract for the dispatch order aggregate.
/// </summary>
public interface IDispatchOrderRepository : IBaseRepository<DispatchOrder>
{
}
