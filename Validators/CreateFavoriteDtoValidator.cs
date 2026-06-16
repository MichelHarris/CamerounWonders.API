using CamerounWonders.API.DTOs;
using FluentValidation;

namespace CamerounWonders.API.Validators;

public class CreateFavoriteDtoValidator
    : AbstractValidator<CreateFavoriteDto>
{
    public CreateFavoriteDtoValidator()
    {
        RuleFor(x => x.TouristSiteId)
            .GreaterThan(0);
    }
}