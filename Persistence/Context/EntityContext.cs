using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
}