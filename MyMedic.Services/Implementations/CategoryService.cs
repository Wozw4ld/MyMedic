using Microsoft.AspNetCore.Http.HttpResults;
using MyMedic.DataAccess.Models;
using MyMedic.DataAccess.Repositories.Interfaces;
using MyMedic.DataAccess.Repositories.Repositories;
using MyMedic.DTO.Dto;
using MyMedic.DTO.Mappers;
using MyMedic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Implementations
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly CategoryMappers _mapper;
		public CategoryService(IUnitOfWork unitOfWork, CategoryMappers categoryMappers)
		{
			_unitOfWork = unitOfWork;
			_mapper = categoryMappers;
			
		}

		public async Task<string> AddCategory(CategoryDto category)
		{
			var categoryEntity = _mapper.ToEntity(category);
			await _unitOfWork.Categories.AddAsync(categoryEntity);
			await _unitOfWork.SaveChangeAsync();
			return ("Success");
		}
		public async Task<IEnumerable<CategoryDto>> GetAllCategories()
		{
			var categories = await _unitOfWork.Categories.GetAllCategoriesAsync();
			return categories.Select(c => _mapper.ToDto(c));
		}
	}
}
