using MyMedic.DataAccess.Models;
using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Mappers
{
	public class OrdersMapper
	{
	
		
		public  OrderDto ToDto(OrdersEntity entity)
		{
			return  new OrderDto
			{
				Id = entity.Id,
				UserAddress = entity.UserAddress,
				UserId = entity.UserId,
				Paid = entity.Paid,
				TotalAmount = entity.TotalAmount,
				UserPhone = entity.UserPhone,
				Status = entity.Status,
				CreatedAt = entity.CreatedAt,
				Products = entity.Products?.Select(x => new ProductDto
				{
					Id = x.Id,

					ProductStatus = x.ProductStatus,
					ProductName = x.ProductName,
					ProductDescription = x.ProductDescription,
					ProductCategoryId = x.ProductCategoryId,
					ProductPrice = x.ProductPrice,
					Images = x.Images?.Select(i => new ProductImageDto
					{
						Id = i.Id,
						ImageUrl = i.ImageUrl
					}).ToList()
				}).ToList()

			};
		}
	
		public OrdersEntity ToEntity(OrderDto dto)
		{
			return new OrdersEntity
			{
				Id = dto.Id,
				Paid = dto.Paid,
				TotalAmount = dto.TotalAmount,
				UserPhone = dto.UserPhone,
				UserAddress = dto.UserAddress,
				UserId = dto.UserId,
				Status = dto.Status,
				CreatedAt = dto.CreatedAt,
				Products = dto.Products?.Select(x => new ProductsEntity
				{
					Id = x.Id,

					ProductStatus = x.ProductStatus,
					ProductName = x.ProductName,
					ProductDescription = x.ProductDescription,
					ProductCategoryId = x.ProductCategoryId,
					ProductPrice = x.ProductPrice,
					Images = x.Images?.Select(i => new ProductImages
					{
						Id = i.Id,
						ImageUrl = i.ImageUrl
					}).ToList()
				}).ToList()
			};
		}

		}
	}

