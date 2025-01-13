using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMedic.DataAccess.Repositories.Repositories;
using MyMedic.DTO.Dto;
using MyMedic.Services.Interfaces;

namespace MyMedic.Controllers
{
	[ApiController]
	[Route("api/categories")]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllCategories()
		{
			var data = await _categoryService.GetAllCategories();
			return Ok(data);
		}
		[HttpPost]
		public async Task<IActionResult> AddCategory(CategoryCreateDto category)
		{
			var data = await _categoryService.AddCategory(category);
			return Ok(data);
		}
		[HttpGet("mainCategories")]
		public async Task<IActionResult> GetMainCategories()
		{
			var data = _categoryService.GetMainCategories();
			return Ok(data);
		}
	}
}
