namespace Domain.Models.API.Request;

public record RegisterCandidateRequest(
    string FirstName,
    string LastName,
    string PhoneNumber,
    DateTime? StartTimeInterval,
    DateTime? EndTimeInterval,
    string Email,
    string GithubProfileUrl,
    string LinkedinProfileUrl,
    string Comment);