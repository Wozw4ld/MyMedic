using MyMedic.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Interfaces
{
	public interface ICategoryRepository : IRepository<CategoriesEntity>
	{
		Task<CategoriesEntity?> GetWithSubcategoriesAsync(Guid id);
		Task<IEnumerable<CategoriesEntity>> GetAllWithTreeAsync();
	}
}
