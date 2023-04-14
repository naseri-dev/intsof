using Domain.SeedWork;
using Domain.Users;
using MediatR;

namespace Application.Users.Commands
{
	public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Guid>
	{
		private readonly IUserRepository _repository;
		private readonly IUnitOfWork _unitOfWork;

		public EditUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(EditUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _repository.GetByIdAsync(new UserId(request.Id));
			if (user is null)
			{
				throw new Exception("User not found.");
			}


			user.SetName(FirstName.Create(request.FirstName)!, LastName.Create(request.LastName)!);
			user.SetNationalCode(NationalCode.Create(request.NationalCode)!);
			user.SetPhoneNumber(PhoneNumber.Create(request.PhoneNumber)!);

			_repository.Update(user);
			await _unitOfWork.SaveChangesAsync();

			return user.Id.Value;
		}
	}
}
