using CamerounWonders.API.DTOs;
using FluentValidation;

namespace CamerounWonders.API.Validators;

public class CreateRegionDtoValidator : AbstractValidator<CreateRegionDto>
{
    public CreateRegionDtoValidator()
    {
        RuleFor(x => x.Nom)
            .NotEmpty()
            .WithMessage("Le nom est obligatoire.")
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("La description est obligatoire.")
            .MinimumLength(10);

        RuleFor(x => x.PhotoUrl)
            .Must(url =>
                string.IsNullOrWhiteSpace(url)
                || Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("URL de photo invalide.");
    }
}