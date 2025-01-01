using Microsoft.EntityFrameworkCore;
using MyMedic.DataAccess.Configurations;
using MyMedic.DataAccess.Models;
using MyMedic.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Repositories
{
	public class UsersRepository : IUserRepository
	{
		private readonly MyMedicDbContext _context;

		public UsersRepository(MyMedicDbContext context)
		{
			_context = context;
		}
		public async Task AddAsync(UsersEntity entity)
		{
			 await _context.Users.AddAsync(entity);
		}

		//public async Task<IEnumerable<UsersEntity>> GetAllAsync()
		//{
		//	await _context.Users().ToList();
		//}

		public async Task<UsersEntity> GetByIdAsync(Guid id)
		{
			return await _context.Users
		  .FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<UsersEntity> GetUserByEmailAsync(string email)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
		}

		public async Task<bool> IsEmailExistAsync(string email)
		{
			var checkEmail =  await _context.Users
			  .FirstOrDefaultAsync(u => u.UserEmail == email);
			if(checkEmail != null) return false  ; return true;
			
		}

		public async Task RemoveAsync(Guid id)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
			if (user != null)
			{
				_context.Users.Remove(user);
			}
		}

		public async Task UpdateAsync(UsersEntity entity)
		{
			_context.Users.Update(entity);
		}
	}
}
