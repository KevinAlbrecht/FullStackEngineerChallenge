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
    public class CreatePerformanceCommandHandler : AsyncRequestHandler<CreatePerformanceCommand>
    {
        private readonly IPerformanceRepository PerformanceRepository;

        public CreatePerformanceCommandHandler(IPerformanceRepository performanceRepository)
        {
            this.PerformanceRepository = performanceRepository;
        }

        protected override async Task Handle(CreatePerformanceCommand request, CancellationToken cancellationToken)
        {
            Performance performanceToCreate = new Performance()
            {
                Date = request.Date,
                Description = request.Description,
                EmployeeId = request.ConcernedId,
                Title = request.Title
            };

            await this.PerformanceRepository.CreatePerformanceAsync(performanceToCreate);
        }
    }

    public class CreatePerformanceCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid ConcernedId { get; set; }
    }
}
