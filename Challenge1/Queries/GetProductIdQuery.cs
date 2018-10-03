using AzureFromTheTrenches.Commanding.Abstractions;

namespace Challenge1.Queries
{
    public class GetProductIdQuery: ICommand<string>
    {
        public string Id { get; set; }
    }
}
