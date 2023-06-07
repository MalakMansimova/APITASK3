using AutoMapper;
using WEB_API.Entities.Dtos.Colors;
using WEB_API.Entities;

namespace WEB_API.Profiles
{
    public class ColorProfile : Profile
    {
        protected ColorProfile()
        {
            CreateMap<Color, GetColorDto>();
            CreateMap<CreateColorDto, Color>();
            CreateMap<UpdateColorDto, Color>();
        }
    }
}
