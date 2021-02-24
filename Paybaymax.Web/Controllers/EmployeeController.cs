using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybaymax.Web.Models;
using Paybaymax.Web.Services.Interfaces;
using System.Threading.Tasks;

namespace Paybaymax.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly  IUserService UserService;
        public EmployeeController(IUserService userService)
        {
            this.UserService = userService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await this.UserService.GetAllEmployeesAsync();
            return Ok(employees);
        }
    }
}
