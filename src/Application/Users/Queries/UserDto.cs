﻿namespace Application.Users.Queries
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string NationalCode { get; set; }
		public string PhoneNumber { get; set; }
	}
}
