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
		public Task<string> AddCategory(CategoryDto category);
		public Task<IEnumerable<CategoryDto>> GetAllCategories();	
	}
}
