using Paybaymax.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Paybaymax.Models
{
    public class PerformanceWithAssignedDTO : PerformanceDTO
    {
        public IEnumerable<LightEmployeeDTO> Assigned { get; set; }

        public static new Expression<Func<Performance, PerformanceWithAssignedDTO>> Projection => (Performance user) => ProjectionDelegate(user);


        public static new Func<Performance, PerformanceWithAssignedDTO> ProjectionDelegate = queryResult => new PerformanceWithAssignedDTO
        {
            Date = queryResult.Date,
            Description = queryResult.Description,
            Id = queryResult.Id,
            Title = queryResult.Title,
            Concerned = LightEmployeeDTO.ProjectionDelegate(queryResult.Employee),
            Assigned = queryResult.PerformanceAssignedEmployees.Select(PAE => LightEmployeeDTO.ProjectionDelegate(PAE.Employee))
        };
    }
}
