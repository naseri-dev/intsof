using Domain.Users;
using MediatR;

namespace Application.Users.Queries
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
	{
		private readonly IUserRepository _repository;

		public GetUserByIdQueryHandler(IUserRepository repository)
		{
			_repository = repository;
		}
		public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _repository.GetByIdAsync(new UserId(request.Id));
			var dto = new UserDto();
			dto.Id = user.Id.Value;
			dto.NationalCode = user.NationalCode.Value;
			dto.PhoneNumber = user.PhoneNumber.Value;
			dto.FirstName = user.FirstName.Value;
			dto.LastName = user.LastName.Value;

			return dto;
		}
	}
}
