using pc2u202114643.API.SCM.Domain.Model.Aggregates;
using pc2u202114643.API.SCM.Domain.Model.Commands;

namespace pc2u202114643.API.SCM.Domain.Services;

/// <summary>
///     Command service contract for dispatch orders.
/// </summary>
public interface IDispatchOrderCommandService
{
    /// <summary>
    ///     Handles the creation of a new dispatch order.
    /// </summary>
    /// <param name="command">Command that contains the data for the new dispatch order.</param>
    /// <returns>The created dispatch order.</returns>
    Task<DispatchOrder> Handle(CreateDispatchOrderCommand command);
}
