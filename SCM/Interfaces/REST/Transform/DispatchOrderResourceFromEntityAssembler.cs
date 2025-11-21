using pc2u202114643.API.SCM.Domain.Model.Aggregates;
using pc2u202114643.API.SCM.Interfaces.REST.Resources;

namespace pc2u202114643.API.SCM.Interfaces.REST.Transform;

/// <summary>
///     Maps dispatch order aggregates to REST resources.
/// </summary>
public static class DispatchOrderResourceFromEntityAssembler
{
    public static DispatchOrderResource ToResourceFromEntity(DispatchOrder dispatchOrder)
    {
        return new DispatchOrderResource(
            dispatchOrder.Id,
            dispatchOrder.DispatchOrderId.ToString(),
            dispatchOrder.ProductId.ToString(),
            dispatchOrder.RequestedUnits,
            dispatchOrder.QualityLevel.ToString(),
            dispatchOrder.DispatchCompletedAt,
            dispatchOrder.DispatchDays,
            dispatchOrder.Notes);
    }
}
