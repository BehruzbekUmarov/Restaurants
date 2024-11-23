using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name).Length(3, 100);
        RuleFor(x => x.ContactEmail).EmailAddress().WithMessage("Please provide a valid email address");
        RuleFor(x => x.PostalCode).Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX.");
    }
}
