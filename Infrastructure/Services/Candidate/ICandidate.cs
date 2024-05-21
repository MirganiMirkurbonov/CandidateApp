using Domain.Models.API.Request;
using Infrastructure.Models;

namespace Infrastructure.Services.Candidate;

public interface ICandidate
{
    Task<DefaultResponse<bool>> Register(RegisterCandidateRequest request);
}