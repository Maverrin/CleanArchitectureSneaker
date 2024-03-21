using Application.Interfaces;
using MediatR;

namespace Application.Sneakers.Commands.DeleteSneaker;

public record DeleteSneakerCommand(Guid Id) : IRequest
{
}


public class DeleteSneakerCommandHandler : IRequestHandler<DeleteSneakerCommand>
{
    private readonly ISneakerRepository _sneakerRepository;
    public DeleteSneakerCommandHandler(ISneakerRepository sneakerRepository)
    {
        _sneakerRepository = sneakerRepository;
    }

    public async Task Handle(DeleteSneakerCommand request, CancellationToken cancellationToken)
    {
        await _sneakerRepository.DeleteById(request.Id);
    }
}
