using Application.Responses;
using Domain.Enums;
using MediatR;

namespace Application.Requests
{
    public class UpdateEmployeeRequest : IRequest<EmployeeDetailResponse>
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        public DateOnly? ExitedDate { get; set; }

        public int? SuperiorId { get; set; }
        public List<int>? SubordinateIds { get; set; }

        public int CountryId { get; set; }
        public List<int> SalaryIds { get; set; } = [];
        public List<int> JobCategoryIds { get; set; } = [];
    }
}
