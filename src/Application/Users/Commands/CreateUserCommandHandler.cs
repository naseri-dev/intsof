using Domain.SeedWork;
using Domain.Users;
using MediatR;

namespace Application.Users.Commands
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
	{
		private readonly IRepository _repository;
		private readonly IUnitOfWork _unitOfWork;

		public CreateUserCommandHandler(IRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			User user = User.Create(Guid.NewGuid(), request.FirstName,
				request.LastName, request.NationalCode, request.PhoneNumber);

			_repository.Add(user);
			await _unitOfWork.SaveChangesAsync();

			return user.Id;
		}
	}
}
