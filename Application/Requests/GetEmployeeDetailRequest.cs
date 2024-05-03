using Application.Responses;
using MediatR;

namespace Application.Requests
{
    public class GetEmployeeDetailRequest : IRequest<EmployeeDetailResponse>
    {
        public int EmployeeId { get; set; }
    }
}
