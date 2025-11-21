namespace pc2u202114643.API.SCM.Interfaces.REST.Resources;

/// <summary>
///     Resource used to register a new dispatch order.
/// </summary>
public record CreateDispatchOrderResource(
    string ProductId,
    int RequestedUnits,
    DateTime DispatchExpectedAt,
    DateTime DispatchCompletedAt,
    string? Notes);
