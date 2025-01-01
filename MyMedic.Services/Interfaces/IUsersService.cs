using MyMedic.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Interfaces
{
	public interface IUsersService
	{
	//	public Task<bool> IsEmailExistAsync(string userEmail);
		public Task<string> UserRegister(UserRegisterDto user);
		public Task<string> UserLogin(UserLoginDto user);
		public Task<UserDto> GetUserByIdAsync(Guid userId);
	}
}
