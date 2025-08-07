using AutoMapper;
using Meetify.Models;
using Meetify.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Meetify.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UserDTO>();
            CreateMap<CreateUserDTO, Users>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => false));
            CreateMap<Users, UpdateUserDTO>().ReverseMap();
        }
    }
}
