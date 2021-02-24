using Paybaymax.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        Task<List<Employee>> GetAllEmployeesAsync();
    }
}
