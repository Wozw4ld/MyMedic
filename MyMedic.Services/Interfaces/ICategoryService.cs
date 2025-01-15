using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Interfaces
{
	public interface ICategoryService
	{
		public Task<string> AddCategory(CategoryCreateDto category);
		public Task<IEnumerable<CategoryDto>> GetAllCategories();
		public Task<IEnumerable<CategoryDto>> GetMainCategories();
		public Task<IEnumerable<CategoryDto>> GetByParentId(Guid parentId);
	}
}
