using AutoMapper;
using WEB_API.Entities;
using WEB_API.Entities.Dtos.Brand;

namespace WEB_API.Profiles
{
    public class BrandProfile : Profile
    {
       public BrandProfile()
            {

            CreateMap <Brand, GetBrandDto>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<UpdateBrandDto, Brand>();

            }
    }
}
