using Paybaymax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paybaymax.Web.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public int TypeId { get; set; }
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }

        public static UserViewModel FromUserDTO(UserDTO dto)
        {
            return new UserViewModel()
            {
                Email = dto.Email,
                EmployeeId = dto.EmployeeId,
                FirstName = dto.FirstName,
                TypeId = dto.TypeId
            };
        }
    }
}
