using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Challenge1.Queries;

namespace Challenge1.Handlers.Queries
{
    public class GetProductIdQueryHandler:ICommandHandler<GetProductIdQuery, string>
    {
        public Task<string> ExecuteAsync(GetProductIdQuery command, string previousResult)
        {
           return Task.Run(() => "The product name for your product id {"+command.Id+"} is Starfruit Explosion");
            
        }
    }
}
