using Application.Responses;
using MediatR;

namespace Application.Requests
{
    public class CreateCountryRequest : IRequest<CountriesListItemResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
