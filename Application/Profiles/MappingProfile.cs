using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SneakerDTO, Sneaker>().ReverseMap();
    }
}
