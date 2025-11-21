namespace pc2u202114643.API.SCM.Domain.Model.ValueObjects;

/// <summary>
///     Value object that represents the unique identifier of a dispatch order.
///     <author>u202114643</author>
/// </summary>
public class DispatchOrderId
{
    /// <summary>
    ///     Initializes a new instance required by Entity Framework Core.
    /// </summary>
    private DispatchOrderId()
    {
        Value = Guid.Empty;
    }

    /// <summary>
    ///     Initializes a new instance using an existing Guid.
    /// </summary>
    /// <param name="value">Guid value that identifies the dispatch order.</param>
    /// <exception cref="ArgumentException">Thrown when the value is Guid.Empty.</exception>
    public DispatchOrderId(Guid value)
    {
        if (value == Guid.Empty) throw new ArgumentException("Dispatch order id cannot be empty.", nameof(value));
        Value = value;
    }

    /// <summary>
    ///     Initializes a new instance using a string representation of a Guid.
    /// </summary>
    /// <param name="value">Guid value as string.</param>
    /// <exception cref="ArgumentException">Thrown when the value cannot be parsed.</exception>
    public DispatchOrderId(string value)
    {
        if (!Guid.TryParse(value, out var parsed))
            throw new ArgumentException("Dispatch order id is invalid.", nameof(value));
        if (parsed == Guid.Empty) throw new ArgumentException("Dispatch order id cannot be empty.", nameof(value));
        Value = parsed;
    }

    /// <summary>
    ///     Gets the Guid value.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    ///     Creates a new identifier using a random Guid.
    /// </summary>
    public static DispatchOrderId New() => new(Guid.NewGuid());

    public override string ToString()
    {
        return Value.ToString();
    }
}
