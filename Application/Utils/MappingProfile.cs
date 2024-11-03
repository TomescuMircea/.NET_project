using Application.DTO;
using Domain.Entities;
using AutoMapper;
using Application.Use_Cases.Commands.ApartmentC;
using Application.Use_Cases.Commands.EstateC;

namespace Application.Utils
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Estate,EstateDto>().ReverseMap();
            CreateMap<CreateEstateCommand,Estate>().ReverseMap();
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<CreateApartmentCommand, Apartment>().ReverseMap();
        }
    }
}
