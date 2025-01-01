using Microsoft.AspNetCore.Mvc;
using MyMedic.Services.Interfaces;

namespace MyMedic.Controllers
{
	[ApiController]
	[Route("api/users")]

	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetUserById(Guid id)
		{
			var user = await _userService.GetUsersByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(user);
			}
		}
		[HttpPost("add-user")]
		public async Task<IActionResult> AddUser()
		{

		}

	
	}
}
