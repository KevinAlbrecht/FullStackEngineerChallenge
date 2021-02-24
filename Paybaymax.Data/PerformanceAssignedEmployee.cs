using System;
using System.Collections.Generic;

#nullable disable

namespace Paybaymax.Data
{
    public partial class PerformanceAssignedEmployee
    {
        public int Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid PerformanceId { get; set; }
        public bool Done { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Performance Performance { get; set; }
    }
}
