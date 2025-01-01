using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.Services.Interfaces
{
	public interface IAuthService
	{
		public string GenerateJwtToken(Guid userId);
	//	public bool ValidateJwtToken(string token);
	}
}
