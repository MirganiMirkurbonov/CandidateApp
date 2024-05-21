using Domain.Models.API.Request;
using FluentValidation;
using Infrastructure.Models;
using Persistence.Context;
using Persistence.Repositories;

namespace Infrastructure.Services.Candidate;

internal class CandidateService(
    IValidator<RegisterCandidateRequest> validator,
    EntityContext entityContext,
    IRepository<Persistence.Context.Tables.Candidate> repository) : ICandidate
{
    public async Task<DefaultResponse<bool>> Register(RegisterCandidateRequest request)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return new DefaultResponse<bool>(validationResult.Errors.First().ErrorMessage);
        }

        var newCandidate = new Persistence.Context.Tables.Candidate
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow,
            PhoneNumber = request.PhoneNumber,
            GithubProfileUrl = request.GithubProfileUrl,
            LinkedinProfileUrl = request.LinkedinProfileUrl,
            StartTimeInterval = request.StartTimeInterval,
            EndTimeInterval = request.EndTimeInterval,
            Comment = request.Comment
        };
        await repository.AddAsync(newCandidate);
        
        return new DefaultResponse<bool>(true);
    }
}