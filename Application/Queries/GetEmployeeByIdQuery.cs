using Application.Abstractions;
using Application.Requests;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    internal class GetEmployeeByIdQuery(IDbContext dbContext) : IRequestHandler<GetEmployeeByIdRequest, EmployeeDetailResponse>
    {
        public async Task<EmployeeDetailResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var model = await dbContext.Employees
                .Where(q => q.Id == request.Id)
                .Include(j => j.Country)
                .Include(j => j.JobCategories)
                .Include(j => j.Salaries)
                .Include(j => j.Subordinates)
                .Include(j => j.Superior)
                .SingleAsync(cancellationToken);

            var country = new ViewModels.CountryViewModel
            {
                Id = model.Country.Id,
                Name = model.Country.Name
            };

            var jobCategories = model.JobCategories
                .Select(x => new ViewModels.JobCategoryViewModel
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .ToList();

            ViewModels.EmployeeViewModel? superior = null;

            if (model.SuperiorId.HasValue)
            {
                superior = new ViewModels.EmployeeViewModel
                {
                    Id = model.SuperiorId.Value,
                    FirstName = model.Superior.FirstName,
                    LastName = model.Superior.LastName,
                    MiddleName = model.Superior.MiddleName
                };
            }

            List<ViewModels.EmployeeViewModel>? subordinates = null;

            if (model.Subordinates.Any())
            {
                subordinates = model.Subordinates
                    .Select(x => new ViewModels.EmployeeViewModel
                    {
                        FirstName = x.FirstName,
                        Id = x.Id,
                        LastName= x.LastName,
                        MiddleName = x.MiddleName
                    })
                    .ToList();
            }

            var response = new EmployeeDetailResponse
            {
                BirthDate = model.BirthDate,
                Country = country,
                Email = model.Email,
                ExitedDate = model.ExitedDate,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Id = model.Id,
                JobCategories = jobCategories,
                JoinedDate = model.JoinedDate,
                MiddleName = model.MiddleName,
                Phone = model.Phone,
                Subordinates = subordinates,
                Superior = superior
            };

            return response;
        }
    }
}
