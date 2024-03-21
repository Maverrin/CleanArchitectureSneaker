using Application.Abstractions;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sneakers.Queries;

public record class GetSneakerCollectionQuery : IRequest<List<SneakerDTO>>;

public class GetSneakerCollectionQueryHandler : IRequestHandler<GetSneakerCollectionQuery, List<SneakerDTO>>
{
    private readonly ISneakerRepository _sneakerRepository;
    private readonly IMapper _mapper;

    public GetSneakerCollectionQueryHandler(ISneakerRepository sneakerRepository, IMapper mapper)
    {
        _sneakerRepository = sneakerRepository;
        _mapper = mapper;
    }
    public async Task<List<SneakerDTO>> Handle(GetSneakerCollectionQuery request, CancellationToken cancellationToken)
    {
        var sneaker = await _sneakerRepository.GetAll();
        var sneakerList = _mapper.Map<List<SneakerDTO>>(sneaker);

        return sneakerList;
    }
}
