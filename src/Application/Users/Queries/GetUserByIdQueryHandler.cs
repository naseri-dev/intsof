using Domain.Users;
using MediatR;

namespace Application.Users.Queries
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
	{
		private readonly IRepository _repository;

		public GetUserByIdQueryHandler(IRepository repository)
		{
			_repository = repository;
		}
		public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _repository.GetByIdAsync(request.Id);
			var dto = new UserDto();
			dto.Id = user.Id;
			dto.NationalCode = user.NationalCode;
			dto.PhoneNumber = user.PhoneNumber;
			dto.FirstName = user.FirstName;
			dto.LastName = user.LastName;

			return dto;
		}
	}
}
