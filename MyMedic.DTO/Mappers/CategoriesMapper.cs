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
		//	Console.WriteLine(categoriesEntity.ParentCategoryId + "asd");
			return new CategoryDto
			{
				Id = categoriesEntity.Id,
				CategoryName = categoriesEntity.CategoryName,
				ParentCategoryId = categoriesEntity.ParentCategoryId,
				Images = categoriesEntity.Images?.Select(x => new ProductImageDto
				{
					Id = x.Id,
					ImageUrl = x.ImageUrl
				}).ToList()
			};
		}

		public CategoriesEntity ToEntity(CategoryCreateDto dto, List<string> imagesUrl)
		{
		
			return new CategoriesEntity
			{
				Id = Guid.NewGuid(),
				CategoryName = dto.CategoryName,
				ParentCategoryId = dto.ParentCategoryId,
				Images = imagesUrl.Select(x =>

					new CategoryImages
					{
						Id = Guid.NewGuid(),
						ImageUrl = x.ToString()
					}
				).ToList()!
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
