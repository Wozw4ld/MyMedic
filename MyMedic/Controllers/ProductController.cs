using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMedic.DTO.Dto;
using MyMedic.Services.Interfaces;

namespace MyMedic.Controllers

{
	[ApiController]
	[Route ("api/products")]
	
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
	//	[Authorize]
		[HttpPost ("add-product")]
		public async Task<IActionResult> AddProduct(ProductCreateDto product)
		{
			var result = await _productService.AddProductAsync(product);
			return Ok(result);
		}
		[HttpGet ("getAllProducts")]
		public async Task<IActionResult> GetAllProducts()
		{
			var products = await _productService.GetAllProducts(1,10);
			return Ok(products);
		}
		[HttpGet("getByCategory")]
		public async Task<IActionResult> GetByCategory(Guid categoryId)
		{
			var products = await _productService.GetByCategory(categoryId, 1, 10);
			return Ok(products);
		}


	}
}
