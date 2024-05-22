using Domain.Enumerators;
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
    public async Task<DefaultResponse<bool>> Register(
        RegisterCandidateRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new DefaultResponse<bool>(ErrorCodeEnum.InvalidInputParams);
        }

        var newCandidate = new Persistence.Context.Tables.Candidate
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            GithubProfileUrl = request.GithubProfileUrl,
            LinkedinProfileUrl = request.LinkedinProfileUrl,
            StartTimeInterval = request.StartTimeInterval,
            EndTimeInterval = request.EndTimeInterval,
            Comment = request.Comment
        };
        await repository.AddAsync(newCandidate, cancellationToken);
        
        return new DefaultResponse<bool>(true);
    }
}