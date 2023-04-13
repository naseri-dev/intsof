using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _dbContext;

		public UserRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void Add(User user)
		{
			_dbContext.Set<User>().Add(user);
		}

		public async Task<User?> GetByIdAsync(UserId id)
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
