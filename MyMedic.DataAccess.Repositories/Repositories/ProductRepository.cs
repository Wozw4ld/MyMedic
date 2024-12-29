using Microsoft.EntityFrameworkCore;
using MyMedic.DataAccess.Models;
using MyMedic.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly MyMedicDbContext _context;
		public ProductRepository(MyMedicDbContext context)
		{
			_context = context;
		}
		public async Task AddAsync(ProductsEntity entity)
		{
			await _context.Products.AddAsync(entity);
		}

		public async Task<IEnumerable<ProductsEntity>> GetByCategoryAsync(Guid categoryId)
		{
			return await _context.Products
			 .Where(p => p.ProductCategoryId == categoryId)
			 .ToListAsync();
		}

		public async Task<ProductsEntity> GetByIdAsync(Guid id)
		{
			return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IEnumerable<ProductsEntity>> GetPopularAsync(int count)
		{
			throw new NotImplementedException();
		}

		public async Task RemoveAsync(Guid id)
		{
			var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
			if (product != null)
			{
				_context.Products.Remove(product);
			}
		}

		public async Task UpdateAsync(ProductsEntity entity)
		{
			_context.Products.Update(entity);
		}
	}
}
