using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Context.Base;
using Persistence.Options;

namespace Persistence.Context;

public partial class EntityContext(
    IOptions<DatabaseOptions> options,
    DbContextOptions<EntityContext> dbContextOptions) : DbContext(dbContextOptions) 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(options.Value.ConnectionString,
            builder =>
            {
                builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(2), null);
                builder.CommandTimeout(200);
            });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public override int SaveChanges()
    {
        SetAuditProperties();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditProperties();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetAuditProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Id = Guid.NewGuid();
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }

            entry.Entity.UpdatedDate = DateTime.UtcNow;
        }
    }
}