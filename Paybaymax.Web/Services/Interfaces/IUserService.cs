using Paybaymax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paybaymax.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByCredentialsAsync(string email, string password);
        Task<IEnumerable<LightEmployeeDTO>> GetAllEmployeesAsync();
    }
}
