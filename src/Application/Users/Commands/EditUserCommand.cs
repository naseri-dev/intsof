using MediatR;

namespace Application.Users.Commands
{
	public record EditUserCommand(
		Guid Id,
		string FirstName,
		string LastName,
		string NationalCode,
		string PhoneNumber
		) : IRequest<Guid>;
}
