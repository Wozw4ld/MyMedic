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
		Task<IEnumerable<ProductsEntity>> GetByCategoryAsync(Guid categoryId);
		Task<IEnumerable<ProductsEntity>> GetPopularAsync(int count);
	}
}
