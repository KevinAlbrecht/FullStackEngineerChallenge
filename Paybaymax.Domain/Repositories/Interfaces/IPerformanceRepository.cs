using Paybaymax.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Repositories.Interfaces
{
    public interface IPerformanceRepository
    {
        Task<Performance> GetPerformanceByIdAsync(Guid performanceId);
        Task<List<Performance>> GetAllPerformances();
        Task<List<Performance>> GetUserAssignedPerformancesAsync(Guid employeeId);
        Task CreatePerformanceAsync(Performance performance);
        Task UpdatePerformanceAsync(Performance performance);
        Task AssignEmployeeToReviePerformanceAsync(Guid employeeId, Guid performanceId);
    }
}
