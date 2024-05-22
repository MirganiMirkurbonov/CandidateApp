using Infrastructure.Services.Candidate;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<ICandidate, CandidateService>();
        return serviceCollection;
    }
}