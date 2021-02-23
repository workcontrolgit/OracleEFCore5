using Microsoft.AspNetCore.Mvc;
using OracleEFCore5.Application.Features.Employees.Queries.GetEmployees;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OracleEFCore5.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EmployeesController : BaseApiController
    {
        /// <summary>
        /// GET: api/controller
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]

        public async Task<IActionResult> Get([FromQuery] GetEmployeesQuery filter)
        {
            return Ok(await Mediator.Send(filter));
        }

    }
}
