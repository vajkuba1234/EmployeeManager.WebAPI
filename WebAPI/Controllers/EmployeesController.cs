using Application.Requests;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<EmployeeListResponse>> GetAllEmployees(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetEmployeeListRequest(), cancellationToken);

            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDetailResponse>> GetEmployeeById(int id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetEmployeeDetailRequest { EmployeeId = id }, cancellationToken);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeIdResponse>> CreateEmployee(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            return result;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeDetailResponse>> UpdateEmployee(int id, UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            request.EmployeeId = id;

            var result = await mediator.Send(request, cancellationToken);

            return result;
        }

        [HttpDelete("{id:int}")]
        public async Task<Unit> DeleteEmployee(int id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteEmployeeRequest { EmployeeId = id }, cancellationToken);

            return result;
        }
    }
}
