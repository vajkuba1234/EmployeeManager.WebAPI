using Application.Abstractions;
using Application.Requests;
using Application.Responses;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
    internal class CreateEmployeeCommand(IDbContext dbContext) : IRequestHandler<CreateEmployeeRequest, EmployeeIdResponse>
    {
        public async Task<EmployeeIdResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var model = new Employee
            {
                BirthDate = request.BirthDate,
                Email = request.Email,
                Phone = request.Phone,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Gender = request.Gender,
                Street = request.Street,
                ZipCode = request.ZipCode,
                City = request.City,
                JoinedDate = request.JoinedDate,
                SuperiorId = request.SuperiorId,
                CountryId = request.CountryId
            };

            var jobCategories = await dbContext.JobCategories
                .Where(q => request.JobCategoryIds.Contains(q.Id))
                .ToListAsync(cancellationToken);
            model.JobCategories.AddRange(jobCategories);

            var salary = new Salary { Amount = request.Salary, From = request.JoinedDate };
            model.Salaries.Add(salary);

            var addResult = await dbContext.Employees.AddAsync(model, cancellationToken);

            _ = await dbContext.CommitAsync(cancellationToken);

            var response = new EmployeeIdResponse { EmployeeId = addResult.Entity.Id };

            return response;
        }
    }
}
