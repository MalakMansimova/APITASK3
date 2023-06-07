using AutoMapper;
using WEB_API.Entities.Auth;
using WEB_API.Entities.Dtos.Auth;

namespace WEB_API.Profiles
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<LoginDto, AppUser>();
        }
    }
}
