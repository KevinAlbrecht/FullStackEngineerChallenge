using Paybaymax.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Paybaymax.Models
{
    public class UserDTO
    {
        public string Email { get; set; }
        public int TypeId { get; set; }
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }

        public static Expression<Func<User, UserDTO>> Projection => (User user) => ProjectionDelegate(user);

        public static Func<User, UserDTO> ProjectionDelegate = queryResult => new UserDTO
        {
            Email = queryResult.Email,
            TypeId = queryResult.UserType,
            FirstName = queryResult.Employee.FirstName,
            EmployeeId = queryResult.EmployeeId
        };
    }
}
