using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Net6ApiExmple.Infrastructure.contracts
{
    public class MongoDbContext : IMongoDbContext
	{
		private IMongoDatabase _db { get; set; }
		private MongoClient _mongoClient { get; set; }
		//public IClientSessionHandle Session { get; set; }

        public MongoDbContext(IOptions<MongoDbSettings> configuration)
		{
			_mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
		}

        public IMongoCollection<T> GeCollection<T>(string Id)
        {
			return (IMongoCollection<T>)_db.GetCollection<T>(Id);
		}
    }
}

