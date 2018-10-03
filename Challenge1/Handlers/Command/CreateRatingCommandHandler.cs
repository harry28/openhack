using System;
using System.Net;
using System.Net.Http;
using Challenge1.Commands;
using AzureFromTheTrenches.Commanding.Abstractions;
using Challenge1.Models;
using Cosmonaut;
using System.Threading.Tasks;
using Challenge1.Exceptions;

namespace Challenge1.Handlers.Command
{
    public class CreateRatingCommandHandler: ICommandHandler<CreateRatingCommand,RatingModel>
    {
        static HttpClient _client = new HttpClient();
        private readonly ICosmosStore<RatingModel> _cosmosStore;

        public CreateRatingCommandHandler(ICosmosStore<RatingModel> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<RatingModel> ExecuteAsync(CreateRatingCommand command, RatingModel previousResult)
        {
            if (Convert.ToInt32(command.rating) < 1 || Convert.ToInt32(command.rating) > 5)
            {
                throw new RatingException($"Rating: {command.rating} should be between 1-5"); 
            }
            string productUrl = Environment.GetEnvironmentVariable("ProductUrl") + command.productId;
            var product = await GetProductAsync(productUrl);
            string userUrl = Environment.GetEnvironmentVariable("UserUrl") + command.userId;
            var user = await GetUserAsync(userUrl);

            if (product.StatusCode == HttpStatusCode.OK && user.StatusCode == HttpStatusCode.OK)
            {
                var rating = new RatingModel
                {
                    UserId = command.userId,
                    ProductId = command.productId,
                    LocationName = command.locationName,
                    Rating = command.rating,
                    UserNotes = command.userNotes,
                    Timestamp = DateTime.Now
                };
                return await _cosmosStore.AddAsync(rating);
            }
            return await FindErrorMessage(product, user);
        }

        /// <summary>
        /// Find ErrorMessage
        /// </summary>
        /// <param name="product"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<RatingModel> FindErrorMessage(HttpResponseMessage product, HttpResponseMessage user)
        {
            var errorMessage = string.Empty;
            if (product.StatusCode==HttpStatusCode.BadRequest)
            {
                errorMessage += await product.Content.ReadAsStringAsync();
            }

            if (user.StatusCode==HttpStatusCode.BadRequest)
            {
                errorMessage += await user.Content.ReadAsStringAsync();
            }

            throw new ProductNotFoundException(errorMessage);
        }

        /// <summary>
        /// Get Product Async
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetProductAsync(string uri)
        {
            _client = new HttpClient();
            return await _client.GetAsync(uri);
        }

        /// <summary>
        /// Get User Async
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetUserAsync(string uri)
        {
            _client = new HttpClient();
            return await _client.GetAsync(uri);
        }
    }
}
