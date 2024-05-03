using Application.Responses;
using MediatR;

namespace Application.Requests
{
    public class GetCountriesRequest : IRequest<CountriesListResponse>
    {
    }
}
