using Application.Abstractions;
using Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
    internal class DeleteEmployeeCommand(IDbContext dbContext) : IRequestHandler<DeleteEmployeeRequest, Unit>
    {
        async Task<Unit> IRequestHandler<DeleteEmployeeRequest, Unit>.Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employeeId = request.EmployeeId;

            var employee = await dbContext.Employees
                .Where(q => q.Id == employeeId)
                .SingleAsync(cancellationToken);

            _ = dbContext.Employees.Remove(employee);

            _ = await dbContext.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
