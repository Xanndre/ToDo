using AutoMapper;
using ToDo.Core.DTOs;
using ToDo.Data.Entities;

namespace ToDo.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, LoginDTO>();
            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();
                
        }
    }
}
