using Paybaymax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paybaymax.Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task SignInAsync(UserDTO user);
        Task SignOutAsync();
        string GetCurrentUserEmail();
        Guid GetCurrentUserEmployeeId();
        UserType GetCurrentUserType();
    }
}
