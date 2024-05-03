using Application.Abstractions;
using Application.Requests;
using Application.Responses;
using Domain.Models;
using MediatR;

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
                JoinedDate = request.JoinedDate
            };

            if (request.SuperiorId.HasValue)
            {
                var superior = new Employee { Id = request.SuperiorId.Value };

                model.Superior = superior;
            }

            var country = new Country { Id = request.CountryId };
            var salary = new Salary { Amount = request.Salary, From = request.JoinedDate };
            var jobCategories = request.JobCategoryIds
                .Select(id => new JobCategory { Id = id})
                .ToList();

            model.Country = country;
            model.Salaries.Add(salary);
            model.JobCategories.AddRange(jobCategories);

            var addResult = await dbContext.Employees.AddAsync(model, cancellationToken);

            _ = await dbContext.CommitAsync(cancellationToken);

            var response = new EmployeeIdResponse { EmployeeId = addResult.Entity.Id };

            return response;
        }
    }
}
