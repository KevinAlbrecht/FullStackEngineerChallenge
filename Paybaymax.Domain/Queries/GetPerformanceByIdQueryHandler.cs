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

    public class GetPerformanceByIdQueryHandler : IRequestHandler<GetPerformanceByIdQuery, PerformanceDTO>
    {
        private readonly IPerformanceRepository PerformanceRepository;

        public GetPerformanceByIdQueryHandler(IPerformanceRepository performanceRepository)
        {
            this.PerformanceRepository = performanceRepository;
        }
        public async Task<PerformanceDTO> Handle(GetPerformanceByIdQuery request, CancellationToken cancellationToken)
        {
            Performance performance = await this.PerformanceRepository.GetPerformanceByIdAsync(request.PerformanceId);
            return PerformanceDTO.ProjectionDelegate(performance);
        }
    }

    public class GetPerformanceByIdQuery : IRequest<PerformanceDTO>
    {
        public Guid PerformanceId { get; set; }
    }
}
