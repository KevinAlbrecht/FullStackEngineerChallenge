using Paybaymax.Models;
using Paybaymax.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paybaymax.Web.Services.Interfaces
{
    public interface IPerformanceService
    {
        Task<IEnumerable<PerformanceDTO>> GetAssignedPerformancesToReviewAsync(Guid userEmployeeId);
        Task<IEnumerable<PerformanceWithAssignedDTO>> GetAllPerformancesAsync();
        Task<PerformanceDTO> GetPerformancesByIdAsync(Guid performanceId);
        Task WriteFeedbackForPerformanceAsync(WriteFeedbackViewModel feedback);
        Task CreatePerformanceAsync(WritePerformanceViewModel feedback);
        Task UpdatePerformanceAsync(WritePerformanceViewModel feedback, Guid id);
        Task AssignToPerformanceAsync(AssignToPerformanceViewModel model);
    }
}
