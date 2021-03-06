using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForDetailedDto>()
                .ForMember(dest => dest.PhotoURL, 
                    opt => opt.MapFrom(sourceMember=>sourceMember.Photos.FirstOrDefault(el => el.IsMain==true).Url))
                .ForMember(destinationMember=> destinationMember.Age, 
                    opt=> opt.MapFrom(sourceMember=>sourceMember.DateOfBirth.CalculateAge()));
            CreateMap<User,UserForListsDto>()
                .ForMember(dest => dest.PhotoURL, 
                    opt => opt.MapFrom(sourceMember=>sourceMember.Photos.FirstOrDefault(el => el.IsMain==true).Url))
                .ForMember(destinationMember=> destinationMember.Age, 
                    opt=> opt.MapFrom(sourceMember=>sourceMember.DateOfBirth.CalculateAge()));
            CreateMap<Photo,PhotoForDetailedDto>();
        }
        
    }
}