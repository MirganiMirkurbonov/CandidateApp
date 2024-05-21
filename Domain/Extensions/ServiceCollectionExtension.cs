using Domain.Context;
using Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomainLayer(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .Configure<DatabaseOptions>(configuration.GetSection("DatabaseOptions"));

        serviceCollection.AddDbContext<EntityContext>();
        return serviceCollection;
    }
}