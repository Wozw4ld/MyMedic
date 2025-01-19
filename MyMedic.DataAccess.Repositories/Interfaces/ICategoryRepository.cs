using MyMedic.DataAccess.Models;
using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Interfaces
{
	public interface ICategoryRepository : IRepository<CategoriesEntity>
	{
		Task<IEnumerable<CategoriesEntity?>> GetSubCategoriesAsync(Guid id);
		Task<IEnumerable<CategoriesEntity>> GetAllCategoriesAsync();
		Task<IQueryable<CategoriesEntity>> GetMainCategories();
		Task<IEnumerable<CategoriesEntity>> GetByParentId(Guid parentId);
		Task<IEnumerable<CategoryLinkDto>> GetCategoriesLink(Guid categoryId);
	}
}
