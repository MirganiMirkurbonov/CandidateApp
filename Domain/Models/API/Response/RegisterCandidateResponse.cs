namespace Domain.Models.API.Response;

public record RegisterCandidateResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string? PhoneNumber,
    DateTime? StartTimeInterval,
    DateTime? EndTimeInterval,
    string Email,
    string Comment);