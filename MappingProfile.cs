using AutoMapper;
using Meetify.Models;
using Meetify.DTOs.Users;

namespace Meetify.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // READ (Entity -> DTO returned by API)
            CreateMap<Users, UsersDTO>();

            // CREATE (DTO -> Entity)
            CreateMap<CreateUsersDTO, Users>()
                // Hash the password OUTSIDE the mapper (service/repo). Do NOT map it here.
                .ForMember(d => d.PasswordHash, opt => opt.Ignore())
                .ForMember(d => d.IsActive, opt => opt.MapFrom(_ => true))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(d => d.IsDeleted, opt => opt.MapFrom(_ => false))
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Phone));

            // UPDATE (DTO -> Entity)
            CreateMap<UpdateUsersDTO, Users>()
                // Don’t overwrite the stored hash via mapping
                .ForMember(d => d.PasswordHash, opt => opt.Ignore());
        }
    }
}
