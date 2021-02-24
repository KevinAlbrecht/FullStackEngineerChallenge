using System;
using System.Collections.Generic;

#nullable disable

namespace Paybaymax.Data
{
    public partial class Performance
    {
        public Performance()
        {
            PerformanceAssignedEmployees = new HashSet<PerformanceAssignedEmployee>();
            Reviews = new HashSet<Review>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<PerformanceAssignedEmployee> PerformanceAssignedEmployees { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
