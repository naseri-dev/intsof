using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
	public interface IUserRepository
	{
		void Add(User user);
		void Update(User user);
		Task<User?> GetByIdAsync(UserId id);
	}

}
