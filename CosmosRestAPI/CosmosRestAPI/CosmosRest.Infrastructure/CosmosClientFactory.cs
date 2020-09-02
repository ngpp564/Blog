﻿using System.ComponentModel;
using Azure.Cosmos;

namespace CosmosRest.Infrastructure
{
    using Microsoft.Azure.Cosmos;

    namespace LOR.Forms.Infrastructure.Cosmos
    {
        public interface ICosmosDbClientFactory
        {
            CosmosContainer GetClient(string collectionName);
        }

        public class CosmosDbClientFactory : ICosmosDbClientFactory
        {
            private readonly CosmosClient _client;
            private readonly string _databaseName;

            public CosmosDbClientFactory(CosmosConfiguration configuration)
            {
                _client = new CosmosClient(
                    configuration.EndpointUrl,
                    configuration.PrimaryKey
                );
                _databaseName = configuration.DatabaseName;
            }

            public CosmosContainer GetClient(string collectionName)
            {
                return _client.GetContainer(_databaseName, collectionName);
            }
        }
    }
}