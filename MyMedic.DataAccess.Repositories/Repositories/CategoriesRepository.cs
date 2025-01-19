using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyMedic.DataAccess.Models;
using MyMedic.DataAccess.Repositories.Interfaces;
using MyMedic.DTO.Dto;
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

		public async Task<IEnumerable<CategoriesEntity>> GetByParentId(Guid parentId)
		{
			return await _context.Categories.Where(x => x.ParentCategoryId == parentId).Include(c => c.Images).ToListAsync();
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
		public async Task<IEnumerable<CategoryLinkDto>> GetCategoriesLink(Guid categoryId)
		{
			List<CategoryLinkDto> categoryList = [] ;
			bool parentIdNullable = false;
			Guid guid = categoryId;
			while (parentIdNullable == false)
			{
				var data = await _context.Categories.FirstOrDefaultAsync(x => x.Id == guid);
				Console.WriteLine(categoryList.LongCount());
				if(data != null) {
					Console.WriteLine(data.Id);
					categoryList.Add(new CategoryLinkDto { Id = data.Id, Name = data.CategoryName });

					if (data.ParentCategoryId != null)
					{
						guid = (Guid)data.ParentCategoryId;
							}
					else {
						parentIdNullable = true;
					}

					


				}
				else
				{
					return categoryList;
				}
			}
			return categoryList;
		
		}

		public async Task UpdateAsync(CategoriesEntity entity)
		{
			_context.Categories.Update(entity);
		}

		
	}
}
