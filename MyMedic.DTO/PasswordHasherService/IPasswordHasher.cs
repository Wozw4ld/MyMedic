using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.PasswordHasherService
{
	public interface IPasswordHasher
	{
		public string HasdPassword(string password);
		public bool VerifyPassword(string password, string hashedPassword);
	}
	public class PasswordHasher : IPasswordHasher
	{
		public string HasdPassword(string password)
		{
			var hashedPass = BCrypt.Net.BCrypt.HashPassword(password);
			return hashedPass;
		}

		public bool VerifyPassword(string password, string hashedPassword)
		{
			var verifyPass = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
			return verifyPass;
		}
	}
}
