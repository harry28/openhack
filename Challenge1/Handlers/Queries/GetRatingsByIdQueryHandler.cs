using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Challenge1.Models;
using Challenge1.Queries;
using Cosmonaut;

namespace Challenge1.Handlers.Queries
{
    public class GetRatingsByIdQueryHandler: ICommandHandler<GetRatingsByIdQuery, RatingModel>
    {

        private readonly ICosmosStore<RatingModel> _cosmosStore;

        public GetRatingsByIdQueryHandler(ICosmosStore<RatingModel> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public Task<RatingModel> ExecuteAsync(GetRatingsByIdQuery command, RatingModel previousResult)
        {
            return _cosmosStore.FindAsync(command.Id);
        }
    }
}
