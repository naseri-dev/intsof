﻿using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);

			builder.Property(u => u.FirstName)
			.HasMaxLength(100);

			builder.Property(u => u.LastName)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(u => u.NationalCode)
				.HasMaxLength(11);

			builder.Property(u => u.PhoneNumber)
				.HasMaxLength(11);
		}
	}
}