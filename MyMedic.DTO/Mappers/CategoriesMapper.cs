using MyMedic.DataAccess.Models;
using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Mappers
{
	public class CategoryMappers
	{
		public CategoryDto ToDto(CategoriesEntity categoriesEntity)
		{
			return new CategoryDto
			{
				Id = categoriesEntity.Id,
				CategoryName = categoriesEntity.CategoryName,
				ParentCategoryId = categoriesEntity.ParentCategoryId,
			};
		}
		public CategoriesEntity ToEntity(CategoryDto categoryDto)
		{
			return new CategoriesEntity
			{
				CategoryName = categoryDto.CategoryName,
				ParentCategoryId = categoryDto.ParentCategoryId,
				Id = categoryDto.Id
			};
		}
	}
}
