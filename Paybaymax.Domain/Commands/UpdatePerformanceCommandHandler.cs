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
    public class UpdatePerformanceCommandHandler : AsyncRequestHandler<UpdatePerformanceCommand>
    {
        private readonly IPerformanceRepository PerformanceRepository;

        public UpdatePerformanceCommandHandler(IPerformanceRepository performanceRepository)
        {
            this.PerformanceRepository = performanceRepository;
        }

        protected override async Task Handle(UpdatePerformanceCommand request, CancellationToken cancellationToken)
        {
            Performance performanceToCreate = new Performance()
            {
                Id = request.Id,
                Date = request.Date,
                Description = request.Description,
                EmployeeId = request.ConcernedId,
                Title = request.Title
            };

            await this.PerformanceRepository.UpdatePerformanceAsync(performanceToCreate);
        }
    }

    public class UpdatePerformanceCommand : CreatePerformanceCommand, IRequest
    {
        public Guid Id { get; set; }
    }
}
