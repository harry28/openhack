using System.Collections.Generic;
using AzureFromTheTrenches.Commanding.Abstractions;
using Challenge1.Models;

namespace Challenge1.Queries
{
    public class GetRatingsQuery: ICommand<IEnumerable<RatingModel>>
    {
    }
}
