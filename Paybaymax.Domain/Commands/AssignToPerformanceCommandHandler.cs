using MediatR;
using Paybaymax.Data;
using Paybaymax.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Commands
{
    public class AssignToPerformanceCommandHandler : AsyncRequestHandler<AssignToPerformanceCommand>
    {
        private readonly IPerformanceRepository PerformanceRepository;

        public AssignToPerformanceCommandHandler(IPerformanceRepository performanceRepository)
        {
            this.PerformanceRepository = performanceRepository;
        }

        protected override async Task Handle(AssignToPerformanceCommand request, CancellationToken cancellationToken)
        {
            await this.PerformanceRepository.AssignEmployeeToReviePerformanceAsync(request.EmployeeID, request.PerformanceId);
        }
    }

    public class AssignToPerformanceCommand : IRequest
    {
        public Guid EmployeeID { get; set; }
        public Guid PerformanceId { get; set; }
    }
}
