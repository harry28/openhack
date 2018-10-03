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
                    "Ratings",
                    "https://openhack.documents.azure.com:443/",
                    "tE01gxQRxrIW8HPu094Ee6yMUBdVZqX8g0nonVQSrHoDGVcK9aTuwpR2KBQkQ4m8CZLxC2oeL49f5crXs8NlGA=="
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
