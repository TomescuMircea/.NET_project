using Application.DTO;
using Domain.Entities;
using AutoMapper;
using Application.Use_Cases.Commands.ApartmentC;
using Application.Use_Cases.Commands.EstateC;
using Application.Use_Cases.Commands.BusinessSpaceC;
using Application.Use_Cases.Commands.UserC;

namespace Application.Utils
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<CreateApartmentCommand, Apartment>().ReverseMap();

            CreateMap<BusinessSpace, BusinessSpaceDto>().ReverseMap();
            CreateMap<CreateBusinessSpaceCommand, BusinessSpace>().ReverseMap();

            CreateMap<Estate,EstateDto>().ReverseMap();
            CreateMap<CreateEstateCommand,Estate>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserCommand, User>().ReverseMap();
        }
    }
}
