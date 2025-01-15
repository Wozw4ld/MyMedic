using Helpers;
using MyMedic.DataAccess.Models;
using MyMedic.DTO.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Interfaces
{	
	public interface IProductService
	{
		public Task<PagedResult<ProductDto>> GetAllProducts(int page, int count);
		public Task<ProductDto> GetProduct(Guid id);
		public Task<PagedResult<ProductDto>> GetByCategory(Guid categoryId, int page, int count);
		public Task<PagedResult<ProductDto>> GetByName(string name);
		public Task<string> AddProductAsync(ProductCreateDto product);
		public Task<PagedResult<ProductDto>> GetByNameAndCategory(string name, Guid categoryId);
	}
}
