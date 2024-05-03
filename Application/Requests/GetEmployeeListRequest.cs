using Application.Responses;
using MediatR;

namespace Application.Requests
{
    public class GetEmployeeListRequest : IRequest<EmployeeListResponse>
    {
    }
}
