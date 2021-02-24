using Paybaymax.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Paybaymax.Models
{
    public class PerformanceDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public LightEmployeeDTO Concerned { get; set; }

        public static Expression<Func<Performance, PerformanceDTO>> Projection => (Performance user) => ProjectionDelegate(user);

        public static Func<Performance, PerformanceDTO> ProjectionDelegate = queryResult => new PerformanceDTO
        {
            Date = queryResult.Date,
            Description = queryResult.Description,
            Id = queryResult.Id,
            Title = queryResult.Title,
            Concerned = LightEmployeeDTO.ProjectionDelegate(queryResult.Employee)
        };
    }
}
