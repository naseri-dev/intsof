using Domain.Exceptions;

namespace Domain.Users;

public record LastName
{
	private const int MaxLength = 100;
	private LastName(string value) => Value = value;
	public string Value { get; init; }

	public static LastName? Create(string value)
	{
		if (value == null)
		{
			throw new DomainException($"Lastname is mandatory");
		}
		if (value.Length > MaxLength)
		{
			throw new DomainException($"Lastname is too long");
		}
		return new LastName(value);
	}
}
