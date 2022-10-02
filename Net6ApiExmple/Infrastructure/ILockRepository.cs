using System;
using Net6ApiExmple.Domain.Entities;
using Net6ApiExmple.Infrastructure.contracts;

namespace Net6ApiExmple.Infrastructure
{
    public interface ILockRepository : IBaseRepository<Lock>
    {
    }

	public class LockRepository : BaseRepository<Lock>, ILockRepository
	{
		public LockRepository(IMongoDbContext context) : base(context)
		{
		}
	}
}

