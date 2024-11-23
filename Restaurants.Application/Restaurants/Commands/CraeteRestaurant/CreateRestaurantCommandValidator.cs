using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.CraeteRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    //private readonly List<String> validCategories = ["Italia", "Mexican", "Japanese", "American", "Indian"];
    public CreateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name).Length(3, 100);

        //RuleFor(x => x.Category)
        //    .Must(validCategories.Contains)
        //    .WithMessage("Invalid category. Please choose from the valid categories.");
        //.Custom((value, context) =>
        //{
        //    var isValidCategory = validCategories.Contains(value);
        //    if (!isValidCategory)
        //    {
        //        context.AddFailure("Category", "Invalid category. Please choose from the valid categories.");
        //    }
        //});



        RuleFor(x => x.ContactEmail).EmailAddress().WithMessage("Please provide a valid email address");
        RuleFor(x => x.PostalCode).Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX.");
    }
}
