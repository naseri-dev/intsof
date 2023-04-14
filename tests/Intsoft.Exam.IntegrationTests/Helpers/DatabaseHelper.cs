using Infrastructure;
using Domain.Users;

namespace Intsoft.Exam.IntegrationTests.Helpers
{
	public static class DatabaseHelper
	{
		public static void InitialDatabaseForTests(AppDbContext dbContext)
		{
			dbContext.Users.Add(User.Create(
				new UserId(Guid.Parse("b158fde2-fd7f-4e3f-98eb-2b248465aec9")),
				FirstName.Create("Mohammad")!,
				LastName.Create("Naseri")!,
				NationalCode.Create("3888841746")!,
				PhoneNumber.Create("09382546901")!
				));

			dbContext.Users.Add(User.Create(
				new UserId(Guid.Parse("4ea2d518-5146-46c5-80f6-5f0c81afdf29")),
				FirstName.Create("Reza")!,
				LastName.Create("Akbari")!,
				NationalCode.Create("3745632548")!,
				PhoneNumber.Create("09121236544")!
				));

			dbContext.SaveChanges();
		}

		public static void ResetDatabaseForTest(AppDbContext dbContext)
		{
			var users = dbContext.Users.ToArray();

			dbContext.RemoveRange(users);
			dbContext.SaveChanges();

			InitialDatabaseForTests(dbContext);
		}
	}
}
