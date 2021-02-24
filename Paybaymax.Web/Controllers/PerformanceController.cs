using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybaymax.Web.Models;
using Paybaymax.Web.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Paybaymax.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly IAuthService AuthService;
        private readonly IPerformanceService PerformanceService;

        public PerformanceController(IAuthService authService, IPerformanceService performanceService)
        {
            this.AuthService = authService;
            this.PerformanceService = performanceService;
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpGet()]
        public async Task<IActionResult> GetAllPerformances()
        {
            var performances = await this.PerformanceService.GetAllPerformancesAsync();
            return Ok(performances);
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPost()]
        public async Task<IActionResult> CreatePerformance(WritePerformanceViewModel model)
        {
            await this.PerformanceService.CreatePerformanceAsync(model);
            return Ok();
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerformance(WritePerformanceViewModel model, Guid id)
        {
            await this.PerformanceService.UpdatePerformanceAsync(model, id);
            return Ok();
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpPost("assign")]
        public async Task<IActionResult> AssignToPerformance(AssignToPerformanceViewModel model)
        {
            await this.PerformanceService.AssignToPerformanceAsync(model);
            return Ok();
        }

        [HttpGet("assigned")]
        public async Task<IActionResult> GetAssignedPerformancesToReview()
        {
            var moi = this.ControllerContext.HttpContext.User;

            var currentUserEmployeeId = this.AuthService.GetCurrentUserEmployeeId();
            var performances = await this.PerformanceService.GetAssignedPerformancesToReviewAsync(currentUserEmployeeId);
            return Ok(performances);
        }
    }
}
