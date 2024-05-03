using Application.Responses;
using MediatR;

namespace Application.Requests
{
    public class GetEmployeeByIdRequest : IRequest<EmployeeDetailResponse>
    {
        public int Id { get; set; }
    }
}
