using MyMedic.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public IProductRepository Products { get; }

		public IUserRepository Users { get; }

		public ICategoryRepository Categories { get; }
		private readonly MyMedicDbContext _context;

		public UnitOfWork(MyMedicDbContext context)
		{
			_context = context;
			Products  = new ProductRepository(context);
			Users = new UsersRepository(context);
			Categories = new CategoriesRepository(context);
		}
		public void Dispose()
		{
			_context.Dispose();
		}

		public async Task<int> SaveChangeAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
