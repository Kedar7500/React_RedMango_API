using AutoMapper;
using RedMango_API.Models.Domain;
using RedMango_API.Models.DTO;

namespace RedMango_API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MenuItem,MenuItemDto>().ReverseMap();
            CreateMap<MenuItem, AddMenuItemDto>().ReverseMap();
            CreateMap<MenuItem, UpdateMenuItemDto>().ReverseMap();
        }
    }
}
