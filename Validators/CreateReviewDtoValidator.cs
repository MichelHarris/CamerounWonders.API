using CamerounWonders.API.DTOs;
using FluentValidation;

namespace CamerounWonders.API.Validators;

public class CreateReviewDtoValidator
    : AbstractValidator<CreateReviewDto>
{
    public CreateReviewDtoValidator()
    {
        RuleFor(x => x.TouristSiteId)
            .GreaterThan(0);

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5);

        RuleFor(x => x.Comment)
            .NotEmpty()
            .MaximumLength(1000);
    }
}