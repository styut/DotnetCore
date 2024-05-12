using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Taskking.Interfaces;
using Taskking.Models;
using Taskking.Services;

namespace Taskking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase

    {
        readonly IUserService UserService;
        // readonly TokenService TokenService;
        public LoginController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        [HttpPost]
        public IActionResult Login(User newUser)
        {
            var user = UserService.GetAll().FirstOrDefault(x => x.Password == newUser.Password&&x.Name == newUser.Name);    
            if (user == null)
            {
                return Unauthorized();
            }
            var claims = new List<Claim>
            {
                new Claim("type", "User"),
                new Claim("Id",newUser.Id.ToString()),
                new Claim("Name",newUser.Name),
            };

            if (user.Type == "Admin")
            {
            claims = new List<Claim>
            {
                new Claim("type", "Admin"),
                new Claim("Id",newUser.Id.ToString()),
                new Claim("Name",newUser.Name),
            };
            }
             var token = TokenService.GetToken(claims);

            return new OkObjectResult(TokenService.WriteToken(token));
        }

        }
    }

