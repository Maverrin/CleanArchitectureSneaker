using Application.Abstractions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Sneakers.Commands.UpdateSneaker;

public record UpdateSneakerCommand : IRequest<Sneaker>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public int Price { get; set; }
    public int Size { get; set; }
    public int Date { get; set; }
    public int Rating { get; set; }
}

public class UpdateSneakerCommandHandler : IRequestHandler<UpdateSneakerCommand, Sneaker>
{
    private readonly ISneakerRepository _sneakerRepository;

    public UpdateSneakerCommandHandler(ISneakerRepository sneakerRepository)
    {
        _sneakerRepository = sneakerRepository;
    }

    public async Task<Sneaker> Handle(UpdateSneakerCommand request, CancellationToken cancellationToken)
    {
        var updatedSneaker = new Sneaker
        {
            Id = request.Id,
            Name = request.Name,
            Brand = request.Brand,
            Price = request.Price,
            Size = request.Size,
            Year = request.Date,
            Rating = request.Rating
        };

        return await _sneakerRepository.Update(updatedSneaker);
    }

}

