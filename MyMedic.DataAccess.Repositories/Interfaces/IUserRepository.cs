using MyMedic.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DataAccess.Repositories.Interfaces
{
	public interface IUserRepository : IRepository<UsersEntity>
	{
		Task<bool> IsEmailExistAsync(string email);
	}
}
