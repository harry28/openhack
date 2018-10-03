using AzureFromTheTrenches.Commanding.Abstractions;
using Challenge1.Models;

namespace Challenge1.Queries
{
    public class GetRatingsByIdQuery: ICommand<RatingModel>
    {
        public string Id { get; set; }
    }
}
