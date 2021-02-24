using Paybaymax.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Review> GetFeedbackById(Guid reviewId);
        Task CreateFeedbackAsync(Review review);
        Task<List<Review>> GetAllFeedbackForByPerformanceIdAsync(Guid performanceId);
        Task UpdateFeedback(Review review);
    }
}
