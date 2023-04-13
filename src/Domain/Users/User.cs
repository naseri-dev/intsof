namespace Domain.Users
{
	public class User
	{
		private User() { }
		public static User Create(Guid id,
			string firstName,
			string lastName,
			string nationalCode,
			string phoneNumber)
		{
			var user = new User();
			user.Id = id;
			user.FirstName = firstName;
			user.LastName = lastName;
			user.NationalCode = nationalCode;
			user.PhoneNumber = phoneNumber;

			return user;
		}
		public Guid Id { get; private set; }
		public string FirstName { get; private set; } = string.Empty;
		public string LastName { get; private set; } = string.Empty;
		public string NationalCode { get; private set; } = string.Empty;
		public string PhoneNumber { get; private set; } = string.Empty;

		public void SetName(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
		public void SetNationalCode(string nationalCode)
		{
			NationalCode = nationalCode;
		}
		public void SetPhoneNumber(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}
	}
}
