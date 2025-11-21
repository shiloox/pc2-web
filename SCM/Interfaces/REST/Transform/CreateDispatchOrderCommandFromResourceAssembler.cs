using pc2u202114643.API.SCM.Domain.Model.Commands;
using pc2u202114643.API.SCM.Interfaces.REST.Resources;

namespace pc2u202114643.API.SCM.Interfaces.REST.Transform;

/// <summary>
///     Converts a REST resource into the corresponding application command.
/// </summary>
public static class CreateDispatchOrderCommandFromResourceAssembler
{
    public static CreateDispatchOrderCommand ToCommandFromResource(CreateDispatchOrderResource resource)
    {
        return new CreateDispatchOrderCommand(
            resource.ProductId,
            resource.RequestedUnits,
            resource.DispatchExpectedAt,
            resource.DispatchCompletedAt,
            resource.Notes);
    }
}
