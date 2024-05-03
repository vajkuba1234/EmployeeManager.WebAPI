using MediatR;

namespace Application.Requests
{
    public class DeleteEmployeeRequest : IRequest<Unit>
    {
        public int EmployeeId { get; set; }
    }
}
