using Microsoft.EntityFrameworkCore;
using Paybaymax.Data;
using Paybaymax.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(PaybaymaxContext context) : base(context) { }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await this.Context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            return await this.Context.Employees.FindAsync(employeeId);
        }
    }
}
