using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users
{
	public class Repository : IRepository
	{
		private readonly AppDbContext _dbContext;

		public Repository(AppDbContext dbContext)
		{
			this._dbContext = dbContext;
		}
		public void Add(User user)
		{
			_dbContext.Set<User>().Add(user);
		}

		public async Task<User?> GetByIdAsync(Guid id)
		{
			return await _dbContext
				.Set<User>()
				.SingleOrDefaultAsync(u => u.Id == id);
		}

		public void Update(User user)
		{
			_dbContext
			  .Set<User>()
			  .Update(user);
		}
	}
}
