using MyMedic.DataAccess;
using MyMedic.DataAccess.Repositories.Interfaces;
using MyMedic.DTO.Dto;
using MyMedic.DTO.Mappers;
using MyMedic.DTO.PasswordHasherService;
using MyMedic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Implementations
{
	public class UserService : IUsersService
	{
		public readonly IPasswordHasher _passwordHasher;
		private readonly IUnitOfWork _unitOfWork;
		public readonly IAuthService _authService;
		private readonly UsersMapper _usersMapper;
		public UserService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IAuthService authService, UsersMapper usersMapper)
		{
			_authService = authService;
			_passwordHasher = passwordHasher;
			_unitOfWork = unitOfWork;
			_usersMapper = usersMapper;
		}

		public async Task<UserDto> GetUserByIdAsync(Guid id)
		{
			var userEntity = await _unitOfWork.Users.GetByIdAsync(id);
			var userDto = _usersMapper.ToDto(userEntity);
			return userDto;
		}

		//public async Task<bool> IsEmailExistAsync(string userEMail)
		//{
		//	var checkUserEmail = await _unitOfWork.Users.IsEmailExistAsync(userEMail);
		//	return checkUserEmail;
		//}

		public async Task<string> UserLogin(UserLoginDto user)
		{
			var userEntity = await _unitOfWork.Users.GetUserByEmailAsync(user.UserEmail);
			if(userEntity == null)
			{
				return "User email or pass is wrong";
			}
			var checkUser =  _passwordHasher.VerifyPassword(user.UserPassword, userEntity.UserPassword);
			if (checkUser)
			{
				var token = _authService.GenerateJwtToken(userEntity.Id);
				return token;
			}
			else
			{
				return "User email or pass is wrong";
			}
		}

		public async Task<string> UserRegister(UserRegisterDto user)
		{
			var isEmailExist = await _unitOfWork.Users.IsEmailExistAsync(user.UserEmail);
			if (!isEmailExist)
			{
				return "Email already exists.";
			}
			
				try
				{
					var userEntity = _usersMapper.ToEntity(user);
					await _unitOfWork.Users.AddAsync(userEntity);
					await _unitOfWork.SaveChangeAsync();
					return ("Success");

				}
				catch
				{
					return ("Error");
				}
			

			
		
		}

		
	}
}
