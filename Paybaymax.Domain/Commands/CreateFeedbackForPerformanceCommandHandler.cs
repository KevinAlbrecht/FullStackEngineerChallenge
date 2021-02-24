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
    public class CreateFeedbackForPerformanceCommandHandler : AsyncRequestHandler<CreateFeedbackForPerformanceCommand>
    {
        private readonly IFeedbackRepository ReviewRepository;

        public CreateFeedbackForPerformanceCommandHandler(IFeedbackRepository reviewRepository)
        {
            this.ReviewRepository = reviewRepository;
        }

        protected override async Task Handle(CreateFeedbackForPerformanceCommand request, CancellationToken cancellationToken)
        {
            Review reviewToCreate = new Review()
            {
                GlobalRating = request.GlobalRating,
                Comment = request.Comment,
                CooperationRating = request.CooperationRating,
                InitiativeRating = request.InitiativeRating,
                PerformanceId = request.PerformanceId,
                QualityRating = request.QualityRating,
                CreatorEmployeeId = request.CreatorEmployeeId,
                CreatedDate = DateTime.Now
            };

            await this.ReviewRepository.CreateFeedbackAsync(reviewToCreate);
        }
    }

    public class CreateFeedbackForPerformanceCommand : IRequest
    {
        public byte GlobalRating
        {
            get
            {
                return Convert.ToByte((this.CooperationRating + this.InitiativeRating + this.QualityRating) / 3);
            }
        }
        public byte QualityRating { get; set; }
        public byte InitiativeRating { get; set; }
        public byte CooperationRating { get; set; }
        public string Comment { get; set; }
        public Guid PerformanceId { get; set; }
        public Guid CreatorEmployeeId { get; set; }
    }
}
