using Application.Users.Commands;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intsoft.Exam.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			this._mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateUserCommand createUser)
		{
			var id = await _mediator.Send(createUser);
			return Ok(id);
		}
		[HttpPut()]
		public async Task<IActionResult> Put([FromBody] EditUserCommand editUser)
		{
			var id = await _mediator.Send(editUser);
			return Ok(id);
		}

		[HttpGet("id:guid")]
		public async Task<ActionResult<UserDto>> Get(Guid id)
		{
			var dto = await _mediator.Send(new GetUserByIdQuery(id));
			return Ok(dto);
		}

	}
}

