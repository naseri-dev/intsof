using Domain.Exceptions;

namespace Domain.Users;

public record NationalCode
{
	private const int MaxLength = 10;
	private NationalCode(string value) => Value = value;
	public string Value { get; init; }

	public static NationalCode? Create(string value)
	{
		if (value == null)
		{
			throw new DomainException($"National code is not valid");
		}
		if (value.Length != MaxLength)
		{
			throw new DomainException($"National code is not valid");
		}
		return new NationalCode(value);
	}
}
