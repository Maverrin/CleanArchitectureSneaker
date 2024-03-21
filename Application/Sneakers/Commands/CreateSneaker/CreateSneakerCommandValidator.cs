using FluentValidation;
using System.Globalization;

namespace Application.Sneakers.Commands.CreateSneaker;

public class CreateSneakerCommandValidator : AbstractValidator<CreateSneakerCommand>
{
    public CreateSneakerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(255)
            .NotEmpty()
            .WithMessage("The sneaker name cannot be empty.");

        RuleFor(v => v.Brand)
            .MaximumLength(255)
            .NotEmpty()
            .WithMessage("The sneaker brand cannot be empty.");

        RuleFor(v => v.Price)
            .NotEmpty()
            .WithMessage("The sneaker price cannot be empty.");

        RuleFor(v => v.Size)
            .NotEmpty()
            .WithMessage("The sneaker size cannot be empty.");

        RuleFor(v => v.DateInYear)
            .NotEmpty()
            .WithMessage("The sneaker date cannot be empty.");
    }

    private bool BeAValidDateYear(DateTime year)
    {
        DateTime d;
        bool checkYear = DateTime.TryParseExact(year.ToString(), new string[] { "yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);

        return checkYear;
            
    }
}
