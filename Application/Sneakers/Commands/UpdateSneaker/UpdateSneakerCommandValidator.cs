using FluentValidation;

namespace Application.Sneakers.Commands.UpdateSneaker;

public class UpdateSneakerCommandValidator : AbstractValidator<UpdateSneakerCommand>
{
    public UpdateSneakerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(255)
            .NotEmpty();

        RuleFor(v => v.Brand)
            .MaximumLength(255)
            .NotEmpty();

        RuleFor(v => v.Price)
            .NotEmpty();

        RuleFor(v => v.Size)
            .NotEmpty();

        RuleFor(v => v.Date)
            .NotEmpty();
    }
}
