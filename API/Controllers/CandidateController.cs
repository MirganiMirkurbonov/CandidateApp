using Domain.Models.API.Request;
using Infrastructure.Models;
using Infrastructure.Services.Candidate;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidateController(ICandidate candidate) : ControllerBase
{
    [HttpPost("register")]
    public async Task<DefaultResponse<bool>> Register(RegisterCandidateRequest request)
    {
        return await candidate.Register(request, HttpContext.RequestAborted);
    }
}