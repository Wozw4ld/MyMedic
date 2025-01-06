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

		public async Task AddOrder(OrderDto orderDto)
		{

			var orderEntity = _ordersMapper.ToEntity(orderDto);
			await _unitOfWork.Orders.AddAsync(orderEntity);
		}

		public Task<IEnumerable<OrderDto>> GetAllOrders(bool byDate = false, bool byPrice = false, bool byStatus = false, bool byPaid = false)
		{
			//var result = _unitOfWork.Orders.GetAllOrders();
			//var ordersList = result.OrderBy(x => x.)
			throw new NotImplementedException();
		}

		public Task<IEnumerable<OrderDto>> GetUserOrders(Guid userId, bool byDate = false, bool byPrice = false, bool byStatus = false, bool byPaid = false)
		{
			throw new NotImplementedException();
		}

		public Task RemoveOrder(OrderDto orderDto)
		{
			throw new NotImplementedException();
		}

		public Task UpdateOrder(OrderDto orderDto)
		{
			throw new NotImplementedException();
		}
	}
}
