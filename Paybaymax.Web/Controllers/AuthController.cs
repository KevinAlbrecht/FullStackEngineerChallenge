using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybaymax.Models;
using Paybaymax.Models.Exceptions;
using Paybaymax.Web.Models;
using Paybaymax.Web.Services;
using Paybaymax.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Paybaymax.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IAuthService AuthService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            this.UserService = userService;
            this.AuthService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel credentials, CancellationToken cancellationToken = default)
        {
            try
            {
                UserDTO user = await this.UserService.GetUserByCredentialsAsync(credentials.Email, credentials.Password);
                await this.AuthService.SignInAsync(user);
                return Ok(UserViewModel.FromUserDTO(user));
            }
            catch (UserNotFoundException e)
            {
                return NotFound();
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await this.AuthService.SignOutAsync();
            return Ok();
        }
    }
}
