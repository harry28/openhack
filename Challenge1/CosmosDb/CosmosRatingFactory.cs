using System;
using Cosmonaut;

namespace Challenge1.CosmosDb
{
    public class CosmosRatingFactory
    {
        public static ICosmosStore<T> GetCosmosStore<T>() where T : class
        {
            return new CosmosStore<T>(
                new CosmosStoreSettings(
                    Environment.GetEnvironmentVariable("CosmosDbDatabaseName"),
                    Environment.GetEnvironmentVariable("CosmosDbEndpoint"),
                    Environment.GetEnvironmentVariable("CosmosDbKey")
                )
            );
        }

        public static string GetEnvironmentVariable(string name)
        {
            return name + ": " +
                   System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
