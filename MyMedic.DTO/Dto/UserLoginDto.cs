using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedic.DTO.Dto
{
	public class UserLoginDto
	{
		public string UserEmail { get; set; } = string.Empty;
		public string UserPassword { get; set; } = string.Empty;
	}
}
