using Application.Abstractions;
using Application.Requests;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    internal class GetCountriesQuery(IDbContext dbContext) : IRequestHandler<GetCountriesRequest, CountriesListResponse>
    {
        public async Task<CountriesListResponse> Handle(GetCountriesRequest request, CancellationToken cancellationToken)
        {
            var models = await dbContext.Countries.ToArrayAsync(cancellationToken);

            var mapping = models.Select(item => new CountriesListItemResponse
            {
                Id = item.Id,
                Name = item.Name
            }).ToList();

            var response = new CountriesListResponse { Items = mapping };

            return response;
        }
    }
}
