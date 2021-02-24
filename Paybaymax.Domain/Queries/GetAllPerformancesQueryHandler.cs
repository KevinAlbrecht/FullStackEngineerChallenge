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
    public class GetAllPerformancesQueryHandler : IRequestHandler<GetAllPerformancesQuery, IEnumerable<PerformanceWithAssignedDTO>>
    {
        private readonly IPerformanceRepository PerformanceRepository;

        public GetAllPerformancesQueryHandler(IPerformanceRepository performanceRepository)
        {
            this.PerformanceRepository = performanceRepository;
        }
        public async Task<IEnumerable<PerformanceWithAssignedDTO>> Handle(GetAllPerformancesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Performance> performance = await this.PerformanceRepository.GetAllPerformances();
            return performance.Select(p => PerformanceWithAssignedDTO.ProjectionDelegate(p));
        }
    }

    public class GetAllPerformancesQuery : IRequest<IEnumerable<PerformanceWithAssignedDTO>> { }
}
