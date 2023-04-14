using Domain.SeedWork;
using Domain.Users;
using MediatR;

namespace Application.Users.Commands
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
	{
		private readonly IUserRepository _repository;
		private readonly IUnitOfWork _unitOfWork;

		public CreateUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			User user = User.Create(
				new UserId(Guid.NewGuid()),
				FirstName.Create(request.FirstName)!,
				LastName.Create(request.LastName)!,
				NationalCode.Create(request.NationalCode)!,
				PhoneNumber.Create(request.PhoneNumber)!);

			_repository.Add(user);
			await _unitOfWork.SaveChangesAsync();

			return user.Id.Value;
		}
	}
}
