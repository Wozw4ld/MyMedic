using MyMedic.DataAccess.Models;
using MyMedic.DataAccess.Repositories.Interfaces;
using MyMedic.Services.Interfaces;

namespace MyMedic.Services.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		public UserService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task AddUserAsync(UsersEntity user)
		{
			 await _unitOfWork.Users.AddAsync(user);
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task DeleteUserAsync(Guid userId)
		{
			await _unitOfWork.Users.RemoveAsync(userId);
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<UsersEntity?> GetUsersByIdAsync(Guid userId)
		{
			return await _unitOfWork.Users.GetByIdAsync(userId);
		}

		public async Task<bool> IsEmailExistAsync(string email)
		{
			return await _unitOfWork.Users.IsEmailExistAsync(email);
		}

		public async Task UpdateUserAsync(UsersEntity user)
		{
			await _unitOfWork.Users.UpdateAsync(user);
			await _unitOfWork.SaveChangeAsync();
		}

		//bool IUserService.IsEmailExistAsync(string email)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
