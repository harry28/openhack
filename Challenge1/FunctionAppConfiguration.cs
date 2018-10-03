using System.Net.Http;
using Challenge1.Commands;
using Challenge1.CosmosDb;
using Challenge1.Handlers.Command;
using Challenge1.Handlers.Queries;
using Challenge1.Models;
using Challenge1.Queries;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Challenge1
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        /// <summary>
        /// Injecting IFunctionHostBuilder
        /// </summary>
        /// <param name="builder"></param>
        public void Build(IFunctionHostBuilder builder)
        {
            JsonConvert.DefaultSettings = () =>
            {
                return new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
            };
            //Using IFunctionBuilder that is passed into our configuration class exposes a fluent API that allows us to define our functions
            builder
                //This is the first step and is used to call the setup method which allows us to 
                //configure our dependencies for dependecny injection using the provided service collection
                //and register our command handlers
                .Setup((serviceCollection, commandRegistry) =>
                {
                    //Injecting CosmosStoreFactory
                    serviceCollection.AddSingleton((_) => CosmosRatingFactory.GetCosmosStore<RatingModel>());

                    //using Discover method provided by the command registry to locate and register any command handlers in my assembly
                    commandRegistry.Discover(this.GetType().Assembly);
                })

                //OpenApiEndPoint configures the Open API definition for out API and Configures the Swagger user interface
                //that will allow us to explore and use our API.
                .OpenApiEndpoint(openApi => openApi
                    .Title("openhack REST API")
                    .Version("1.0.0")
                    .UserInterface()
                )

                //Defining configuration for our functions.
                //This example  is only covering HTTP functions
                //for other triggers please check this: https://functionmonkey.azurefromthetrenches.com
                .Functions(functions => functions
                    .HttpRoute("/api/v1/product", route => route
                        //Get Product by Id
                        .HttpFunction<GetProductIdQuery>("/{id}", AuthorizationTypeEnum.Anonymous, HttpMethod.Get)
                    )
                    .OpenApiDescription("Methods on this route represent the Product Api")
                    .OpenApiName("Product Api")

                    .HttpRoute("/api/v1/rating", route => route
                        //Get All Ratings
                        .HttpFunction<GetRatingsQuery>(AuthorizationTypeEnum.Anonymous, HttpMethod.Get).OpenApiDescription("Get Ratings Query")
                        //Get Rating by Id
                        .HttpFunction<GetRatingsByIdQuery>("/{id}", AuthorizationTypeEnum.Anonymous, HttpMethod.Get).OpenApiDescription("Get Rating By Id Query")
                        //Create Rating
                        .HttpFunction<CreateRatingCommand>(AuthorizationTypeEnum.Anonymous, HttpMethod.Post).OpenApiDescription("Create Rating Command")
                    )
                    .OpenApiDescription("Methods on this route represent the Rating Api")
                    .OpenApiName("Rating Api")
                );
        }
    }
}
