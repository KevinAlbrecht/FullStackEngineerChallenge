using Microsoft.EntityFrameworkCore;
using Paybaymax.Data;
using Paybaymax.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Repositories
{
    public class PerformanceRepository : BaseRepository, IPerformanceRepository
    {
        public PerformanceRepository(PaybaymaxContext context) : base(context) { }

        public async Task<Performance> GetPerformanceByIdAsync(Guid performanceId)
        {
            return await this.Context.Performances.Include(p => p.Employee).FirstOrDefaultAsync(p => p.Id == performanceId);
        }

        public async Task<List<Performance>> GetUserAssignedPerformancesAsync(Guid employeeId)
        {
            return await this.Context.PerformanceAssignedEmployees
                .Where(pae => pae.EmployeeId == employeeId && pae.Done == false)
                .Include(pae => pae.Performance)
                .ThenInclude(p => p.Employee)
                .Select(pae => pae.Performance)
                .ToListAsync();
        }

        public async Task AssignEmployeeToReviePerformanceAsync(Guid employeeId, Guid performanceId)
        {
            PerformanceAssignedEmployee Pae = new PerformanceAssignedEmployee()
            {
                EmployeeId = employeeId,
                PerformanceId = performanceId
            };

            await this.Context.PerformanceAssignedEmployees.AddAsync(Pae);
            await this.Context.SaveChangesAsync();
        }

        public async Task<List<Performance>> GetAllPerformances()
        {
            return await this.Context.Performances
                .Include(p => p.Employee)
                .Include(p => p.PerformanceAssignedEmployees).ThenInclude(pae => pae.Employee)
                .ToListAsync();
        }

        public async Task CreatePerformanceAsync(Performance performance)
        {
            this.Context.Performances.Add(performance);
            await this.Context.SaveChangesAsync();
        }

        public async Task UpdatePerformanceAsync(Performance performance)
        {
            this.Context.Performances.Update(performance);
            await this.Context.SaveChangesAsync();
        }
    }
}
