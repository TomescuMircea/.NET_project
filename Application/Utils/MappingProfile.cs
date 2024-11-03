using Application.DTO;
using Domain.Entities;
using AutoMapper;
using Application.Use_Cases.Commands.ApartmentC;

namespace Application.Utils
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Estate,EstateDto>().ReverseMap();
            //CreateMap<CreateEstateCommand,Estate>().ReverseMap();
            //CreateMap<UpdateEstateCommand,Estate>().ReverseMap();
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<CreateApartmentCommand, Apartment>().ReverseMap();
        }
    }
}
