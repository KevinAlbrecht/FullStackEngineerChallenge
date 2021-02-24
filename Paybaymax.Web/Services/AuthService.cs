using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Paybaymax.Models;
using Paybaymax.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Paybaymax.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor ContextAccessor;
        //private readonly string USER_IDENTITY_COOKIE = "uic";
        private readonly string EMPLOYEE_ID_CLAIM_TYPE = "EmployeeId";
        private readonly string EMPLOYEE_USERTYPE_CLAIM_TYPE = "UserType";
        public AuthService(IHttpContextAccessor contextAccessor)
        {
            this.ContextAccessor = contextAccessor;
        }

        public string GetCurrentUserEmail()
        {
            this.IsAuthenticated();
            return this.ContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
        }

        public Guid GetCurrentUserEmployeeId()
        {
            this.IsAuthenticated();
            return Guid.Parse(this.ContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == EMPLOYEE_ID_CLAIM_TYPE).Value);
        }

        public UserType GetCurrentUserType()
        {
            this.IsAuthenticated();
            string claim = this.ContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == EMPLOYEE_USERTYPE_CLAIM_TYPE).Value;
            int numericValue = int.Parse(claim);
            return (UserType)numericValue;
        }

        public async Task SignInAsync(UserDTO user)
        {
            const string scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(EMPLOYEE_ID_CLAIM_TYPE, user.EmployeeId.ToString()),
                new Claim(EMPLOYEE_USERTYPE_CLAIM_TYPE,user.TypeId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, scheme);
            var authProperties = new AuthenticationProperties();

            await this.ContextAccessor.HttpContext.SignInAsync(scheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        public async Task SignOutAsync()
        {
            await this.ContextAccessor.HttpContext.SignOutAsync();
        }

        private void IsAuthenticated()
        {
            if (!this.ContextAccessor.HttpContext.User.Identity.IsAuthenticated) throw new NotImplementedException();
        }
    }
}
