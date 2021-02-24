using Microsoft.EntityFrameworkCore;
using Paybaymax.Data;
using Paybaymax.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Repositories
{
    public class FeedbackRepository : BaseRepository, IFeedbackRepository
    {
        public FeedbackRepository(PaybaymaxContext context) : base(context) { }

        public async Task<List<Review>> GetAllFeedbackForByPerformanceIdAsync(Guid performanceId)
        {
            return await this.Context.Reviews.Where(r => r.PerformanceId == performanceId).ToListAsync();
        }

        public async Task<Review> GetFeedbackById(Guid reviewId)
        {
            return await this.Context.Reviews.FindAsync(reviewId);
        }

        public async Task CreateFeedbackAsync(Review review)
        {
            var fae = await this.Context.PerformanceAssignedEmployees
                .FirstOrDefaultAsync(pae => pae.PerformanceId == review.PerformanceId && pae.EmployeeId == review.CreatorEmployeeId);

            if (fae.Done == true) return;
            fae.Done = true;
            this.Context.Reviews.Add(review);
            this.Context.PerformanceAssignedEmployees.Update(fae);
            await this.Context.SaveChangesAsync();
        }

        public async Task UpdateFeedback(Review review)
        {
            this.Context.Reviews.Update(review);
            await this.Context.SaveChangesAsync();
        }
    }
}
