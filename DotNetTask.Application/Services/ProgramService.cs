using DotNetTask.Models.Programs;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Application.Services
{
    public class ProgramService : IProgramService
    {
        private Container _container;

        public ProgramService(
            CosmosClient cosmosDbClient,
            string databaseName,
            string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddAsync(ProgramModel item)
        {
            try
            {
                await _container.CreateItemAsync(item, new PartitionKey(item.Id));
            }
            catch (CosmosException ex) //For handling item not found and other exceptions
            {
                
            }


        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _container.DeleteItemAsync<ProgramModel>(id, new PartitionKey(id));
            }
            catch (CosmosException ex) //For handling item not found and other exceptions
            {

            }

        }

        public async Task<ProgramModel> GetAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<ProgramModel>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) //For handling item not found and other exceptions
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProgramModel>> GetMultipleAsync(string queryString)
        {
            try
            {
                var query = _container.GetItemQueryIterator<ProgramModel>(new QueryDefinition(queryString));

                var results = new List<ProgramModel>();
                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }

                return results;
            }
            catch (CosmosException ex) //For handling item not found and other exceptions
            {
                return null;
            }

        }

        public async Task UpdateAsync(string id, ProgramModel item)
        {
            try
            {
                await _container.UpsertItemAsync(item, new PartitionKey(id));
            }
            catch (CosmosException ex) //For handling item not found and other exceptions
            {

            }

        }
    }
}
