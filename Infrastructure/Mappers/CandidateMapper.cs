using Domain.Models.API.Request;
using Domain.Models.API.Response;
using Persistence.Context.Tables;

namespace Infrastructure.Mappers;

public static class CandidateMapper
{
    public static Candidate MapTo(this RegisterCandidateRequest request)
    {
        return new Candidate
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = request.Email.ToLower().Trim(),
            PhoneNumber = request.PhoneNumber.Trim(),
            GithubProfileUrl = request.GithubProfileUrl.Trim(),
            LinkedinProfileUrl = request.LinkedinProfileUrl.Trim(),
            StartTimeInterval = request.StartTimeInterval,
            EndTimeInterval = request.EndTimeInterval,
            Comment = request.Comment.Trim()
        };
    }
    
    public static RegisterCandidateResponse MapTo(this Candidate model)
    {
        return new RegisterCandidateResponse(
            Id: model.Id,
            FirstName: model.FirstName,
            LastName: model.LastName,
            PhoneNumber: model.PhoneNumber,
            StartTimeInterval: model.StartTimeInterval,
            EndTimeInterval: model.EndTimeInterval,
            Email: model.Email,
            Comment: model.Comment);
    }
}