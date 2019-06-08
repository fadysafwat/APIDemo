using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APIDemo.DataLayer.Models;
using APIDemo.DomainLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthontecationController : ControllerBase
    {
        private IAuthontecationService _AuontecatedUser;
        private IConfiguration _Configuration;
        public AuthontecationController(IAuthontecationService AuontecatedUser,IConfiguration Configuration)
        {
            _AuontecatedUser = AuontecatedUser;
            _Configuration = Configuration;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Regist([FromBody] AuthontecatedUserModel user)
        {
            
            if(await _AuontecatedUser.IsExistName(user.Name.ToLower()))
            return BadRequest("Exists Name");
            await _AuontecatedUser.Registration(user);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthontecatedUserModel u)
        {
            AuthontecatedUserModel user = await _AuontecatedUser.Login(u.Name.ToLower(),u.Password);
            if(user == null) return Unauthorized(); 
            var claims = new []{
                new Claim(ClaimTypes.NameIdentifier,user.ID.ToString()),
                new Claim(ClaimTypes.Name,user.Name)
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration.GetSection("AppSetting:Token").Value));

            var creds = new SigningCredentials(Key,SecurityAlgorithms.HmacSha512);

            var TokenDescriptor  = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var TokenHandler = new JwtSecurityTokenHandler();

            var Token = TokenHandler.CreateToken(TokenDescriptor);
            
            return Ok(new{token =TokenHandler.WriteToken(Token)});
        }      
   
    }
}