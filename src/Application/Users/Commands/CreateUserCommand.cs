using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
	public record CreateUserCommand
	(
		string FirstName,
		string LastName,
		string NationalCode,
		string PhoneNumber
		) : IRequest<Guid>;
}
