using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace pc2u202114643.API.SCM.Domain.Model.Aggregates;

/// <summary>
///     Audit information for <see cref="DispatchOrder" />.
/// </summary>
public partial class DispatchOrder : IEntityWithCreatedUpdatedDate
{
    [Column("created_at")] public DateTimeOffset? CreatedDate { get; set; }

    [Column("updated_at")] public DateTimeOffset? UpdatedDate { get; set; }
}
