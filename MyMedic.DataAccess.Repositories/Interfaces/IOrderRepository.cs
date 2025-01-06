using MyMedic.DataAccess.Models;
using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Interfaces
{
	public interface IOrderRepository : IRepository<OrdersEntity>
	{
		public IQueryable<OrdersEntity> GetUserOrders(Guid userId);
		public IQueryable<OrdersEntity> GetAllOrders();
	}
}
