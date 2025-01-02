using MyMedic.DataAccess.Models;
using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Mappers
{
	public class ProductsMapper
	{
		public ProductDto ToDto(ProductsEntity productEntity)
		{
			var productDto = new ProductDto{
				Id = productEntity.Id,
				ProductName = productEntity.ProductName,
				ProductStatus = productEntity.ProductStatus,
				ProductDescription = productEntity.ProductDescription,
				ProductCategoryId = productEntity.ProductCategoryId,
				ProductPrice = productEntity.ProductPrice,
				Images = productEntity.Images?.Select(x => new ProductImageDto
				{
					Id = x.Id,
					ImageUrl = x.ImageUrl,
				}).ToList() ?? new List<ProductImageDto>()
				
			};
			return productDto;
		}
		public ProductsEntity ToEntity(ProductCreateDto productDto, List<string> imageUrls)
		{
			return new ProductsEntity
			{
				Id = Guid.NewGuid(),
				ProductName = productDto.ProductName,
				ProductDescription = productDto.ProductDescription,
				ProductCategoryId = productDto.ProductCategoryId,
				ProductPrice = productDto.ProductPrice,
				ProductStatus = productDto.ProductStatus,
				Images = imageUrls.Select(x => new ProductImages
				{
					Id = Guid.NewGuid(),
					ImageUrl = x
				}).ToList() ?? new List<ProductImages>()
			};
		}
		public ProductsEntity ToEntity(ProductDto productDto)
		{
			var productEntity = new ProductsEntity
			{
				Id = productDto.Id,
				ProductName = productDto.ProductName,
				ProductStatus = productDto.ProductStatus,
				ProductDescription = productDto.ProductDescription,
				ProductCategoryId = productDto.ProductCategoryId,
				ProductPrice = productDto.ProductPrice,
				Images  = productDto.Images?.Select(x => new ProductImages
				{
					Id = x.Id,
					ImageUrl = x.ImageUrl,
					ProductId = productDto.Id
				}).ToList() ?? new List<ProductImages>()
			};
			return productEntity;
		}
	}
}
