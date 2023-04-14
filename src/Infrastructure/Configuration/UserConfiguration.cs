using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);

			builder.Property(u => u.Id).HasConversion(
					userId => userId.Value,
					value => new UserId(value));

			builder.Property(u => u.FirstName).HasConversion(
				firstName => firstName.Value,
				value => FirstName.Create(value)!);

			builder.Property(u => u.LastName).HasConversion(
				lastName => lastName.Value,
				value => LastName.Create(value)!);

			builder.Property(u => u.NationalCode).HasConversion(
				nationalCode => nationalCode.Value,
				value => NationalCode.Create(value)!);

			builder.Property(u => u.PhoneNumber).HasConversion(
				phoneNumber => phoneNumber.Value,
				value => PhoneNumber.Create(value)!);

			builder.Property(u => u.FirstName)
			.HasMaxLength(100);

			builder.Property(u => u.LastName)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(u => u.NationalCode)
				.HasMaxLength(10);

			builder.Property(u => u.PhoneNumber)
				.HasMaxLength(13);
		}
	}
}
