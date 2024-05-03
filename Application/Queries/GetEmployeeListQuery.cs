using Application.Abstractions;
using Application.Requests;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    internal class GetEmployeeListQuery(IDbContext dbContext) : IRequestHandler<GetEmployeeListRequest, EmployeeListResponse>
    {
        public async Task<EmployeeListResponse> Handle(GetEmployeeListRequest request, CancellationToken cancellationToken)
        {
            var data = await dbContext.Employees
                .Select(item => new EmployeeListItemResponse
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Id = item.Id,
                    MiddleName = item.MiddleName
                })
                .ToListAsync(cancellationToken);

            var result = data
                .OrderBy(o => o.LastName)
                .ThenBy(o => o.FirstName)
                .ToList();

            var response = new EmployeeListResponse { Items = result };

            return response;
        }
    }
}
