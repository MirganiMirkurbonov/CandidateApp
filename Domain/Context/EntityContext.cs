using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context;

public partial class EntityContext(DbContextOptions<EntityContext> options) : DbContext(options) 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("",
            builder => { builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(2), null);
                builder.CommandTimeout(200);
            });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}