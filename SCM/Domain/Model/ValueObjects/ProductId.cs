namespace pc2u202114643.API.SCM.Domain.Model.ValueObjects;

/// <summary>
///     Value object that represents the identifier of a product supplied by another bounded context.
///     <author>u202114643</author>
/// </summary>
public class ProductId
{
    /// <summary>
    ///     Initializes a new instance required by Entity Framework Core.
    /// </summary>
    private ProductId()
    {
        Value = Guid.Empty;
    }

    /// <summary>
    ///     Initializes a new instance using an existing Guid.
    /// </summary>
    public ProductId(Guid value)
    {
        if (value == Guid.Empty) throw new ArgumentException("Product id cannot be empty.", nameof(value));
        Value = value;
    }

    /// <summary>
    ///     Initializes a new instance using a GUID string representation.
    /// </summary>
    /// <param name="value">String representation of the product identifier.</param>
    /// <exception cref="ArgumentException">Thrown when the value is null, empty, or not a valid GUID.</exception>
    public ProductId(string value)
    {
        if (!Guid.TryParse(value, out var parsed))
            throw new ArgumentException("Product id must be a valid GUID.", nameof(value));
        if (parsed == Guid.Empty) throw new ArgumentException("Product id cannot be empty.", nameof(value));
        Value = parsed;
    }

    /// <summary>
    ///     Gets the Guid value associated to the product.
    /// </summary>
    public Guid Value { get; private set; }

    public override string ToString()
    {
        return Value.ToString();
    }
}
