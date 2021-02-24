using MediatR;
using Paybaymax.Data;
using Paybaymax.Domain.Repositories.Interfaces;
using Paybaymax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Queries
{
    public class GetUserAssignedPerformancesToReviewQueryHandler : IRequestHandler<GetUserAssignedPerformancesToReviewQuery, IEnumerable<PerformanceDTO>>
    {
        private readonly IPerformanceRepository PerformanceRepository;

        public GetUserAssignedPerformancesToReviewQueryHandler(IPerformanceRepository performanceRepository)
        {
            this.PerformanceRepository = performanceRepository;
        }
        public async Task<IEnumerable<PerformanceDTO>> Handle(GetUserAssignedPerformancesToReviewQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Performance> performance = await this.PerformanceRepository.GetUserAssignedPerformancesAsync(request.AssignedEmployeeId);
            return performance.Select(p => PerformanceDTO.ProjectionDelegate(p));
        }
    }

    public class GetUserAssignedPerformancesToReviewQuery : IRequest<IEnumerable<PerformanceDTO>>
    {
        public Guid AssignedEmployeeId { get; set; }
    }
}
