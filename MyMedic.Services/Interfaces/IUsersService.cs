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
		public Task<bool> IsEmailExistAsync();
		public Task UserRegister();
		public Task UserLogin();
		public Task<UserDto> GetUserByIdAsync();
	}
}
