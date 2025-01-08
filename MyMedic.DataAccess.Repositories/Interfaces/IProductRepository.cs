using MyMedic.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Interfaces
{
	public interface IProductRepository : IRepository<ProductsEntity>
	{
		Task<IQueryable<ProductsEntity>> GetByCategoryAsync(Guid categoryId);
		Task<IQueryable<ProductsEntity>> GetPopularAsync(int count);
		
		Task<IEnumerable<ProductsEntity>> GetByIds(IEnumerable<Guid> ids);
		Task<IQueryable<ProductsEntity>> GetAllAsync();
	}
}
