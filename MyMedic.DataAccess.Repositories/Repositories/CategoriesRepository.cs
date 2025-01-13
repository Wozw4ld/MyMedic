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
	public class CategoriesRepository : ICategoryRepository
	{
		private readonly MyMedicDbContext _context;
		public CategoriesRepository(MyMedicDbContext context)
		{
			_context = context;
		}
		public async Task AddAsync(CategoriesEntity entity)
		{
			await _context.Categories.AddAsync(entity);	
		}

		

		public async Task<IEnumerable<CategoriesEntity>> GetAllCategoriesAsync()
		{
			return await _context.Categories
				
				.Include(c => c.SubCategories)
				.Include(c => c.Images)
				.ToListAsync();
 				
				}

		public async Task<CategoriesEntity> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		//public async Task<IEnumerable<CategoriesEntity>> GetMainCategories()
		//{
		//	return await _context.Categories
		//		.Include(c => c.SubCategories)
		//		.Include(c => c.Images)
		//		.Where(c => c.ParentCategoryId == null) 
		//		.ToListAsync(); 
		//}		
		public async Task<IQueryable<CategoriesEntity>> GetMainCategories()
		{
			return _context.Categories.AsQueryable();
		}

		public async Task<IEnumerable<CategoriesEntity?>> GetSubCategoriesAsync(Guid id)
		{
			return await _context.Categories
				.Where(c => c.Id == id)
				.Include(c => c.SubCategories) .ToListAsync();
				
				
				
		}

		public async Task RemoveAsync(Guid id)
		{
			var category = _context.Categories.FirstOrDefault(c => c.Id == id);
			if (category != null)
			{
				_context.Categories.Remove(category);
			}
		}

		public async Task UpdateAsync(CategoriesEntity entity)
		{
			_context.Categories.Update(entity);
		}

	
	}
}
