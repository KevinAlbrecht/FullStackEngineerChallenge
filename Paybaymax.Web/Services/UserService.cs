using MediatR;
using Paybaymax.Domain.Queries;
using Paybaymax.Models;
using Paybaymax.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paybaymax.Web.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IMediator m) : base(m) { }

        public async Task<IEnumerable<LightEmployeeDTO>> GetAllEmployeesAsync()
        {
            return await this.Mediator.Send(new GetAllEmployeesQuery());
        }

        public async Task<UserDTO> GetUserByCredentialsAsync(string email, string password)
        {
            var query = new GetUserByCredentialsQuery()
            {
                email = email,
                password = password
            };

            return await this.Mediator.Send(query);
        }
    }
}
