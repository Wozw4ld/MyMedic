using Microsoft.AspNetCore.Mvc;
using MyMedic.DTO.Dto;
using MyMedic.Services.Implementations;
using MyMedic.Services.Interfaces;

namespace MyMedic.Controllers
{
	[ApiController]
	[Route("api/users")]

	public class UsersController : ControllerBase
	{
		private readonly IUsersService _userService;
		public UsersController(IUsersService userService)
		{
			_userService = userService;
		}

		//[HttpGet("{id:guid}")]
		//public async Task<IActionResult> GetUserById(Guid id)
		//{
		//	var user = await _userService.GetUsersByIdAsync(id);
		//	if (user == null)
		//	{
		//		return NotFound();
		//	}
		//	else
		//	{
		//		return Ok(user);
		//	}
		//}
		[HttpPost("register")]
		public async Task<IActionResult> RegisterUser(UserRegisterDto user)
		{
		
			var message = await _userService.UserRegister(user);

			// Верните результат в виде подходящего IActionResult
			if (message == "Success")
			{
				return Ok(message); // HTTP 200 с данными ответа
			}

			return BadRequest(message); // HTTP 400 с ошибкой
		}
		[HttpPost("login")]
		public async Task<IActionResult> LoginUser(UserLoginDto user)
		{
			var token = await _userService.UserLogin(user);
			return Ok(token);
		}

	}
}
