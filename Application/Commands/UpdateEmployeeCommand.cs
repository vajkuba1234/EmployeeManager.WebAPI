using Application.Abstractions;
using Application.Requests;
using Application.Responses;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
    internal class UpdateEmployeeCommand(IDbContext dbContext) : IRequestHandler<UpdateEmployeeRequest, EmployeeDetailResponse>
    {
        public async Task<EmployeeDetailResponse> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var model = await dbContext.Employees
                .Where(q => q.Id == request.EmployeeId)
                .SingleAsync(cancellationToken);

            model.FirstName = request.FirstName;
            model.MiddleName = request.MiddleName;
            model.LastName = request.LastName;
            model.Gender = request.Gender;
            model.BirthDate = request.BirthDate;
            model.Email = request.Email;
            model.Phone = request.Phone;
            model.City = request.City;
            model.Street = request.Street;
            model.ZipCode = request.ZipCode;
            model.ExitedDate = request.ExitedDate;
            model.SuperiorId = request.SuperiorId;

            var newJobCategories = request.JobCategoryIds.Select(x => new JobCategory { Id = x });
            model.JobCategories.Clear();
            model.JobCategories.AddRange(newJobCategories);

            _ = dbContext.CommitAsync();

            var response = new EmployeeDetailResponse();

            return response;
        }
    }
}
