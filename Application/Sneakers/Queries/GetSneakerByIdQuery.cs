using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Sneakers.Queries;

public record GetSneakerByIdQuery(Guid Id) : IRequest<SneakerDTO>;

public class GetSneakerByIdQueryHandler : IRequestHandler<GetSneakerByIdQuery, SneakerDTO>
{
    private readonly ISneakerRepository _sneakerRepository;
    private readonly IMapper _mapper;
    public GetSneakerByIdQueryHandler(ISneakerRepository sneakerRepository, IMapper mapper)
    {
        _sneakerRepository = sneakerRepository;
        _mapper = mapper;
    }

    public async Task<SneakerDTO> Handle(GetSneakerByIdQuery request, CancellationToken cancellationToken)
    {
        var sneaker = await _sneakerRepository.GetById(request.Id);

        return _mapper.Map<SneakerDTO>(sneaker);
    }
}

