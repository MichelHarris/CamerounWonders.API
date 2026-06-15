using CamerounWonders.API.DTOs;
using FluentValidation;

namespace CamerounWonders.API.Validators;

public class UpdateRegionDtoValidator : AbstractValidator<UpdateRegionDto>
{
    public UpdateRegionDtoValidator()
    {
        RuleFor(x => x.Nom)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(10);

        RuleFor(x => x.PhotoUrl)
            .Must(url =>
                string.IsNullOrWhiteSpace(url)
                || Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("URL de photo invalide.");
    }
}