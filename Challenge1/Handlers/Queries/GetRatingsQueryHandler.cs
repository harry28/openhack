using System.Collections.Generic;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Challenge1.Models;
using Challenge1.Queries;
using Cosmonaut;
using Cosmonaut.Extensions;

namespace Challenge1.Handlers.Queries
{
    public class GetRatingsQueryHandler: ICommandHandler<GetRatingsQuery, IEnumerable<RatingModel>>
    {
        private readonly ICosmosStore<RatingModel> _cosmosStore;

        public GetRatingsQueryHandler(ICosmosStore<RatingModel> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<IEnumerable<RatingModel>> ExecuteAsync(GetRatingsQuery command, IEnumerable<RatingModel> previousResult)
        {
            return await _cosmosStore
                .Query()
                .ToListAsync();
        }
    }
}
