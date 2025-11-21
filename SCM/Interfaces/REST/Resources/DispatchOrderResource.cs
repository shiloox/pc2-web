namespace pc2u202114643.API.SCM.Interfaces.REST.Resources;

/// <summary>
///     Resource returned after registering a dispatch order.
/// </summary>
public record DispatchOrderResource(
    int Id,
    string DispatchOrderId,
    string ProductId,
    int RequestedUnits,
    string QualityLevel,
    DateTime DispatchCompletedAt,
    int DispatchDays,
    string? Notes);
