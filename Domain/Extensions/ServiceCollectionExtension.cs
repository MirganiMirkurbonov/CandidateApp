using Domain.Models.API.Request;
using Domain.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IValidator<RegisterCandidateRequest>, RegisterCandidateRequestValidator>();
        
        return serviceCollection;
    }
}