using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Sneakers.Queries;

public record GetSneakerByPredicateQuery(Func<Sneaker, bool> where, Func<Sneaker, object> order) : IRequest <List<SneakerDTO>>;

public class GetSneakerByPredicateQueryHandler : IRequestHandler<GetSneakerByPredicateQuery, List<SneakerDTO>>
{
    private readonly ISneakerRepository _sneakerRepository;
    private readonly IMapper _mapper;
    public GetSneakerByPredicateQueryHandler(ISneakerRepository sneakerRepository, IMapper mapper)
    {
        _sneakerRepository = sneakerRepository;
        _mapper = mapper;
    }

    public async Task <List<SneakerDTO>> Handle(GetSneakerByPredicateQuery request, CancellationToken cancellationToken)
    {
        var sneaker = _sneakerRepository.GetAllPredicate(request.where, request.order);
        return _mapper.Map<List<SneakerDTO>>(sneaker);
    }
}

