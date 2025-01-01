using MyMedic.DataAccess.Models;
using MyMedic.DTO.Dto;
using MyMedic.DTO.PasswordHasherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Mappers
{
	public  class UsersMapper
	{
		private readonly IPasswordHasher _passwordHasher;
		public UsersMapper(IPasswordHasher passwordHasher)
		{
			_passwordHasher = passwordHasher;
		}
		public UsersEntity ToEntity(UserRegisterDto userDto)
		{
			var hashPass = _passwordHasher.HasdPassword(userDto.UserPassword);
			return new UsersEntity
			{
				Id = Guid.NewGuid(),
				UserFullName = userDto.UserFullName,
				UserPassword = hashPass,
			};

		}
		public UserDto ToDto(UsersEntity userEntity)
		{
			
			return new UserDto
			{
				Email = userEntity.UserEmail,
				Name = userEntity.UserFullName
			};
		}

	}
}
