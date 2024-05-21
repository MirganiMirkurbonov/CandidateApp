using Domain.Models.API.Request;
using FluentValidation;
using Infrastructure.Models;
using Persistence.Context;

namespace Infrastructure.Services.Candidate;

internal class CandidateService(
    IValidator<RegisterCandidateRequest> validator,
    EntityContext entityContext) : ICandidate
{
    public async Task<DefaultResponse<bool>> Register(RegisterCandidateRequest request)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return new DefaultResponse<bool>(validationResult.Errors.First().ErrorMessage);
        }
        
        return new DefaultResponse<bool>(true);
    }
}