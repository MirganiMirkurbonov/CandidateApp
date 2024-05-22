using Domain.Models.API.Request;
using Domain.Models.API.Response;
using Infrastructure.Models;

namespace Infrastructure.Services.Candidates;

public interface ICandidate
{
    Task<DefaultResponse<RegisterCandidateResponse>> Register(RegisterCandidateRequest request, CancellationToken cancellationToken);
}