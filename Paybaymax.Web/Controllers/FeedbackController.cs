using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybaymax.Web.Models;
using Paybaymax.Web.Services.Interfaces;
using System.Threading.Tasks;

namespace Paybaymax.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IPerformanceService PerformanceService;
        public FeedbackController(IPerformanceService performanceService)
        {
            this.PerformanceService = performanceService;
        }


        [HttpPost()]
        public async Task<IActionResult> CreateFeedback(WriteFeedbackViewModel model)
        {
            await this.PerformanceService.WriteFeedbackForPerformanceAsync(model);
            return Ok();
        }
    }
}
