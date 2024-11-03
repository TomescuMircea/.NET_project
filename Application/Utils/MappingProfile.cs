using Application.DTO;
using Domain.Entities;
using AutoMapper;
using Application.Use_Cases.Commands.ApartmentC;
using Application.Use_Cases.Commands.EstateC;
using Application.Use_Cases.Commands.BusinessSpaceC;
using Application.Use_Cases.Commands.UserC;
using Application.Use_Cases.Commands.HouseC;
using Application.Use_Cases.Commands.ContactC;
using Application.Use_Cases.Commands.CredentialC;
using Application.Use_Cases.Commands.FavoriteC;
using Application.Use_Cases.Commands.ImageC;
using Application.Use_Cases.Commands.ReportC;
using Application.Use_Cases.Commands.ReviewPropertyC;
using Application.Use_Cases.Commands.ReviewUserC;

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

            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<CreateContactCommand,  Contact>().ReverseMap();

            CreateMap<Credential, CredentialDto>().ReverseMap();
            CreateMap<CreateCredentialCommand, Credential>().ReverseMap();

            CreateMap<Estate,EstateDto>().ReverseMap();
            CreateMap<CreateEstateCommand,Estate>().ReverseMap();

            CreateMap<Favorite, FavoriteDto>().ReverseMap();
            CreateMap<CreateFavoriteCommand, Favorite>().ReverseMap();
            
            CreateMap<House, HouseDto>().ReverseMap();
            CreateMap<CreateHouseCommand, House>().ReverseMap();

            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<CreateImageCommand, Image>().ReverseMap();

            CreateMap<Report, ReportDto>().ReverseMap();
            CreateMap<CreateReportCommand, Report>().ReverseMap();

            CreateMap<ReviewProperty, ReviewPropertyDto>().ReverseMap();
            CreateMap<CreateReviewPropertyCommand, ReviewProperty>().ReverseMap();

            CreateMap<ReviewUser, ReviewUserDto>().ReverseMap();
            CreateMap<CreateReviewUserCommand, ReviewUser>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserCommand, User>().ReverseMap();
        }
    }
}
