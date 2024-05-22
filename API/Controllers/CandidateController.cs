using Domain.Models.API.Request;
using Domain.Models.API.Response;
using Infrastructure.Models;
using Infrastructure.Services.Candidates;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidateController(ICandidate candidate) : ControllerBase
{
    [HttpPost("register")]
    public async Task<DefaultResponse<RegisterCandidateResponse>> Register(RegisterCandidateRequest request)
    {
        return await candidate.Register(request, HttpContext.RequestAborted);
    }
}