using Paybaymax.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Paybaymax.Models
{
    public class LightEmployeeDTO
    {
        public Guid EmployeeId { get; set; }
        public string FullName { get; set; }

        public static Expression<Func<Employee, LightEmployeeDTO>> Projection => (Employee user) => ProjectionDelegate(user);

        public static Func<Employee, LightEmployeeDTO> ProjectionDelegate = queryResult => new LightEmployeeDTO
        {
            EmployeeId = queryResult.Id,
            FullName = String.Concat(queryResult.LastName, " ", queryResult.FirstName)
        };
    }
}
