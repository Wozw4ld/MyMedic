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

		public async Task<IQueryable<ProductsEntity>> GetAllAsync()
		{
			return  _context.Products.AsQueryable();
		}
		//public async Task<IEnumerable<ProductsEntity>> GetByIds()
		//{

		//}

		public async Task<IQueryable<ProductsEntity>> GetByCategoryAsync(Guid categoryId)
		{
			return  _context.Products
			 .Where(p => p.ProductCategoryId == categoryId).Include(x => x.Images).AsQueryable();

		}

		public async Task<ProductsEntity> GetByIdAsync(Guid id)
		{
			var product =  await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
			return product;
		}

		public async Task<IQueryable<ProductsEntity>> GetPopularAsync(int count)
		{
			return   _context.Products.AsQueryable();
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

		public async Task<IEnumerable<ProductsEntity>> GetByIds(IEnumerable<Guid> ids)
		{
			return await _context.Products.Where(x => ids.Contains(x.Id)).ToListAsync();

		}

		public Task<IQueryable<ProductsEntity>> GetPopularAsyncs(int count)
		{
			throw new NotImplementedException();
		}
	}
}
