using Application.Requests;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CountriesListResponse>> GetCountries(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetCountriesRequest(), cancellationToken);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<CountriesListItemResponse>> CreateCountry(CreateCountryRequest request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);

            return result;
        }
    }
}
