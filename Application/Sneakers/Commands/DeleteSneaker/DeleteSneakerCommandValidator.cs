using FluentValidation;

namespace Application.Sneakers.Commands.DeleteSneaker;

public class DeleteSneakerCommandValidator : AbstractValidator<DeleteSneakerCommand>
{
    public DeleteSneakerCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}
