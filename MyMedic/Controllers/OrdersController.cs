using Helpers;
using Helpers.Builders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMedic.DTO.Dto;
using MyMedic.Services.Implementations;
using MyMedic.Services.Interfaces;

namespace MyMedic.Controllers
{
	[ApiController]
	[Route("api/orders")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly CookiesService _cookiesService;
		public OrdersController(IOrderService orderService, CookiesService cookiesService)
		{
			_cookiesService = cookiesService;
			_orderService = orderService;
		}
		[Authorize]
		[HttpPost("add-order")]
		public async Task<IActionResult> AddOrder(OrderCreateDto orderDto)
		{
			try
			{

				var userId = _cookiesService.GetUserIdFromCookie();
				if(userId == null)
				{
					return Unauthorized();
				}
				await _orderService.AddOrder(orderDto, userId);
				return Ok("Success");
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
			
		}
		[Authorize]
		[HttpPost("getByUserId")]
		public async Task<IActionResult> GetOrdersByUserId(OrderQuery query)
		{
			var userId =  _cookiesService.GetUserIdFromCookie();
			if (userId == null)
			{
				return Unauthorized();
			}
			return   Ok(await _orderService.GetUserOrders(userId, query));

		}
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetAllOrders()
		{
			try
			{
				var userId = _cookiesService.GetUserIdFromCookie();
				if (userId == null)
				{
					return Unauthorized();
				}
				var result = await _orderService.GetAllOrders();
				return Ok(result);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

			
	}
}
