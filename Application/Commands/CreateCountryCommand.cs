using Application.Abstractions;
using Application.Requests;
using Application.Responses;
using Domain.Models;
using MediatR;

namespace Application.Commands
{
    internal class CreateCountryCommand(IDbContext dbContext) : IRequestHandler<CreateCountryRequest, CountriesListItemResponse>
    {
        public async Task<CountriesListItemResponse> Handle(CreateCountryRequest request, CancellationToken cancellationToken)
        {
            var model = new Country
            {
                Id = request.Id,
                Name = request.Name
            };

            _ = await dbContext.Countries.AddAsync(model, cancellationToken);

            _ = await dbContext.CommitAsync(cancellationToken);

            var response = new CountriesListItemResponse
            {
                Id = model.Id,
                Name = model.Name,
            };

            return response;
        }
    }
}
