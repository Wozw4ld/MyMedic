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
		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		[HttpPost("add-order")]
		public async Task<IActionResult> AddOrder(OrderCreateDto orderDto)
		{
			try
			{
				var tesTgUID = Guid.Parse("057f3e74-c495-48b3-8247-bc1d743b5b41");
				await _orderService.AddOrder(orderDto, tesTgUID);
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
