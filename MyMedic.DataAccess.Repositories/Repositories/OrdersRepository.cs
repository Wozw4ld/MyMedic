using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MyMedic.DataAccess.Models;
using MyMedic.DataAccess.Repositories.Interfaces;
using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Repositories
{
	public class OrdersRepository : IOrderRepository
	{
		private readonly MyMedicDbContext _context;
		public OrdersRepository(MyMedicDbContext context)
		{
			_context = context;
		}
		public async Task AddAsync(OrdersEntity entity)
		{
			await _context.Orders.AddAsync(entity);
		}

		public  IQueryable<OrdersEntity> GetAllOrders()
		{
			return _context.Orders.Include(o => o.Products);
			
		}

		public async Task<OrdersEntity> GetByIdAsync(Guid id)
		{
			return await _context.Orders.FirstOrDefaultAsync(i => i.Id == id);
		}

		public IQueryable<OrdersEntity> GetUserOrders(Guid userId)
		{
			return _context.Orders.Where(o => o.UserId == userId);
		}

		public async Task RemoveAsync(Guid id)
		{
			var result =  await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
			if(result != null)
			{
				 _context.Orders.Remove(result);

			}
		
		}

		public async Task UpdateAsync(OrdersEntity entity)
		{
			 _context.Orders.Update(entity);
		}

		
	}
}
