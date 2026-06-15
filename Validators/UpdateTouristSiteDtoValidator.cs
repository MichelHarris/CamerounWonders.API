using CamerounWonders.API.DTOs;
using FluentValidation;

namespace CamerounWonders.API.Validators;

public class UpdateTouristSiteDtoValidator
    : AbstractValidator<UpdateTouristSiteDto>
{
    public UpdateTouristSiteDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Le nom est obligatoire.")
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("La description est obligatoire.");

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("La localisation est obligatoire.");

        RuleFor(x => x.RegionId)
            .GreaterThan(0)
            .WithMessage("Une région valide est requise.");
    }
}