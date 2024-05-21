using Persistence.Context;
using Persistence.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPersistenceLayer(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .Configure<DatabaseOptions>(configuration.GetSection("DatabaseOptions"));

        serviceCollection
            .AddScoped(typeof(IRepository<>), typeof(Repository<>));

        serviceCollection.AddDbContext<EntityContext>();
        return serviceCollection;
    }
}