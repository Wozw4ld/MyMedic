using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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
		private readonly IFileService _fileService;
		private readonly CategoryMappers _mapper;
		public CategoryService(IUnitOfWork unitOfWork, CategoryMappers categoryMappers, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = categoryMappers;
			_fileService = fileService;
		}

		public async Task<string> AddCategory(CategoryCreateDto category)
		{

			if (category.Images == null || !category.Images.Any())
			{
				return "No images provided.";
			}


			var imageUrls = await _fileService.SaveImageAsync(category.Images);
			
			var categoryEntity = _mapper.ToEntity(category, imageUrls);
			await _unitOfWork.Categories.AddAsync(categoryEntity);
			await _unitOfWork.SaveChangeAsync();
			return ("Success");
		}
		public async Task<IEnumerable<CategoryDto>> GetAllCategories()
		{
			
		
			var categories = await _unitOfWork.Categories.GetAllCategoriesAsync();
			return categories.Select(c => _mapper.ToDto(c)).ToList();
		}

		public async Task<IEnumerable<CategoryDto>> GetMainCategories()
		{
			var categories =  _unitOfWork.Categories.GetAllCategoriesAsync();
			var res = categories.Result.Where(c => c.ParentCategoryId == null).ToList();
			return res.Select(c => _mapper.ToDto(c)).ToList();
		}
	}
}
