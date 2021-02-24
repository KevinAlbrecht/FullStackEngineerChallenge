using System;
using System.Collections.Generic;

#nullable disable

namespace Paybaymax.Data
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte UserType { get; set; }
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
