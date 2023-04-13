using Domain.Exceptions;

namespace Domain.Users;

public record PhoneNumber
{
	private const int MaxLength = 13; // +989126862901
	private const int MinLength = 6; // 021118
	private PhoneNumber(string value) => Value = value;
	public string Value { get; init; }

	public static PhoneNumber? Create(string value)
	{
		if (value == null)
		{
			throw new DomainException($"Phone number is not valid (Empty)");
		}
		if (value.Length > MaxLength)
		{
			throw new DomainException($"Phone number is not valid (too long)");
		}
		if (value.Length < MinLength)
		{
			throw new DomainException($"Phone number is not valid (too short)");
		}
		return new PhoneNumber(value);
	}
}
