using pc2u202114643.API.SCM.Domain.Model.Aggregates;
using pc2u202114643.API.SCM.Domain.Model.Commands;
using pc2u202114643.API.SCM.Domain.Repositories;
using pc2u202114643.API.SCM.Domain.Services;
using pc2u202114643.API.Shared.Domain.Repositories;

namespace pc2u202114643.API.SCM.Application.Internal.CommandServices;

/// <summary>
///     Command service implementation responsible for managing dispatch orders.
///     <author>u202114643</author>
/// </summary>
/// <param name="dispatchOrderRepository">Repository used to persist dispatch orders.</param>
/// <param name="unitOfWork">Unit of work for committing changes.</param>
public class DispatchOrderCommandService(
    IDispatchOrderRepository dispatchOrderRepository,
    IUnitOfWork unitOfWork) : IDispatchOrderCommandService
{
    /// <inheritdoc />
    public async Task<DispatchOrder> Handle(CreateDispatchOrderCommand command)
    {
        var dispatchOrder = new DispatchOrder(command);
        await dispatchOrderRepository.AddAsync(dispatchOrder);
        await unitOfWork.CompleteAsync();
        return dispatchOrder;
    }
}
