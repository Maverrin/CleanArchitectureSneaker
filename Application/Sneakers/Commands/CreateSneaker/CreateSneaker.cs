using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Sneakers.Commands.CreateSneaker;

public record CreateSneakerCommand : IRequest<Sneaker>
{

    public string? Name { get; set; }
    public string? Brand { get; set; }
    public int Price { get; set; }
    public int Size { get; set; }
    public int DateInYear { get; set; }
    public int Rating { get; set; }
}

public class CreateSneakerCommandHandler : IRequestHandler<CreateSneakerCommand, Sneaker>
{
    private readonly ISneakerRepository _sneakerRepository;

    public CreateSneakerCommandHandler(ISneakerRepository sneakerRepository)
    {
        _sneakerRepository = sneakerRepository;
    }

    public async Task<Sneaker> Handle(CreateSneakerCommand request, CancellationToken cancellationToken)
    {
        var newSneaker = new Sneaker
        {
            Name = request.Name,
            Brand = request.Brand,
            Price = request.Price,
            Size = request.Size,
            Year = request.DateInYear,
            Rating = request.Rating
        };

        return await _sneakerRepository.Add(newSneaker);
    }
}
