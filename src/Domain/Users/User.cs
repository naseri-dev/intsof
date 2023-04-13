namespace Domain.Users
{
	public class User
	{
		private User() { }
		public static User Create(UserId id,
			FirstName firstName,
			LastName lastName,
			NationalCode nationalCode,
			PhoneNumber phoneNumber)
		{
			var user = new User();
			user.Id = id;
			user.FirstName = firstName;
			user.LastName = lastName;
			user.NationalCode = nationalCode;
			user.PhoneNumber = phoneNumber;

			return user;
		}
		public UserId Id { get; private set; }
		public FirstName FirstName { get; private set; }
		public LastName LastName { get; private set; }
		public NationalCode NationalCode { get; private set; }
		public PhoneNumber PhoneNumber { get; private set; }

		public void SetName(FirstName firstName, LastName lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
		public void SetNationalCode(NationalCode nationalCode)
		{
			NationalCode = nationalCode;
		}
		public void SetPhoneNumber(PhoneNumber phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}
	}
}
