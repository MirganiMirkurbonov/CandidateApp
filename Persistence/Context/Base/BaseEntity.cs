using System.ComponentModel.DataAnnotations.Schema;
using Persistence.Enumerators;

namespace Persistence.Context.Base;

public abstract class BaseEntity
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("updated_at")]
    public DateTime UpdatedDate { get; set; }
    
    [Column("state")]
    public EntityState State { get; set; }
}