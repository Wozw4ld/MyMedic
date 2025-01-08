using Helpers;
using Microsoft.EntityFrameworkCore;
using MyMedic.DataAccess.Models;
using MyMedic.DataAccess.Repositories.Interfaces;
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
	public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly OrdersMapper _ordersMapper;
		public OrderService(IUnitOfWork unitOfWork, OrdersMapper ordersMapper)
		{
			_unitOfWork = unitOfWork;
			_ordersMapper = ordersMapper;
		}

		public async Task AddOrder(OrderCreateDto orderCreateDto, Guid userId)
		{
			var products = await _unitOfWork.Products.GetByIds(orderCreateDto.Products);
			OrdersEntity orderEntity = new OrdersEntity
			{
				Id = Guid.NewGuid(),
				CreatedAt = orderCreateDto.CreatedAt,
				TotalAmount = orderCreateDto.TotalAmount,
				UserAddress = orderCreateDto.UserAddress,
				Paid = orderCreateDto.Paid,
				Products = products.ToList(),
				Status = orderCreateDto.Status,
				UserId = userId,
				UserPhone = orderCreateDto.UserPhone

			};
		
			await _unitOfWork.Orders.AddAsync(orderEntity);
			try
			{
				await _unitOfWork.SaveChangeAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.InnerException.Message);
				return;
			}
		
		}

		

		public async Task<IEnumerable<OrderDto>> GetAllOrders(
			bool byDate = false, 
			bool byPrice = false, 
			OrderStatus? byStatus = null, 
			bool byPaid = false)
		{
		var result = _unitOfWork.Orders.GetAllOrders();
			if(byDate)
			
				result.OrderBy(x => x.CreatedAt);

			if (byPrice) 
				result.OrderBy(x => x.TotalAmount);
			if(byStatus.HasValue) 
				result.OrderBy(x => x.Status == byStatus);
			if(byPaid)
				result.OrderBy(x => x.Paid);
			var ordersList = await result.Select(x => _ordersMapper.ToDto(x)).ToListAsync();

			return ordersList;

		}

		public async Task<IEnumerable<OrderDto>> GetUserOrders(
			Guid userId, 
			bool byDate = false, 
			bool byPrice = false, 
			OrderStatus? byStatus = null, 
			bool byPaid = false)
		{
			var result = _unitOfWork.Orders.GetUserOrders(userId);
			if (byDate)

				result.OrderBy(x => x.CreatedAt);

			if (byPrice)
				result.OrderBy(x => x.TotalAmount);
			if (byStatus.HasValue)
				result.OrderBy(x => x.Status == byStatus);
			if (byPaid)
				result.OrderBy(x => x.Paid);
			var ordersList = await result.Select(x => _ordersMapper.ToDto(x)).ToListAsync();

			return ordersList;
		}

		public async Task RemoveOrder(OrderDto orderDto)
		{
			
			await _unitOfWork.Orders.RemoveAsync(orderDto.Id);
		}

		public Task UpdateOrder(OrderDto orderDto)
		{
			throw new NotImplementedException();
		}
	}
}
