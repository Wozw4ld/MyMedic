using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IOrderRepository Orders { get; }
		IProductRepository Products { get; }
		IUserRepository Users { get; }
		ICategoryRepository Categories { get; }
		Task<int> SaveChangeAsync();
	}
}
