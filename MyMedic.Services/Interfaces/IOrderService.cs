using Helpers;
using Helpers.Builders;
using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Interfaces
{
	public interface IOrderService
	{
		public Task<IEnumerable<OrderDto>> GetAllOrders(bool byDate = false,  bool byPrice = false, OrderStatus? byStatus = null, bool byPaid = false);
		public Task<IEnumerable<OrderDto>> GetUserOrders(Guid userId, OrderQuery order);
		public Task AddOrder(OrderCreateDto orderCreateDto, Guid userId);
		public Task RemoveOrder(OrderDto orderDto);
		public Task UpdateOrder(OrderDto orderDto);

	}
}
