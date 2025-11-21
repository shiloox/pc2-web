namespace pc2u202114643.API.SCM.Domain.Model.Commands;

/// <summary>
///     Command object that contains the data required to register a new dispatch order.
/// </summary>
/// <param name="ProductId">External product identifier.</param>
/// <param name="RequestedUnits">Requested units count.</param>
/// <param name="DispatchExpectedAt">Expected dispatch date in UTC.</param>
/// <param name="DispatchCompletedAt">Completed dispatch date in UTC.</param>
/// <param name="Notes">Optional notes.</param>
public record CreateDispatchOrderCommand(
    string ProductId,
    int RequestedUnits,
    DateTime DispatchExpectedAt,
    DateTime DispatchCompletedAt,
    string? Notes);
