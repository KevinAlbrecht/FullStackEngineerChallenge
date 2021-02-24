using System;
using System.Collections.Generic;

#nullable disable

namespace Paybaymax.Data
{
    public partial class Employee
    {
        public Employee()
        {
            PerformanceAssignedEmployees = new HashSet<PerformanceAssignedEmployee>();
            Performances = new HashSet<Performance>();
            Reviews = new HashSet<Review>();
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }

        public virtual ICollection<PerformanceAssignedEmployee> PerformanceAssignedEmployees { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
