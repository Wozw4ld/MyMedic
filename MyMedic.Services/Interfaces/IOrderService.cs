﻿using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Interfaces
{
	public interface IOrderService
	{
		public Task<IEnumerable<OrderDto>> GetAllOrders(bool byDate = false,  bool byPrice = false, bool byStatus = false, bool byPaid = false);
		public Task<IEnumerable<OrderDto>> GetUserOrders(Guid userId, bool byDate = false, bool byPrice = false, bool byStatus = false, bool byPaid = false);
		public Task AddOrder(OrderDto orderDto);
		public Task RemoveOrder(OrderDto orderDto);
		public Task UpdateOrder(OrderDto orderDto);

	}
}