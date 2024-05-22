using Domain.Enumerators;
using Domain.Models.API.Request;
using Domain.Models.API.Response;
using FluentValidation;
using Infrastructure.Mappers;
using Infrastructure.Models;
using Persistence.Context.Tables;
using Persistence.Repositories;

namespace Infrastructure.Services.Candidates;

internal class CandidateService(
    IValidator<RegisterCandidateRequest> validator,
    IRepository<Candidate> repository) : ICandidate
{
    public async Task<DefaultResponse<RegisterCandidateResponse>> Register(
        RegisterCandidateRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ErrorCodeEnum.InvalidInputParams;
        }
        
        var candidate = await repository.FindAsync(x => x.Email.ToLower() == request.Email.ToLower().Trim(), cancellationToken);
        if (candidate == null)
        {
            return await AddNewCandidate(request, cancellationToken);
        }

        return UpdateCandidate(request, candidate);
    }

    private async Task<RegisterCandidateResponse> AddNewCandidate(RegisterCandidateRequest request, CancellationToken cancellationToken)
    {
        var newCandidate = request.MapTo();
        await repository.AddAsync(newCandidate, cancellationToken);
        return newCandidate.MapTo();
    }
    
    private RegisterCandidateResponse UpdateCandidate(RegisterCandidateRequest request, Candidate candidate)
    {
        candidate.FirstName = request.FirstName;
        candidate.LastName = request.LastName;
        candidate.PhoneNumber = request.PhoneNumber;
        candidate.Comment = request.Comment;
        candidate.GithubProfileUrl = request.GithubProfileUrl;
        candidate.LinkedinProfileUrl = request.LinkedinProfileUrl;
        candidate.StartTimeInterval = request.StartTimeInterval;
        candidate.EndTimeInterval = request.EndTimeInterval;
        
        repository.Update(candidate);
        return candidate.MapTo();
    }
}