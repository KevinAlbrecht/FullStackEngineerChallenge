using MediatR;
using Paybaymax.Domain.Commands;
using Paybaymax.Domain.Queries;
using Paybaymax.Models;
using Paybaymax.Web.Models;
using Paybaymax.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paybaymax.Web.Services
{
    public class PerformanceService : BaseService, IPerformanceService
    {
        public PerformanceService(IMediator m) : base(m) { }

        public async Task<IEnumerable<PerformanceDTO>> GetAssignedPerformancesToReviewAsync(Guid userEmployeeId)
        {
            var query = new GetUserAssignedPerformancesToReviewQuery()
            {
                AssignedEmployeeId = userEmployeeId
            };
            return await this.Mediator.Send(query);
        }

        public async Task<PerformanceDTO> GetPerformancesByIdAsync(Guid performanceId)
        {
            var query = new GetPerformanceByIdQuery()
            {
                PerformanceId = performanceId
            };
            return await this.Mediator.Send(query);
        }

        public async Task WriteFeedbackForPerformanceAsync(WriteFeedbackViewModel feedback)
        {
            var command = new CreateFeedbackForPerformanceCommand()
            {
                Comment = feedback.Comment,
                CooperationRating = Convert.ToByte(feedback.CooperationRating),
                InitiativeRating = Convert.ToByte(feedback.InitiativeRating),
                QualityRating = Convert.ToByte(feedback.QualityRating),
                CreatorEmployeeId = feedback.CreatorEmployeeId,
                PerformanceId = feedback.PerformanceId,
            };
            await this.Mediator.Send(command);
        }

        public async Task CreatePerformanceAsync(WritePerformanceViewModel performance)
        {
            var command = new CreatePerformanceCommand()
            {
                ConcernedId = performance.Concerned,
                Date = performance.Date,
                Description = performance.Description,
                Title = performance.Title
            };

            await this.Mediator.Send(command);
        }

        public async Task UpdatePerformanceAsync(WritePerformanceViewModel performance, Guid id)
        {
            var command = new UpdatePerformanceCommand()
            {
                Id = id,
                ConcernedId = performance.Concerned,
                Date = performance.Date,
                Description = performance.Description,
                Title = performance.Title
            };

            await this.Mediator.Send(command);
        }

        public async Task<IEnumerable<PerformanceWithAssignedDTO>> GetAllPerformancesAsync()
        {
            return await this.Mediator.Send(new GetAllPerformancesQuery());
        }

        public async Task AssignToPerformanceAsync(AssignToPerformanceViewModel model)
        {
            await this.Mediator.Send(new AssignToPerformanceCommand()
            {
                PerformanceId = model.PerformanceId,
                EmployeeID = model.EmployeeId
            });
        }
    }
}
