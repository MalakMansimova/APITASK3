using Microsoft.AspNetCore.Identity;

namespace WEB_API.Entities.Auth
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }

    }
}
