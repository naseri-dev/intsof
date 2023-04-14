using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;

		public UnitOfWork(AppDbContext dbContext)
		{
			this._dbContext = dbContext;
		}
		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
