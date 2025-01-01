using MyMedic.DataAccess.Models;

namespace MyMedic.Services.Interfaces
{
	public interface IUserService
	{
		public Task<bool> IsEmailExistAsync(string email);
		Task<UsersEntity?> GetUsersByIdAsync(Guid userId);
		Task AddUserAsync(UsersEntity user);
		Task UpdateUserAsync(UsersEntity user);
		Task DeleteUserAsync(Guid userId);
	}
}
