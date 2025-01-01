using Microsoft.IdentityModel.Tokens;
using MyMedic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Implementations
{
	
	public class AuthService : IAuthService
	{
		public string GenerateJwtToken(Guid userId)
		{
			string jwtSecr = "justsecretfortestnotmoresdsds111";
			Claim[] claims = [new("userId", userId.ToString())];
			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecr)),
				SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				claims: claims,
				signingCredentials: signingCredentials,
				expires: DateTime.UtcNow.AddHours(1));
			var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
			return tokenValue;
		}

		

		//public bool ValidateJwtToken(string token)
		//{
		
		//}
	}
}
