using Microsoft.AspNetCore.Mvc;
using MyMedic.DTO.Dto;
using MyMedic.Services.Implementations;

namespace MyMedic.Controllers
{
	[ApiController]
	[Route("api/orders")]
	public class OrdersController : ControllerBase
	{
		private readonly OrderService _orderService;
		public OrdersController(OrderService orderService)
		{
			_orderService = orderService;
		}
		[HttpPost("add-order")]
		public async Task<IActionResult> AddOrder(OrderDto orderDto)
		{
			try
			{
				await _orderService.AddOrder(orderDto);
				return Ok("Success");
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
			
		}
		[HttpGet]
		public async Task<IActionResult> GetAllOrders()
		{
			try
			{
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
