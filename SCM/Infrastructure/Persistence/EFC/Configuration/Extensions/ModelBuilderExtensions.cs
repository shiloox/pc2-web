using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pc2u202114643.API.SCM.Domain.Model.Aggregates;
using pc2u202114643.API.SCM.Domain.Model.ValueObjects;

namespace pc2u202114643.API.SCM.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Contains Entity Framework Core mappings for the SCM bounded context.
///     <author>u202114643</author>
/// </summary>
public static class ModelBuilderExtensions
{
    public static void ApplyScmConfiguration(this ModelBuilder builder)
    {
        ConfigureDispatchOrders(builder.Entity<DispatchOrder>());
    }

    private static void ConfigureDispatchOrders(EntityTypeBuilder<DispatchOrder> entity)
    {
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

        entity.Property(x => x.DispatchOrderId)
            .HasConversion(
                id => id.Value,
                value => new DispatchOrderId(value))
            .HasColumnName("dispatch_order_id")
            .IsRequired();

        entity.Property(x => x.ProductId)
            .HasConversion(
                id => id.Value,
                value => new ProductId(value))
            .HasColumnName("product_id")
            .IsRequired();

        entity.Property(x => x.RequestedUnits).IsRequired();
        entity.Property(x => x.DispatchExpectedAt).IsRequired();
        entity.Property(x => x.DispatchCompletedAt).IsRequired();
        entity.Property(x => x.QualityLevel).IsRequired().HasConversion<string>();
        entity.Property(x => x.Notes).HasMaxLength(1024);
    }
}
