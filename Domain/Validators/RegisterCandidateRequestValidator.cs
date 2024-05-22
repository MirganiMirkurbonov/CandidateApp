using Domain.Models.API.Request;

namespace Domain.Validators;

using FluentValidation;

public class RegisterCandidateRequestValidator : AbstractValidator<RegisterCandidateRequest>
{
    public RegisterCandidateRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(20);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);

        RuleFor(x => x.GithubProfileUrl)
            .MaximumLength(200)
            .Must(BeAValidUrl)
            .When(x => !string.IsNullOrEmpty(x.GithubProfileUrl));

        RuleFor(x => x.LinkedinProfileUrl)
            .MaximumLength(200)
            .Must(BeAValidUrl)
            .When(x => !string.IsNullOrEmpty(x.LinkedinProfileUrl));

        RuleFor(x => x.Comment)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.EndTimeInterval)
            .GreaterThan(x => x.StartTimeInterval)
            .When(x => x.StartTimeInterval.HasValue && x.EndTimeInterval.HasValue);
    }

    private bool BeAValidUrl(string url)
    {
        if (!url.StartsWith("http://") && !url.StartsWith("https://"))
        {
            url = "http://" + url;
        }
    
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }

}
