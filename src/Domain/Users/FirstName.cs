namespace Domain.Users;

public record FirstName
{
	public string Value { get; init; }

	private FirstName(string value) => Value = value;
	public static FirstName? Create(string value) => new FirstName(value);
}
