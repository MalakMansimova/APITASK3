using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEB_API.Entities.Auth;
using WEB_API.Entities.Dtos.Auth;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly TokenOption _tokenOption;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _configuration = configuration;
            _tokenOption = _configuration.GetSection("TokenOptions").Get<TokenOption>();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            AppUser appUser = _mapper.Map<AppUser>(registerDto);
            var createUserResult = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!createUserResult.Succeeded)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    errors = createUserResult.Errors
                });
            }
            await _roleManager.CreateAsync(new IdentityRole { Name = "user" });
            var addRoleResult = await _userManager.AddToRoleAsync(appUser, "user");
            if (!addRoleResult.Succeeded)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    errors = addRoleResult.Errors
                });
            }
            return Ok(new
            {
                message = "User Created"
            });
        }

        
        
    }
}
