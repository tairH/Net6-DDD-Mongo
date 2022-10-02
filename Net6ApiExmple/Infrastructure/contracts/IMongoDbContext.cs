using System;
using MongoDB.Driver;
using Net6ApiExmple.Domain.Entities;

namespace Net6ApiExmple.Infrastructure.contracts
{
	public interface IMongoDbContext
	{
        IMongoCollection<T> GeCollection<T>(string Id);
	}
}

