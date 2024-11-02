using Application.DTO;
using Domain.Entities;
using AutoMapper;

namespace Application.Utils
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Estate,EstateDto>().ReverseMap();
            //CreateMap<CreateEstateCommand,Estate>().ReverseMap();
            //CreateMap<UpdateEstateCommand,Estate>().ReverseMap();
        }
    }
}
