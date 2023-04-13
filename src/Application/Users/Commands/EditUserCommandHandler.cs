using Domain.SeedWork;
using Domain.Users;
using MediatR;

namespace Application.Users.Commands
{
	public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Guid>
	{
		private readonly IRepository _repository;
		private readonly IUnitOfWork _unitOfWork;

		public EditUserCommandHandler(IRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(EditUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _repository.GetByIdAsync(request.Id);
			if (user is null)
			{
				throw new Exception("User not found.");
			}


			user.SetName(request.FirstName, request.LastName);
			user.SetNationalCode(request.NationalCode);
			user.SetPhoneNumber(request.PhoneNumber);

			_repository.Update(user);
			await _unitOfWork.SaveChangesAsync();

			return user.Id;
		}
	}
}
