using Domain.Models.API.Request;
using FluentValidation;

namespace Domain.Validators;

using FluentValidation;

public class RegisterCandidateRequestValidator : AbstractValidator<RegisterCandidateRequest>
{
    public RegisterCandidateRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(100).WithMessage("First name must not exceed 100 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(100).WithMessage("Last name must not exceed 100 characters.");

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(20).WithMessage("Phone number must not exceed 20 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

        RuleFor(x => x.GithubProfileUrl)
            .MaximumLength(200).WithMessage("GitHub profile URL must not exceed 200 characters.")
            .Must(BeAValidUrl).WithMessage("Invalid GitHub profile URL format.")
            .When(x => !string.IsNullOrEmpty(x.GithubProfileUrl));

        RuleFor(x => x.LinkedinProfileUrl)
            .MaximumLength(200).WithMessage("LinkedIn profile URL must not exceed 200 characters.")
            .Must(BeAValidUrl).WithMessage("Invalid LinkedIn profile URL format.")
            .When(x => !string.IsNullOrEmpty(x.LinkedinProfileUrl));

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment is required.")
            .MaximumLength(500).WithMessage("Comment must not exceed 500 characters.");

        RuleFor(x => x.EndTimeInterval)
            .GreaterThan(x => x.StartTimeInterval).WithMessage("End time must bigger than start time.")
            .When(x => x.StartTimeInterval.HasValue && x.EndTimeInterval.HasValue);
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}
